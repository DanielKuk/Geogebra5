using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsGraphics_math
{
    class RealIntersect : RealFigure
    {
        public List<RealPoint> points;
        RealSegment ab;
        RealSegment cd;
        RealPoint intersectPoint; 

        public RealIntersect(RealSegment ab, RealSegment cd)
        {
            this.ab = ab;
            this.cd = cd;
            intersectPoint = new RealPoint(0, 0);
        }

        public override void Draw(Graphics g, CoordinateSystem cs)
        {           

            double xa = ab.firstPoint.x;
            double ya = ab.firstPoint.y;
            double xb = ab.secondPoint.x;
            double yb = ab.secondPoint.y;
            double xc = cd.firstPoint.x;
            double yc = cd.firstPoint.y;
            double xd = cd.secondPoint.x;
            double yd = cd.secondPoint.y;
            double z1 = (xb - xa) * (yc - ya) - (xc - xa) * (yb - ya);
            double z2 = (xb - xa) * (yd - ya) - (xd - xa) * (yb - ya);
            double xp = xc + (xd - xc) * Math.Abs(z1) / Math.Abs(z2 - z1);
            double yp = yc + (yd - yc) * Math.Abs(z1) / Math.Abs(z2 - z1);

            if (cs.PointInInterval(xp, xa, xb) &&
                cs.PointInInterval(xp, xc, xd) &&
                cs.PointInInterval(yp, ya, yb) &&
                cs.PointInInterval(yp, yc, yd)
               
                )
            {
                intersectPoint.x = xp;
                intersectPoint.y = yp;
                intersectPoint.Draw(g, cs);
            }
 
            //points = new List<RealPoint>();
            //points.Add(rp);

            //foreach (RealPoint point in points)
            //{
            //    point.Draw(g, cs);
            //}
        }
    }

}
