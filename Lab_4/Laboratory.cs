using System;

namespace Lab_4
{
    class Laboratory
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercises 5.1");
            Console.WriteLine("Введите целое число a: ");
            if (!int.TryParse(Console.ReadLine(), out int inputA))
            {
                throw new FormatException("Wrong format for input1. String 11");
            }
            Console.WriteLine("Введите целое число b: ");
            if (!int.TryParse(Console.ReadLine(), out int inputB))
            {
                throw new FormatException("Wrong format for input2. String 12");
            }
            Console.WriteLine("Максимальное значение: " + MaxValue(1, 2));


            Console.WriteLine("\nExercises 5.2");
            Console.WriteLine($"a = {inputA}; b = {inputB}");
            ReplaceParametr(ref inputA, ref inputB);
            Console.WriteLine($"a = {inputA}; b = {inputB}");

            Console.WriteLine("\nExercises 5.3");
            Console.WriteLine("Введите натуральное число: ");
            if (!uint.TryParse(Console.ReadLine(), out uint inputF) || inputF == 0)
            {
                throw new FormatException("Wrong format for inputF. String 30");
            }
            bool flagChecked = FactorilChecked(inputF);

            Console.WriteLine("\nExercises 5.4");
            if (flagChecked)
            {
                Console.WriteLine("Факториал числа равен " + Factorial(inputF));
            }
           
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
        static bool FactorilChecked(uint n)
        {
            try
            {
                for (uint i = n - 1; i > 0; i--)
                {
                    n = checked(n * i);
                }
                Console.WriteLine("Факториал числа равен " + n);
                return true;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        static uint Factorial(uint n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n* Factorial(n -1);
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
