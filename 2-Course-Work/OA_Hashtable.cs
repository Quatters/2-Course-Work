using System.Collections;
using System.Collections.Generic;

namespace OA_Hashtable
{
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; }
        public TValue Value { get; }
        public bool Deleted { get; internal set; }
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Deleted = false;
        }
    }
    public class OA_Hashtable<TKey, TValue> : IEnumerable<Pair<TKey, TValue>>
    {
        private static double MAX_FULLNESS = 0.6;
        private static double MIN_FULLNESS = 0.15;
        private static int DEFAULT_SIZE = 8;
        private Pair<TKey, TValue>[] hashtable = new Pair<TKey, TValue>[DEFAULT_SIZE];
        private int size = DEFAULT_SIZE;
        private int stored = 0;
        public double Fullness => (double)stored / size;
        private int GetIndex(TKey key)
        {
            int i = 0;
            int hash = Hash(key, i);
            while (hashtable[hash] != null && !hashtable[hash].Key.Equals(key))
            {
                i++;
                hash = Hash(key, i);
            }
            return hashtable[hash] != null ? hash : -1;
        }
        public TValue GetValue(TKey key)
        {
            int index = GetIndex(key);
            return index != -1 ? hashtable[index].Value : default;
        }
        public void Delete(Pair<TKey, TValue> pair)
        {
            int index = GetIndex(pair.Key);
            if (index != -1)
            {
                hashtable[index].Deleted = true;
                stored--;
                if (Fullness < MIN_FULLNESS) Reduce();
            }
        }
        public void Delete(TKey key)
        {
            int index = GetIndex(key);
            if (index != -1)
            {
                hashtable[index].Deleted = true;
                stored--;
                if (Fullness < MIN_FULLNESS) Reduce();
            }

        }
        public void Add(TKey key, TValue value)
        {
            if (Fullness > MAX_FULLNESS) Expand();
            int i = 0;
            int hash = Hash(key, i);
            while (hashtable[hash] != null && !hashtable[hash].Deleted && !hashtable[hash].Key.Equals(key))
            {
                i++;
                hash = Hash(key, i);
            }
            if (hashtable[hash] == null || hashtable[hash].Deleted || !hashtable[hash].Key.Equals(key))
            {
                hashtable[hash] = new Pair<TKey, TValue>(key, value);
                stored++;
            }            
        }
        public void Add(Pair<TKey, TValue> pair)
        {
            if (Fullness > MAX_FULLNESS) Expand();
            int i = 0;
            int hash = Hash(pair.Key, i);
            while (hashtable[hash] != null && !hashtable[hash].Deleted && !hashtable[hash].Key.Equals(pair.Key))
            {
                i++;
                hash = Hash(pair.Key, i);
            }
            if (hashtable[hash] == null || hashtable[hash].Deleted || !hashtable[hash].Key.Equals(pair.Key))
            {
                hashtable[hash] = pair;
                stored++;
            }            
        }
        private int KeyToInt(TKey key)
        {
            string str = key.ToString();
            int value = 0;
            foreach (var ch in str) value += ch;
            return value;
        }
        private int Hash(TKey key, int i) => (H1(key) + i * H2(key)) % size;
        private int H1(TKey key)
        {
            int intkey = KeyToInt(key);
            int hash = 0;
            while (intkey != 0)
            {
                hash += intkey % 10;
                intkey /= 10;
            }
            return hash % size;
        }
        private int H2(TKey key)
        {
            int hash = KeyToInt(key);
            hash %= size;
            if (hash % 2 == 0)
            {
                if (hash + 1 < size) hash++;
                else hash--;
            }
            return hash;
        }
        private void Expand()
        {
            var oldtable = hashtable;
            stored = 0;
            size *= 2;
            hashtable = new Pair<TKey, TValue>[size];
            foreach (var item in oldtable) if (item != null) Add(item);
        }
        private void Reduce()
        {
            if (size <= DEFAULT_SIZE) return;
            var oldtable = hashtable;
            stored = 0;
            size /= 2;
            hashtable = new Pair<TKey, TValue>[size];
            foreach (var item in oldtable) if (item != null && !item.Deleted) Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            int i = 0;
            while (i < size && hashtable[i] == null) i++;
            if (hashtable[i] != null && !hashtable[i].Deleted) yield return hashtable[i];
        }
        IEnumerator<Pair<TKey, TValue>> IEnumerable<Pair<TKey, TValue>>.GetEnumerator()
        {
            int i = 0;
            while (i < size)
            {
                while (i + 1 < size && hashtable[i] == null) i++;
                if (hashtable[i] != null && !hashtable[i].Deleted) yield return hashtable[i];
                i++;
            }
        }
    }
}
