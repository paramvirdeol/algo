using System;
using System.IO;

namespace QuickUnion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running quick-union...");
            using (var reader = File.OpenText(args[0]))
            {
                int size = Convert.ToInt32(reader.ReadLine());
                var uf = new QuickUnion(size);

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var p = Convert.ToInt32(numbers[0]);
                    var q = Convert.ToInt32(numbers[1]);
                    if (!uf.Connected(p, q))
                    {
                        uf.Union(p, q);
                        Console.WriteLine(p + " " + q);
                    }
                }

            }


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
