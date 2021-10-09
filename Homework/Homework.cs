using System;
using System.Collections.Generic;

namespace Homework
{
    class Homework
    {
        static void Main(string[] args)
        {
            //DoTask1();
            DoTask2();

            Console.ReadKey();
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
            Console.WriteLine("Определите связь графов между собой\n0 - отсутсвие связи\n1 - наличие связи");
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i; j < n - 1; j++)
                {
                    Console.Write($"Edge[{i}, {j + 1}] = ");
                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (consoleKey)
                    {
                        case ConsoleKey.D0:
                        case ConsoleKey.NumPad0:
                            break;
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            matrixG[i, j + 1] = true;
                            matrixG[j + 1, i] = matrixG[i, j + 1];
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуй снова: ");
                            j--;
                            break;
                    }
                }
            }
            Console.Write("Введите точку входа a (0 < a <= n): ");
            if (!uint.TryParse(Console.ReadLine(), out uint start) || start > n || start < 0)
            {
                throw new FormatException("Format of start is wrong. String: 99");
            }
            Console.Write("Введите точку выхода b (0 < b <= n b != a): ");
            if (!uint.TryParse(Console.ReadLine(), out uint end) || end > n || end < 0 || end == start)
            {
                throw new FormatException("Format of end is wrong. String: 104");
            }
            if (BFS(out List<uint> path, matrixG, start, end))
            {
                Console.WriteLine("Путь от А до B: ");
                foreach (var item in path)
                {
                    Console.Write(item + " ");
                }
            }
            else
            {
                Console.WriteLine("Достигнуть точки B из A невозможно....");
            }
        }
        static List<int> QSort(List<int> order, bool descendingSort = false)
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
        static bool BFS(out List<uint> path, bool[,] matrG, uint start, uint end)
        {
            List<uint> visited = new List<uint>() { start };
            List<uint> explore = new List<uint>() { start };
            path = new List<uint>();
            while (explore.Count != 0)
            {
                uint vertex = explore[0];
                explore.RemoveAt(0);
                path.Add(vertex);
                for (uint i = 0; i < matrG.GetLength(1); i++)
                {
                    if (!visited.Contains(i))
                    {
                        if (matrG[vertex, i])
                        {
                            explore.Add(i);
                            visited.Add(i);
                            if (i == end)
                            {
                                path.Add(end);
                                return true;
                            }
                        }
                    }
                }

            }
            path.Clear();
            return false;
        }
        static bool DFS(out List<uint> path, bool[,] matrG, uint start, uint end)
        {
            List<uint> visited = new List<uint>() { start };
            List<uint> explore = new List<uint>() { start };
            path = new List<uint>();
            while (explore.Count != 0)
            {
                uint vertex = explore[explore.Count - 1];
                explore.RemoveAt(explore.Count - 1);
                path.Add(vertex);
                for (uint i = 0; i < matrG.GetLength(1); i++)
                {
                    if (!visited.Contains(i))
                    {
                        if (matrG[vertex, i])
                        {
                            explore.Add(i);
                            visited.Add(i);
                            if (i == end)
                            {
                                path.Add(end);
                                return true;
                            }
                        }
                    }
                }

            }
            path.Clear();
            return false;
        }
    }
}
