using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Final_Project.Shape
{
    public class Line : DrawingObject
    {

        private const double EPSILON = 3.0;
        private Pen pen;
        public Point startPoint { get; set; }
        public Point finishPoint { get; set; }

        public Line()
        {
            this.pen = new Pen(Color.Black);
        }

        public Line(Point pointX): this()
        {
            this.startPoint = pointX;
        }

        public Line(Point pointX, Point pointY): this()
        {
            this.finishPoint = pointY;
        }

        public override void DrawEdit()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override void DrawPreview()
        {
            pen.Color = Color.Blue;
            pen.DashStyle = DashStyle.DashDotDot;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override void DrawStatic()
        {
            pen.Color = Color.Black;
            pen.DashStyle = DashStyle.Solid;
            this.graphics.DrawLine(pen, this.startPoint, this.finishPoint);
        }

        public override Point GetCenterPoint()
        {
            Point point = new Point();
            point.X = (startPoint.X + finishPoint.X) / 2;
            point.Y = (startPoint.Y + finishPoint.Y) / 2;
            return point;
        }

        public override bool HitArea(int x, int y)
        {
            double a = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            double b = finishPoint.Y - a * finishPoint.X;
            double c = a * x + b;

            if (Math.Abs(y - c) < EPSILON)
            {
                return true;
            }
            return false;
        }

        public override void Move(int x, int y, MouseEventArgs e)
        {
            Point point = e.Location;
            this.startPoint = new Point(this.startPoint.X + x, this.startPoint.Y + y);
            this.finishPoint = new Point(this.finishPoint.X + x, this.finishPoint.Y + y);
        }

        public override string GetText()
        {
            throw new NotImplementedException();
        }

        public override void SetText(string text)
        {
            throw new NotImplementedException();
        }

        public override bool Add(DrawingObject drawingObject)
        {
            throw new NotImplementedException();
        }

        public override bool Remove(DrawingObject drawingObject)
        {
            throw new NotImplementedException();
        }

        public override Point GetCenterPoint2()
        {
            throw new NotImplementedException();
        }
    }
}
