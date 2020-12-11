using System;

namespace MvpConfDemos
{
    public static class IfSwitch
    {
        const int _max = 100_000_000;
        public static void ExecutarIf()
        {
            Console.WriteLine("## Comecei o IF ##");

            for (int i = 0; i < _max; i++)
            {
                NumeroValidoIf(i);

                //NumeroValidoIf(0);
                //NumeroValidoIf(3);
                //NumeroValidoIf(5);
                //NumeroValidoIf(0);
                //NumeroValidoIf(3);
                //NumeroValidoIf(5);
                //NumeroValidoIf(0);
                //NumeroValidoIf(3);
                //NumeroValidoIf(5);

            }

            Console.WriteLine("## Finalizei ##");
        }

        public static void ExecutarSwitch()
        {
            Console.WriteLine("## Comecei o SWITCH ##");

            for (int i = 0; i < _max; i++)
            {
                NumeroValidoSwitch(i);

                //NumeroValidoSwitch(0);
                //NumeroValidoSwitch(3);
                //NumeroValidoSwitch(5);
                //NumeroValidoSwitch(0);
                //NumeroValidoSwitch(3);
                //NumeroValidoSwitch(5);
                //NumeroValidoSwitch(0);
                //NumeroValidoSwitch(3);
                //NumeroValidoSwitch(5);
            }

            Console.WriteLine("## Finalizei ##");
        }

        public static bool NumeroValidoIf(int i)
        {
            if (i == 0 || i == 1)
            {
                return true;
            }

            if (i == 2 || i == 3)
            {
                return false;
            }

            if (i == 4 || i == 5)
            {
                return true;
            }

            return false;
        }

        public static bool NumeroValidoSwitch(int i)
        {
            switch (i)
            {
                case 0:
                case 1:
                    return true;
                case 2:
                case 3:
                    return false;
                case 4:
                case 5:
                    return true;
                default:
                    return false;
            }
        }

    }
}
