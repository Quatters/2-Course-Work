﻿using System;
using System.Collections.Generic;

using RBTree;
using OAHashtable;
using DoubleLinkedList;
using ChainHashtable;
using BinaryTree;

namespace Tests
{
    class Tests
    {
        static void RB_Tree_test()
        {
            RBTree<int, int> tree = new RBTree<int, int>();
            bool quit = false;
            while (!quit)
            {
                tree.Draw();
                Console.WriteLine();
                Console.WriteLine("1) Добавить");
                Console.WriteLine("2) Удалить");
                Console.WriteLine("3) Заполнить случайно");
                Console.WriteLine("4) Очистить");
                Console.WriteLine("7) Симметричный обход");
                Console.WriteLine("0) Выход");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine();
                        Console.Write("Элемент: ");
                        string input = Console.ReadLine();
                        tree.Add(int.Parse(input), 0);
                        Console.Clear();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine();
                        Console.Write("Элемент: ");
                        string del = Console.ReadLine();
                        tree.Remove(int.Parse(del));
                        Console.Clear();
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine();
                        Console.Write("Количество элементов: ");
                        int quantity = int.Parse(Console.ReadLine());
                        tree.Clear();
                        for (int i = 0; i < quantity; i++)
                        {
                            tree.Add((i + 1), 0);
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        tree.Clear();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        tree.PrintInOrder();
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case ConsoleKey.D0:
                        quit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Не реализовано");
                        Console.WriteLine();
                        break;
                }
            }
        }
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
            BinaryTree<double, double> tree = new BinaryTree<double, double>();
            tree.Add(20, 1);
            tree.Add(15, 1);
            tree.Add(10, 1);
            tree.Add(11, 1);
            tree.Add(10.5, 1);
            tree.Add(14, 1);
            tree.Add(13, 1);
            tree.Add(12, 1);
            tree.Add(13.5, 1);
            foreach (var node in tree)
            {
                Console.WriteLine(node.Key);
            }
            Console.WriteLine();
            tree.Remove(15, 1);
            foreach (var node in tree)
            {
                Console.WriteLine(node.Key);
            }
        }
    }
}
