using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();

            tree.Add(10);
            tree.Add(5);
            tree.Add(7);
        }
    }



    public class Tree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        class TreeNode<T>
        {
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
                    parent.Left = new TreeNode<T>(item);
                    return;
                }

                AddRecursively(parent.Left, item);
            }
            else
            {
                if (parent.Right == null)
                {
                    parent.Right = new TreeNode<T>(item);
                    return;
                }


                AddRecursively(parent.Right, item);
            }
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
