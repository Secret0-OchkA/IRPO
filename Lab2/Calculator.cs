namespace Lab2
{
    public class Calculator
    {
        public double Sum(double a, double b) => new Addition().Execute(a, b);
        public double Sub(double a, double b) => new Subtraction().Execute(a, b);
        public double Mul(double a, double b) => new Multiplication().Execute(a, b);
        public double Div(double a, double b) => new Division().Execute(a, b);
    }
}