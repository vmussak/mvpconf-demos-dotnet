using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpConfDemos
{
    public static class CafeDaManhaAsync
    {
        public static async Task Executar()
        {
            Cafe cafezinho = ColocarCafe();
            Console.WriteLine("cafézinho tá pronto");

            var ovoTask = FritarOvosAsync(2);
            var baconzeraTask = FritarBaconAsync(3);
            var paoTask = MontarPaoComManteigaNutellaAsync(2);

            var tarefas = new List<Task> { ovoTask, baconzeraTask, paoTask };

            while(tarefas.Count > 0)
            {
                Task tarefaFinalizada = await Task.WhenAny(tarefas);
                if (tarefaFinalizada == ovoTask)
                {
                    Console.WriteLine("os ovos estão prontos");
                }
                else if (tarefaFinalizada == baconzeraTask)
                {
                    Console.WriteLine("aquele bacon maravilhoso está pronto!");
                }
                else if (tarefaFinalizada == paoTask)
                {
                    Console.WriteLine("o pão está pronto");
                }

                tarefas.Remove(tarefaFinalizada);
            }
           

            Suco suco = ColocarSuco();
            Console.WriteLine("Suquinho de laranja está ok");
            Console.WriteLine("O café da manhã está pronto!!! :D");
        }

        private static Suco ColocarSuco()
        {
            Console.WriteLine("Colocando suco no copo");
            return new Suco();
        }

        private static void PassarNutella(Pao toast) =>
            Console.WriteLine("Passando aquela nutellinha no pão");

        private static void PassarManteiga(Pao pao) =>
            Console.WriteLine("Passando manteiga no pão");

        private static async Task<Pao> ColocarPaoNaChapaAsync(int fatias)
        {
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("Colocando uma fatia de pao na chapa");
            }
            Console.WriteLine("Pão está torrando...");
            await Task.Delay(3000);
            Console.WriteLine("Tirando o pão da chapa");

            return new Pao();
        }

        private static async Task<Bacon> FritarBaconAsync(int fatias)
        {
            Console.WriteLine($"colocando {fatias} do delicioso bacon na frigideira");
            Console.WriteLine("fritando o primeiro lado...");
            await Task.Delay(3000);
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("mais uma fatia :D");
            }
            Console.WriteLine("fritando o segundo lado...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Colocando o bacon no prato");

            return new Bacon();
        }

        private static async Task<Ovo> FritarOvosAsync(int quantidade)
        {
            Console.WriteLine("Aquecendo a frigideira...");
            await Task.Delay(3000);
            Console.WriteLine($"quebrando {quantidade} ovos");
            Console.WriteLine("fritando os ovos...");
            await Task.Delay(3000);
            Console.WriteLine("Colocando os ovos no prato");

            return new Ovo();
        }

        private static async Task<Pao> MontarPaoComManteigaNutellaAsync(int quantidade)
        {
            var paoNaChapa = await ColocarPaoNaChapaAsync(quantidade);
            PassarManteiga(paoNaChapa);
            PassarNutella(paoNaChapa);

            return paoNaChapa;
        }

        private static Cafe ColocarCafe()
        {
            Console.WriteLine("Colocando café...");
            return new Cafe();
        }
    }
}
