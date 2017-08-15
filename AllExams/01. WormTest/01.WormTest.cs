namespace _01.WormTest
{
    using System;
    public class Program
    {
        public static void Main()
        {
            uint lengthInCentimeters = uint.Parse(Console.ReadLine()) * 100;
            double widthInCentimeters = double.Parse(Console.ReadLine());

            double remainder = lengthInCentimeters % widthInCentimeters;

            if (remainder == 0 || widthInCentimeters == 0)
            {
                double calculated = lengthInCentimeters * widthInCentimeters;
                Console.WriteLine($"{calculated:f2}");
            }
            else
            {
                double result = (lengthInCentimeters / widthInCentimeters) * 100;
                Console.WriteLine($"{result:f2}%");
            }
        }
    }
}
