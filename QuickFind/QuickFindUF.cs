using System;
using System.Collections.Generic;
using System.Text;

namespace QuickFind
{
    public class QuickFindUF
    {
        private int[] id;

        public QuickFindUF(int size)
        { 
            id = new int[size];
         
            for (int i = 0; i < size; i++) 
            {
                id[i] = i;
            }
        }
        
        public bool Connected(int p, int q)
        {
            return id[p] == id[q];
        }
        
        public void Union(int p, int q)
        {
            int pid = id[p];
            int qid = id[q];

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pid) id[i] = qid;
            }
        }
    }
}
