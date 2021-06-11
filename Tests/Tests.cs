using System;
using System.Collections.Generic;

using RBTree;
using OAHashtable;
using DoubleLinkedList;
using BinaryTree;
using ChainHashtable;

namespace Tests
{
    class Tests
    {
        static void OA_Hashtbale_test()
        {
            OAHashtable<string, string> table = new OAHashtable<string, string>();
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine($"Хеш-таблица: ({table.Fullness})");
                foreach (var pair in table) Console.WriteLine($"{pair.Key}, {pair.Value}");
                Console.WriteLine();
                Console.WriteLine("1) Добавить");
                Console.WriteLine("2) Удалить");
                Console.WriteLine("0) Выйти");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.Write("Ключ: ");
                        string key = Console.ReadLine();
                        Console.Write("Значение: ");
                        string value = Console.ReadLine();
                        table.Add(key, value);
                        Console.Clear();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.Write("Ключ: ");
                        string del = Console.ReadLine();
                        table.Delete(del);
                        Console.Clear();
                        break;
                    case ConsoleKey.D0:
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }

        }
        static void Main(string[] args)
        {
            OAHashtable<int, int> table = new OAHashtable<int, int>();
            table.Add(1, 1);
            table.Add(10, 10);
        }
    }
}
