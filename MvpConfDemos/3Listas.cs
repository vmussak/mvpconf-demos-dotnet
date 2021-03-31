using System;
using System.Collections;
using System.Collections.Generic;

namespace MvpConfDemos
{
    public static class Listas
    {
        const int _max = 1_000_000;

        public static void PercorrerArrayList()
        {
            Console.WriteLine("## Comecei o ArrayList ##");

            ArrayList arrayList = new ArrayList(_max);

            for (int i = 0; i < _max; i++)
                arrayList.Add(i);

            Console.WriteLine("## Finalizei ##");
        }

        public static void PercorrerList()
        {
            Console.WriteLine("## Comecei o List<T> ##");

            List<int> intList = new List<int>(_max);

            for (int i = 0; i < _max; i++)
                intList.Add(i);

            Console.WriteLine("## Finalizei ##");
        }


    }
}
