using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canvases;
using System.Drawing;

namespace Shapes
{
    public class Polygon : Shape
    {
        protected List<Point> _points = new List<Point>();

        public void AddPoint(Point p)
        {
            _points.Add(p);
        }

        public override Point GetLeftMostPoint()
        {
            Point leftMost = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].X < leftMost.X)
                {
                    leftMost = _points[i];
                }
            }
            return leftMost;
        }

        public override Point GetRightMostPoint()
        {
            Point rightMost = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].X > rightMost.X)
                {
                    rightMost = _points[i];
                }
            }
            return rightMost;
        }

        public override Point GetTopMostPoint()
        {
            Point topMost = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].Y < topMost.Y)
                {
                    topMost = _points[i];
                }
            }
            return topMost;
        }

        public override Point GetBottomMostPoint()
        {
            Point bottomMost = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].Y > bottomMost.Y)
                {
                    bottomMost = _points[i];
                }
            }
            return bottomMost;
        }

        public override void Draw(Canvas c)
        {
            for (int i = 1; i < _points.Count; i++)
                c.DrawLine(_points[i - 1], _points[i]);
        }

    }
}
