using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Choose one of the following activities:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
        int choice = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the duration for the activity in seconds:");
        int duration = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            BreathingActivity breathingActivity = new BreathingActivity(duration);
            Console.Clear();
            breathingActivity.Run();
        }
        else if (choice == 2)
        {
            ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
            Console.Clear();
            reflectionActivity.Run();
        }
        else if (choice == 3)
        {
            ListingActivity listingActivity = new ListingActivity(duration);
            Console.Clear();
            listingActivity.Run();
        }
        else if (choice == 4)
        {
            Console.WriteLine("Exiting the program.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

    }
}