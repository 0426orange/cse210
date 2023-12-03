using System;
using System.Threading;

public class MindfulnessProgram
{
    private int countdownSeconds = 5; // Default countdown time

    public void StartBreathingActivity()
    {
        Console.WriteLine("Breathing Activity: Take a deep breath in and out.");
        CountdownAnimation();
    }

    public void StartReflectionActivity()
    {
        Console.WriteLine("Reflection Activity: Think deeply about a meaningful experience.");
        CountdownAnimation();
    }

    public void StartListingActivity()
    {
        Console.WriteLine("Listing Activity: List as many positive things as you can.");
        CountdownAnimation();
    }

    private void CountdownAnimation()
    {
        Console.WriteLine($"Get ready... Starting in {countdownSeconds} seconds.");
        for (int i = countdownSeconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine("\nActivity started!\n");
        // Add logic for the respective activity here
    }
}

class Program
{
    static void Main()
    {
        MindfulnessProgram mindfulnessProgram = new MindfulnessProgram();

        while (true)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Select an option (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    mindfulnessProgram.StartBreathingActivity();
                    break;
                case "2":
                    mindfulnessProgram.StartReflectionActivity();
                    break;
                case "3":
                    mindfulnessProgram.StartListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
