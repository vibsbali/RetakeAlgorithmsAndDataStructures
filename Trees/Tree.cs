using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees
{
    public class Tree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        class TreeNode<T>
        {
            public TreeNode<T> Parent { get; set; }
            public TreeNode<T> Left { get; set; }
            public TreeNode<T> Right { get; set; }

            public T Value { get; }

            public TreeNode(T value)
            {
                Value = value;
            }
        }

        public int Count { get; private set; }
        private TreeNode<T> head;

        public void Add(T item)
        {
            if (head == null)
            {
                head = new TreeNode<T>(item);
            }
            else
            {
                AddRecursively(head, item);
            }

            Count++;
        }

        private void AddRecursively(TreeNode<T> parent, T item)
        {
            if (item.CompareTo(parent.Value) < 0)
            {
                if (parent.Left == null)
                {
                    parent.Left = new TreeNode<T>(item)
                    {
                        //update parent node
                        Parent = parent
                    };
                    
                    return;
                }

                AddRecursively(parent.Left, item);
            }
            else
            {
                if (parent.Right == null)
                {
                    parent.Right = new TreeNode<T>(item)
                    {
                        //update parent node
                        Parent = parent
                    };
                    
                    return;
                }


                AddRecursively(parent.Right, item);
            }
        }

        public void Remove(T item)
        {
            if (head.Value.CompareTo(item) == 0)
            {
                //Remove head
                return;
            }

            var parentOfNodeToRemove = FindNode(item);
            
        }

        private TreeNode<T> FindNode(T item)
        {
            var current = head;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    return current;
                }

                if (current.Value.CompareTo(item) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    current = current.Left;
                }
            }

            return null;
        }

        private static bool IsValueEqualsRightNode(TreeNode<T> binaryTreeNode, T item)
        {
            return binaryTreeNode.Right != null && item.CompareTo(binaryTreeNode.Right.Value) == 0;
        }

        private static bool IsValueEqualsLeftNode(TreeNode<T> binaryTreeNode, T item)
        {
            return binaryTreeNode.Left != null && item.CompareTo(binaryTreeNode.Left.Value) == 0;
        }

        public bool Contains(T item)
        {
            return FindNode(item) != null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}