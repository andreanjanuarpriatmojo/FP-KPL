using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Final_Project.Shape;

namespace Final_Project.Tool
{
    public class LineTool : ToolStripButton, ITool
    {

        private ICanvas canvas;
        private Line line;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas Canvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public LineTool()
        {
            this.Name = "Line Tool";
            this.ToolTipText = "Line Tool";
            this.Image = IconSet.line;
            this.CheckOnClick = true;
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                line = new Line(new Point(e.X, e.Y));
                line.finishPoint = new Point(e.X, e.Y);
                canvas.AddDrawingObject(line);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                line.finishPoint = new Point(e.X, e.Y);
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                line.finishPoint = new Point(e.X, e.Y);
                line.Selected();
            }
        }
    }
}
