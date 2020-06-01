using System;
using System.Collections.Generic;
using System.Text;

namespace QuickUnionWeighted
{
    public class QuickUnionWeighted
    {
        private int[] id;
        private int[] sz;


        public QuickUnionWeighted(int size)
        {
            id = new int[size];
            sz = new int[size];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }            
        }

        private int root(int i)
        {
            while (i != id[i]) i = id[i];
            return i;
        }

        public bool Connected(int p, int q)
        {
            return root(p) == root(q);
        }

        public void Union(int p, int q)
        {
            int i = root(p);
            int j = root(q);
            if (i == j) return;
            if (sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
        }

        public void Display()
        {
            Console.WriteLine("id array: " + String.Join(' ', id));
            Console.WriteLine("sz array: " + String.Join(' ', sz));
        }

    }
}
