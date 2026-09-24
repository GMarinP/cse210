using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        Console.WriteLine("Enter a list of numbers");
        Console.WriteLine("Enter number: ");
        int number = int.Parse(Console.ReadLine());

        List<int> numbers_list = new List<int>();

        while (number != 0)
        {
            Console.WriteLine("Enter number: ");
            number = int.Parse(Console.ReadLine());
            numbers_list.Add(number);
        }

        if (number == 0)
        {
            int sum = 0;

            // sum
            foreach (int num in numbers_list)
            {
                sum += num;
            }
            Console.WriteLine($"Sum: {sum}");

            // average
            int average = sum / numbers_list.Count;
            Console.WriteLine($"Average: {average}");

            // largest
            int largest = numbers_list[0];

            foreach (int num in numbers_list)
            {
                if (num > largest)
                {
                    largest = num;
                }
            }
            Console.WriteLine($"Largest: {largest}");
        }

        
        
    }
}