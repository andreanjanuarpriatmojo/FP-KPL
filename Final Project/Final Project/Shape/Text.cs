using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project.Shape
{
    public class Text : DrawingObject
    {
        public string Value { get; set; }
        public int textX { get; set; }
        public int textY { get; set; }

        private Brush brush;
        private Font font;
        private SizeF size;

        public Text()
        {
            this.Value = "sembarang";
            this.brush = new SolidBrush(Color.Black);
            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(fontFamily, 16, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public override bool HitArea(int x, int y)
        {
            if ((x >= textX && x <= textX + size.Width) && (y >= textY && y <= textY + size.Height))
            {
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, MouseEventArgs e)
        {
            Point point = e.Location;
            textX += x;
            textY += y;
        }

        public override void DrawPreview()
        {
            this.graphics.DrawString(Value, font, brush, new PointF(textX, textY));
            size = this.graphics.MeasureString(Value, font);
        }

        public override void DrawStatic()
        {
            this.graphics.DrawString(Value, font, brush, new PointF(textX, textY));
            size = this.graphics.MeasureString(Value, font);
        }

        public override void DrawEdit()
        {
            this.graphics.DrawString(Value, font, brush, new PointF(textX, textY));
            size = this.graphics.MeasureString(Value, font);
        }

        public override Point GetCenterPoint()
        {
            throw new NotImplementedException();
        }

        public override string GetText()
        {
            return this.Value;
        }

        public override void SetText(string text)
        {
            this.Value = text;
        }

        public override bool Add(DrawingObject drawingObject)
        {
            return false;
        }

        public override bool Remove(DrawingObject drawingObject)
        {
            return false;
        }

        public override Point GetCenterPoint2()
        {
            throw new NotImplementedException();
        }
    }
}
