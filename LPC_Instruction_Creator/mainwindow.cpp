#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <QDebug>
#include <QVector>
#include <QFile>
#include <QTextStream>
#include <QMessageBox>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    S_Scene = new QGraphicsScene(this);

    this->filename = "";
    ui->graphicsView->setScene(S_Scene);

    grid = new Grid;
    grid->setPos(0,0);
    S_Scene->addItem(grid);
}

MainWindow::~MainWindow()
{
    delete ui;
}


void MainWindow::LoadinImage()
{
   S_Scene->clear();

   grid = new Grid;
   grid->setPos(0,0);
   S_Scene->addItem(grid);

   image = new QImage;
   filename = QFileDialog::getOpenFileName(this,tr("Choose"),"",tr("Images(*.jfif *.png *.jpg *.jpeg *.bmp *.gif)"));
   image->load(filename);

   int tmph, tmpw;
   tmph = image->height(); tmpw = image->width();
   ui->ScaleImageX->setValue(tmpw);
   ui->ScaleImageY->setValue(tmph);

   ui->MoveImageX->setValue(0);
   ui->MoveImageY->setValue(0);

   QGraphicsPixmapItem *pm = S_Scene->addPixmap( QPixmap::fromImage(*image));
    grid->setPos(0,0);
    img_update();

}


void MainWindow::on_buttonLoadImage_clicked()
{
    LoadinImage();
}


void MainWindow::img_update()
{
    this->img_height    = ui->ScaleImageY->value();
    this->img_width     = ui->ScaleImageX->value();
    this->img_x         = ui->MoveImageX->value();
    this->img_y         = ui->MoveImageY->value();

    ui->MoveImageX->setMaximum(1200-this->img_width+1);
    ui->MoveImageY->setMaximum(800-this->img_height+1);
    ui->ScaleImageX->setMaximum(1200-this->img_x);
    ui->ScaleImageY->setMaximum(800-this->img_y);
}

void MainWindow::on_ExportFile_clicked()
{
    filename = QFileDialog::getSaveFileName(this,
       tr("Save LPC Instruction File"), "",
       tr("Text File (*.txt);;All Files (*)"));

    if (filename.isEmpty())
            return;
    else {
            QRgb pixColor;
            int pixelmatrix[img_width][img_height];
            int temp_total;

            QFile file(filename);
            if(!file.open(QFile::WriteOnly | QFile::Text)){
                QMessageBox::warning(this,"title","file not open");
            }
            QTextStream out(&file);
            QString line_text;
            out << ui->MoveImageX->text() << "," << ui->MoveImageY->text()<< "," << ui->ScaleImageX->text()<< "," << ui->ScaleImageY->text() << "\n";

            line_text = "";
            int flag = 0;

            for(int i = 0; i < img_height; i++)
            {
                for(int j = 0; j < img_width; j++)
                {
                    pixColor    = image->pixel(j, i);
                    temp_total  = qRed(pixColor) + qGreen(pixColor) + qBlue(pixColor);
                    if (temp_total>380){
                            flag = 0;
                    }else{
                            flag = 1;
                    }
                    pixelmatrix[i][j] = flag;
                    out << flag;
                }
                out << "\n";
            }

            file.close();
        }

}



void MainWindow::on_btn_Close_clicked()
{
    MainWindow::close();
}


void MainWindow::on_MoveImageX_textChanged(const QString &arg1)
{
    move();
}

void MainWindow::on_MoveImageY_textChanged(const QString &arg1)
{
    move();
}

void MainWindow::move()
{
    S_Scene->clear();

    grid = new Grid;
    grid->setPos(0,0);
    S_Scene->addItem(grid);

    image = new QImage;
    img_update();
    image->load(filename);
    *image = image->scaled(img_width,img_height);

    QGraphicsPixmapItem *pm = S_Scene->addPixmap( QPixmap::fromImage(*image));

    if((img_x+img_width<+1200)&&(img_y+img_height<=800)){
       pm->setPos(img_x,img_y);
    }

}

void MainWindow::on_ScaleImageX_textChanged(const QString &arg1)
{
   scale();
}


void MainWindow::on_ScaleImageY_textChanged(const QString &arg1)
{
    scale();
}


void MainWindow::scale()
{
    S_Scene->clear();

    grid = new Grid;
    grid->setPos(0,0);
    S_Scene->addItem(grid);

    image = new QImage;
    img_update();
    image->load(filename);
    *image = image->scaled(img_width,img_height);

    QGraphicsPixmapItem *pm = S_Scene->addPixmap( QPixmap::fromImage(*image));
    pm->setPos(img_x,img_y);
}

