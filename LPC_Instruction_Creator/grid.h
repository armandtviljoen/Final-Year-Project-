#ifndef GRID_H
#define GRID_H
using namespace std;
#include <QPainter>
#include <QGraphicsItem>
#include <QWidget>


class Grid : public QGraphicsItem{
private:

    QRectF boundingRect() const;
    void populateGridpoints();
    void paint(QPainter *painter,
    const QStyleOptionGraphicsItem *option,
    QWidget *widget = nullptr);
public:
    Grid();
    vector<QPointF> gridpoints;
} ;
#endif // GRID_H

