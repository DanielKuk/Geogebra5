using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsGraphics_math
{
    class RealRightTriangle : RealFigure
    {
        public RealPoint firstPoint;
        public RealPoint secondPoint;

        public RealRightTriangle(RealPoint first, RealPoint second)
        {
            this.firstPoint = first;
            this.secondPoint = second;
        }

        public override void Draw(Graphics g, CoordinateSystem cs)
        {
            if (this.firstPoint != null && this.secondPoint != null)
            {
                base.Draw(g, cs);
                int x1 = cs.RealToVisualX(this.firstPoint.x);
                int y1 = cs.RealToVisualY(this.firstPoint.y);
                int x2 = cs.RealToVisualX(this.secondPoint.x);
                int y2 = cs.RealToVisualY(this.secondPoint.y);
                int bottomLeftPointX;             
                int bottomRightPointX;
                if (x1 < x2)
                {
                    bottomLeftPointX = x1;            
                    bottomRightPointX = x2; 
                }
                else
                {
                    bottomLeftPointX = x2;                
                    bottomRightPointX = x1;
                }
                int bottomLeftPointY;            
                int bottomRightPointY;
                if (y1 > y2)
                {
                    bottomLeftPointY = y1;                
                    bottomRightPointY = y1;
                }
                else
                {
                    bottomLeftPointY = y2;             
                    bottomRightPointY = y2;
                }
                g.DrawLine(pen, x1,y1, x2, y2);
                if ((x1 - x2) * (y1 - y2) > 0) // 2
                {
                    g.DrawLine(pen, x1, y1, bottomLeftPointX, bottomLeftPointY);
                    g.DrawLine(pen, x2, y2, bottomLeftPointX, bottomLeftPointY);
                }
                else // 1
                {
                    g.DrawLine(pen, bottomRightPointX, bottomRightPointY, x1, y1);
                    g.DrawLine(pen, bottomRightPointX, bottomRightPointY, x2, y2);
                }

              
            }


        }

        public override void Move(double distanceToMoveX, double distanceToMoveY)
        {
            firstPoint.x += distanceToMoveX;
            firstPoint.y += distanceToMoveY;
            secondPoint.x += distanceToMoveX;
            secondPoint.y += distanceToMoveY;
        }

        public override bool HitTest(RealPoint pt, CoordinateSystem cs)
        {
            double x1 = firstPoint.x;
            double y1 = firstPoint.y;
            double x2 = secondPoint.x;
            double y2 = secondPoint.y;

            double x3 = secondPoint.x;
            double y3 = firstPoint.y;
            if (firstPoint.y > secondPoint.y)
            {
                x3 = firstPoint.x;
                y3 = secondPoint.y;
            }
          

            double x0 = pt.x;
            double y0 = pt.y;
            double a = (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0);
            double b = (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0);
            double c = (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0);



            if ((a > 0 && b > 0 && c > 0) || (a < 0 && b < 0 && c < 0))
            {
                return true;
            }

            return false;
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
