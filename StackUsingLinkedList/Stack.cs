namespace StackUsingLinkedList
{
    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        private readonly System.Collections.Generic.LinkedList<T> BackingStore =
            new System.Collections.Generic.LinkedList<T>();

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return BackingStore.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(T item)
        {
            BackingStore.AddFirst(item);
        }

        public void Clear()
        {
            BackingStore.Clear();
        }

        public bool Contains(T item)
        {
            return BackingStore.Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = BackingStore.First;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public T Peek()
        {
            if (Count != 0)
            {
                return BackingStore.First.Value;
            }

            throw new System.InvalidOperationException("Stack empty");
        }

        public T Pop()
        {
            if (Count != 0)
            {
                var head = BackingStore.First;
                BackingStore.RemoveFirst();
                return head.Value;
            }

            throw new System.InvalidOperationException("Stack empty");
        }

        public int Count => BackingStore.Count;
        public bool IsReadOnly => false;
    }
}