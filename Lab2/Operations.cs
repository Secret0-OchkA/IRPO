namespace Lab2
{
    internal class Addition : IOperation
    {
        public double Execute(double a, double b) => a + b;
    }
    internal class Subtraction : IOperation
    {
        public double Execute(double a, double b) => a - b;
    }
    internal class Multiplication : IOperation
    {
        public double Execute(double a, double b) => a * b;
    }
    internal class Division : IOperation
    {
        public double Execute(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
    }
}
