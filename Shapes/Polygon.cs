using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canvases;

namespace Shapes
{
    public class Polygon : Shape
    {
        protected List<Tuple<int, int>> _points = new List<Tuple<int, int>>();

        public void AddPoint(Tuple<int, int> p)
        {
            _points.Add(p);
        }

        public override Tuple<int, int> GetLeftMostPoint()
        {
            Tuple<int, int> leftMost = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].Item1 < leftMost.Item1)
                {
                    leftMost = _points[i];
                }
            }
            return leftMost;
        }

        public override Tuple<int, int> GetRightMostPoint()
        {
            Tuple<int, int> rightMost = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].Item1 > rightMost.Item1)
                {
                    rightMost = _points[i];
                }
            }
            return rightMost;
        }

        public override Tuple<int, int> GetTopMostPoint()
        {
            Tuple<int, int> topMost = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].Item2 < topMost.Item2)
                {
                    topMost = _points[i];
                }
            }
            return topMost;
        }

        public override Tuple<int, int> GetBottomMostPoint()
        {
            Tuple<int, int> bottomMost = _points[0];
            for (int i = 1; i < _points.Count; i++)
            {
                if (_points[i].Item2 > bottomMost.Item2)
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
