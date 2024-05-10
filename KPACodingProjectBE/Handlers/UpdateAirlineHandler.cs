using KPACodingProject.Data;
using KPACodingProject.Models;

namespace KPACodingProject.Handlers;

public class UpdateAirlineHandler : IUpdateAirlineHandler
{
    private IAirportDA _airportDa;

    public UpdateAirlineHandler(IAirportDA airportDa)
    {
        this._airportDa = airportDa;
    }

    public bool updateAirline(AirportVM airportVm)
    {
        return _airportDa.updateAirline(airportVm);
    }
}