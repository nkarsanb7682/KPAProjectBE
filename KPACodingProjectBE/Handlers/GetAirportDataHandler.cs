using KPACodingProject.Data;
using KPACodingProject.Models;

namespace KPACodingProject.Handlers;

public class GetAirportDataHandler : IGetAirportDataHandler
{
    private IAirportDA _airportDa;

    public GetAirportDataHandler(IAirportDA airportDa)
    {
        this._airportDa = airportDa;
    }
    
    public List<AirportVM> getAirportData()
    {
        return this._airportDa.getAirportData();
    }
}