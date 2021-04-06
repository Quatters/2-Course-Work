using System;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T>
    {
        private Node head = null;
        private Node tail = null;
        public int Size { get; private set; } = 0;
        public class Node
        {
            public Node next;
            public Node prev;
            public T key;
            public Node(T key, Node next = null, Node prev = null)
            {
                this.key = key;
                this.next = next;
                this.prev = prev;
            }
        }
        public void AddFirst(T key)
        {
            if (head == null)
            {
                head = new Node(key);
                tail = head;
            }
            else
            {
                head.prev = new Node(key, head);
                head = head.prev;
            }
            Size++;
        }
        public void AddLast(T key)
        {
            if (head == null)
            {
                head = new Node(key);
                tail = head;
            }
            else
            {
                tail.next = new Node(key, null, tail);
                tail = tail.next;
            }
            Size++;
        }
        public bool Contains(T key)
        {
            if (head == null) return false;
            Node ptr = head;
            do
            {
                if (ptr.key.Equals(key)) return true;
                ptr = ptr.next;
            } while (ptr != null);
            return false;
        }
        public void Remove(T key)
        {
            Node node = GetNode(key);
            if (node == null) return;
            if (node.prev == null) // первый
            {
                if (node.next == null) // единственный
                {
                    head = null;
                }
                else
                {
                    head = head.next;
                    head.prev = null;
                }
            }
            else if (node.next == null) // последний
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
            Size--;
        }
        public void Clear()
        {
            head = tail = null;
        }
        private Node GetNode(T key)
        {
            if (head == null) return null;
            Node ptr = head;
            do
            {
                if (ptr.key.Equals(key)) return ptr;
                ptr = ptr.next;
            } while (ptr != null);
            return null;
        }
        
        // следующие методы необходимы только для теста в консоли
        public void Print()
        {
            if (head == null) return;
            if (head == tail)
            {
                Console.Write($"{head.key} ");
                return;
            }
            Node ptr = head;
            do
            {
                Console.Write($"{ptr.key} ");
                ptr = ptr.next;
            } while (ptr != null);
        }
    }
}
