using System;

namespace StackUsingLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();

            stack.Push("One");
            stack.Push("Two");
            stack.Push("Three");

            foreach (var value in stack)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine($"Total count = {stack.Count}");

            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine(stack.Peek());

            stack.Push("One");
            Console.WriteLine(stack.Peek());
        }
    }
}
