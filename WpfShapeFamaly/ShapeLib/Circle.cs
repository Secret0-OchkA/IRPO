using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeFamaly
{
    internal class Circle : Shape 
    {
        double r = 0;
        public Circle() : base()
        {
            name = "Circle";
        }
        public Circle(double r) : this()
        {
            perimeter = r * Math.PI * 2;
            area = r * r * Math.PI;
        }
    }
}