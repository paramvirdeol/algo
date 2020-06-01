using System;
using System.Diagnostics;
using System.IO;

namespace QuickUnionPathCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("Running quick-union with path compression...");
            using (var reader = File.OpenText(args[0]))
            {
                int size = Convert.ToInt32(reader.ReadLine());
                var uf = new QuickUnionPC(size);

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
                uf.Display();
            }

            watch.Stop();
            Console.WriteLine("Runtime: " + watch.ElapsedMilliseconds);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
