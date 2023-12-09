using System;
using System.Collections.Generic;

class Activity
{
    private string activityType;
    private string activityDate;
    private int activityLength;

    public Activity(string type, string date, int length)
    {
        activityType = type;
        activityDate = date;
        activityLength = length;
    }

    public virtual double GetDistance()
    {
        return 0.0;
    }

    public virtual double GetSpeed()
    {
        return 0.0;
    }

    public virtual double GetPace()
    {
        return 0.0;
    }

    public virtual string GetSummary()
    {
        return $"{activityDate} {activityType} ({activityLength} min)";
    }
}

class Running : Activity
{
    private double distance;

    public Running(string date, int length, double distance)
        : base("Running", date, length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (activityLength / 60.0);
    }

    public override double GetPace()
    {
        return activityLength / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Cycling : Activity
{
    private double speed;

    public Cycling(string date, int length, double speed)
        : base("Cycling", date, length)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60.0 / speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {speed} mph, Pace: {GetPace()} min per mile";
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(string date, int length, int laps)
        : base("Swimming", date, length)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        // Assuming the length of each lap is 50 meters
        return laps * 50 / 1000.0; // Convert meters to kilometers
    }

    public override double GetPace()
    {
        return activityLength / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance():F2} km, Pace: {GetPace():F2} min per km";
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("2023-11-01", 30, 3.5),
            new Cycling("2023-11-05", 45, 15.0),
            new Swimming("2023-11-10", 20, 10)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

