using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// comment
//modification
// modification2

namespace Geogebra3
{
    public partial class Form1 : Form
    {
        delegate void Action(object sender, MouseEventArgs e);
        string actionKey = "AddPointButton";     
        Dictionary<string, Action> actions = new Dictionary<string, Action>(8);
        Dictionary<string, ToolStripItem> menuitems = new Dictionary<string, ToolStripItem>(8);

        private CoordinateSystem cs1;      
        RealPoint firstPoint;
        RealPoint secondPoint;
        bool creatingLine;      
        List<RealFigure> realFigureList;
        RealPoint selectedPoint;
        RealFigure selected;
        RealPoint clickPoint;
        List<RealPoint> pointList;
        Label selectedLabel;
        RealSegment selectedSeg1 = null;
        RealSegment selectedSeg2 = null;
        bool csMove = false;
        Point clickPointPixel = new Point(0, 0);

        public Form1()
        {
            InitializeComponent();
            // create Coordinate System
            int unitInterval = 30;
            //int x0 = pictureBox1.Width / 2;
            //int y0 = pictureBox1.Height / 2;
            int x0 = 100;
            int y0 = 200;
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;           
            cs1 = new CoordinateSystem(unitInterval, x0, y0, w,h);           
            firstPoint = null;
            secondPoint = null;        
            creatingLine = false;
            realFigureList = new List<RealFigure>();          
            selectedPoint = null;
            selectedLabel = null;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            actions["AddPointButton"] = AddPointAction;
            actions["AddLineButton"] = AddLineAction;
            actions["RightTriangleButton"] = AddRightTriangeAction;
            actions["AddRectangleButton"] = AddRectangeAction;
            actions["IntersectButton"] = AddIntersectAction;
            actions["IsoscelesTriangleButton"] = AddIsoscelesAction;
            actions["AddCircleButton"] = AddCircleAction;
            actions["AddPolygonButton"] = AddPolygonAction;

            menuitems["AddPointButton"] = AddPointButton;
            menuitems["AddLineButton"] = AddLineButton;
            menuitems["AddRectangleButton"] = AddRectangleButton;
            menuitems["AddCircleButton"] = AddCircleButton;
            menuitems["RightTriangeButton"] = RightTriangleButton;
            menuitems["IsoscelesTriangleButton"] = IsoscelesTriangleButton;
            menuitems["AddPolygonButton"] = AddPolygonButton;
            menuitems["AddIntersectButton"] = IntersectButton;
            menuitems["MoveButton"] = MoveButton;
            menuitems["DeleteButton"] = DeleteButton;

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
            cs1.DrawCoordinateSystem(g);
            foreach (RealFigure figure in realFigureList)
            {
                figure.Draw(g, cs1);
            }
        }

        private void AddIntersectAction(object sender, MouseEventArgs e)
        {
            if (selectedSeg1 == null)
            {
                double mouseX = cs1.VisualToRealX(e.X);
                double mouseY = cs1.VisualToRealY(e.Y);
                clickPoint = new RealPoint(mouseX, mouseY);

                selectedSeg1 = (RealSegment)SelectFigure(clickPoint);
                if (selectedSeg1 != null)
                {
                    selectedSeg1.SetBackLight();
                }
                this.Text = "select first segment";
            }

            else
            {
                double mouseX = cs1.VisualToRealX(e.X);
                double mouseY = cs1.VisualToRealY(e.Y);
                clickPoint = new RealPoint(mouseX, mouseY);

                this.Text = "select second segment";
                selectedSeg2 = (RealSegment)SelectFigure(clickPoint);
                if (selectedSeg2 != null)
                {
                    selectedSeg1.UnSetBackLight();
                    RealIntersect intersectPoint = new RealIntersect(selectedSeg1, selectedSeg2);
                    realFigureList.Add(intersectPoint);
                    selectedSeg1 = null;
                    selectedSeg2 = null;
                }
            }
        }

        private void AddPointAction(object sender, MouseEventArgs e)
        {
            double x;
            double y;

            if (RoundingButton.Checked)
            {
                x = Math.Round(cs1.VisualToRealX(e.X));
                y = Math.Round(cs1.VisualToRealY(e.Y));
            }
            else
            {
                x = cs1.VisualToRealX(e.X);
                y = cs1.VisualToRealY(e.Y);
            }
            realFigureList.Add(new RealPoint(x, y));     
        }

