namespace QuadraticSolverLib
{
    public static class QuadraticSolver
    {
        public static void Solve(double a, double b, double c, out double x1, out double x2)
        {
            //Quadratic Formula: x = (-b +- sqrt(b^2 - 4ac)) / 2a

            //Calculate the inside of the square root
            double insideSquareRoot = (b * b) - 4 * a * c;

            if (insideSquareRoot < 0)
            {
                //There is no solution
                x1 = double.NaN;
                x2 = double.NaN;
            }
            else
            {
                //Compute the value of each x
                //if there is only one solution, both x's will be the same
                double sqrt = Math.Sqrt(insideSquareRoot);
                x1 = (-b + sqrt) / (2 * a);
                x2 = (-b - sqrt) / (2 * a);
            }
        }
    }
}