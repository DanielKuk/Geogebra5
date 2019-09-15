using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Geogebra3
{
    class RealRectangle : RealFigure
    {
        public RealPoint firstPoint;
        public RealPoint secondPoint;



        public RealRectangle(RealPoint first, RealPoint second)
        {
            this.firstPoint = first;
            this.secondPoint = second;
        }

        public override bool HitTest(RealPoint pt, CoordinateSystem cs)
        {
            
            if (firstPoint.x < pt.x && pt.x < secondPoint.x  &&  firstPoint.y > pt.y &&  pt.y > secondPoint.y ||
                secondPoint.x < pt.x && pt.x < firstPoint.x  &&  secondPoint.y > pt.y &&  pt.y > firstPoint.y ||
                firstPoint.x > pt.x && pt.x > secondPoint.x  &&  firstPoint.y > pt.y && pt.y > secondPoint.y ||
                secondPoint.x > pt.x && pt.x > firstPoint.x  &&  secondPoint.y > pt.y && pt.y > firstPoint.y)
            {
                return true;
            }
            return false; 
        }

        public override void Draw(Graphics g, CoordinateSystem cs)
        {
           
            if (this.firstPoint != null && this.secondPoint != null)
            {
                // Point topLeftPoint = new Point(0,0);
                int x1 = cs.RealToVisualX(this.firstPoint.x);
                int y1 = cs.RealToVisualY(this.firstPoint.y);
                int x2 = cs.RealToVisualX(this.secondPoint.x);
                int y2 = cs.RealToVisualY(this.secondPoint.y);

                base.Draw(g, cs);

                int topLeftPointX;
                if (x1 < x2)
                {
                    topLeftPointX = x1;
                }
                else
                {
                    topLeftPointX = x2;
                }
                int topLeftPointY;
                if (y1 < y2)
                {
                    topLeftPointY = y1;
                }
                else
                {
                    topLeftPointY = y2;
                }
                // x2 = 3.6, x2 = 13.4  ==> round ==> 13 - 4 = 9
                // x2 = 3.6, x2 = 13.4 --> 13.4-3.6= 9.8 ==> 10
                int height = cs.RealToVisualDistance(Math.Abs(secondPoint.y - firstPoint.y));
                int width = cs.RealToVisualDistance(Math.Abs(secondPoint.x - firstPoint.x));
              
                
                g.DrawRectangle(pen, topLeftPointX, topLeftPointY, width, height);
            }
        }

        public override void Move(double distanceToMoveX, double distanceToMoveY)
        {
            this.firstPoint.x += distanceToMoveX;
            this.firstPoint.y += distanceToMoveY;
            this.secondPoint.x += distanceToMoveX;
            this.secondPoint.y += distanceToMoveY;
        }

        public override void SetBackLight()
        {
            isSelected = true;
            firstPoint.isSelected = true;
            secondPoint.isSelected = true;
        }

        public override void UnSetBackLight()
        {
            isSelected = false;
            firstPoint.isSelected = false;
            secondPoint.isSelected = false;
        }
    }
}
