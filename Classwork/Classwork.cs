using System;
using System.Drawing;

namespace Classwork
{
    class Classwork
    {
        static void Main(string[] args)
        {
            Console.Write("Нажми номер задания, который Вам нужен: ");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            Console.WriteLine();
            switch (consoleKey)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    DoTask1();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    DoTask2();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    DoTask3();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    DoTask4();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    DoTask5();
                    break;
                default:
                    Console.WriteLine("Такого задания не существует");
                    break;
            }
            Console.ReadKey();
        }
        static private void DoTask1()
        {
            Console.WriteLine("Введите вещественные коэффициенты уравнения.");
            bool flag = true;
            while (flag)
            {
                Console.Write("Введите коэффициент a перед x^2: ");
                bool exception1 = double.TryParse(Console.ReadLine(), out double a);
                Console.Write("Введите коэффициент b перед x: ");
                bool exception2 = double.TryParse(Console.ReadLine(), out double b);
                Console.Write("Введите свободный член c: ");
                bool exception3 = double.TryParse(Console.ReadLine(), out double c);
                if (exception1 && exception2 && exception3)
                {
                    SolveQuadratEqution(a, b, c, true); flag = false;
                }
                else
                {
                    Console.WriteLine("Формат ввода неправильный. Попробуй снова.");
                }
            }

        }
        static public void DoTask2()
        {
            Random random = new Random();
            Console.WriteLine("Array: ");
            int[] arrayRandNum = new int[20];
            for (int i = 0; i < 20; i++)
            {
                arrayRandNum[i] = random.Next(1000);
                Console.Write(arrayRandNum[i] + " ");
            }
            Console.WriteLine("\nChoise 2 different number from this array.");
            Console.Write("Number 1: ");
            bool exception1 = int.TryParse(Console.ReadLine(), out int num1);
            Console.Write("Number 2: ");
            bool exception2 = int.TryParse(Console.ReadLine(), out int num2);
            if (!exception1 || !exception2) throw new Exception("Exception output: num1 и num2");
            int index1 = -1, index2 = -1;
            for (int i = 0; i < 20; i++)
            {
                if (arrayRandNum[i] == num1) index1 = i;
                if (arrayRandNum[i] == num2) index2 = i;
            }
            if (index1 == -1 || index2 == -1)
            {
                Console.WriteLine("Невозможно совершить перестановку с числом, которое не из массива");
            }
            else
            {
                if (num1 == num2)
                {
                    Console.WriteLine("Числа одинаковые. Массив не изменится");
                }
                else
                {
                    int temp = arrayRandNum[index1];
                    arrayRandNum[index1] = arrayRandNum[index2];
                    arrayRandNum[index2] = temp;
                }
                Console.WriteLine("Array: ");
                foreach (var item in arrayRandNum)
                {
                    Console.Write(item + " ");
                }
            }

        }
        static public void DoTask3()
        {
            Console.Write("Введите количесвто членов последоватеьности n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
            {
                throw new FormatException("Wrong format n. String: 112");
            }
            Console.WriteLine("Введите последовательность чисел: ");
            string input = Console.ReadLine();
            if (input.Split().Length != n)
            {
                throw new FormatException("Format input string fit n. String: 120");
            }
            int[] order = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(input.Split()[i], out order[i]))
                    throw new FormatException($"Wrong format A{i}. String: 126");
            }
            Console.Write("1) Сортировка по возрастанию.\n2) Сортировка по убыванию.\nНажми цифру: ");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            Console.WriteLine();
            switch (consoleKey)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    for (int i = 0; i < n - 1; i++)
                    {
                        for (int j = i; j < n - 1; j++)
                        {
                            if (order[i] > order[j + 1])
                            {
                                int temp;
                                temp = order[i];
                                order[i] = order[j + 1];
                                order[j + 1] = temp;
                            }
                        }
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    for (int i = 0; i < n - 1; i++)
                    {
                        for (int j = i; j < n - 1; j++)
                        {
                            if (order[i] < order[j + 1])
                            {
                                int temp;
                                temp = order[i];
                                order[i] = order[j + 1];
                                order[j + 1] = temp;
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Третьего не дано");
                    break;
            }
            Console.WriteLine("Массив после сортировки:");
            foreach (var item in order)
            {
                Console.Write(item + " ");
            }
        }
        static public void DoTask4()
        {
            Console.WriteLine("Введите последовательность чисел: ");
            string[] inputStrArray = Console.ReadLine().Split();
            double[] inputDoubleArray = new double[inputStrArray.Length];
            for (int i = 0; i < inputStrArray.Length; i++)
            {
                if (!double.TryParse(inputStrArray[i], out inputDoubleArray[i]))
                    throw new FormatException($"Wrong format A{i}. String: 183");
            }
            double productArray = 1;
            double sumArray = CalculateArray(ref productArray, out double average, inputDoubleArray);
            Console.WriteLine($"Произведение всех элементов массива: {productArray}\n"+
                $"Сумма = {sumArray}\nСреднее арефметическое: {average}");
        }
        static public void DoTask5()
        {
            Console.Write("Введите цифру: ");
            string inputUser = Console.ReadLine();
            while (!(inputUser.ToLower().Equals("exit") || inputUser.ToLower().Equals("закрыть")))
            {
                if (!int.TryParse(inputUser, out int numberUser))
                {
                    throw new FormatException("Format of the inputing string is wrong. String: 197");
                }
                bool flag = true;
                char[,] matrixPicture = new char[5,3]{ { '#', '#', '#' }, { '#', '#', '#' }, { '#', '#', '#' }, { '#', '#', '#' }, { '#', '#', '#' } };
                switch (numberUser)
                {
                    case 0:
                        for (int i = 1; i < 4; i++)
                        {
                            matrixPicture[i, 1] = ' ';
                        }
                        break;
                    case 1:
                        for (int i = 0; i < 5; i++)
                        {
                            matrixPicture[i, 0] = ' ';
                            matrixPicture[i, 1] = ' ';
                        }
                        break;
                    case 2:
                        for (int i = 0; i < 2; i++)
                        {
                            matrixPicture[1, i] = ' ';
                            matrixPicture[3, 2 - i] = ' ';
                        }
                        break;
                    case 3:
                        for (int i = 0; i < 2; i++)
                        {
                            matrixPicture[1, i] = ' ';
                            matrixPicture[3, i] = ' ';
                        }
                        break;
                    case 4:
                        matrixPicture[4, 0] = ' ';
                        matrixPicture[4, 1] = ' ';
                        matrixPicture[0, 1] = ' ';

                        goto case 9;
                    case 5:
                        for (int i = 0; i < 2; i++)
                        {
                            matrixPicture[1, 2 - i] = ' ';
                            matrixPicture[3, i] = ' ';
                        }
                        break;
                    case 6:
                        matrixPicture[1, 2] = ' ';
                        goto case 8;
                    case 7:
                        for (int i = 1; i < 5; i++)
                        {
                            matrixPicture[i, 0] = ' ';
                            matrixPicture[i, 1] = ' ';
                        }
                        break;
                    case 8:
                        matrixPicture[1, 1] = ' ';
                        matrixPicture[3, 1] = ' ';
                        break;
                    case 9:
                        matrixPicture[3, 0] = ' ';
                        goto case 8;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("Данное число не является цифрой. Подожди 3 секунды.");
                        System.Threading.Thread.Sleep(3000);
                        Console.ResetColor();
                        Console.Clear();
                        flag = false;
                        break;
                }
                if (flag)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(matrixPicture[i, j]);
                        }
                        Console.WriteLine();
                    }
                    
                }
                Console.Write("Введите следующую цифру: ");
                inputUser = Console.ReadLine();
            }
        }
        
        static public double[] SolveQuadratEqution(double a, double b, double c, bool outputBool = false)
        {
            if (a == 0)
            {
                throw new Exception("a не должен быть равен нулю");
            }
            else
            {
                double[] solution = new double[2];
                if (b * b < 4 * a * c)
                {
                    throw new Exception("Решений у полинома 2-ой степени не cуществует");
                }
                else if (b * b > 4 * a * c)
                {
                    double dis = Math.Sqrt(b * b - 4 * a * c);
                    solution[0] = (-b + dis) / (2 * a);
                    solution[1] = (-b - dis) / (2 * a);
                    if (outputBool)
                    {
                        Console.WriteLine($"Discriminant = {dis} ");
                        Console.WriteLine($"x1 = {solution[0]} ");
                        Console.WriteLine($"x2 = {solution[1]} ");
                    }
                }
                else
                {
                    solution[0] = -b / (2 * a);
                    solution[1] = solution[0];
                    if (outputBool)
                    {
                        Console.WriteLine("Dsscriminant = 0");
                        Console.WriteLine($"x = {solution[0]} ");
                    }
                }
                return solution;
            }
        }
        static public double CalculateArray(ref double product, out double average, params double[] array)
         {
            product = 1; double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                product *= array[i];
                sum += array[i];
            }
            average = sum / array.Length;
            return sum;
         }
    }
}
