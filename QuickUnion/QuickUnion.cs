using System;
using System.Collections.Generic;
using System.Text;

namespace QuickUnion
{
    public class QuickUnion
    {
        private int[] id;

        public QuickUnion(int size)
        {
            id = new int[size];
            for (int i = 0; i < size; i++)
            {
                id[i] = i;
            }
        }

        private int root(int i)
        {
            while (i != id[i]) i = id[i];
            return i;
        }
        public bool Connected(int p, int q)
        {
            // Check if p and q have same root
            return root(p) == root(q);
        }
        public void Union(int p, int q)
        {
            // Change the root of p to point to root of q
            int i = root(p);
            int j = root(q);
            id[i] = j;
        }
    }
}
