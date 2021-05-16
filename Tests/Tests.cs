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
            BinaryTree<int, int> tree = new BinaryTree<int, int>();
            RBTree<int, int> rbtree = new RBTree<int, int>();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            int n1, n2;

            

            for (int i = 0; i < 10; i++)
            {
                n1 = new Random().Next(0, 100);
                n2 = new Random().Next(0, 100);
                rbtree.Add(n1, n2);
                tree.Add(n1, n2);
                list1.Add(n1);
                list2.Add(n2);
            }
            Console.WriteLine(tree.Root.Key);
            Console.WriteLine();
            foreach(var item in tree)
            {
                Console.WriteLine(item.Key);
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                //rbtree.Remove(list1[i], list2[i]);
                tree.Remove(list1[i], list2[i]);
            }
            foreach (var item in tree)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
