using KPACodingProject.Models;

namespace KPACodingProject.Handlers;

public interface IUpdateAirlineHandler
{
    public bool updateAirline(AirportVM airportVm);
}