using System;

namespace Lab_4
{
    class Laboratory
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercises 5.1");
            Console.WriteLine(" " + MaxValue(1, 2));


            Console.WriteLine("\nExercises 5.2");
            // testing method
            int a = 1;
            int b = 2;
            Console.WriteLine($"a = {a}; b = {b}");
            ReplaceParametr(ref a, ref b);
            Console.WriteLine($"a = {a}; b = {b}");

            //Console.WriteLine("\nExercises 5.3");

            Console.WriteLine("\nExercises 5.4");
            Console.WriteLine(" " + Factorial(10UL));

            Console.WriteLine("\nHome Exercises 5.1");
            Console.WriteLine(" " + GSD(17, 18, 19));

            Console.WriteLine("Home Exercises 5.2");
            Console.WriteLine(" " + Fibonacci(17));

            Console.ReadKey();
        }
        static int MaxValue(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        static void ReplaceParametr(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        //static bool FactorilChecked (ulong n)
        //{
        //    try
        //    {
        //        FactorilChecked(n)

        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
        static ulong Factorial(ulong n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        static int GSD(int a, int b)
        {
            while (true)
            {
                if (a == b)
                {
                    return a;
                }
                else if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
        }
        static int GSD(int a, int b, int c)
        {
            if (a == b && b == c)
            {
                return a;
            }
            else
            {
                a = GSD(a, b);
                return GSD(a, c);
            }
        }
        static int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
