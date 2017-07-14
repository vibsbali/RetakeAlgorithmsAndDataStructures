using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueUsingArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();

            queue.Enqueue("One");
            queue.Enqueue("Two");

            Console.WriteLine(queue.Deque());
            
            queue.Enqueue("Three");
            queue.Enqueue("Four");

            Console.WriteLine(queue.Deque());

            queue.Enqueue("Five");
            queue.Enqueue("Six");
            queue.Enqueue("Seven");
            queue.Enqueue("Eight");
            queue.Enqueue("Nine");
            queue.Enqueue("Ten");

            foreach (var value in queue)
            {
                Console.WriteLine(value);
            }
        }
    }
}
