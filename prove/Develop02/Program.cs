using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");

        bool isRunning = true;

        
        Journal journal = new Journal();

        while (isRunning)
        {
            
            Console.WriteLine(@"
            Please choose one of the following options:
            1. Write
            2. Display
            3. Save
            4. Load
            5. Quit
            ");

            string userInput = Console.ReadLine();
            int choice = int.Parse(userInput);

            if (choice == 1)
            {
                Console.WriteLine("You chose to write.");
                
                Entry entry = new Entry();

                entry.GetDate();
                entry.GiveRandomPrompt();
                entry.GetResponse();

                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                Console.WriteLine("You chose to display.");
                journal.DisplayEntries();

            }
            else if (choice == 3)
            {
                Console.WriteLine("You chose to save.");
                journal.SaveJournal();
                Console.WriteLine("Your journal has been saved.");
            }
            else if (choice == 4)
            {
                Console.WriteLine("You chose to upload.");
                journal.LoadJournal();
            }
            else if (choice == 5)
            {
                Console.WriteLine("You chose to quit.");
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

        }
    }
}