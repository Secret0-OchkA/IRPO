
using ShapeFamaly;

Console.WriteLine("1:Rect\n2:Square\n3:Circle");
int shapeType = Convert.ToInt32((Console.ReadLine()));
Shape shape = new Shape();
switch(shapeType)
{
    case 1:
        Console.WriteLine("Input a");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input b");
        int b = Convert.ToInt32(Console.ReadLine());
        shape = new Rect(a, b);
        break;
    case 2:
        Console.WriteLine("Input a");
        int squareA = Convert.ToInt32(Console.ReadLine());
        shape = new Square(squareA);
        break;
    case 3:
        Console.WriteLine("Input r");
        int r = Convert.ToInt32(Console.ReadLine());
        shape = new Circle(r);
        break;
}

shape.Show();
