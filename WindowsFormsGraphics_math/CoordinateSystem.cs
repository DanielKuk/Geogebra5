using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsGraphics_math
{
    class CoordinateSystem
    {
        public Font fontLabel;
        public int labelOffset;
        public Brush brush;
        public Brush selectedBrush;
        public Pen pen;
        public Pen selectedPen;

        public int unitInterval; // in pixels   
        public int measure;
        public Font fontMeasure;
        public int x0;
        public int y0;
        public int w;
        public int h;
        public int radius;
        public double epsilon;


        public CoordinateSystem(int unitInterval, int x0, int y0, int w, int h)
        {
            brush = new SolidBrush(Color.Black);           
            selectedBrush = new SolidBrush(Color.Red);
            pen = new Pen(brush, 2);
            selectedPen = new Pen(selectedBrush, 2);
            fontMeasure = new Font("Calibri", 11); 
            fontLabel = new Font("Arial", 12, FontStyle.Bold);            
            measure = 3;
            radius = 10;
            this.x0 = x0;
            this.y0 = y0;
            this.w = w;
            this.h = h;
            this.unitInterval = unitInterval;
            epsilon = 0.2;

        }



        public int RealToVisualDistance(double distance) // from meters to pixels
        {
            return (int)Math.Round((distance * unitInterval));
        }

        public double VisualToRealDistance(double distance) // from pixels to meters
        {
            return distance / unitInterval;
        }

        public int RealToVisualX(double x) // from meters to pixels
        {
            return (int)(x0 + x * unitInterval);
        }

        public double VisualToRealX(double visualX)
        {
            return (double)(visualX - x0) / unitInterval;
        }

        public int RealToVisualY(double y) // y = 2
        {
            return (int)(y0 - y * unitInterval);
        }

        public double VisualToRealY(double visualY)
        {
            return (double)(y0 - visualY) / unitInterval;
        }

        public double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double GetDistance(RealPoint p1, RealPoint p2)
        {
            return GetDistance(p1.x, p1.y, p2.x, p2.y);
        }





        public bool PointInInterval(double p, double a, double b)
        {
            return p > a && p < b || p < a && p > b;
        }
       
        public void DrawCoordinateSystem(Graphics g)
        {
//             g.DrawLine(pen, new Point(1, 100), new Point(200, 200));

            int counter = 0;
            g.DrawLine(pen, new Point(0, h / 2), new Point(w, h / 2));
            g.DrawLine(pen, new Point(w / 2, 0), new Point(w / 2, h));

            for (int i = x0; i < w; i += unitInterval)
            {
                g.DrawLine(pen, new Point(i, y0 - measure), new Point(i, y0 + measure));
                if (counter != 0)
                    g.DrawString(counter.ToString(), fontMeasure, brush, i - 5, y0 + 3 * measure);
                counter++;
            }
            counter = 0;
            for (int i = x0; i > 0; i -= unitInterval)
            {
                g.DrawLine(pen, new Point(i, y0 - measure), new Point(i, y0 + measure));
                g.DrawString(counter.ToString(), fontMeasure, brush, i - 10, y0 + 3 * measure);
                counter--;
            }
            counter = 0;
            for (int i = y0; i < h; i += unitInterval)
            {
                g.DrawLine(pen, new Point(x0 - measure, i), new Point(x0 + measure, i));
                if (counter != 0)
                    g.DrawString(counter.ToString(), fontMeasure, brush, x0 + 3 * measure, i - 10);
                counter--;
            }
            counter = 0;
            for (int i = y0; i > 0; i -= unitInterval)
            {
                g.DrawLine(pen, new Point(x0 - measure, i), new Point(x0 + measure, i));
                if (counter != 0)
                    g.DrawString(counter.ToString(), fontMeasure, brush, x0 + 3 * measure, i - 10);
                counter++;
            }
        }
    }
}
