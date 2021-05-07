using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoubleLinkedList;

namespace ChainHashtable
{
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; }
        public TValue Value { get; }
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

    }

    public class ChainHashtable<TKey, TValue>
    {               
        private DoubleLinkedList<Pair<TKey, TValue>>[] hashtable;
        int size;        

        public ChainHashtable(int size = 10)
        {
            this.size = size;
            hashtable = new DoubleLinkedList<Pair<TKey, TValue>>[size];
        }


        //Хэш-функция
        private int Hash(TKey key)
        {
            string str_key = key.ToString();
            //обработка строки
            int int_key = 0;
            char simbol;
            for(int i = 0; i< str_key.Length; i++)
            {
                simbol = str_key[i];
                int_key = int_key + simbol;
            }

            //считаем хэш-фукнцию
            int rem = 0;
            int di = int_key;
            do
            {
                rem = rem + (di % 10);
                di = di / 10;
            } while (di != 0);
            return rem % size;            
        }

        public bool Contains(TKey key) => FindElem(key) != -1;
        public int FindElem(Pair<TKey, TValue> pair)
        {
            int index = Hash(pair.Key);
            return hashtable[index].Contains(pair) == false ? -1 : index;
        }

        public int FindElem(TKey key)
        {            
            int index = Hash(key);
            if (hashtable[index] != null)
            {
                foreach (var pair in hashtable[index])
                {
                    if (pair.Key.Key.Equals(key))
                    {
                        return index;
                    }
                }
            }            
            return -1;
        }

        public void Clear()
        {
            hashtable = new DoubleLinkedList<Pair<TKey, TValue>>[size];
        }

        //добавление элемента
        public void AddElem(Pair<TKey, TValue> pair)
        {
            if (Contains(pair.Key)) return;                    
            int index = Hash(pair.Key);
            if(hashtable[index] == null || hashtable[index].Contains(pair) == false)
            {
                if (hashtable[index] == null)
                {
                    hashtable[index] = new DoubleLinkedList<Pair<TKey, TValue>>();
                }
                hashtable[index].AddFirst(pair);            
            }            
        }

        public void AddElem(TKey key, TValue value)
        {
            if (Contains(key)) return;
            Pair<TKey, TValue> pair = new Pair<TKey, TValue>(key, value);            
            int index = Hash(pair.Key);
            if (hashtable[index] == null || hashtable[index].Contains(pair) == false)
            {
                if (hashtable[index] == null)
                {
                    hashtable[index] = new DoubleLinkedList<Pair<TKey, TValue>>();
                }
                hashtable[index].AddFirst(pair);                
            }            
        }               

        //удаление элемента
        public void DeleteElem(Pair<TKey, TValue> pair)
        {
            int index = FindElem(pair);
            if (index != -1)
            {
                hashtable[index].Remove(pair);
            }
        }

        public void DeleteElem(TKey key)
        {            
            int index = FindElem(key);
            if (index != -1)
            {                
                foreach (var pair in hashtable[index])
                {
                    if (pair.Key.Key.Equals(key))
                    {
                        hashtable[index].Remove(pair.Key);                        
                        break;
                    }
                }                              
            }
        }        

        //вывод в консоль для отладки
        public void Print()
        {
            for (int i=0; i<size; i++)
            {
                Console.Write($"{i} ");
                if (hashtable[i] != null)
                {
                    foreach (var pair in hashtable[i])
                    {
                        Console.Write($"{pair.Key.Key} {pair.Key.Value}");
                    }
                }                
                Console.WriteLine();
            }
        }
    }
}
