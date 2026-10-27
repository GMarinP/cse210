using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(
            reference,
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press Enter to hide words or type quit: ");
            string response = Console.ReadLine();

            if (response.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

}
