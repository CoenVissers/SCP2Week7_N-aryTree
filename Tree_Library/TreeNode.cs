using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP2Week7_N_aryTree
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Kids { get; set; }
        
        public TreeNode(T data, TreeNode<T> parent, List<TreeNode<T>> kids)
        {
            this.Data = data;
            this.Parent = parent;
            this.Kids = kids;
        }
    }
}
