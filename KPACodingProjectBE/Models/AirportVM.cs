
namespace KPACodingProject.Models;

public class AirportVM
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public List<FlightsVM> Flights { get; set; }
}

public class FlightsVM
{
    public int Id { get; set; }
    public int Cancelled { get; set; }
    public int Delayed { get; set; }
    public int Diverted { get; set; }
    public int OnTime { get; set; }
    public int Total { get; set; }
}
