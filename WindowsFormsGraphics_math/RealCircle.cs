using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsGraphics_math
{
    class RealCircle : RealFigure
    {
        public double x;
        public double y;
        public double radius;
        public RealPoint centre;
        public RealPoint circumference;

        public RealCircle(RealPoint point1, RealPoint point2, CoordinateSystem cs)
        {
            this.centre = point1;
            circumference = point2;
            x = centre.x;
            y = centre.y;
            radius = cs.GetDistance(centre, circumference);            
        }

        //public RealCircle(double x, double y, double radius)
        //{
        //    this.x = x;
        //    this.y = y;
        //    this.radius = radius;
        //    centre = null;
        //    circumference = null;
        //}

        public override void Draw(Graphics g, CoordinateSystem cs)
        {

            Update(cs);
            base.Draw(g, cs);
            int x = cs.RealToVisualX(this.x);
            int y = cs.RealToVisualY(this.y);
            int radius = cs.RealToVisualDistance(this.radius);
          
            g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
        }


        public void Update(CoordinateSystem cs)
        {
            x = centre.x;
            y = centre.y;
            radius = cs.GetDistance(centre, circumference);
        }

        public override void Move(double distanceToMoveX, double distanceToMoveY)
        {
            centre.x += distanceToMoveX;
            centre.y += distanceToMoveY;
            circumference.x += distanceToMoveX;
            circumference.y += distanceToMoveY;
        }

        public override bool HitTest(RealPoint pt, CoordinateSystem cs)
        {
            if (cs.GetDistance(pt, centre) < radius)
            {
                return true;
            }
            return false;
        }

        public override void SetBackLight()
        {
            isSelected = true;
            centre.isSelected = true;
            circumference.isSelected = true;
        }

        public override void UnSetBackLight()
        {
            isSelected = false;
            centre.isSelected = false;
            circumference.isSelected = false;
        }
    }
}
