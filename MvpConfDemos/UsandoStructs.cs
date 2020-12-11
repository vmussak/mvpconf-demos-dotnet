using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpConfDemos
{
    public static class UsandoStructs
    {
        public static void Executar()
        {
            const int quantidadeSorteios = 10_000_000;

            var points = new List<Sorteio>(quantidadeSorteios);
            for (var i = 0; i < quantidadeSorteios; i++)
            {
                points.Add(new Sorteio
                {
                    Numero1 = i,
                    Numero2 = i,
                    Numero3 = i
                });
            }

            var gen0antes = GC.CollectionCount(0);
            var cartelaSorteada = new Sorteio { Numero1 = 1, Numero2 = 2, Numero3 = 3 };

            var sw = new Stopwatch();
            sw.Start();

            var temCartelaSorteada = points.Contains(cartelaSorteada);

            sw.Stop();

            Console.WriteLine("Tempo: {0}ms", sw.ElapsedMilliseconds);
            Console.WriteLine("gen0: {0}", (GC.CollectionCount(0) - gen0antes));
            Console.WriteLine("RAM: {0}mb", Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024);
        }
    }

    public class Sorteio //: IEquatable<Sorteio>
    {
        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
        public int Numero3 { get; set; }

        public override bool Equals(object obj)
        {
            var outroSorteio = (Sorteio)obj;

            return outroSorteio.Numero1 == Numero1 &&
                outroSorteio.Numero2 == Numero2 &&
                outroSorteio.Numero3 == Numero3;

        }

        //public bool Equals(Sorteio outroSorteio) => outroSorteio.Numero1 == Numero1 &&
        //        outroSorteio.Numero2 == Numero2 &&
        //        outroSorteio.Numero3 == Numero3;
    }
}
