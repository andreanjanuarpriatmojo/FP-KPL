using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project.Shape;

namespace Final_Project.Tool
{
    public class TextTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Text text;
        private string textValue;

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

        public TextTool()
        {
            this.Name = "Text Tool";
            this.ToolTipText = "Text Tool";
            this.Image = IconSet.text;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                text = new Text();
                text.textX = e.X;
                text.textY = e.Y;
                
                DrawingObject drawingObject = canvas.GetObject(e.X, e.Y);

                if (drawingObject == null)
                {
                    canvas.AddDrawingObject(text);
                }
                else
                {
                    textValue = drawingObject.GetText();
                    using (TextForm textForm = new TextForm(textValue, drawingObject, canvas))
                    {
                        if (textForm.ShowDialog() == DialogResult.OK)
                        {
                            textForm.ShowDialog();
                        }
                    }
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
