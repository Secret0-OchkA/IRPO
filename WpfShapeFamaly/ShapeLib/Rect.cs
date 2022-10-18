using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeFamaly
{
    internal class Rect : Shape
    {
        protected double a;
        protected double b;

        public Rect() : base()
        {
            name = "Rect";
        }

        public Rect(double a, double b) : this()
        {
            perimeter = (a + b) * 2;
            area = a * b;
        }

        public double GetPerimetr() => perimeter;
        public double GetArea() => area;
    }
}