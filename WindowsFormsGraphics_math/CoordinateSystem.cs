using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Geogebra3
{
    class CoordinateSystem
    {
        public Font fontLabel;
        public Brush brush;
        public Brush selectedBrush;
        public Pen pen;
        public Pen selectedPen;

        public int unitInterval; // in pixels   
        public int dashLength;
        int distanceDashMeasurementText;
        public Font fontMeasure;
        public int x0;
        public int y0;
        public int w;
        public int h;
        public int radiusPoint;
        public double dashInterval;



        public CoordinateSystem(int unitInterval, int x0, int y0, int w, int h)
        {
            brush = new SolidBrush(Color.Black);
            selectedBrush = new SolidBrush(Color.Red);
            pen = new Pen(brush, 2);
            selectedPen = new Pen(selectedBrush, 2);
            fontMeasure = new Font("Calibri", 11);
            //fontMeasure = new Font("Calibri", 24); 
            fontLabel = new Font("Arial", 12, FontStyle.Bold);
            dashLength = 7;
            distanceDashMeasurementText = 10; // distance between Dash and MeasurementText in pixels
            radiusPoint = 5;
            this.x0 = x0;
            this.y0 = y0;
            this.w = w;
            this.h = h;
            this.unitInterval = unitInterval;
            dashInterval = 200;
        }

        public int RealToVisualDistance(double distance) // from meters to pixels
        {
            return (int)Math.Round(( distance * unitInterval));
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

        public void drawXAxisDashes(Graphics g, int dashUpPoint, int dashDownPoint, int measurementTextPositionY, double interval)
        {
            int counter = 0;
            int intervalVisual = RealToVisualDistance(interval);
            for (int i = x0; i < w; i += intervalVisual)
            {
                g.DrawLine(pen, new Point(i, dashUpPoint), new Point(i, dashDownPoint)); // черточки внизу экрана                
                if (counter != 0)
                    g.DrawString((counter * interval).ToString(), fontMeasure, brush, i - 5, measurementTextPositionY);
                counter++;
            }
            counter = 0;
            for (int i = x0; i > 0; i -= intervalVisual)
            {
                g.DrawLine(pen, new Point(i, dashUpPoint), new Point(i, dashDownPoint));
                g.DrawString((counter*interval).ToString(), fontMeasure, brush, i - 5, measurementTextPositionY);
                counter--;
            }
        }

        private void drawYAxisDashes(Graphics g, int dashLeftPoint, int dashRightPoint, int measurementTextPositionX, double interval)
        {
            int counter = 0;
            int intervalVisual = RealToVisualDistance(interval);
            for (int i = y0; i < h; i += intervalVisual)
            {
                g.DrawLine(pen, new Point(dashLeftPoint, i), new Point(dashRightPoint, i));
                if (counter != 0)
                    g.DrawString((counter * interval).ToString(), fontMeasure, brush, measurementTextPositionX, i - 10);
                counter--;
            }
            counter = 0;
            for (int i = y0; i > 0; i -= intervalVisual)
            {
                g.DrawLine(pen, new Point(dashLeftPoint, i), new Point(dashRightPoint, i));
                if (counter != 0)
                    g.DrawString((counter * interval).ToString(), fontMeasure, brush, measurementTextPositionX, i - 10);
                counter++;
            }
        }

        public void DrawCoordinateSystem(Graphics g)
        {

        
            g.DrawLine(pen, new Point(0, y0), new Point(w, y0));
            g.DrawLine(pen, new Point(x0, 0), new Point(x0, h));
            // numbers of x Axis
            if (y0 > h)
            {
                drawXAxisDashes(g, h - dashLength, h, h - fontMeasure.Height - (dashLength + distanceDashMeasurementText), dashInterval);
            }
            else if (y0 < 0)
            {
                drawXAxisDashes(g, 0, dashLength, 0 + (dashLength + distanceDashMeasurementText), dashInterval);
            }
            else
            {
                drawXAxisDashes(g, y0 - dashLength, y0 + dashLength, y0 + (dashLength + distanceDashMeasurementText), dashInterval);
            }
            // numbers of y Axis           
            if (x0 < 0)
            {
                drawYAxisDashes(g, 1 + dashLength, x0 + dashLength, dashLength + 1, dashInterval);
            }
            else if (x0 > w)
            {
                drawYAxisDashes(g, w - dashLength, w, w - dashLength - 22, dashInterval);
            }
            else
            {
                drawYAxisDashes(g, x0 - dashLength, x0 + dashLength, x0 + 3 * dashLength, dashInterval);
            }
        }









    }
}
