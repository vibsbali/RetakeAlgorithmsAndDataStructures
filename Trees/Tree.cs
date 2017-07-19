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
            var nodeToRemove = FindNode(item);

            if (nodeToRemove == null)
            {
                return;
            }

            //1. Does the node to remove have any right children
            if (nodeToRemove.Right == null)
            {
                if (IsNodeOnRightOfParent(nodeToRemove))
                {
                    nodeToRemove.Parent.Right = null;
                    nodeToRemove.Parent.Right = nodeToRemove.Left;

                    //Update parent
                    if (nodeToRemove.Left != null)
                    {
                        nodeToRemove.Left.Parent = nodeToRemove.Parent;
                    }

                    Count--;
                }
                else
                {
                    nodeToRemove.Parent.Left = null;
                    nodeToRemove.Parent.Left = nodeToRemove.Left;

                    //Update Parent
                    if (nodeToRemove.Left != null)
                    {
                        nodeToRemove.Left.Parent = nodeToRemove.Parent;
                    }

                    Count--;
                }
                return;
            }

            //2. Does the node to remove has a right child which in-turn doesn't have any left child
            if (nodeToRemove.Right != null)
            {
                if (IsNodeOnRightOfParent(nodeToRemove))
                {
                    nodeToRemove.Parent.Right = null;
                    nodeToRemove.Parent.Right = nodeToRemove.Right; //Promote right child
                    nodeToRemove.Right.Left = nodeToRemove.Left;
                    nodeToRemove.Right.Parent = nodeToRemove.Parent;

                    Count--;
                }
                else
                {
                    nodeToRemove.Parent.Left = null;
                    nodeToRemove.Parent.Left = nodeToRemove.Right; //Promote right child
                    nodeToRemove.Right.Left = nodeToRemove.Left;
                    nodeToRemove.Right.Parent = nodeToRemove.Parent;

                    Count--;
                }
                return;
            }
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

        private static bool IsNodeOnRightOfParent(TreeNode<T> binaryTreeNode)
        {
            //Check if the node has parent and parent's value is greater than current node
            if (binaryTreeNode.Parent != null && binaryTreeNode.Parent.Value.CompareTo(binaryTreeNode.Value) <= 0)
            {
                return true;
            }

            return false;
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