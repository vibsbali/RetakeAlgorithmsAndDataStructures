
namespace StackUsingArrays
{
    public class Stack<T> : System.Collections.Generic.IEnumerable<T>
    {
        //default to size of 4
        public T[] BackingStore = new T[4];

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (BackingStore.Length == Count)
            {
                //resize
                ResizeBackingStore();
            }

            BackingStore[Count++] = item;
        }

        private void ResizeBackingStore()
        {
            var newArray = new T[Count * 2];
            System.Array.Copy(BackingStore, newArray, Count);
            BackingStore = newArray;
        }

        public T Pop()
        {
            if (Count != 0)
            {
                //Using Count - 1 because of 0 based index
                var valueToReturn = BackingStore[Count - 1];
                BackingStore[Count - 1] = default(T);

                //resize array if less than 1/3 is used and count is greater than 4 (default size) i.e. shrink it
                if (BackingStore.Length > 4 && Count < BackingStore.Length / 3)
                {
                    ResizeBackingStore();
                }


                Count--;
                return valueToReturn;
            }

            throw new System.InvalidOperationException("Stack empty");
        }

        public T Peek()
        {
            if (Count != 0)
            {
                //Using Count - 1 because of 0 based index
                return BackingStore[Count - 1];
            }

            throw new System.InvalidOperationException("Stack empty");
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return BackingStore[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}