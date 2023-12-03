using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public string Reference { get; }
    public string Text { get; }
    private List<string> hiddenWords;

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
        hiddenWords = Text.Split(' ').ToList();
    }

    public void HideWords(int count)
    {
        if (count >= hiddenWords.Count)
        {
            Console.WriteLine("All words are hidden. Memorization complete!");
            return;
        }

        int wordsToHide = Math.Min(count, hiddenWords.Count);
        int startIndex = hiddenWords.Count - wordsToHide;

        for (int i = startIndex; i < hiddenWords.Count; i++)
        {
            hiddenWords[i] = new string('*', hiddenWords[i].Length);
        }

        DisplayScripture();
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine($"{Reference}:");
        Console.WriteLine(string.Join(" ", hiddenWords));
        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
    }
}

class Program
{
    static void Main()
    {
        // Example usage
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            scripture.DisplayScripture();

            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                break;
            }
            else if (input == "")
            {
                scripture.HideWords(2); // Adjust the number of words to hide
            }
        }

        Console.WriteLine("Program ended.");
    }
}
