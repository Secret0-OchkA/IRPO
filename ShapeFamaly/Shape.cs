using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapeFamaly
{
    internal class Shape
    {
        protected double area;
        protected double perimeter;
        protected string name;

        public Shape()
        {
            area = 0.0;
            perimeter = 0.0;
            name = "noName";
        }

        public void Show()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"name:{name}\n" +
                   $"perimetr: {perimeter}\n" +
                   $"area: {area}\n";
        }
    }
}