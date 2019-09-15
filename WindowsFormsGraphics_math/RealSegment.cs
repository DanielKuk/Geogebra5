using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace WindowsFormsGraphics_math

{
    class RealSegment : RealFigure
    {
        public RealPoint firstPoint;
        public RealPoint secondPoint;

        public RealSegment(RealPoint first, RealPoint second)
        {
            this.firstPoint = first;
            this.secondPoint = second;
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

        public override void Draw(Graphics g, CoordinateSystem cs)
        {
            if (this.firstPoint != null && this.secondPoint != null)
            {
                base.Draw(g, cs);
                int x1 = cs.RealToVisualX(this.firstPoint.x);
                int y1 = cs.RealToVisualY(this.firstPoint.y);
                int x2 = cs.RealToVisualX(this.secondPoint.x);
                int y2 = cs.RealToVisualY(this.secondPoint.y);
                g.DrawLine(pen, x1, y1, x2, y2);

            }
        }

        public override bool HitTest(RealPoint pt, CoordinateSystem cs)
        {
             double x0 = pt.x;
            double y0 = pt.y;
        
            double x1 = firstPoint.x;
            double y1 = firstPoint.y;

            double x2 = secondPoint.x;
            double y2 = secondPoint.y;


            if (Math.Abs((x2 - x0) / (x2-x1) - (y2 - y0) / (y2 - y1))<0.1  
               && (x1 - x0) * (x2 - x0) < 0 && (y1 - y0) * (y2 - y0) < 0
                 )
            {
                return true;
            }
            return false;
        }

        public override void Move(double distanceToMoveX, double distanceToMoveY)
        {
            this.firstPoint.x += distanceToMoveX;
            this.firstPoint.y += distanceToMoveY;
            this.secondPoint.x += distanceToMoveX;
            this.secondPoint.y += distanceToMoveY;
        } 
    }
}
