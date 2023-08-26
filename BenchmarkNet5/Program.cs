using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BenchmarkNet5
{
    internal class Program
    {
        private static readonly SHA256 sha = SHA256.Create();
        private class NombreNumero
        {
            private string Name;
            private int Num;
            public NombreNumero(string name, int n)
            {
                this.Name = SHA256HexHashString(name);
                this.Num = n;
            }
        }

        private static string ToHex(byte[] bytes)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString("x2"));
            return result.ToString();
        }

        private static string SHA256HexHashString(string str)
        {
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(str));
            return ToHex(hash);
        }
        static void Main(string[] args)
        {
            List<NombreNumero> lista = new List<NombreNumero>();
            List<double> miliseconds = new List<double>();
            for (int i = 0; i < 5; i++)
            {
                var start = Stopwatch.GetTimestamp();
                for (int j = 0; j < 1000000; j++)
                    lista.Add(new NombreNumero(j.ToString(), i));
                var end = Stopwatch.GetTimestamp();
                var elapsed = new TimeSpan(end - start);
                Console.WriteLine($"Elapsed: {elapsed.TotalMilliseconds}ms");
                miliseconds.Add(elapsed.TotalMilliseconds);
                lista.Clear();
            }
            Console.WriteLine($"Avg. Miliseconds: {miliseconds.Average()}ms");
            Console.ReadKey();
        }
    }
}
