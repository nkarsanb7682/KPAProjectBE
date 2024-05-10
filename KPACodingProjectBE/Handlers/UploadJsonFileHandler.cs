using KPACodingProject.Data;
using KPACodingProject.Entities;
using KPACodingProject.Models;
using Newtonsoft.Json;
using Airport = KPACodingProject.Entities.Airport;

namespace KPACodingProject.Handlers;

public class UploadJsonFileHandler : IUploadJsonFileHandler
{
    private IAirportDA _airportDa;

    public UploadJsonFileHandler(IAirportDA airportDa)
    {
        this._airportDa = airportDa;
    }

    public bool bulkUploadAirportData(IFormFile airports)
    {
        Stream airportsStream = airports.OpenReadStream();
        StreamReader airportReader = new StreamReader(airportsStream);
        string airportJsonString = airportReader.ReadToEnd();
        IEnumerable<AirportData> airportDataModel = JsonConvert.DeserializeObject<IEnumerable<AirportData>>(airportJsonString);
        IEnumerable<Airport> airportRecords = airportToEntity(airportDataModel);
        this._airportDa.bulkInsertAirport(airportRecords);
        IEnumerable<Carrier> carrierRecords = carrierToEntity(airportDataModel);
        this._airportDa.bulkInsertCarrier(carrierRecords);
        IEnumerable<Flight> flightRecords = flightToEntity(airportDataModel);
        this._airportDa.bulkInsertFlight(flightRecords);
        return true;
    }

    private IEnumerable<Airport> airportToEntity(IEnumerable<AirportData> airportDataModel)
    {
        IEnumerable<Airport> result =
            from a in airportDataModel
            select new Airport
            {
                Code = a.Airport.Code,
                Name = a.Airport.Name
            };
        IEnumerable<Airport> destinctAirports =
            from r in result
            group r by r.Code
            into groupedAirports
            select groupedAirports.First();
        return destinctAirports;
    }
    
    private IEnumerable<Carrier> carrierToEntity(IEnumerable<AirportData> airportDataModel)
    {
        IEnumerable<Carrier> result =
            from a in airportDataModel
            from n in a.Statistics.Carriers.Names.Split(',')
            select new Carrier
            {
                Name = n
            };
        IEnumerable<Carrier> distinctCarriers =
            from r in result
            group r by r.Name
            into groupedCarriers
            select groupedCarriers.First();
        return distinctCarriers;
    }

    private IEnumerable<Flight> flightToEntity(IEnumerable<AirportData> airportDataModel)
    {
        List<Airport> airports = _airportDa.getAirports();
        IEnumerable<Flight> result =
            from a in airportDataModel
            select new Flight
            {
                Cancelled = a.Statistics.Flights.Cancelled,
                Delayed = a.Statistics.Flights.Delayed,
                Diverted = a.Statistics.Flights.Diverted,
                OnTime = a.Statistics.Flights.OnTime,
                Total = a.Statistics.Flights.Total,
                AirportId = airports.Where(r => r.Code == a.Airport.Code).Select(r => r.Id).FirstOrDefault()
            };
        return result;

    }
}