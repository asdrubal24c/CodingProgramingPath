using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestor
{
    public class Logic
    {
        public class solution {

        public node? root;
        private ArrayList path1 = new ArrayList();
        private ArrayList path2 = new ArrayList();


        public void InitTree()
        {
            var tree = new solution();
            tree.root = new node(1);

            tree.root.left = new node(2);
            tree.root.right = new node(3);

            tree.root.left.right = new node(5);
            tree.root.left.left = new node(4);

            tree.root.right.right = new node(7);
            tree.root.right.left = new node(6);

            Console.Write("LCA(4, 5) = " + tree.findLCA(4, 5));

            Console.Write("\nLCA(4, 6) = "
                          + tree.findLCA(4, 6));

            Console.Write("\nLCA(3, 4) = "
                          + tree.findLCA(3, 4));

            Console.Write("\nLCA(2, 4) = "
                          + tree.findLCA(2, 4));
        }

        public int findLCA(int n1, int n2)
        {
            path1.Clear();
            path2.Clear();
            return findLCAInternal(root, n1, n2);
        }

        public int findLCAInternal(node root, int n1, int n2)
        {
            if (!findPath(root, n1, path1) || !findPath(root, n2, path2))
            {
                return -1;
            }

            int i;
            for (i = 0; i < path1.Count && i < path2.Count; i++)
            {
                if (Convert.ToInt32(path1[i]) != Convert.ToInt32(path2[i]))
                    break;
            }

            return Convert.ToInt32(path1[i - 1]);
        }

        public static bool findPath(node root, int n, ArrayList path)
        {
            if (root is null)
                return false;

            path.Add(root.data);

            if (root.data == n)
                return true;

            if (root.left != null && findPath(root.left, n, path))
                return true;

            if (root.right != null && findPath(root.right, n, path))
                return true;

            path.RemoveAt(path.Count - 1);

            return false;
        }

        public class node
        {
            public node(int val)
            {
                this.data = val;
                this.left = this.right = null;
            }

            public node(int val, node left, node right)
            {
                this.data = val;
                this.left = left;
                this.right = right;
            }

            public int data;
            public node? left, right;
        }
        
        }

    }
}
