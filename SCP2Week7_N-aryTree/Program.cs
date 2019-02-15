using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP2Week7_N_aryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<string> NAryTree = new Tree<string>();
            TreeNode<string> Root = new TreeNode<string>("Boomstam", null, new List<TreeNode<string>>());

            TreeNode<string> Branche1 = NAryTree.AddChildNode(Root, "Tak1");
            TreeNode<string> Branche2 = NAryTree.AddChildNode(Branche1, "Blad1");
            TreeNode<string> Branche3 = NAryTree.AddChildNode(Root, "Blad2");
            NAryTree.RemoveNode(Branche1);
            Console.WriteLine(NAryTree.AllKids.Count);
            TreeNode<string> Branche4 = NAryTree.AddChildNode(Root, "Tak2");
            TreeNode<string> Branche5 = NAryTree.AddChildNode(Branche4, "Tak2.1");
            TreeNode<string> Branche6 = NAryTree.AddChildNode(Branche5, "Blad3");
            TreeNode<string> Branche7 = NAryTree.AddChildNode(Branche4, "Tak2.2");
            TreeNode<string> Branche8 = NAryTree.AddChildNode(Branche7, "Blad4");
            TreeNode<string> Branche9 = NAryTree.AddChildNode(Branche7, "Blad5");
            List<string> SummedLeafs = NAryTree.SumToLeafs();
            for (int i = 0; i < SummedLeafs.Count; i++)
            {
                Console.WriteLine(SummedLeafs[i]);
            }
            Console.WriteLine();
            List<string> TraversedNodes = NAryTree.TraverseNodes();
            for (int i = 0; i < TraversedNodes.Count; i++)
            {
                Console.WriteLine(TraversedNodes[i]);
            }
            Console.WriteLine(NAryTree.AllKids.Count);
            Console.ReadLine();
            
        }
    }
}
