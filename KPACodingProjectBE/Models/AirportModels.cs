namespace KPACodingProject.Models
{
    public class AirportData
    {
        public Airport Airport { get; set; }
        public Time Time { get; set; }
        public Statistics Statistics { get; set; }
    }

    public class Airport
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Time
    {
        public string Label { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
    }

    public class Statistics
    {
        public Delays Delays { get; set; }
        public Carriers Carriers { get; set; }
        public Flights Flights { get; set; }
        public MinutesDelayed MinutesDelayed { get; set; }
    }

    public class Delays
    {
        public int Carrier { get; set; }
        public int LateAircraft { get; set; }
        public int NationalAviationSystem { get; set; }
        public int Security { get; set; }
        public int Weather { get; set; }
    }

    public class Carriers
    {
        public string Names { get; set; }
        public int Total { get; set; }
    }

    public class Flights
    {
        public int Cancelled { get; set; }
        public int Delayed { get; set; }
        public int Diverted { get; set; }
        public int OnTime { get; set; }
        public int Total { get; set; }
    }

    public class MinutesDelayed
    {
        public int Carrier { get; set; }
        public int LateAircraft { get; set; }
        public int NationalAviationSystem { get; set; }
        public int Security { get; set; }
        public int Total { get; set; }
        public int Weather { get; set; }
    }
}