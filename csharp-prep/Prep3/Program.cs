using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);
        Console.WriteLine("What is your guess from 1-100? ");
        int guess = int.Parse(Console.ReadLine());

       
        while (guess != number)
        {   
            
            if (guess > number)
            {
                Console.WriteLine("Lower");
                Console.WriteLine("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
                Console.WriteLine("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Please enter a valid input.");
                Console.WriteLine("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
            }
        
        }

         if (guess == number)
        {
            Console.WriteLine("You guessed it!");
        }
    }
}