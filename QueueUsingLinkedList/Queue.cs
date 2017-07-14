

namespace QueueUsingLinkedList
{
    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        private readonly System.Collections.Generic.LinkedList<T> backingStore = new System.Collections.Generic.LinkedList<T>();

        public void Enqueue(T value)
        {
            backingStore.AddLast(value);
        }

        public T Dequeue()
        {
            if (backingStore.Count == 0)
            {
                throw new System.InvalidOperationException("Empty queue");
            }

            var value = backingStore.First.Value;
            backingStore.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (backingStore.Count == 0)
            {
                throw new System.InvalidOperationException("Empty queue");
            }

            return backingStore.First.Value;
        }

        public int Cout => backingStore.Count;
        public bool IsReadOnly => false;
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return backingStore.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}