namespace Geogebra3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.AddPointButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLineButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddRectangleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCircleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTriangleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RightTriangleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.IsoscelesTriangleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.AddPolygonButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.IntersectButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.RoundingButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(8, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1021, 348);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMenu,
            this.MoveButton,
            this.DeleteButton,
            this.RoundingButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1059, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddMenu
            // 
            this.AddMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPointButton,
            this.AddLineButton,
            this.AddRectangleButton,
            this.AddCircleButton,
            this.AddTriangleButton,
            this.AddPolygonButton,
            this.toolStripSeparator1,
            this.IntersectButton});
            this.AddMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Size = new System.Drawing.Size(81, 22);
            this.AddMenu.Text = "Add (Point)";
            // 
            // AddPointButton
            // 
            this.AddPointButton.Checked = true;
            this.AddPointButton.CheckOnClick = true;
            this.AddPointButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AddPointButton.Name = "AddPointButton";
            this.AddPointButton.Size = new System.Drawing.Size(180, 22);
            this.AddPointButton.Text = "Add Point";
            this.AddPointButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // AddLineButton
            // 
            this.AddLineButton.CheckOnClick = true;
            this.AddLineButton.Name = "AddLineButton";
            this.AddLineButton.Size = new System.Drawing.Size(180, 22);
            this.AddLineButton.Text = "Add Line";
            this.AddLineButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // AddRectangleButton
            // 
            this.AddRectangleButton.CheckOnClick = true;
            this.AddRectangleButton.Name = "AddRectangleButton";
            this.AddRectangleButton.Size = new System.Drawing.Size(180, 22);
            this.AddRectangleButton.Text = "Add Rectangle";
            this.AddRectangleButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // AddCircleButton
            // 
            this.AddCircleButton.CheckOnClick = true;
            this.AddCircleButton.Name = "AddCircleButton";
            this.AddCircleButton.Size = new System.Drawing.Size(180, 22);
            this.AddCircleButton.Text = "Add Circle";
            this.AddCircleButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // AddTriangleButton
            // 
            this.AddTriangleButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightTriangleButton,
            this.IsoscelesTriangleButton});
            this.AddTriangleButton.Name = "AddTriangleButton";
            this.AddTriangleButton.Size = new System.Drawing.Size(180, 22);
            this.AddTriangleButton.Text = "Add Triangle";
            // 
            // RightTriangleButton
            // 
            this.RightTriangleButton.CheckOnClick = true;
            this.RightTriangleButton.Name = "RightTriangleButton";
            this.RightTriangleButton.Size = new System.Drawing.Size(180, 22);
            this.RightTriangleButton.Text = "Right";
            this.RightTriangleButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // IsoscelesTriangleButton
            // 
            this.IsoscelesTriangleButton.CheckOnClick = true;
            this.IsoscelesTriangleButton.Name = "IsoscelesTriangleButton";
            this.IsoscelesTriangleButton.Size = new System.Drawing.Size(180, 22);
            this.IsoscelesTriangleButton.Text = "Isosceles";
            this.IsoscelesTriangleButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // AddPolygonButton
            // 
            this.AddPolygonButton.CheckOnClick = true;
            this.AddPolygonButton.Name = "AddPolygonButton";
            this.AddPolygonButton.Size = new System.Drawing.Size(180, 22);
            this.AddPolygonButton.Text = "Add Polygon";
            this.AddPolygonButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // IntersectButton
            // 
            this.IntersectButton.Name = "IntersectButton";
            this.IntersectButton.Size = new System.Drawing.Size(180, 22);
            this.IntersectButton.Text = "Intersect";
            this.IntersectButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // MoveButton
            // 
            this.MoveButton.CheckOnClick = true;
            this.MoveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(41, 22);
            this.MoveButton.Text = "Move";
            this.MoveButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // DeleteButton
            // 
            this.DeleteButton.CheckOnClick = true;
            this.DeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(44, 22);
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.CheckEngine);
            // 
            // RoundingButton
            // 
            this.RoundingButton.CheckOnClick = true;
            this.RoundingButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RoundingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RoundingButton.Name = "RoundingButton";
            this.RoundingButton.Size = new System.Drawing.Size(63, 22);
            this.RoundingButton.Text = "Rounding";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 379);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton AddMenu;
        private System.Windows.Forms.ToolStripMenuItem AddPointButton;
        private System.Windows.Forms.ToolStripMenuItem AddLineButton;
        private System.Windows.Forms.ToolStripButton MoveButton;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripMenuItem AddRectangleButton;
        private System.Windows.Forms.ToolStripMenuItem AddCircleButton;
        private System.Windows.Forms.ToolStripMenuItem AddTriangleButton;
        private System.Windows.Forms.ToolStripMenuItem RightTriangleButton;
        private System.Windows.Forms.ToolStripButton RoundingButton;
        private System.Windows.Forms.ToolStripMenuItem IsoscelesTriangleButton;
        private System.Windows.Forms.ToolStripMenuItem AddPolygonButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem IntersectButton;
    }
}

