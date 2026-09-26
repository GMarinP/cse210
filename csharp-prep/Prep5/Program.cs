using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int userBirthYear = PromptUserBirthYear();

        int squareNumber = SquareNumber(userNumber);
        
        DisplayResult(userName, squareNumber, userBirthYear);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }
    static int PromptUserBirthYear()
    {
        Console.Write("Please enter the year you were born: ");
        int userBirthYear = int.Parse(Console.ReadLine());
        return userBirthYear;
    }
    static int SquareNumber(int number)
    {
        return number * number;
    }
    static void DisplayResult(string userName, int squareNumber, int userBirthYear)
    {
        Console.WriteLine($"{userName}, the square of your number is {squareNumber}");
        int age = 2026 - userBirthYear;
        Console.WriteLine($"{userName}, you will turn {age} this year.");
    }
}