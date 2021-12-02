#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include "grid.h"
#include <QMainWindow>

#include <QFileDialog>
#include <QUrl>
#include <QtMath>
#include <complex>
#include <QDebug>
#include <iostream>
#include <QImage>
#include <QColor>
#include <QTimer>

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();
    QString filepath;
    QString filename;
    QImage *image;

    int img_height, img_width, img_x, img_y;

private:
    Ui::MainWindow *ui;
    QGraphicsScene *S_Scene;

    Grid *grid;

private slots:
    //Image Processing
    void LoadinImage();
    void on_buttonLoadImage_clicked();
    void img_update();
    void on_ExportFile_clicked();
    void on_btn_Close_clicked();
    void on_MoveImageX_textChanged(const QString &arg1);
    void move();
    void scale();
    void on_MoveImageY_textChanged(const QString &arg1);
    void on_ScaleImageX_textChanged(const QString &arg1);
    void on_ScaleImageY_textChanged(const QString &arg1);
};
#endif // MAINWINDOW_H
