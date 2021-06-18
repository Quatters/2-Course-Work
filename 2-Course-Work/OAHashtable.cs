// для защиты приготовить таблицу с ASCII-кодами
namespace OAHashtable
{
    public class Pair<TKey, TValue>
    {
        public TKey Key { get; protected internal set; }
        public TValue Value { get; set; }
        protected internal bool Deleted { get; set; }
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Deleted = false;
        }
    }
    public class OAHashtable<TKey, TValue> : System.Collections.Generic.IEnumerable<Pair<TKey, TValue>>
    {
        private const double MAX_FULLNESS = 0.6;
        private const double MIN_FULLNESS = 0.15;
        private const int DEFAULT_SIZE = 8;
        public int Comparisons { get; set; } = 0;
        private Pair<TKey, TValue>[] hashtable = new Pair<TKey, TValue>[DEFAULT_SIZE];
		public double Fullness => (double)Stores / CurrentSize;
		public int Stores { get; private set; } = 0;
		public int CurrentSize { get; private set; } = DEFAULT_SIZE;
		public void Clear()
        {
            CurrentSize = DEFAULT_SIZE;
            Stores = 0;
            hashtable = new Pair<TKey, TValue>[DEFAULT_SIZE];    
        }
        protected internal int GetIndex(TKey key)
        {
            int i = 0;
            int hash = Hash(key, i);
            while (hashtable[hash] != null && !hashtable[hash].Key.Equals(key))
            {
                i++;
                hash = Hash(key, i);
            }
            return hashtable[hash] != null && !hashtable[hash].Deleted ? hash : -1;
        }
        protected internal int GetIndexWithComparisons(TKey key)
        {
            int i = 0;
            int hash = Hash(key, i);
            while (hashtable[hash] != null && !hashtable[hash].Key.Equals(key))
            {
                i++;
                hash = Hash(key, i);
            }
            Comparisons = i + 1;
            return hashtable[hash] != null && !hashtable[hash].Deleted ? hash : -1;
        }
        public bool Contains(TKey key) => GetIndex(key) != -1;
        public TValue GetValue(TKey key)
        {
            int index = GetIndex(key);
            return index != -1 ? hashtable[index].Value : default;
        }
        public TValue GetValueWithComparisons(TKey key)
        {
            int index = GetIndexWithComparisons(key);
            return index != -1 ? hashtable[index].Value : default;
        }
        public Pair<TKey, TValue> GetPair(TKey key)
        {
            int index = GetIndex(key);
            return index != -1 ? hashtable[index] : null;
        }
        public void Delete(Pair<TKey, TValue> pair)
        {
            int index = GetIndex(pair.Key);
            if (index != -1)
            {
                hashtable[index].Deleted = true;
                Stores--;
                if (Fullness < MIN_FULLNESS) Reduce();
            }
        }
        public void Delete(TKey key)
        {
            int index = GetIndex(key);
            if (index != -1)
            {
                hashtable[index].Deleted = true;
                Stores--;
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
                Stores++;
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
                Stores++;
            }            
        }
        private int KeyToInt(TKey key)
        {
            string str = key.ToString();
            int value = 0;
            foreach (var ch in str) value += ch;
            return value;
        }
        protected internal int Hash(TKey key, int i) => (H1(key) + i * H2(key)) % CurrentSize;
        protected internal int H1(TKey key)
        {
            int intkey = KeyToInt(key);
            int hash = 0;
            while (intkey != 0)
            {
                hash += intkey % 10;
                intkey /= 10;
            }
            return hash % CurrentSize;
        }
        protected internal int H2(TKey key)
        {
            int hash = KeyToInt(key);
            hash %= CurrentSize;
            if (hash % 2 == 0)
            {
                if (hash + 1 < CurrentSize) hash++;
                else hash--;
            }
            return hash;
        }
        private void Expand()
        {
            var oldtable = hashtable;
            Stores = 0;
            CurrentSize *= 2;
            hashtable = new Pair<TKey, TValue>[CurrentSize];
            foreach (var item in oldtable) if (item != null) Add(item);
        }
        private void Reduce()
        {
            if (CurrentSize <= DEFAULT_SIZE) return;
            var oldtable = hashtable;
            Stores = 0;
            CurrentSize /= 2;
            hashtable = new Pair<TKey, TValue>[CurrentSize];
            foreach (var item in oldtable) if (item != null && !item.Deleted) Add(item);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            int i = 0;
            while (i < CurrentSize && hashtable[i] == null) i++;
            if (hashtable[i] != null && !hashtable[i].Deleted) yield return hashtable[i];
        }
        System.Collections.Generic.IEnumerator<Pair<TKey, TValue>> System.Collections.Generic.IEnumerable<Pair<TKey, TValue>>.GetEnumerator()
        {
            int i = 0;
            while (i < CurrentSize)
            {
                while (i + 1 < CurrentSize && hashtable[i] == null) i++;
                if (hashtable[i] != null && !hashtable[i].Deleted) yield return hashtable[i];
                i++;
            }
        }
    }
}
