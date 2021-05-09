using System;
using static Misc.Misc;
using DoubleLinkedList;

namespace RBTree
{
    public class RBTreeNode<TKey, TValue>
    {
        internal enum Color { BLACK, RED };
        internal TKey key;
        public TKey Key => key;
        internal RBTreeNode<TKey, TValue> left, right, parent;
        internal Color color;
        internal DoubleLinkedList<TValue> list = new DoubleLinkedList<TValue>();
        public DoubleLinkedList<TValue> Value => list;
        public RBTreeNode(TKey key, TValue value)
        {
            this.key = key;
            color = Color.RED;
            left = null;
            right = null;
            parent = null;
            list.AddLast(value);
        }
        internal RBTreeNode<TKey, TValue> Brother()
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
                Console.WriteLine($"{key} ({list.Size})");
            }
        }
    }
    public class RBTree<TKey, TValue> : System.Collections.Generic.IEnumerable<RBTreeNode<TKey, TValue>> where TKey : IComparable 
    {
        public RBTreeNode<TKey, TValue> First
        {
            get
            {
                if (root == null) return null;
                RBTreeNode<TKey, TValue> node = root;
                while (node.left != null) node = node.left;
                return node;
            }
        }
        public RBTreeNode<TKey, TValue> Last
        {
            get
            {
                if (root == null) return null;
                RBTreeNode<TKey, TValue> node = root;
                while (node.right != null) node = node.right;
                return node;
            }
        }
        private RBTreeNode<TKey, TValue> root = null;
        private enum Direction { LEFT, RIGHT };
        private void Rotate(RBTreeNode<TKey, TValue> ptr, Direction dir)
        {
            if (dir == Direction.LEFT)
            {
                RBTreeNode<TKey, TValue> ptr_r = ptr.right;
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
                RBTreeNode<TKey, TValue> ptr_l = ptr.left;
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
        private void BalanceAfterAddition(RBTreeNode<TKey, TValue> ptr)
        {
            RBTreeNode<TKey, TValue> parent = null;
            RBTreeNode<TKey, TValue> grand = null;

            while (ptr != root && ptr.color != RBTreeNode<TKey, TValue>.Color.BLACK &&
                ptr.parent.color == RBTreeNode<TKey, TValue>.Color.RED)
            {
                parent = ptr.parent;
                grand = ptr.parent.parent;
                if (parent == grand.left)
                {
                    RBTreeNode<TKey, TValue> uncle = grand.right;
                    if (uncle != null && uncle.color == RBTreeNode<TKey, TValue>.Color.RED)
                    {
                        grand.color = RBTreeNode<TKey, TValue>.Color.RED;
                        parent.color = RBTreeNode<TKey, TValue>.Color.BLACK;
                        uncle.color = RBTreeNode<TKey, TValue>.Color.BLACK;
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
                    RBTreeNode<TKey, TValue> uncle = grand.left;
                    if (uncle != null && uncle.color == RBTreeNode<TKey, TValue>.Color.RED)
                    {
                        grand.color = RBTreeNode<TKey, TValue>.Color.RED;
                        parent.color = RBTreeNode<TKey, TValue>.Color.BLACK;
                        uncle.color = RBTreeNode<TKey, TValue>.Color.BLACK;
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
            root.color = RBTreeNode<TKey, TValue>.Color.BLACK;
        }
        private void Remove(RBTreeNode<TKey, TValue> v)
        {
            RBTreeNode<TKey, TValue> u = Replace(v);
            bool uvBlack = ((u == null || u.color == RBTreeNode<TKey, TValue>.Color.BLACK) &&
                (v.color == RBTreeNode<TKey, TValue>.Color.BLACK));
            RBTreeNode<TKey, TValue> parent = v.parent;
            if (u == null)
            {
                if (v == root) root = null;
                else
                {
                    if (uvBlack) FixDoubleBlack(v);
                    else
                    {
                        if (v.Brother() != null) v.Brother().color = RBTreeNode<TKey, TValue>.Color.RED;
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
                    else u.color = RBTreeNode<TKey, TValue>.Color.BLACK;
                }
                return;
            }
            Swap(ref u.key, ref v.key);
            Swap(ref u.list, ref v.list);
            Remove(u);
        }
        private void FixDoubleBlack(RBTreeNode<TKey, TValue> x)
        {
            if (x == root) return;
            RBTreeNode<TKey, TValue> bro = x.Brother();
            RBTreeNode<TKey, TValue> parent = x.parent;
            if (bro == null) FixDoubleBlack(parent);
            else
            {
                if (bro.color == RBTreeNode<TKey, TValue>.Color.RED)
                {
                    parent.color = RBTreeNode<TKey, TValue>.Color.RED;
                    bro.color = RBTreeNode<TKey, TValue>.Color.BLACK;
                    if (bro.isOnLeft()) Rotate(parent, Direction.RIGHT);
                    else Rotate(parent, Direction.LEFT);
                    FixDoubleBlack(x);
                }
                else
                {
                    if (bro.hasRedChild())
                    {
                        if (bro.left != null && bro.left.color == RBTreeNode<TKey, TValue>.Color.RED)
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
                        parent.color = RBTreeNode<TKey, TValue>.Color.BLACK;
                    }
                    else
                    {
                        bro.color = RBTreeNode<TKey, TValue>.Color.RED;
                        if (parent.color == RBTreeNode<TKey, TValue>.Color.BLACK) FixDoubleBlack(parent);
                        else parent.color = RBTreeNode<TKey, TValue>.Color.BLACK;
                    }
                }
            }
        }
        private RBTreeNode<TKey, TValue> Replace(RBTreeNode<TKey, TValue> x)
        {
            if (x.left != null && x.right != null) return Successor(x.left);
            if (x.left == null && x.right == null) return null;
            if (x.left != null) return x.left;
            else return x.right;
        }
        private RBTreeNode<TKey, TValue> Successor(RBTreeNode<TKey, TValue> x)
        {
            RBTreeNode<TKey, TValue> temp = x;
            while (temp.right != null) temp = temp.right;
            return temp;
        }
        public void Add(TKey key, TValue value)
        {
            if (root == null)
            {
                root = new RBTreeNode<TKey, TValue>(key, value);
                root.left = null;
                root.right = null;
                root.color = RBTreeNode<TKey, TValue>.Color.BLACK;
                return;
            }
            RBTreeNode<TKey, TValue> p = root;
            RBTreeNode<TKey, TValue> elem = new RBTreeNode<TKey, TValue>(key, value);
            bool added = false;
            while (!added)
            {
                if (elem.key.Equals(p.key))
                {
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
        private RBTreeNode<TKey, TValue> Find(TKey key)
        {
            if (root == null) return null;
            RBTreeNode<TKey, TValue> ptr = root;
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
            RBTreeNode<TKey, TValue> ptr = Find(key);
            if (ptr == null) return;
            Remove(ptr);
        }
        public void Clear() => root = null;
        public DoubleLinkedList<TValue> GetValues(TKey key)
        {
            RBTreeNode<TKey, TValue> node = Find(key);
            if (node != null) return node.list;
            else
            {
                DoubleLinkedList<TValue> list = new DoubleLinkedList<TValue>();
                return list;
            }
        }

        // следующие методы необходимы только для теста в консоли
        public void Draw() => Draw(root, 0);
        private void Draw(RBTreeNode<TKey, TValue> ptr, int n)
        {
            if (ptr != null)
            {
                Draw(ptr.right, n + 1);
                for (int i = 0; i < n; i++) Console.Write("   ");
                Console.Write(ptr.key);
                if (ptr.color == RBTreeNode<TKey, TValue>.Color.BLACK) Console.Write(" (B)");
                else Console.Write(" (R)");
                Console.WriteLine();
                Draw(ptr.left, n + 1);
            }
        }
        public void PrintInOrder() => PrintInOrder(root);
        private void PrintInOrder(RBTreeNode<TKey, TValue> ptr)
        {
            if (ptr == null) return;
            PrintInOrder(ptr.left);
            ptr.Print();
            PrintInOrder(ptr.right);
        }

        System.Collections.Generic.IEnumerator<RBTreeNode<TKey, TValue>> System.Collections.Generic.IEnumerable<RBTreeNode<TKey, TValue>>.GetEnumerator()
        {
            if (root == null) yield break;
            DoubleLinkedList<RBTreeNode<TKey, TValue>> stack =
                new DoubleLinkedList<RBTreeNode<TKey, TValue>>();
            RBTreeNode<TKey, TValue> node = root;
            while (node != null || stack.Size > 0)
            {
                while (node != null)
                {
                    stack.AddFirst(node);
                    node = node.left;
                }
                node = stack.First.Key;
                yield return node;
                node = node.right;
                stack.Remove(stack.First.Key);                
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (root == null) yield break;
            DoubleLinkedList<RBTreeNode<TKey, TValue>> stack =
                new DoubleLinkedList<RBTreeNode<TKey, TValue>>();
            RBTreeNode<TKey, TValue> node = root;
            while (node != null || stack.Size > 0)
            {
                while (node != null)
                {
                    stack.AddFirst(node);
                    node = node.left;
                }
                node = stack.First.Key;
                yield return node.Key;
                node = node.right;
                stack.Remove(stack.First.Key);
            }
        }
    }
}
