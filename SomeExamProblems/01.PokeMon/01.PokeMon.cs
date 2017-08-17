using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int powerN = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionFactorY = int.Parse(Console.ReadLine());

            int pokes = 0;
            int currentPower = powerN;
            double halfOfpowerN = powerN * 0.5;

            while (currentPower >= distanceM)
            {
                if (currentPower == halfOfpowerN && currentPower != 0 && exhaustionFactorY != 0)
                {
                    currentPower /= exhaustionFactorY;
                    if (currentPower < distanceM)
                    {
                        break;
                    }
                }

                currentPower -= distanceM;
                pokes++;
            }

            Console.WriteLine(currentPower);
            Console.WriteLine(pokes);
        }
    }
}
