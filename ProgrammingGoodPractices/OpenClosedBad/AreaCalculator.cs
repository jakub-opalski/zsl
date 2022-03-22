using OpenClosedBad.Models;
using System.Collections.Generic;

namespace OpenClosedBad
{
    public class AreaCalculator
    {
        public double TotalArea(List<Rectangle> rectangles)
        {
            double area = 0;
            foreach (var rectangle in rectangles)
            {
                area += rectangle.Width * rectangle.Height;
            }
            return area;
        }
    }
}
