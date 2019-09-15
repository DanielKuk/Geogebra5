using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsGraphics_math
{
    class RealPoint : RealFigure
    {
        public Label label;
        public double x;
        public double y;

        public RealPoint(double x, double y)
        {
            this.x = x;
            this.y = y;           
            this.label = new Label();
        }

        public override void SetBackLight()
        {
            isSelected = true;           
        }

        public override void UnSetBackLight()
        {
            isSelected = false;            
        }

        public override bool HitTest(RealPoint pt, CoordinateSystem cs)
        {
            if (cs.GetDistance(pt.x, pt.y, x, y) < cs.epsilon)
            {
                return true;
            }
            return false;
        }

        public override void Move(double distanceToMoveX, double distanceToMoveY)
        {
            x += distanceToMoveX;
            y += distanceToMoveY;
        }

        public bool HitTestLabel(RealPoint clickPoint)
        {              
            if (x + label.offsetX < clickPoint.x && 
                y + label.offsetY > clickPoint.y && 
                x + label.offsetX + label.width > clickPoint.x && 
                y + label.offsetY - label.height < clickPoint.y)
            {                
                return true;
            }
            return false;
        }

        public override void Draw(Graphics g, CoordinateSystem cs)
        {
            base.Draw(g, cs);
            int xVisual = cs.RealToVisualX(this.x);
            int yVisual = cs.RealToVisualY(this.y);
            g.FillEllipse(pen.Brush, xVisual - cs.radius / 2, yVisual - cs.radius / 2, cs.radius, cs.radius);           
            label.Draw(g, cs, x, y);
        }
    }
}
