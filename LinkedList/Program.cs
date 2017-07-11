using System;

namespace LinkedList
{
    class Program
    {
        static void Main()
        {
            //Easy way to add items to a linked list
            var linkedList = new LinkedList<string>
            {
              "One",
              "Two",
              "Three",
              "Four"
            };

            foreach (var value in linkedList)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine($"Total count = {linkedList.Count}");
        }
    }
}
