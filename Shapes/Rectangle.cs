using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Rectangle : Polygon
    {
        private Tuple<int, int> _topLeft;
        private Tuple<int, int> _bottomRight;

        public Rectangle(Tuple<int,int> topLeft, Tuple<int,int> bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
            base.AddPoint(new Tuple<int,int>(_topLeft.Item1, _topLeft.Item2));
            base.AddPoint(new Tuple<int, int>(_topLeft.Item1, _bottomRight.Item2));
            base.AddPoint(new Tuple<int, int>(_bottomRight.Item1, _bottomRight.Item2));
            base.AddPoint(new Tuple<int, int>(_topLeft.Item2, _bottomRight.Item1));
        }
    }
}
