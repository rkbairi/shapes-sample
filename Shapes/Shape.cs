using System;
using Canvases;

namespace Shapes
{
    public abstract class Shape
    {
        public int ZOrder { get; set; }

        public abstract void Draw(Canvas c);

        public abstract Tuple<int, int> GetLeftMostPoint();
        public abstract Tuple<int, int> GetRightMostPoint();
        public abstract Tuple<int, int> GetTopMostPoint();
        public abstract Tuple<int, int> GetBottomMostPoint();

    }
}