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

            myList.Remove("Two");
            Console.WriteLine($"Total number of nodes {myList.Count}");

            foreach (var node in myList)
            {
                Console.WriteLine(node);
            }

            myList.Remove("Two");

            myList.RemoveLast();
            foreach (var node in myList)
            {
                Console.WriteLine(node);
            }

            myList.Remove("Three");

            Console.WriteLine($"Total number of nodes {myList.Count}");

            foreach (var node in myList)
            {
                Console.WriteLine(node);
            }
        }
    }
}
