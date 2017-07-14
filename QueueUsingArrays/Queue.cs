namespace QueueUsingArrays
{
    public class Queue<T> : System.Collections.Generic.IEnumerable<T>
    {
        private int head = 0;
        private int tail = -1;
        private T[] backingArray;

        public int Count { get; private set; }

        public Queue(int size)
        {
            backingArray = new T[size];
        }

        public Queue()
            : this(4)
        {
        }

        public void Enqueue(T item)
        {
            if (Count == backingArray.Length)
            {
                SizeUp();
            }
            else if (tail == backingArray.Length - 1)
            {
                tail = -1;
            }
            

            backingArray[++tail] = item;
            Count++;
        }

        public T Deque()
        {
            if (Count == 0)
            {
                throw new System.InvalidOperationException("Empty queue");
            }

            var item = backingArray[head];
            backingArray[head] = default(T);
            //If head is at the last index
            if (head == backingArray.Length - 1)
            {
                head = 0;
            }
            else
            {
                head++;
            }

            --Count;
            return item;
        }

        private void SizeUp()
        {
            var tempArray = new T[Count * 2];

            //check if we have wrapped
            if (head > tail)
            {
                System.Array.Copy(backingArray, head, tempArray, 0, backingArray.Length - head);
                System.Array.Copy(backingArray, 0, tempArray, backingArray.Length - head, tail + 1);
            }
            else
            {
                System.Array.Copy(backingArray, 0, tempArray, 0, Count);
            }

            backingArray = tempArray;
            head = 0;
            tail = Count - 1;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            //are we wrapped
            if (head > tail)
            {
                for (int i = head; i < backingArray.Length; i++)
                {
                    yield return backingArray[i];
                }

                for (int i = 0; i <= tail; i++)
                {
                    yield return backingArray[i];
                }
            }
            else
            {
                for (int i = head; i <= tail; i++)
                {
                    yield return backingArray[i];
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}