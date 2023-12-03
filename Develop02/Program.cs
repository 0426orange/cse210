using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(string prompt, string response, string date)
    {
        JournalEntry entry = new JournalEntry(prompt, response, date);
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}\n");
        }
    }

    public List<JournalEntry> GetEntries()
    {
        return entries;
    }

    public void SetEntries(List<JournalEntry> newEntries)
    {
        entries = newEntries;
    }
}

class FileManager
{
    public void SaveJournalToFile(string fileName, List<JournalEntry> entries)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
    }

    public List<JournalEntry> LoadJournalFromFile(string fileName)
    {
        List<JournalEntry> loadedEntries = new List<JournalEntry>();
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string date = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];
                        loadedEntries.Add(new JournalEntry(prompt, response, date));
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Creating a new journal.");
        }
        return loadedEntries;
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        FileManager fileManager = new FileManager();
        string fileName = "journal.txt";

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select a prompt or enter your own:");
                        string prompt = Console.ReadLine();
                        Console.WriteLine("Enter your response:");
                        string response = Console.ReadLine();
                        DateTime currentDate = DateTime.Now;
                        journal.AddEntry(prompt, response, currentDate.ToString("yyyy-MM-dd"));
                        break;

                    case 2:
                        journal.DisplayJournal();
                        break;

                    case 3:
                        fileManager.SaveJournalToFile(fileName, journal.GetEntries());
                        Console.WriteLine("Journal saved to file.");
                        break;

                    case 4:
                        Console.WriteLine("Enter the name of the file to load:");
                        string loadFileName = Console.ReadLine();
                        journal.SetEntries(fileManager.LoadJournalFromFile(loadFileName));
                        Console.WriteLine("Journal loaded from file.");
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