        private void AddLineAction(object sender, MouseEventArgs e)
        {
            double x;
            double y;

            if (RoundingButton.Checked)
            {
                x = Math.Round(cs1.VisualToRealX(e.X));
                y = Math.Round(cs1.VisualToRealY(e.Y));
            }
            else
            {
                x = cs1.VisualToRealX(e.X);
                y = cs1.VisualToRealY(e.Y);
            }

            if (creatingLine)
            {
                if (RoundingButton.Checked)
                {
                    selectedPoint.x = Math.Round(selectedPoint.x);
                    selectedPoint.y = Math.Round(selectedPoint.y);
                }
                selectedPoint = null;
                creatingLine = false;
            }
            else
            {
                firstPoint = new RealPoint(x, y);
                realFigureList.Add(firstPoint);
                secondPoint = new RealPoint(x, y);
                realFigureList.Add(secondPoint);
                RealSegment rs = new RealSegment(firstPoint, secondPoint);
                realFigureList.Add(rs);
                selectedPoint = secondPoint;
                creatingLine = true;
            }
        }

        //Todo Global to Local SelectedPoint
        private void AddRectangeAction(object sender, MouseEventArgs e)
        {
            double x;
            double y;

            if (RoundingButton.Checked)
            {
                x = Math.Round(cs1.VisualToRealX(e.X));
                y = Math.Round(cs1.VisualToRealY(e.Y));
            }
            else
            {
                x = cs1.VisualToRealX(e.X);
                y = cs1.VisualToRealY(e.Y);
            }

            if (creatingLine)
            {
                if (RoundingButton.Checked)
                {
                    selectedPoint.x = Math.Round(selectedPoint.x);
                    selectedPoint.y = Math.Round(selectedPoint.y);
                }
                selectedPoint = null;
                creatingLine = false;
            }
            else
            {
                firstPoint = new RealPoint(x, y);
                realFigureList.Add(firstPoint);
                secondPoint = new RealPoint(x, y);
                realFigureList.Add(secondPoint);
                RealRectangle rr = new RealRectangle(firstPoint, secondPoint);
                realFigureList.Add(rr);
                selectedPoint = secondPoint;
                creatingLine = true;
            }
        }

        private void AddCircleAction(object sender, MouseEventArgs e)
        {
            double x;
            double y;

            if (RoundingButton.Checked)
            {
                x = Math.Round(cs1.VisualToRealX(e.X));
                y = Math.Round(cs1.VisualToRealY(e.Y));
            }
            else
            {
                x = cs1.VisualToRealX(e.X);
                y = cs1.VisualToRealY(e.Y);
            }

            if (creatingLine)
            {
                if (RoundingButton.Checked)
                {
                    selectedPoint.x = Math.Round(selectedPoint.x);
                    selectedPoint.y = Math.Round(selectedPoint.y);
                }
                selectedPoint = null;
                creatingLine = false;
            }
            else
            {
                firstPoint = new RealPoint(x, y);
                realFigureList.Add(firstPoint);
                secondPoint = new RealPoint(x, y);
                realFigureList.Add(secondPoint);
                realFigureList.Add(new RealCircle(firstPoint, secondPoint, cs1));
                selectedPoint = secondPoint;
                creatingLine = true;
            }
        }

        private void AddRightTriangeAction(object sender, MouseEventArgs e)
        {
            double x;
            double y;

            if (RoundingButton.Checked)
            {
                x = Math.Round(cs1.VisualToRealX(e.X));
                y = Math.Round(cs1.VisualToRealY(e.Y));
            }
            else
            {
                x = cs1.VisualToRealX(e.X);
                y = cs1.VisualToRealY(e.Y);
            }

            if (creatingLine)
            {
                if (RoundingButton.Checked)
                {
                    selectedPoint.x = Math.Round(selectedPoint.x);
                    selectedPoint.y = Math.Round(selectedPoint.y);
                }
                selectedPoint = null;
                creatingLine = false;
            }
            else
            {
                firstPoint = new RealPoint(x, y);
                realFigureList.Add(firstPoint);
                secondPoint = new RealPoint(x, y);
                realFigureList.Add(secondPoint);
                RealRightTriangle rt = new RealRightTriangle(firstPoint, secondPoint);
                realFigureList.Add(rt);
                selectedPoint = secondPoint;
                creatingLine = true;
            }
        }

