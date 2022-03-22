using System;
using System.Collections.Generic;
using System.Text;

namespace OpenClosedGood.Models
{
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override double Area()
        {
            return Height * Width;
        }
    }
}
