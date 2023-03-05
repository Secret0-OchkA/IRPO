namespace QuadraticSolverLib.Test
{
    public class Tests
    {
        [Test]
        public void Should_TwoSolve_When_GreatZero()
        {
            QuadraticSolver.Solve(2,-3,-2,out double x1,out double x2);

            Assert.That(x1 == 2);
            Assert.That(x2 == -0.5);
        }

        [Test]
        public void Should_OneSolve_When_A_EquealZero()
        {
            QuadraticSolver.Solve(1, 4, 4, out double x1, out double x2);

            Assert.That(x1 == -2);
            Assert.That(x2 == -2);
        }

        [Test]
        public void Should_NotSolve_When_A_LessZero()
        {
            QuadraticSolver.Solve(1, 6, 45, out double x1, out double x2);

            Assert.That(double.IsNaN(x1));
            Assert.That(double.IsNaN(x2));
        }
    }
}