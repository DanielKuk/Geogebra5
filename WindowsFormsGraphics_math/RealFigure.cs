using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsGraphics_math
{
    class RealFigure
    {
       
        public bool isSelected;
        public Pen pen = null;

        public RealFigure()
        {
            isSelected = false;
        }

        public virtual void Draw(Graphics g, CoordinateSystem cs)
        {
            if (isSelected)
            {
                pen = cs.selectedPen;
            }
            else
            {
                pen = cs.pen;
            }
        }

        public virtual void SetBackLight()
        {

        }

        public virtual void UnSetBackLight()
        {

        }

        public virtual bool HitTest(RealPoint pt, CoordinateSystem cs)
        {
            return false;
        }

        public virtual void Move(double distanceToMoveX, double distanceToMoveY)
        {
        }

    }
}
