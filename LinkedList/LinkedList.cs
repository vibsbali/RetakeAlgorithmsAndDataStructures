using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }

        public void Add(T item)
        {
            AddToBack(item);
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (Count != 0)
            {
                if (Head.Value.Equals(item))
                {
                    RemoveFirst();
                    return true;
                }
                if (Tail.Value.Equals(item))
                {
                    RemoveLast();
                    return true;
                }

                //Else
                var current = Head;
                if (current.Next.Value.Equals(item))
                {
                    var temp = current.Next.Next;

                    //next two steps are for housekeeping and for GC 
                    //set the next's next pointer to null
                    current.Next.Next = null;
                    //set the current's next point to null - the following is not that important 
                    current.Next = null;

                    current.Next = temp;
                    Count--;
                    return true;
                }
            }


            return false;
        }

        /// <summary>
        /// A completely new way to remove items from a linked list
        /// </summary>
        public void RemoveFirst()
        {
            if (Head == Tail)
            {
                Clear();
                return;
            }

            Head = Head.Next;
            Count--;
        }

        public void RemoveLast()
        {
            if (Head == Tail)
            {
                Clear();
                return;
            }

            var current = Head;
            while (current.Next != Tail)
            {
                current = current.Next;
            }

            Tail = current;
            Tail.Next = null;
            Count--;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void AddToFront(T value)
        {
            if (Count == 0)
            {
                Head = Tail = new LinkedListNode<T>(value);
            }
            else
            {
                var existingHead = Head;
                Head = new LinkedListNode<T>(value)
                {
                    Next = existingHead
                };
            }

            Count++;
        }

        public void AddToBack(T value)
        {
            if (Count == 0)
            {
                Head = Tail = new LinkedListNode<T>(value);
            }
            else
            {
                var existingTail = Tail;
                Tail = new LinkedListNode<T>(value);
                existingTail.Next = Tail;
            }

            Count++;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
