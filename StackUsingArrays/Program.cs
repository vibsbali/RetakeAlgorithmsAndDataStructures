using System;

namespace StackUsingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();

            stack.Push("One");
            stack.Push("Two");
            stack.Push("Three");
            stack.Push("Four");
            stack.Push("Five");
            stack.Push("Six");
            stack.Push("Seven");
            stack.Push("Eight");
            stack.Push("Nine");
            stack.Push("Ten");

            foreach (var value in stack)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine($"Total count = {stack.Count}");

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
           
            Console.WriteLine($"Total count = {stack.Count}");

            stack.Push("Two");
            stack.Push("Three");
            stack.Push("Four");
            stack.Push("Five");
            stack.Push("Six");
            stack.Push("Seven");
            stack.Push("Eight");
            stack.Push("Nine");
            stack.Push("Ten");

            foreach (var value in stack)
            {
                Console.WriteLine(value);
            }

            //Console.WriteLine(stack.Peek());

            stack.Push("One");
            Console.WriteLine(stack.Peek());
        }
    }
}
