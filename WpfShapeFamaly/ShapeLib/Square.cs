using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeFamaly
{
    internal class Square : Rect
    {
        public Square() : base()
        {
            name = "Square";
        }

        public Square(double a) : base(a, a) 
        {
            name = "Square";
        }
    }
}