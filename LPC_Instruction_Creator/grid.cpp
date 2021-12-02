#include "grid.h"

Grid :: Grid(){
    this->populateGridpoints();
}


QRectF Grid :: boundingRect() const{
    return QRectF(0,0,1200,800);
}

void Grid::populateGridpoints()
{
    for(int i = 0 ; i<=1200;i=i+2){
        for(int j = 0 ; j<=800;j=j+2){
            gridpoints.push_back(QPointF(i,j));
        }
    }
}

void Grid :: paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget){
    painter->setPen(Qt::black);
    for(auto x:gridpoints){
       painter->drawPoint(x);
    }
}

