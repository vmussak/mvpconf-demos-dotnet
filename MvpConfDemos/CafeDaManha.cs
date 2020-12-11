using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpConfDemos
{
    public static class CafeDaManha
    {
        public static void Executar()
        {
            Cafe cafezinho = ColocarCafe();
            Console.WriteLine("cafézinho tá pronto");

            Ovo ovos = FritarOvos(2);
            Console.WriteLine("os ovos estão prontos");

            Bacon baconzera = FritarBacon(3);
            Console.WriteLine("aquele bacon maravilhoso está pronto!");

            Pao paozinho = ColocarPaoNaChapa(2);
            PassarManteiga(paozinho);
            PassarNutella(paozinho);
            Console.WriteLine("o pão está pronto");

            Suco oj = ColocarSuco();
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

        private static Pao ColocarPaoNaChapa(int fatias)
        {
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("Colocando uma fatia de pao na chapa");
            }
            Console.WriteLine("Pão está torrando...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Tirando o pão da chapa");

            return new Pao();
        }

        private static Bacon FritarBacon(int fatias)
        {
            Console.WriteLine($"colocando {fatias} do delicioso bacon na frigideira");
            Console.WriteLine("fritando o primeiro lado...");
            Task.Delay(3000).Wait();
            for (int fatia = 0; fatia < fatias; fatia++)
            {
                Console.WriteLine("mais uma fatia :D");
            }
            Console.WriteLine("fritando o segundo lado...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Colocando o bacon no prato");

            return new Bacon();
        }

        private static Ovo FritarOvos(int quantidade)
        {
            Console.WriteLine("Aquecendo a frigideira...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"quebrando {quantidade} ovos");
            Console.WriteLine("fritando os ovos...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Colocando os ovos no prato");

            return new Ovo();
        }

        private static Cafe ColocarCafe()
        {
            Console.WriteLine("Colocando café...");
            return new Cafe();
        }
    }
}
