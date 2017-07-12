using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new DoublyLinkedList<string>
            {
                "One",
                "Two",
                "Three"
            };

            foreach (var node in myList)
            {
                Console.WriteLine(node);
            }

            Console.WriteLine($"Total number of nodes {myList.Count}");
        }
    }
}
