using System;
using static Misc.Misc;
using DoubleLinkedList;

namespace RB_Tree
{
    public class RB_Tree<TKey, TValue> where TKey : IComparable 
    {
        internal class Node
        {
            internal enum Color { BLACK, RED };
            internal TKey key;
            internal Node left, right, parent;
            internal Color color;
            internal int count;
            internal DoubleLinkedList<TValue> list = new DoubleLinkedList<TValue>();
            internal Node(TKey key, TValue value)
            {
                this.key = key;
                color = Color.RED;
                left = null;
                right = null;
                parent = null;
                count = 1;
                list.AddLast(value);
            }
            internal Node Brother()
            {
                if (parent == null) return null;
                if (this == parent.left) return parent.right;
                return parent.left;
            }
            internal bool isOnLeft() { return this == parent.left; }
            internal bool hasRedChild()
            {
                return (left != null && left.color == Color.RED) ||
                    (right != null && right.color == Color.RED);
            }

            // следующие методы необходимы только для теста в консоли
            internal void Print()
            {
                if (this != null)
                {
                    Console.WriteLine($"{key} ({count})");
                }
            }
        }
        private Node root = null;
        private enum Direction { LEFT, RIGHT };
        private void Rotate(Node ptr, Direction dir)
        {
            if (dir == Direction.LEFT)
            {
                Node ptr_r = ptr.right;
                ptr.right = ptr_r.left;
                if (ptr.right != null) ptr.right.parent = ptr;
                ptr_r.parent = ptr.parent;
                if (ptr.parent == null) root = ptr_r;
                else if (ptr == ptr.parent.left) ptr.parent.left = ptr_r;
                else ptr.parent.right = ptr_r;
                ptr_r.left = ptr;
                ptr.parent = ptr_r;
            }
            else
            {
                Node ptr_l = ptr.left;
                ptr.left = ptr_l.right;
                if (ptr.left != null) ptr.left.parent = ptr;
                ptr_l.parent = ptr.parent;
                if (ptr.parent == null) root = ptr_l;
                else if (ptr == ptr.parent.left) ptr.parent.left = ptr_l;
                else ptr.parent.right = ptr_l;
                ptr_l.right = ptr;
                ptr.parent = ptr_l;
            }
        }
        private void BalanceAfterAddition(Node ptr)
        {
            Node parent = null;
            Node grand = null;

            while (ptr != root && ptr.color != Node.Color.BLACK &&
                ptr.parent.color == Node.Color.RED)
            {
                parent = ptr.parent;
                grand = ptr.parent.parent;
                if (parent == grand.left)
                {
                    Node uncle = grand.right;
                    if (uncle != null && uncle.color == Node.Color.RED)
                    {
                        grand.color = Node.Color.RED;
                        parent.color = Node.Color.BLACK;
                        uncle.color = Node.Color.BLACK;
                        ptr = grand;
                    }
                    else
                    {
                        if (ptr == parent.right)
                        {
                            Rotate(parent, Direction.LEFT);
                            ptr = parent;
                            parent = ptr.parent;
                        }
                        Rotate(grand, Direction.RIGHT);
                        Swap(ref parent.color, ref grand.color);
                        ptr = parent;
                    }
                }
                else
                {
                    Node uncle = grand.left;
                    if (uncle != null && uncle.color == Node.Color.RED)
                    {
                        grand.color = Node.Color.RED;
                        parent.color = Node.Color.BLACK;
                        uncle.color = Node.Color.BLACK;
                        ptr = grand;
                    }
                    else
                    {
                        if (ptr == parent.left)
                        {
                            Rotate(parent, Direction.RIGHT);
                            ptr = parent;
                            parent = ptr.parent;
                        }
                        Rotate(grand, Direction.LEFT);
                        Swap(ref parent.color, ref grand.color);
                        ptr = parent;
                    }
                }
            }
            root.color = Node.Color.BLACK;
        }
        private void Remove(Node v)
        {
            Node u = Replace(v);
            bool uvBlack = ((u == null || u.color == Node.Color.BLACK) &&
                (v.color == Node.Color.BLACK));
            Node parent = v.parent;
            if (u == null)
            {
                if (v == root) root = null;
                else
                {
                    if (uvBlack) FixDoubleBlack(v);
                    else
                    {
                        if (v.Brother() != null) v.Brother().color = Node.Color.RED;
                    }
                    if (v.isOnLeft()) parent.left = null;
                    else parent.right = null;
                }
                v = null; // delete v;
                return;
            }
            if (v.left == null || v.right == null)
            {
                if (v == root)
                {
                    v.key = u.key;
                    v.left = null;
                    v.right = null;
                    u = null; // delete u;
                }
                else
                {
                    if (v.isOnLeft()) parent.left = u;
                    else parent.right = u;
                    v = null; // delete v;
                    u.parent = parent;
                    if (uvBlack) FixDoubleBlack(u);
                    else u.color = Node.Color.BLACK;
                }
                return;
            }
            Swap(ref u.key, ref v.key);
            Remove(u);
        }
        private void FixDoubleBlack(Node x)
        {
            if (x == root) return;
            Node bro = x.Brother();
            Node parent = x.parent;
            if (bro == null) FixDoubleBlack(parent);
            else
            {
                if (bro.color == Node.Color.RED)
                {
                    parent.color = Node.Color.RED;
                    bro.color = Node.Color.BLACK;
                    if (bro.isOnLeft()) Rotate(parent, Direction.RIGHT);
                    else Rotate(parent, Direction.LEFT);
                    FixDoubleBlack(x);
                }
                else
                {
                    if (bro.hasRedChild())
                    {
                        if (bro.left != null && bro.left.color == Node.Color.RED)
                        {
                            if (bro.isOnLeft())
                            {
                                bro.left.color = bro.color;
                                bro.color = parent.color;
                                Rotate(parent, Direction.RIGHT);
                            }
                            else
                            {
                                bro.left.color = parent.color;
                                Rotate(bro, Direction.RIGHT);
                                Rotate(parent, Direction.LEFT);
                            }
                        }
                        else
                        {
                            if (bro.isOnLeft())
                            {
                                bro.right.color = parent.color;
                                Rotate(bro, Direction.LEFT);
                                Rotate(parent, Direction.RIGHT);
                            }
                            else
                            {
                                bro.right.color = bro.color;
                                bro.color = parent.color;
                                Rotate(parent, Direction.LEFT);
                            }
                        }
                        parent.color = Node.Color.BLACK;
                    }
                    else
                    {
                        bro.color = Node.Color.RED;
                        if (parent.color == Node.Color.BLACK) FixDoubleBlack(parent);
                        else parent.color = Node.Color.BLACK;
                    }
                }
            }
        }
        private Node Replace(Node x)
        {
            if (x.left != null && x.right != null) return Successor(x.left);
            if (x.left == null && x.right == null) return null;
            if (x.left != null) return x.left;
            else return x.right;
        }
        private Node Successor(Node x)
        {
            Node temp = x;
            while (temp.right != null) temp = temp.right;
            return temp;
        }
        public void Add(TKey key, TValue value)
        {
            if (root == null)
            {
                root = new Node(key, value);
                root.left = null;
                root.right = null;
                root.color = Node.Color.BLACK;
                return;
            }
            Node p = root;
            Node elem = new Node(key, value);
            bool added = false;
            while (!added)
            {
                if (elem.key.Equals(p.key))
                {
                    p.count++;
                    if (!p.list.Contains(value)) p.list.AddLast(value);
                    added = true;
                }
                else if (elem.key.CompareTo(p.key) == -1)
                {
                    if (p.left == null)
                    {
                        p.left = elem;
                        elem.parent = p;
                        elem.left = null;
                        elem.right = null;
                        BalanceAfterAddition(elem);
                        added = true;
                    }
                    p = p.left;
                }
                else
                {
                    if (p.right == null)
                    {
                        p.right = elem;
                        elem.parent = p;
                        elem.left = null;
                        elem.right = null;
                        BalanceAfterAddition(elem);
                        added = true;
                    }
                    p = p.right;
                }
            }
        }
        private Node Find(TKey key)
        {
            if (root == null) return null;
            Node ptr = root;
            while (ptr != null)
            {
                if (ptr.key.Equals(key)) return ptr;
                else if (ptr.key.CompareTo(key) == -1) ptr = ptr.right;
                else ptr = ptr.left;
            }
            return null;
        }
        public bool Contains(TKey key) => Find(key) == null;
        public void Remove(TKey key)
        {
            if (root == null) return;
            Node ptr = Find(key);
            if (ptr == null) return;
            if (ptr.count > 1)
            {
                ptr.count--;
                return;
            }
            Remove(ptr);
        }
        public void Clear() => root = null;
        public DoubleLinkedList<TValue> GetValues(TKey key)
        {
            Node node = Find(key);
            if (node != null) return node.list;
            else
            {
                DoubleLinkedList<TValue> list = new DoubleLinkedList<TValue>();
                return list;
            }
        }

        // следующие методы необходимы только для теста в консоли
        public void Draw() => Draw(root, 0);
        private void Draw(Node ptr, int n)
        {
            if (ptr != null)
            {
                Draw(ptr.right, n + 1);
                for (int i = 0; i < n; i++) Console.Write("   ");
                Console.Write(ptr.key);
                if (ptr.color == Node.Color.BLACK) Console.Write(" (B, " + ptr.count + ")");
                else Console.Write(" (R, " + ptr.count + ")");
                Console.WriteLine();
                Draw(ptr.left, n + 1);
            }
        }
        public void PrintInOrder() => PrintInOrder(root);
        private void PrintInOrder(Node ptr)
        {
            if (ptr == null) return;
            PrintInOrder(ptr.left);
            ptr.Print();
            PrintInOrder(ptr.right);
        }
    }
}
