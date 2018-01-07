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

            tree.Add(30); //Root
            tree.Add(50); //Right
            tree.Add(10); //Left

            tree.Add(20); //Right of 10
            tree.Add(17); //Left of 20
            tree.Add(15); //Left of 15
            tree.Add(5); //left of 10
            tree.Add(2); //left of 5
            tree.Add(1); //left of 2
            
            tree.Add(40); //left of 50
            tree.Add(70); //Right of 50

            Console.WriteLine(tree.Contains(50));

            tree.Remove(10);
            tree.InOrderTraversal(x => Console.WriteLine(x));
        }
    }
}
