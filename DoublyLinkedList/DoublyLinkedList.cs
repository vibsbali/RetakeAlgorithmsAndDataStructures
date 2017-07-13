using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }

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

        public void Add(T item)
        {
            AddToFront(item);
        }

        public void AddToFront(T item)
        {
            var node = new DoublyLinkedListNode<T>(item);

            if (Head == null)
            {
                Head = Tail = node;
            }
            else
            {
                var currentHead = Head;
                Head = node;
                Head.Next = currentHead;
                currentHead.Previous = Head;
            }

            Count++;
        }

        public void AddToBack(T item)
        {
            var node = new DoublyLinkedListNode<T>(item);

            if (Tail == null)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = Tail.Next;   //Update Tail                
            }

            Count++;
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
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
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

                //Since head cannot be the value
                var current = Head.Next;
                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        current = null; //Not important in managed language

                        Count--;
                        return true;
                    }
                    current = current.Next;
                }
            }

            return false;
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Tail == Head)
                {
                    Clear();
                    return;
                }

                var newTail = Tail.Previous;
                Tail = null;    //Important if Node stores ref type
                Tail = newTail;
                Tail.Next = null;
                Count--;
            }
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                //i.e. only one item in the linked list
                if (Head == Tail)
                {
                    Clear();
                    return;
                }

                var newHead = Head.Next;
                Head = null;
                Head = newHead;
                Head.Previous = null;

                Count--;
            }
        }

        public int Count { get; private set; }
        public bool IsReadOnly => false;
    }
}
