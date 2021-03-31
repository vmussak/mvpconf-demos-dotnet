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

            var database = new Database();
            var x = database.BuscarClientes2();

            sw.Stop();

            Console.WriteLine("Tempo: {0}ms", sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}


//OrdemCondicoesIf.Executar(10, true);

/*

CompararStrings.ExecutarStringCompare();
CompararStrings.ExecutarRaiz();
 */

/*

Listas.PercorrerArrayList();
 */

/*
IteracoesInstancias.VerificarSeEmailValido();
IteracoesInstancias.VerificarSeEmailValidoRapidao();
 */