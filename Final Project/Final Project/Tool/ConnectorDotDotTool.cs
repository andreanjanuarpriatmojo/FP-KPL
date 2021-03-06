﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Final_Project.Shape;
using Final_Project.State;

namespace Final_Project.Tool
{
    class ConnectorDotDotTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        Point point;

        public DrawingObject objectSource;
        public DrawingObject objectDestination;

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

        public ConnectorDotDotTool()
        {
            this.Name = "Dependency Tool";
            this.ToolTipText = "Dependency Tool";
            this.Image = IconSet.dependency;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAll();
                objectSource = canvas.SelectObject(e.X, e.Y);

            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {

                canvas.DeselectAll();

                if (objectSource != null)
                {
                    objectDestination = canvas.SelectObject(e.X, e.Y);

                    ConnectorDotDot connector = new ConnectorDotDot(objectSource, objectDestination);
                    objectSource.Attach(connector);
                    objectDestination.Attach(connector);

                    canvas.AddDrawingObject(connector);
                    connector.ChangeState(StaticState.GetInstance());

                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
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
