using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees
{
    public class Tree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        class BinaryTreeNode<T> : IComparable<T>
            where T : IComparable<T>
        {
            public BinaryTreeNode<T> Left { get; set; }
            public BinaryTreeNode<T> Right { get; set; }

            public T Value { get; }

            public BinaryTreeNode(T value)
            {
                Value = value;
            }

            public int CompareTo(T other)
            {
                return Value.CompareTo(other);
            }

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        public int Count { get; private set; }
        private BinaryTreeNode<T> head;

        public void Add(T item)
        {
            if (head == null)
            {
                head = new BinaryTreeNode<T>(item);
            }
            else
            {
                AddRecursively(head, item);
            }

            Count++;
        }

        private void AddRecursively(BinaryTreeNode<T> curentNode, T item)
        {
            if (item.CompareTo(curentNode.Value) < 0)
            {
                if (curentNode.Left == null)
                {
                    curentNode.Left = new BinaryTreeNode<T>(item);
                    return;
                }

                AddRecursively(curentNode.Left, item);
            }
            else
            {
                if (curentNode.Right == null)
                {
                    curentNode.Right = new BinaryTreeNode<T>(item);
                    return;
                }
                AddRecursively(curentNode.Right, item);
            }
        }

        public void Remove(T value)
        {
            if (head.Value.CompareTo(value) == 0)
            {
                //Remove head
                throw new NotImplementedException("Removing root not implemented");
            }
            else
            {
                var nodeToRemove = FindNode(value, out BinaryTreeNode<T> parent);
                if (nodeToRemove != null)
                {
                    //4 options
                    //1. Leaf node - easy remove the node and update reference
                    //2. No right node just replace the removed node with left node
                    //3. Right node doesn't have a left child, replace with right node
                    //4. Right node has a left child, go all the way down to the leftmost child and replace the removed
                    //   node with left most node
                    RemoveNode(ref nodeToRemove, parent);
                }
            }
            //--Count;
        }

        private void RemoveNode(ref BinaryTreeNode<T> nodeToRemove, BinaryTreeNode<T> parent)
        {
            var isRightOfParent = IsRightOfParentNode(parent, nodeToRemove.Value);
            //1. Leaf node - easy remove the node and update reference
            if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                if (isRightOfParent)
                {
                    parent.Right = null;
                }
                else
                {
                    parent.Left = null;
                }
            }

            //2. No right node just replace the removed node with left node
            else if (nodeToRemove.Left != null && nodeToRemove.Right == null)
            {
                if (isRightOfParent)
                {
                    parent.Right = nodeToRemove.Left;
                }
                else
                {
                    parent.Left = nodeToRemove.Left;
                }
            }

            //3. Right node doesn't have a left child, replace with right node
            else if (nodeToRemove.Right != null && nodeToRemove.Right.Left == null)
            {
                if (isRightOfParent)
                {
                    parent.Right = nodeToRemove.Right;
                    nodeToRemove.Right.Left = nodeToRemove.Left;
                }
                else
                {
                    parent.Left = nodeToRemove.Right;
                    nodeToRemove.Right.Left = nodeToRemove.Left;
                }
            }

            //4. Right node has a left child, replace with right most node
            else if (nodeToRemove.Right != null && nodeToRemove.Right.Left != null)
            {
                var parentOfLeftNode = nodeToRemove.Right;
                var leftNode = nodeToRemove.Right.Left;
                while (leftNode.Left != null)
                {
                    parentOfLeftNode = leftNode;
                    leftNode = leftNode.Left;
                }

                if (isRightOfParent)
                {
                    parent.Right = leftNode;
                }
                else
                {
                    parent.Left = leftNode;
                }
                parentOfLeftNode.Left = null;
                leftNode.Left = nodeToRemove.Left;
                leftNode.Right = nodeToRemove.Right;
            }
            --Count;
        }
        
        private BinaryTreeNode<T> FindNode(T item, out BinaryTreeNode<T> parent)
        {
            var current = head;
            parent = null;
            while (current != null)
            {
                if (current.CompareTo(item) == 0)
                {
                    return current;
                }

                if (current.Value.CompareTo(item) < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    parent = current;
                    current = current.Left;
                }
            }

            return null;
        }

        private static bool IsRightOfParentNode(BinaryTreeNode<T> parentNode, T item)
        {
            return parentNode.Right != null && item.CompareTo(parentNode.Right.Value) == 0;
        }

        private static bool IsLeftOfParentNode(BinaryTreeNode<T> parentNode, T item)
        {
            return parentNode.Left != null && item.CompareTo(parentNode.Left.Value) == 0;
        }

        public bool Contains(T item)
        {
            return FindNode(item, out BinaryTreeNode<T> _) != null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void PreOrderTraversal(Action<T> actionToPerform)
        {
            var root = head;
            PerformPreOrderTraversal(root, actionToPerform);
        }

        private void PerformPreOrderTraversal(BinaryTreeNode<T> node, Action<T> actionToPerform)
        {
            if (node != null)
            {
                actionToPerform.Invoke(node.Value);
                PerformPreOrderTraversal(node.Left, actionToPerform);
                PerformPreOrderTraversal(node.Right, actionToPerform);
            }
        }

        public void PostOrderTraversal(Action<T> actionToPerform)
        {
            var root = head;
            PerformPostOrderTraversal(root, actionToPerform);
        }

        private void PerformPostOrderTraversal(BinaryTreeNode<T> node, Action<T> actionToPerform)
        {
            if (node != null)
            {
                PerformPreOrderTraversal(node.Left, actionToPerform);
                PerformPreOrderTraversal(node.Right, actionToPerform);
                actionToPerform.Invoke(node.Value);
            }
        }

        public void InOrderTraversal(Action<T> actionToPerform)
        {
            var root = head;
            PerformInOrderTraversal(root, actionToPerform);
        }

        private void PerformInOrderTraversal(BinaryTreeNode<T> node, Action<T> actionToPerform)
        {
            if (node != null)
            {
                PerformInOrderTraversal(node.Left, actionToPerform);
                actionToPerform.Invoke(node.Value);
                PerformInOrderTraversal(node.Right, actionToPerform);
            }
        }
    }
}