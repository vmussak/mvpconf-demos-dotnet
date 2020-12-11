using System;
using System.Threading.Tasks;

namespace MvpConfDemos
{
    public static class OrdemCondicoesIf
    {
        public static void Executar(int idade, bool pareceFeliz)
        {
            Console.WriteLine("## Comecei ##");

            if(pareceFeliz && VerificaFelicidade(idade))
            {
                //faz algo aqui
                Console.WriteLine("Está feliz :D");
            }
            else
            {
                //faz outra coisa
                Console.WriteLine("Não está feliz D:");
            }

            Console.WriteLine("## Finalizei ##"); 
        }

        public static bool VerificaFelicidade(int idade)
        {
            Task.Delay(3000).Wait();

            return idade == 1;
        }
    }
}
