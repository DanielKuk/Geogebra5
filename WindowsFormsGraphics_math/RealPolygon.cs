using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsGraphics_math
{
    class RealPolygon : RealFigure
    {
        public List<RealPoint> vertices; // meter

        public RealPolygon(List<RealPoint> vertices)
        {
            this.vertices = vertices;
        }

        public override void Draw(Graphics g, CoordinateSystem cs)
        {
            base.Draw(g, cs);
            Point[] visualVertices = new Point[vertices.Count]; // pixel
            int index = 0;
            foreach (RealPoint rp in vertices)
            {
                int x1 = cs.RealToVisualX(rp.x);
                int y1 = cs.RealToVisualY(rp.y);
                visualVertices[index] = new Point(x1, y1);
                index++;
            }
            g.DrawPolygon(pen, visualVertices);
        }

        public override void Move(double distanceToMoveX, double distanceToMoveY)
        {
            foreach (RealPoint point in vertices)
            {
                point.x += distanceToMoveX;
                point.y += distanceToMoveY;
            }
        }


        public override bool HitTest(RealPoint pt, CoordinateSystem cs)
        {
            double x = pt.x;
            double y = pt.y;
            int npol = vertices.Count;
            int j = npol - 1;
            bool c = false;
            for (int i = 0; i < npol; i++)
            {
                if ((((vertices[i].y<=y) && (y<vertices[j].y)) || ((vertices[j].y<=y) && (y<vertices[i].y))) && 
                    (x > (vertices[j].x - vertices[i].x) * (y - vertices[i].y) / (vertices[j].y - vertices[i].y) + vertices[i].x)) {
                    c = !c;
                }
                j = i;
            }
            return c; 
        }

        public override void SetBackLight()
        {
            isSelected = true;
            foreach (RealPoint point in vertices)
            {
                point.isSelected = true;
            }
        }

        public override void UnSetBackLight()
        {
            isSelected = false;
            foreach (RealPoint point in vertices)
            {
                point.isSelected = false;
            }
        }
    }
}
