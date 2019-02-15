using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SCP2Week7_N_aryTree
{
    [TestFixture]
    public class TreeTest
    {
        [TestCase]
        public void Test_Tree_AddChildNode_int()
        {
            Tree<int> NAryTree = new Tree<int>();
            TreeNode<int> Root = new TreeNode<int>(1, null, new List<TreeNode<int>>());

            TreeNode<int> Branche1 = NAryTree.AddChildNode(Root, 2);
            TreeNode<int> Branche2 = NAryTree.AddChildNode(Branche1, 3);
            TreeNode<int> Branche3 = NAryTree.AddChildNode(Root, 4);
            int Tellen = 3;
            Assert.Multiple(() =>
            {
                Assert.Equals(NAryTree.AllKids.Count, Tellen);
                Assert.Contains(Branche1, NAryTree.AllKids);
                Assert.Contains(Branche2, NAryTree.AllKids);
                Assert.Equals(Branche2.Parent.Data, Branche1.Data);
            });
        }

        [TestCase]
        public void Test_Tree_RemoveNode_string()
        {
            Tree<string> NAryTree = new Tree<string>();
            TreeNode<string> Root = new TreeNode<string>("Boomstam", null, new List<TreeNode<string>>());

            TreeNode<string> Branche1 = NAryTree.AddChildNode(Root, "Tak1");
            TreeNode<string> Branche2 = NAryTree.AddChildNode(Branche1, "Blad1");
            TreeNode<string> Branche3 = NAryTree.AddChildNode(Root, "Blad2");
            NAryTree.RemoveNode(Branche1);

            Assert.Multiple(() =>
            {
                Assert.That(NAryTree.AllKids.Count == 1);
                Assert.IsFalse(NAryTree.AllKids.Contains(Branche2));
            });

        }

        [TestCase]
        public void Test_Tree_TraverseNodes_double()
        {
            Tree<double> NAryTree = new Tree<double>();
            TreeNode<double> Root = new TreeNode<double>(1.1, null, new List<TreeNode<double>>());

            TreeNode<double> Branche1 = NAryTree.AddChildNode(Root, 1.2);
            TreeNode<double> Branche2 = NAryTree.AddChildNode(Branche1, 1.3);
            TreeNode<double> Branche3 = NAryTree.AddChildNode(Root, 1.4);
            List<double> AllNodes = NAryTree.TraverseNodes();

            Assert.Multiple(() =>
            {
                Assert.That(NAryTree.AllKids.Count == 3);
                Assert.IsTrue(AllNodes.Contains(Branche2.Data));
                Assert.IsTrue(AllNodes.Contains(1.4));
                Assert.Equals(Branche2.Parent, Branche1);
            });
        }

        [TestCase]
        public void Test_Tree_SumToLeafs_int()
        {
            Tree<int> NAryTree = new Tree<int>();
            TreeNode<int> Root = new TreeNode<int>(1, null, new List<TreeNode<int>>());

            TreeNode<int> Branche1 = NAryTree.AddChildNode(Root, 2);
            TreeNode<int> Branche2 = NAryTree.AddChildNode(Branche1, 3);
            TreeNode<int> Branche3 = NAryTree.AddChildNode(Root, 4);
            List<int> SummedLeafs = NAryTree.SumToLeafs();

            Assert.Multiple(() =>
            {
                Assert.That(NAryTree.AllKids.Count == 3);
                Assert.IsTrue(SummedLeafs.Contains(Branche3.Data + Root.Data));
                Assert.IsTrue(SummedLeafs.Contains(Branche2.Data + Branche1.Data + Root.Data));
                Assert.Equals(Branche2.Parent, Branche1);
            });
        }
    }
}
