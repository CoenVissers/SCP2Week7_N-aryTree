using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP2Week7_N_aryTree
{
    public class Tree<T>
    {
        public int Count { get; set; }
        public int LeafCount { get; set; }
        public List<TreeNode<T>> AllKids = new List<TreeNode<T>>();

        public Tree()
        {
            Count = 0;
            LeafCount = 1;
        }

        public TreeNode<T> AddChildNode(TreeNode<T> parent, T data)
        {
            TreeNode<T> NewKid = new TreeNode<T>(data, parent, new List<TreeNode<T>>());
            if (parent.Kids.Any())
            {
                LeafCount++;
            }
            parent.Kids.Add(NewKid);
            AllKids.Add(NewKid);

            Count++;

            return NewKid;
        }

        public TreeNode<T> RemoveNode(TreeNode<T> node)
        {
            node.Parent.Kids.Remove(node);
            AllKids.Remove(node);
            if (node.Parent.Kids.Any())
            {
                LeafCount--;
            }
            if (node.Kids.Any())
            {
                for (int i = 0; i < node.Kids.Count; i++)
                {
                    RemoveNode(node.Kids[i]);
                    Count--;
                }
            }
            Count--;

            return node.Parent;
        }

        public List<T> TraverseNodes()
        {
            List<T> AllNodes = new List<T>();
            for (int i = 0; i < AllKids.Count; i++)
            {
                AllNodes.Add(AllKids[i].Data);
            }
            
            AllNodes.Add(AllKids[0].Parent.Data);
            
            return AllNodes;
        }

        public List<T> SumToLeafs()
        {
            List<T> SummedLeafs = new List<T>();
            for (int i = 0; i < AllKids.Count; i++)
            {
                if (!AllKids[i].Kids.Any())
                {
                    dynamic SumData = null;
                    SumData += AllKids[i].Data;
                    TreeNode<T> parent = AllKids[i].Parent;
                    bool par = true;
                    while (par)
                    {
                        if (parent == null)
                        {
                            par = false;
                        }
                        else
                        {
                            SumData += parent.Data;
                            parent = parent.Parent;
                        }
                    }
                    SummedLeafs.Add(SumData);
                }
            }

            return SummedLeafs;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
