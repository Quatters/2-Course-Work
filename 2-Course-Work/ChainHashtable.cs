using DoubleLinkedList;

namespace ChainHashtable
{
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; protected internal set; }
        public TValue Value { get; protected internal set; }
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    public class ChainHashtable<TKey, TValue> : System.Collections.Generic.IEnumerable<Pair<TKey, TValue>>
    {               
        private DoubleLinkedList<Pair<TKey, TValue>>[] hashtable;
        public int Size { get; private set; }

        public ChainHashtable(int size = 10)
        {
            this.Size = size;
            hashtable = new DoubleLinkedList<Pair<TKey, TValue>>[size];
        }
        protected internal int Hash(TKey key)
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
            return rem % Size;            
        }
        public bool Contains(TKey key) => FindElem(key) != -1;
        private int FindElem(Pair<TKey, TValue> pair)
        {
            int index = Hash(pair.Key);
            return hashtable[index].Contains(pair) == false ? -1 : index;
        }
        public TValue GetValue(TKey key)
        {
            int index = FindElem(key);
            if ( index != -1)
            {
                foreach (var pair in hashtable[index])
                {
                    if (pair.Key.Key.Equals(key))
                    {
                        return pair.Key.Value;
                    }
                }
            }
            return default;
        }
        public Pair<TKey, TValue> GetPair(TKey key)
        {
            int index = FindElem(key);
            if (index == -1) return null;
            foreach (var node in hashtable[index])
            {
                if (node.Key.Key.Equals(key)) return node.Key;
            }
            return null;
        } 
        private int FindElem(TKey key)
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
        public void Clear() => hashtable = new DoubleLinkedList<Pair<TKey, TValue>>[Size];
        public void Add(Pair<TKey, TValue> pair)
        {
            if (Contains(pair.Key)) return;                    
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
        public void Add(TKey key, TValue value)
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
        public void Delete(Pair<TKey, TValue> pair)
        {
            int index = FindElem(pair);
            if (index != -1)
            {
                hashtable[index].Remove(pair);
            }
        }
        public void Delete(TKey key)
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
        System.Collections.Generic.IEnumerator<Pair<TKey, TValue>> System.Collections.Generic.IEnumerable<Pair<TKey, TValue>>.GetEnumerator()
        {
            foreach (var item in hashtable)
            {
                if (item != null)
                {
                    foreach (var node in item)
                    {
                        yield return node.Key;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            foreach (var item in hashtable)
            {
                if (item != null)
                {
                    foreach (var node in item)
                    {
                        yield return node.Key;
                    }
                }
            }
        }
    }
}