        private void AddPolygonAction(object sender, MouseEventArgs e)
        {
            double x;
            double y;

            if (RoundingButton.Checked)
            {
                x = Math.Round(cs1.VisualToRealX(e.X));
                y = Math.Round(cs1.VisualToRealY(e.Y));
            }
            else
            {
                x = cs1.VisualToRealX(e.X);
                y = cs1.VisualToRealY(e.Y);
            }

            if (creatingLine)
            {
                if (RoundingButton.Checked)
                {
                    selectedPoint.x = Math.Round(selectedPoint.x);
                    selectedPoint.y = Math.Round(selectedPoint.y);
                }
                selectedPoint = new RealPoint(x, y);
                int x1 = cs1.RealToVisualX(pointList[0].x);
                int y1 = cs1.RealToVisualY(pointList[0].y);
                if (cs1.GetDistance(x1, y1, e.X, e.Y) < cs1.radius)
                {
                    creatingLine = false;
                    pointList.RemoveAt(pointList.Count - 1);
                    realFigureList.RemoveAt(realFigureList.Count - 1);
                }
                else
                {
                    pointList.Add(selectedPoint);
                    realFigureList.Add(selectedPoint);
                }
            }
            else
            {
                pointList = new List<RealPoint>();
                firstPoint = new RealPoint(x, y);
                secondPoint = new RealPoint(x, y);
                realFigureList.Add(firstPoint);
                realFigureList.Add(secondPoint);
                pointList.Add(firstPoint);
                pointList.Add(secondPoint);

                RealPolygon polygon = new RealPolygon(pointList);
                realFigureList.Add(polygon);
                selectedPoint = secondPoint;
                creatingLine = true;
            }
        }

        private void AddIsoscelesAction(object sender, MouseEventArgs e)
        {
            double x;
            double y;

            if (RoundingButton.Checked)
            {
                x = Math.Round(cs1.VisualToRealX(e.X));
                y = Math.Round(cs1.VisualToRealY(e.Y));
            }
            else
            {
                x = cs1.VisualToRealX(e.X);
                y = cs1.VisualToRealY(e.Y);
            }

            if (creatingLine)
            {
                if (RoundingButton.Checked)
                {
                    selectedPoint.x = Math.Round(selectedPoint.x);
                    selectedPoint.y = Math.Round(selectedPoint.y);
                }
                selectedPoint = null;
                creatingLine = false;
            }
            else
            {
                firstPoint = new RealPoint(x, y);
                realFigureList.Add(firstPoint);
                secondPoint = new RealPoint(x, y);
                realFigureList.Add(secondPoint);
                RealIsoscelesTriangle rt = new RealIsoscelesTriangle(firstPoint, secondPoint);
                realFigureList.Add(rt);
                selectedPoint = secondPoint;
                creatingLine = true;
            }
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (actions.ContainsKey(actionKey))
            {
                actions[actionKey](sender, e);
            }
            pictureBox1.Invalidate();
        }

        private RealFigure SelectFigure(RealPoint clickPoint)
        {
            foreach (RealFigure figure in realFigureList)
            {                        
                if (figure.HitTest(clickPoint, cs1))
                {
                    return figure;
                }
            }
            return null;
        }

