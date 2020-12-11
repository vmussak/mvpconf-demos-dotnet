using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpConfDemos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();

            IteracoesInstancias.VerificarSeEmailValidoRapidao();


            Console.WriteLine("Tempo: {0}ms", sw.ElapsedMilliseconds);

           

            //sw.Restart();

            //Listas.PercorrerList();

            //sw.Stop();
            //Console.WriteLine("Tempo: {0}ms", sw.ElapsedMilliseconds);




            Console.ReadKey();
        }
    }
}
