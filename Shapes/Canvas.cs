using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace Canvases
{
    public class Canvas : VectorGraphicsCanvas
    {
        private List<Shape> _shapes = new List<Shape>();
        public new void DrawLine(Tuple<int,int> p1, Tuple<int,int> p2)
        {
            // Custom logic here
            base.DrawLine(p1, p2);
        }

        public void AddShape(Shape shape)
        {
            this._shapes.Add(shape);
            this.Paint();
        }

        public void Paint()
        {
            foreach (var shape in this._shapes)
                shape.Draw(this);
        }

        // Returns the Old and New Z-orders of the shape
        public Tuple<int, int> BringForward(Shape shape)
        {
            Tuple<int, int> z = new Tuple<int, int>(0, 0);

            // Logic to bring front and update old, new Z orders
            // Does shape overlap with any other shape?
            for (int i = 0; i < this._shapes.Count; i++)
            {
                if (this._shapes[i] != shape)
                {
                    // Is to the left of the shape
                    Tuple<int, int> rightMost = this._shapes[i].GetRightMostPoint();
                    Tuple<int, int> leftMost = shape.GetLeftMostPoint();
                    if (rightMost.Item1 > leftMost.Item1)
                    {
                        // Overlapping
                        z = new Tuple<int, int>(shape.ZOrder, Math.Max(shape.ZOrder, this._shapes[i].ZOrder + 1));
                    }

                    // Is to the right of the shape
                    Tuple<int, int> leftMost2 = this._shapes[i].GetLeftMostPoint();
                    Tuple<int, int> rightMost2 = shape.GetRightMostPoint();
                    if (leftMost2.Item1 < rightMost2.Item1)
                    {
                        // Overlapping
                        z = new Tuple<int, int>(shape.ZOrder, Math.Max(shape.ZOrder, this._shapes[i].ZOrder + 1));
                    }

                    // Is above the shape
                    Tuple<int, int> bottomMost = this._shapes[i].GetBottomMostPoint();
                    Tuple<int, int> topMost = shape.GetTopMostPoint();
                    if (bottomMost.Item2 > topMost.Item2)
                    {
                        // Overlapping
                        z = new Tuple<int, int>(shape.ZOrder, Math.Max(shape.ZOrder, this._shapes[i].ZOrder + 1));
                    }

                    // Is below the shape
                    Tuple<int, int> topMost2 = this._shapes[i].GetTopMostPoint();
                    Tuple<int, int> bottomMost2 = shape.GetBottomMostPoint();
                    if (topMost2.Item2 < bottomMost2.Item2)
                    {
                        // Overlapping
                        z = new Tuple<int, int>(shape.ZOrder, Math.Max(shape.ZOrder, this._shapes[i].ZOrder + 1));
                    }
                }
            }

            return z;
        }
    }
}
