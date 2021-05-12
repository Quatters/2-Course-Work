namespace DoubleLinkedList
{
    public class DoubleLinkedListNode<T>
    {
        public T Key { get; internal set; }
        public DoubleLinkedListNode<T> Next { get; internal set; }
        public DoubleLinkedListNode<T> Prev { get; internal set; }
        internal DoubleLinkedListNode(T key, DoubleLinkedListNode<T> next = null, DoubleLinkedListNode<T> prev = null)
        {
            Key = key;
            Next = next;
            Prev = prev;
        }        
    }
    public class DoubleLinkedList<T> : System.Collections.Generic.IEnumerable<DoubleLinkedListNode<T>>
    {
        public DoubleLinkedListNode<T> First { get; private set; } = null;
        public DoubleLinkedListNode<T> Last { get; private set; } = null;
        public int Size { get; private set; } = 0;
        public void AddFirst(T key)
        {
            if (First == null)
            {
                First = new DoubleLinkedListNode<T>(key);
                Last = First;
            }
            else
            {
                First.Prev = new DoubleLinkedListNode<T>(key, First);
                First = First.Prev;
            }
            Size++;
        }
        public void AddLast(T key)
        {
            if (First == null)
            {
                First = new DoubleLinkedListNode<T>(key);
                Last = First;
            }
            else
            {
                Last.Next = new DoubleLinkedListNode<T>(key, null, Last);
                Last = Last.Next;
            }
            Size++;
        }
        public bool Contains(T key)
        {
            if (First == null) return false;
            DoubleLinkedListNode<T> ptr = First;
            do
            {
                if (ptr.Key.Equals(key)) return true;
                ptr = ptr.Next;
            } while (ptr != null);
            return false;
        }
        public void Remove(T key)
        {
            DoubleLinkedListNode<T> node = GetNode(key);
            if (node == null) return;
            if (node.Prev == null) // первый
            {
                if (node.Next == null) // единственный
                {
                    First = null;
                }
                else
                {
                    First = First.Next;
                    First.Prev = null;
                }
            }
            else if (node.Next == null) // последний
            {
                Last = Last.Prev;
                Last.Next = null;
            }
            else
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }
            Size--;
        }
        public void Clear()
        {
            First = Last = null;
        }
        public DoubleLinkedListNode<T> GetNode(T key)
        {
            if (First == null) return null;
            DoubleLinkedListNode<T> ptr = First;
            do
            {
                if (ptr.Key.Equals(key)) return ptr;
                ptr = ptr.Next;
            } while (ptr != null);
            return null;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            DoubleLinkedListNode<T> ptr = First;
            while (ptr != null) {
                yield return ptr.Key;
                ptr = ptr.Next;
            }
        }
        System.Collections.Generic.IEnumerator<DoubleLinkedListNode<T>> System.Collections.Generic.IEnumerable<DoubleLinkedListNode<T>>.GetEnumerator()
        {
            DoubleLinkedListNode<T> ptr = First;
            while (ptr != null)
            {
                yield return ptr;
                ptr = ptr.Next;
            }
        }
    }
}
