using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpConfDemos
{
    public static class CompararStrings
    {
        const int _max = 100_000_000;
        public static void ExecutarIgual()
        {
            Console.WriteLine("## Comecei o CompararComIgual ##");

            for (int i = 0; i < _max; i++)
            {
                CompararComIgual("VINICIUS", "vinicius");
                CompararComIgual("DifeRenTe", "Outra coisa");
            }

            Console.WriteLine("## Finalizei ##");
        }

        public static void ExecutarStringCompare()
        {
            Console.WriteLine("## Comecei o CompararComStringCompare ##");

            for (int i = 0; i < _max; i++)
            {
                CompararComStringCompare("VINICIUS", "vinicius");
                CompararComStringCompare("DifeRenTe", "Outra coisa");
            }

            Console.WriteLine("## Finalizei ##");
        }

        public static void ExecutarRaiz()
        {
            Console.WriteLine("## Comecei o CompararDoJeitoRaiz ##");

            for (int i = 0; i < _max; i++)
            {
                CompararDoJeitoRaiz("VINICIUS", "vinicius");
                CompararDoJeitoRaiz("DifeRenTe", "Outra coisa");
            }

            Console.WriteLine("## Finalizei ##");
        }

        public static bool CompararComIgual(string s1, string s2)
        {
            return s1.ToLower() == s2.ToLower();
        }

        public static bool CompararComStringCompare(string s1, string s2)
        {
            return string.Compare(s1, s2, true) == 0;
        }

        public static bool CompararDoJeitoRaiz(string strA, string strB)
        {
            if (strA.Length != strB.Length)
                return false;

            int length = strA.Length - 1;

            while (length != 0)
            {
                int charA = strA[length];
                int charB = strB[length];

                if ((uint)(charA - 'a') <= (uint)('z' - 'a')) charA -= 0x20;
                if ((uint)(charB - 'a') <= (uint)('z' - 'a')) charB -= 0x20;

                if (charA != charB)
                    return false;

                length--;
            }

            return true;
        }
    }
}
