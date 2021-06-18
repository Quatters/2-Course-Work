using System;
using DoubleLinkedList;

namespace BinaryTree
{
    public class BinaryTreeNode<TKey, TValue>
    {
        protected internal BinaryTreeNode<TKey, TValue> parent, left, right;
        protected internal TKey key;
        protected internal DoubleLinkedList<TValue> value;
        public TKey Key => key;
        public DoubleLinkedList<TValue> Values => value;

        public BinaryTreeNode(TKey key, TValue value)
        {
            this.key = key;
            this.value = new DoubleLinkedList<TValue>();
            this.value.AddLast(value);
            parent = left = right = null;
        }

    }
    public class BinaryTree<TKey, TValue> : System.Collections.Generic.IEnumerable<BinaryTreeNode<TKey,TValue>> where TKey : IComparable
    {
        private BinaryTreeNode<TKey, TValue> root = null;
        public BinaryTreeNode<TKey, TValue> Root => root;
        public int Comparisons { get; set; } = 0;
        public void Add(TKey key, TValue value) => Add(ref root, key, value);
        private void Add(ref BinaryTreeNode<TKey, TValue> ptr, TKey key, TValue value)
        {
            if (ptr == null)
            {
                ptr = new BinaryTreeNode<TKey, TValue>(key, value);
            }
            else
            {               
                if (key.Equals(ptr.key))
                {
                    ptr.value.AddLast(value);
                }
                else
                {
                    if (key.CompareTo(ptr.key) == -1)
                    {
                        if (ptr.left == null)
                        {
                            ptr.left = new BinaryTreeNode<TKey, TValue>(key, value);
                            ptr.left.parent = ptr;
                        }
                        else
                        {
                            Add(ref ptr.left, key, value);
                        }
                    }
                }
                if (key.CompareTo(ptr.key) == 1)
                {
                    if (ptr.right == null)
                    {
                        ptr.right = new BinaryTreeNode<TKey, TValue>(key, value);
                        ptr.right.parent = ptr;
                    }
                    else
                    {
                        Add(ref ptr.right, key, value);
                    }
                }
            }
        }
        public void Clear() => root = null;
        public void Remove(TKey key, TValue value)
        {
            var ptr = Find(key);
            if (ptr == null) return;
            ptr.value.Remove(value);
            if (ptr.value.Size != 0) return;
            var parent = ptr.parent;
            if (ptr.left == null && ptr.right == null)
            {
                if (ptr == root)
                {
                    root = null;
                    return;
                }
                if (parent.left == ptr) parent.left = null;
                if (parent.right == ptr) parent.right = null;
            }
            else if (ptr.left == null || ptr.right == null)
            {
                if (ptr.left == null)
                {
                    if (ptr == root)
                    {
                        root = root.right;
                        root.parent = null;
                        return;
                    }
                    if (parent.left == ptr) parent.left = ptr.right;
                    else parent.right = ptr.right;
                    ptr.right.parent = parent;
                }
                else
                {
                    if (ptr == root)
                    {
                        root = root.left;
                        root.parent = null;
                        return;
                    }
                    if (parent.left == ptr) parent.left = ptr.left;
                    else parent.right = ptr.left;
                    ptr.left.parent = parent;
                }
            }
            else
            {
                var successor = ptr.left;
                while (successor.right != null) successor = successor.right;
                ptr.key = successor.key;
                ptr.value = successor.value;
                if (successor.parent.left == successor)
                {
                    successor.parent.left = successor.right;
                    if (successor.right != null)
                        successor.right.parent = successor.parent;
                }
                else
                {
                    successor.parent.right = successor.right;
                    if (successor.right != null)
                        successor.right.parent = successor.parent;
                }
            }
        }
        public DoubleLinkedList<TValue> GetValues(TKey key)
        {
            BinaryTreeNode<TKey, TValue> ptr = Find(key);
            if (ptr == null)
            {
                return new DoubleLinkedList<TValue>();
            }
            return ptr.value;
        }
        private BinaryTreeNode<TKey, TValue> Find(TKey key) => Find(ref root, key);
        private BinaryTreeNode<TKey, TValue> Find(ref BinaryTreeNode<TKey, TValue> ptr, TKey key)
        {
            if (ptr == null)
            {
                return null;
            }
            else
            {
                Comparisons++;
                if (ptr.key.Equals(key))
                {
                    return ptr;
                }
                else
                {
                    Comparisons++;
                    if (ptr.key.CompareTo(key) == -1)
                    {
                        return (Find(ref ptr.right, key));
                    }
                    else
                    {
                        return (Find(ref ptr.left, key));
                    }
                }
            }
        }

        System.Collections.Generic.IEnumerator<BinaryTreeNode<TKey, TValue>> System.Collections.Generic.IEnumerable<BinaryTreeNode<TKey, TValue>>.GetEnumerator()
        {
            if (root == null) yield break;
            DoubleLinkedList<BinaryTreeNode<TKey, TValue>> stack =
                new DoubleLinkedList<BinaryTreeNode<TKey, TValue>>();
            BinaryTreeNode<TKey, TValue> node;
            stack.AddFirst(root);
            while (stack.Size > 0)
            {
                node = stack.First.Key;
                stack.Remove(stack.First.Key);
                yield return node;
                if (node.right != null) stack.AddFirst(node.right);
                if (node.left != null) stack.AddFirst(node.left);
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (root == null) yield break;
            DoubleLinkedList<BinaryTreeNode<TKey, TValue>> stack =
                new DoubleLinkedList<BinaryTreeNode<TKey, TValue>>();
            BinaryTreeNode<TKey, TValue> node;
            stack.AddFirst(root);
            while (stack.Size > 0)
            {
                node = stack.First.Key;
                stack.Remove(stack.First.Key);
                yield return node;
                if (node.right != null) stack.AddFirst(node.right);
                if (node.left != null) stack.AddFirst(node.left);
            }
        }
    }
}
