namespace ConsoleApplication1
{
    class Program
    {
        public static double X(double x, double y) => -0.1 * Math.Pow(x, 2) - 0.2 * Math.Pow(y, 2) + 0.3;
        public static double Y(double x, double y)
        {

            var a1 = Math.Pow(x, 2);
            var a2 = (0.1 * x * y);
            return -0.2 * a1 + a2 + 0.7;

        }

        public static void Main()
        {
            var solve = new IterationMethod(X, Y, 0.25, 0.75);
            solve.Solve(10);

        }
    }
    class IterationMethod
    {
        public Func<double, double, double> x;
        public Func<double, double, double> y;

        public double x0 = 0, y0 = 0;
        public IterationMethod(Func<double, double, double> func1, Func<double, double, double> func2)
        {
            x = func1;
            y = func2;
        }
        public IterationMethod(Func<double, double, double> func1, Func<double, double, double> func2, double X0, double Y0)
        {
            x = func1;
            y = func2;
            x0 = X0;
            y0 = Y0;
        }
        public void Solve(int iterations)
        {

            for (int i = 0; i < iterations; i++)
            {
                var tempx0 = x(x0, y0);
                var tempy0 = y(x0, y0);
                x0 = Math.Round(tempx0, 5);
                y0 = Math.Round(tempy0, 5);
                Console.WriteLine($"{i + 1}.\t{Math.Round(x0, 5)}, {Math.Round(y0, 5)}");
            }
        }
    }
}