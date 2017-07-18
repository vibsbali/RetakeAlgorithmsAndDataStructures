using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();

            tree.Add(10);
            tree.Add(7);
            tree.Add(5);

            Console.WriteLine(tree.Contains(5));

            tree.Remove(5);
        }
    }
}
