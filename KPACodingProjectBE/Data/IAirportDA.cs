using KPACodingProject.Entities;
using KPACodingProject.Models;
using Airport = KPACodingProject.Entities.Airport;

namespace KPACodingProject.Data;

public interface IAirportDA
{
    public bool bulkInsertAirport(IEnumerable<Airport> airportRecords);
    public bool bulkInsertCarrier(IEnumerable<Carrier> carrierRecords);
    public bool bulkInsertFlight(IEnumerable<Flight> flightRecords);
    List<Airport> getAirports();
    public List<Carrier> getCarrierIdByName(string name);
    List<AirportVM> getAirportData();
    public bool updateAirline(AirportVM airportVm);
}