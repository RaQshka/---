namespace ConsoleApplication1
{
    class Program
    {
        public static double F(double x)
        {
            //Функция
            return Math.Pow(x, 3)- 0.2 * Math.Pow(x, 2) + 0.5* x +1.5;
            //return x * x - 1;
        }

        public static void Main()
        {
            /*            var solve = new HalfDivideMethod(F, -2, -1, 4);
                        solve.Solve(100);*/

            var solve = new ProportionsMethod(F, -1, 0, 5);
            solve.Solve(10, false);

        }
    }
    class HalfDivideMethod
    {
        public Func<double, double> Function;

        public double a = 0, b = 0;

        public double x = 0;

        public int eps = 5;
        public HalfDivideMethod(Func<double, double> func1)
        {
            Function = func1;   
        }
        public HalfDivideMethod(Func<double, double> func1, double a, double b, int eps)
        {
            Function = func1;
            this.a = a;
            this.b = b;
            this.eps = eps;
        }
        public void Solve(int iterations)
        {
            Console.WriteLine($"n\t|\ta\t|\tb\t|\tx\t|\tf(a)\t|\tf(b)\t|\tf(x)\t|\t|bn-an");
            x = Math.Round((a + b) / 2, eps);

            double fa = Math.Round(Function(a), eps);
            double fb = Math.Round(Function(b), eps);
            double fx = Math.Round(Function(x), eps);

            double abs = Math.Round(Math.Abs(b-a), eps);

            Console.WriteLine($"{0}\t|\t{a}\t|\t{b}\t|\t{x}\t|\t{fa}\t|\t{fb}\t|\t{fx}\t|\t{abs}");
            bool isLeft = false;

            for (int i = 0; i < iterations; i++)
            {

                if (Math.Sign(a) != Math.Sign(fx))
                {
                    isLeft = false;
                }
                else isLeft = true;
                
                if (!isLeft)
                {
                    a = x;
                    x = Math.Round((a + b)/2, eps);
                    fa = fx;
                    fx = Math.Round(Function(x), eps);
                    abs = Math.Round(Math.Abs(b-a), eps);
                }           
                else 
                {
                    b = x;
                    x = Math.Round((a + b)/2, eps);
                    fb = fx;
                    fx = Math.Round(Function(x), eps);
                    abs = Math.Round(Math.Abs(b-a), eps);
                }
                

                Console.WriteLine($"{i+1}\t|\t{a}\t|\t{b}\t|\t{x}\t|\t{fa}\t|\t{fb}\t|\t{fx}\t|\t{abs}");
            }
        }
    }

    class ProportionsMethod
    {
        public Func<double, double> Function;

        public double a = 0, b = 0;

        public double h = 0, x = 0;

        public int eps = 5;
        public ProportionsMethod(Func<double, double> func1)
        {
            Function = func1;
        }
        public ProportionsMethod(Func<double, double> func1, double a, double b, int eps)
        {
            Function = func1;
            this.a = a;
            this.b = b;
            this.eps = eps;
        }
        public void Solve(int iterations, bool isRight)
        {
            if (isRight)
            {
                x = a;
            } else x = b;

            Console.WriteLine($"n\t|\ta\t|\tb\t|\th\t|\tx\t|\tf(a)\t|\tf(b)\t|\tf(x)\t|");

            double fa = Math.Round(Function(a), eps);
            double fb = Math.Round(Function(b), eps);

            h = Math.Round(((-fa)/(fb-fa))*(b-a), eps);
            x = Math.Round((a*fb-b*fa)/(fb-fa), eps);
            double fx = Math.Round(Function(x), eps);

            Console.WriteLine($"{0}\t|\t{Math.Round(a, 4)}\t|\t{Math.Round(b, 4)}\t|\t{Math.Round(h, 4)}\t|\t{Math.Round(x, 4)}\t|\t{Math.Round(fa, 4)}\t|\t{Math.Round(fb, 4)}\t|\t{fx}");


            for (int i = 0; i < iterations; i++)
            {
                if (isRight)
                {
                    a = x;
                    fa = Function(a);
                    x = Math.Round((a * fb - b * fa) / (fb - fa), eps);
                    fx = Math.Round(Function(x), eps);
                    h = Math.Round(((-fa) / (fb - fa)) * (b - a), eps);
                }
                else
                {
                    b = x;
                    fb = Function(b);
                    x = Math.Round((a * fb - b * fa) / (fb - fa), eps);
                    fx = Math.Round(Function(x), eps);
                    h = Math.Round(((-fa) / (fb - fa)) * (b - a), eps);
                }
                Console.WriteLine($"{i+1}\t|\t{Math.Round(a, 4)}\t|\t{Math.Round(b, 4)}\t|\t{Math.Round(h, 4)}\t|\t{Math.Round(x, 4)}\t|\t{Math.Round(fa, 4)}\t|\t{Math.Round(fb, 4)}\t|\t{fx}");
                /*a = x;
                x = Math.Round((a + b) / 2, eps);
                fa = fx;
                fx = Math.Round(Function(x), eps);
                abs = Math.Round(Math.Abs(b - a), eps);
                */
                //Console.WriteLine($"{i + 1}\t|\t{a}\t|\t{b}\t|\t{x}\t|\t{fa}\t|\t{fb}\t|\t{fx}\t|\t{abs}");
            }
        }
    }
}