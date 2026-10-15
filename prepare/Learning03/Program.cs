using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);
        Fraction fraction4 = new Fraction(1, 3);

        Console.WriteLine($"{fraction1.GetFractionString()}");
        Console.WriteLine($"{fraction1.GetDecimalValue()}");
        Console.WriteLine($"{fraction2.GetFractionString()}");
        Console.WriteLine($"{fraction2.GetDecimalValue()}");
        Console.WriteLine($"{fraction3.GetFractionString()}");
        Console.WriteLine($"{fraction3.GetDecimalValue()}");
        Console.WriteLine($"{fraction4.GetFractionString()}");
        Console.WriteLine($"{fraction4.GetDecimalValue()}");


        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine($"Fraction {i}:");
            int randomTop = new Random().Next(1, 10);
            int randomBottom = new Random().Next(1, 10);
            Fraction fraction = new Fraction(randomTop, randomBottom);
            Console.WriteLine($"string: {fraction.GetFractionString()}");
            Console.WriteLine($"number: {fraction.GetDecimalValue()}");
        }
    }
}