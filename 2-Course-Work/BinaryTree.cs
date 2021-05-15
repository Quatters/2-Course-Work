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
            BinaryTreeNode<TKey, TValue> ptr = Find(key);
            if (ptr != null)
            {
                ptr.value.Remove(value);
                if (ptr.value.Size == 0)
                {
                    if(ptr.left == null && ptr.right == null)
                    {
                        if (ptr == root)
                        {
                            Clear();
                        }
                        else
                        {
                            if (ptr.parent.left == ptr)
                            {
                                ptr.parent.left = null;
                            }
                            else
                            {
                                ptr.parent.right = null;
                            }
                        }
                    }
                    else
                    {
                        if(ptr.left == null)
                        {
                            ptr.value = ptr.right.value;
                            ptr.key = ptr.right.key;                            
                            ptr = ptr.right;
                            ptr.parent.right = ptr.right;
                        }
                        else
                        {
                            BinaryTreeNode<TKey, TValue> leaf = ptr.left;
                            while (leaf.right != null)
                            {
                                leaf = leaf.right;
                            }
                            ptr.value = leaf.value;
                            ptr.key = leaf.key;
                            if (leaf.parent == ptr)
                            {
                                ptr.left = leaf.left;
                            }
                            else
                            {
                                leaf.parent.right = leaf.left;
                            }                            
                        }
                    }
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
                if (ptr.key.Equals(key))
                {
                    return ptr;
                }
                else
                {
                    if(ptr.key.CompareTo(key) == -1)
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
            DoubleLinkedList<BinaryTreeNode<TKey, TValue>> stack = new DoubleLinkedList<BinaryTreeNode<TKey, TValue>>();
            BinaryTreeNode<TKey, TValue> ptr = root;
            while(ptr != null || stack.Size > 0)
            {
                while(ptr != null)
                {
                    stack.AddFirst(ptr);
                    ptr = ptr.left;
                }
                ptr = stack.First.Key;
                yield return ptr;
                ptr = ptr.right;
                stack.Remove(stack.First.Key);
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            DoubleLinkedList<BinaryTreeNode<TKey, TValue>> stack = new DoubleLinkedList<BinaryTreeNode<TKey, TValue>>();
            BinaryTreeNode<TKey, TValue> ptr = root;
            while (ptr != null || stack.Size > 0)
            {
                while (ptr != null)
                {
                    stack.AddFirst(ptr);
                    ptr = ptr.left;
                }
                ptr = stack.First.Key;
                yield return ptr.key;
                ptr = ptr.right;
                stack.Remove(stack.First.Key);
            }
        }
    }
}
