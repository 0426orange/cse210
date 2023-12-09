using System;

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
}

class Event
{
    private string eventTitle;
    private string eventDescription;
    private string eventDate;
    private string eventTime;
    private Address eventAddress;

    public Event(string title, string description, string date, string time, Address address)
    {
        eventTitle = title;
        eventDescription = description;
        eventDate = date;
        eventTime = time;
        eventAddress = address;
    }

    public string GenerateStandardMessage()
    {
        return $"Standard details:\nTitle: {eventTitle}\nDescription: {eventDescription}\nDate: {eventDate}\nTime: {eventTime}\nAddress: {eventAddress.Street}, {eventAddress.City}, {eventAddress.State} {eventAddress.ZipCode}";
    }

    public virtual string GenerateFullMessage()
    {
        return GenerateStandardMessage();
    }

    public string GenerateShortDescription()
    {
        return $"Short description:\nType: {GetType().Name}\nTitle: {eventTitle}\nDate: {eventDate}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity} attendees";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main()
    {
        Address eventAddress = new Address("123 Main St", "Cityville", "State", "12345");

        Event lecture = new Lecture("Programming Lecture", "Learn about coding", "2023-11-10", "18:00", eventAddress, "John Doe", 50);
        Event reception = new Reception("Networking Reception", "Connect with professionals", "2023-11-15", "19:30", eventAddress, "rsvp@example.com");
        Event outdoorGathering = new OutdoorGathering("Community Picnic", "Enjoy food and games", "2023-11-20", "12:00", eventAddress, "Sunny");

        Console.WriteLine(lecture.GenerateFullMessage());
        Console.WriteLine(reception.GenerateFullMessage());
        Console.WriteLine(outdoorGathering.GenerateFullMessage());

        Console.WriteLine("\nShort Descriptions:");
        Console.WriteLine(lecture.GenerateShortDescription());
        Console.WriteLine(reception.GenerateShortDescription());
        Console.WriteLine(outdoorGathering.GenerateShortDescription());
    }
}
