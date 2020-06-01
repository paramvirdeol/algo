namespace QuickUnionPathCompression
{
    public class QuickUnionPC
    {
        private int[] id;
        private int[] sz;

        public QuickUnionPC(int size)
        {
            id = new int[size];
            sz = new int[size];

            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }
        }

        // Simpler one-pass variant
        private int root(int i)
        {
            while (i != id[i])
            {
                id[i] = id[id[i]];
                i = id[i];
            }
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