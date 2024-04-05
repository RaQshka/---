class Program {
    public static double func(double x) => 2*Math.Pow(x, 3) - 10*Math.Pow(x, 2) + 10;

    public static void Main()
    {
        var f = new FibonacciMethod(func, 1, 5, 10, 0);
        f.Solve();
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine("-------------------------------------------------------------");
        Console.ResetColor();
        var g = new GoldenMeanMethod(func, 1, 5, 0.001);
        g.Solve();
    }
    
    
}
public class FibonacciMethod
{
    public double A { get; set; }
    public double B { get; set; }

    public int Iterations { get; set; }
    public double Epsilon { get; set; }
    public Func<double, double> f { get; set; }
    public FibonacciMethod(Func<double, double> f, double a, double b, int iterations = 10, double epsilon = 0)
    {
        this.f = f;
        this.A = a;
        this.B = b;
        this.Iterations = iterations;
        epsilon = 0;
    }
    public double Solve()
    {
        Console.WriteLine($"n a b Xl Xr f(Xl) f(Xr)");
        double L1 = B - A;
        double L2 = Fibonacci(Iterations - 1) / Fibonacci(Iterations) * L1 + (Math.Pow(-1, Iterations) / Fibonacci(Iterations)) * Epsilon;
        double Xr = A + L2;
        double Xl = B - L2;
        double Fxl = f(Xl);
        double Fxr = f(Xr);
        Console.WriteLine($"1 {rnd(A)} {rnd(B)} {rnd(Xl)} {rnd(Xr)} {rnd(Fxl)} {rnd(Fxr)}");

        for (int i = 2; i <= Iterations; i++)
        {
            if (Fxl > Fxr)
            {
                A = Xl;
                Xl = Xr;
                Fxl = Fxr;
                Xr = B - (Xl - A);
                Fxr = f(Xr);
            }
            else if (Fxl < Fxr)
            {
                B = Xr;
                Xr = Xl;
                Fxr = Fxl;
                Xl = A + (B - Xl);
                Fxl = f(Xl);
            }
            Console.WriteLine($"{i} {rnd(A)} {rnd(B)} {rnd(Xl)} {rnd(Xr)} {rnd(Fxl)} {rnd(Fxr)}");

        }
        return 0;
    }
    private double Fibonacci(int x)
    {
        int x1 = 1;
        int x2 = 1, tempx2 = 0;

        for (int i = 2; i <= x; i++)
        {
            tempx2 = x2;
            x2 = x2 + x1;
            x1 = tempx2;
        }
        return x2;
    }
    private double rnd(double x) => Math.Round(x, 3);
}
public class GoldenMeanMethod
{
    public double A { get; set; }
    public double B { get; set; }

    public static readonly double Tau = (1 + Math.Sqrt(5)) / 2;
    public int Iterations { get; set; }
    public double Epsilon { get; set; }
    public Func<double, double> f { get; set; }
    public GoldenMeanMethod(Func<double, double> f, double a, double b, double epsilon = 0)
    {
        this.f = f;
        this.A = a;
        this.B = b;
        this.Epsilon = epsilon;
    }
    public double Solve() 
    {
        Console.WriteLine($"n a b Xl Xr f(Xl) f(Xr)");
        double L1 = B - A;
        double L2 = L1 / Tau ;
        double Xr = A + L2;
        double Xl = B - L2;
        double Fxl = f(Xl);
        double Fxr = f(Xr);
        Console.WriteLine($"1 {rnd(A)} {rnd(B)} {rnd(Xl)} {rnd(Xr)} {rnd(Fxl)} {rnd(Fxr)}");

        for (int i = 2; B-A >=Epsilon; i++)
        {
            if (Fxl > Fxr)
            {
                A = Xl;
                Xl = Xr;
                Fxl = Fxr;
                Xr = B - (Xl - A);
                Fxr = f(Xr);
            }
            else if (Fxl < Fxr)
            {
                B = Xr;
                Xr = Xl;
                Fxr = Fxl;
                Xl = A + (B - Xl);
                Fxl = f(Xl);
            }
            Console.WriteLine($"{i} {rnd(A)} {rnd(B)} {rnd(Xl)} {rnd(Xr)} {rnd(Fxl)} {rnd(Fxr)}");

        }
        return 0;
    }
    private double rnd(double x) => Math.Round(x, 3);
}