        private void SelectLabel(MouseEventArgs e) // top left --> center // change this code 
        { 
            foreach (RealFigure figure in realFigureList)
            {
                if (figure is RealPoint)
                {
                    RealPoint point = (RealPoint)figure;
                    double mouseX = cs1.VisualToRealX(e.X);
                    double mouseY = cs1.VisualToRealY(e.Y);
                    clickPoint = new RealPoint(mouseX, mouseY);
                    if (point.HitTestLabel(clickPoint))
                    {
                       selectedLabel = point.label;                       
                    }
                }
            }
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
             if (MoveButton.Checked)
             {                 
                SelectLabel(e);

                double mouseX = cs1.VisualToRealX(e.X);
                double mouseY = cs1.VisualToRealY(e.Y);
                clickPoint = new RealPoint(mouseX, mouseY);

                selected = SelectFigure(clickPoint);

                 if (selected != null)
                     Text = selected.ToString();
                 else
                     Text = "null";

                 if (selected != null)
                 {                    
                     selected.SetBackLight();
                 }
                 else
                 {
                    csMove = true;
                    clickPointPixel.X = e.X;
                    clickPointPixel.Y = e.Y;
                }
                 pictureBox1.Invalidate();
             }

             if (DeleteButton.Checked)
             {
                double mouseX = cs1.VisualToRealX(e.X);
                double mouseY = cs1.VisualToRealY(e.Y);
                clickPoint = new RealPoint(mouseX, mouseY);

                selected = SelectFigure(clickPoint);
                 realFigureList.Remove(selected);
                 selected = null;
                 pictureBox1.Invalidate();
             }
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {          

            // deselect label
            if (MoveButton.Checked && selectedLabel != null)
            {
                selectedLabel = null;               
            }

            // deselect figure
            if (MoveButton.Checked && selected != null)
            {
                selected.UnSetBackLight();               
                selected = null;
            }
            else
            {
                csMove = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            Graphics g = pictureBox1.CreateGraphics();
            if (selectedPoint != null)
            {
                selectedPoint.x = cs1.VisualToRealX(e.X);
                selectedPoint.y = cs1.VisualToRealY(e.Y);
                pictureBox1.Invalidate();
            }

            if (selectedLabel != null)
            {               
                double distanceToMoveX = cs1.VisualToRealX(e.X) - clickPoint.x;
                double distanceToMoveY = cs1.VisualToRealY(e.Y) - clickPoint.y;
                selectedLabel.offsetX += distanceToMoveX;
                selectedLabel.offsetY += distanceToMoveY;
                clickPoint.x = cs1.VisualToRealX(e.X);
                clickPoint.y = cs1.VisualToRealY(e.Y);

                pictureBox1.Invalidate();
            }
            if (selected != null)
            {
                double distanceToMoveX = cs1.VisualToRealX(e.X) - clickPoint.x;
                double distanceToMoveY = cs1.VisualToRealY(e.Y) - clickPoint.y;
                selected.Move(distanceToMoveX, distanceToMoveY);
                clickPoint.x = cs1.VisualToRealX(e.X);
                clickPoint.y = cs1.VisualToRealY(e.Y);
                pictureBox1.Invalidate();
            }

            if (csMove)
            {
                //cs1.x0 = e.X;
                //cs1.y0 = e.Y;
                int distanceToMoveX = e.X - clickPointPixel.X;
                int distanceToMoveY = e.Y - clickPointPixel.Y;
                //Move CoordinateSystem
                cs1.x0 += distanceToMoveX;
                cs1.y0 += distanceToMoveY;
                clickPointPixel.X = e.X;
                clickPointPixel.Y = e.Y;
                pictureBox1.Invalidate();
            }
        }
              

        private void CheckEngine(object sender, EventArgs e)
        {
            //AddPointButton.Checked = false;
            //AddLineButton.Checked = false;
            //AddRectangleButton.Checked = false;
            //AddCircleButton.Checked = false;
            //RightTriangleButton.Checked = false;
            //IsoscelesTriangleButton.Checked = false;
            //AddPolygonButton.Checked = false;
            //IntersectButton.Checked = false;
            //MoveButton.Checked = false;
            //DeleteButton.Checked = false;
            foreach (ToolStripItem button in menuitems.Values)
            {
                if (button is ToolStripMenuItem)
                    ((ToolStripMenuItem)button).Checked = false;
                if (button is ToolStripButton)
                    ((ToolStripButton)button).Checked = false;
                //button.Checked = false;
            }
            if (sender is ToolStripMenuItem)
            {
                ((ToolStripMenuItem)sender).Checked = true;
                AddMenu.Text = "Add (" + ((ToolStripMenuItem)sender).Text + ")";
                //AddMenu.Text = " (" + sender.ToString() + ")";
            }
            if (sender is ToolStripButton)
            {
                ((ToolStripButton)sender).Checked = true;
            }          
            actionKey = ((ToolStripItem)sender).Name;
            
        }
    }
}
