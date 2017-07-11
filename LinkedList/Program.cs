using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>
            {
              1,
              2,
              3
            };

            linkedList.RemoveLast();


            foreach (var value in linkedList)
            {
                Console.WriteLine(value);
            }
        }
    }
}
