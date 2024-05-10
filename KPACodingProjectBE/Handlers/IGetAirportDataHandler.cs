using KPACodingProject.Models;

namespace KPACodingProject.Handlers;

public interface IGetAirportDataHandler
{
    public List<AirportVM> getAirportData();
}