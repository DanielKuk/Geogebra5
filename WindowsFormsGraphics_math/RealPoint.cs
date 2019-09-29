using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Geogebra3
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

            if (cs.RealToVisualDistance(cs.GetDistance(pt.x, pt.y, x, y)) < cs.radiusPoint) // при масштабирование изменять радиус захвата точки
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

        public bool HitTestLabel(Point clickPointPixel, CoordinateSystem cs)
        {
            if (cs.RealToVisualX(x) + label.offsetX < clickPointPixel.X &&
                cs.RealToVisualY(y) + label.offsetY < clickPointPixel.Y &&
                cs.RealToVisualX(x) + label.offsetX + label.width > clickPointPixel.X &&
                cs.RealToVisualY(y) + label.offsetY + label.height > clickPointPixel.Y)
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
            g.FillEllipse(pen.Brush, xVisual - cs.radiusPoint, yVisual - cs.radiusPoint, 2 * cs.radiusPoint, 2 * cs.radiusPoint);           
            label.Draw(g, cs, x, y);
        }
    }
}
