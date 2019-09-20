using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Geogebra3
{
    class Label  // point has a label == композиция
    {     
        public double offsetX = 0.3; // distance between point and label in metres
        public double offsetY = -0.3; // distance between point and label in metres
        string name;
        bool visible;
        public static char lastLabel = 'A';      
        public static int round = 0;
        public double height;
        public double width;


        public Label(bool visible = true)
        {                     
            this.visible = visible;
            if (lastLabel > 'Z')
            {
                round++;
                lastLabel = 'A';
            }
            if (round == 0)
                this.name = Convert.ToString(lastLabel++);
            else
                this.name = lastLabel++ + Convert.ToString(round);
        }

       

        public void Draw(Graphics g, CoordinateSystem cs, double x, double y)
        {
            if (visible)
            {
                int labelX = cs.RealToVisualX(x + this.offsetX); 
                int labelY = cs.RealToVisualY(y + this.offsetY); 
                SizeF size = g.MeasureString(name, cs.fontLabel);
                this.height = cs.VisualToRealDistance(size.Height);
                this.width = cs.VisualToRealDistance(size.Width);

                // g.DrawRectangle(Pens.Red, labelX , labelY, size.Width, size.Height);
                String labelName = name + "(" + Math.Round(x, 1) + "; " + Math.Round(y, 1) + ")";
                g.DrawString(labelName, cs.fontLabel, cs.brush, labelX, labelY);

            }
        }
    }
}
