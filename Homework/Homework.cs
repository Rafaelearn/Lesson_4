using System;
using System.Collections.Generic;

namespace Homework
{
    class Homework
    {
        static void Main(string[] args)
        {
            DoTask1();
            DoTask2();
            
            Console.ReadKey();
        }
        static double DFS(bool[,] matrG, uint start, uint end)
        {
            string path = start.ToString();
            int n = matrG.GetLength(1);
            bool[] visited = new bool[n], explore = new bool[n];
            visited[start] = explore[start] = true;
            for (int i = 0; i < n; i++)
            {
                if (explore[i])
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (!visited[j])
                        {
                            if (matrG[i, j])
                            {
                                visited[j] = true;
                                explore[j] = true;
                            }
                        }

                    }
                    explore[i] = false;
                }
            }
            while (true)
            {

            }
        }
        static void DoTask1()
        {
            Console.Write("Введите количесвто членов последоватеьности целых чисел n: ");
            if (!uint.TryParse(Console.ReadLine(), out uint n) || n < 1)
            {
                throw new FormatException("Wrong format n. String: 112");
            }
            List<int> order = new List<int>();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"A[{i}] = ");
                if (!int.TryParse(Console.ReadLine(), out int itemAdd))
                {
                    Console.WriteLine("Неправильный формат введенных данных");
                    i--;
                }
                else
                {
                    order.Add(itemAdd);
                }
            }
            Console.WriteLine("Полученная последовательность: ");
            foreach (var item in order)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n1) Сортировка по возрастанию.\n2) Сортировка по убыванию.\nНажми цифру: ");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            switch (consoleKey)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    order = QSort(order);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    order = QSort(order, true);
                    break;
                default:
                    Console.WriteLine("К сожалению, такой выбор невозможен!");
                    break;
            }
            Console.WriteLine("\nПоследовательность после сортировки: ");
            foreach (var item in order)
            {
                Console.Write(item + " ");
            }
        } 
        static void DoTask2()
        {
            Console.Write("Введите количество вершин графа n: ");
            if (!uint.TryParse(Console.ReadLine(), out uint n))
            {
                throw new FormatException("Format of n is wrong. String: 12");
            }
            bool[,] matrixG = new bool[n, n];
            Console.WriteLine("Определите связь графов между собой\n0 - отсутсвие связи\n1 - наличие связи)");
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i; j < n - 1; j++)
                {

                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (consoleKey)
                    {
                        case ConsoleKey.D0:
                        case ConsoleKey.NumPad0:
                            matrixG[i, j + 1] = true;
                            matrixG[j + 1, i] = matrixG[i, j + 1];
                            break;
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуй снова: ");
                            j--;
                            break;
                    }
                }
            }
            Console.WriteLine("Введите точку входа a (0 < a <= n): ");
            if (!uint.TryParse(Console.ReadLine(), out uint start) || start > n || start < 0)
            {
                throw new FormatException("Format of start is wrong. String: 39");
            }
            Console.WriteLine("Введите точку выхода b (0 < b <= n b != a): ");
            if (!uint.TryParse(Console.ReadLine(), out uint end) || end > n || end < 0 || end == start)
            {
                throw new FormatException("Format of end is wrong. String: 44");
            }
        }
        static List<int> QSort (List<int> order, bool descendingSort = false)
        {
            if (order.Count <= 1)
            {
                return order;
            }
            List<int> right = new List<int>();
            List<int> center = new List<int>();
            List<int> left = new List<int>();
            for (int i = 0; i < order.Count; i++)
            {
                if (!descendingSort)
                {
                    if (order[i] < order[0])
                    {
                        left.Add(order[i]);
                    }
                    else if (order[i] > order[0])
                    {
                        right.Add(order[i]);
                    }
                    else
                    {
                        center.Add(order[i]);
                    }
                }
                else
                {
                    if (order[i] > order[0])
                    {
                        left.Add(order[i]);
                    }
                    else if (order[i] < order[0])
                    {
                        right.Add(order[i]);
                    }
                    else
                    {
                        center.Add(order[i]);
                    }
                }
               
            }
            left = QSort(left, descendingSort);
            left.AddRange(center);
            left.AddRange(QSort(right, descendingSort));

            return left;
        }
    }
}
