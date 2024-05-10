using EFCore.BulkExtensions;
using KPACodingProject.Entities;
using KPACodingProject.Models;
using Microsoft.EntityFrameworkCore;
using Airport = KPACodingProject.Entities.Airport;

namespace KPACodingProject.Data;

public class AirportDA : IAirportDA
{
    private readonly AirlinesContext _airlinesContext;

    public AirportDA(AirlinesContext airlinesContext)
    {
        this._airlinesContext = airlinesContext;
    }

    public bool bulkInsertAirport(IEnumerable<Airport> airportRecords)
    {
        List<string> existingAirportCodes = _airlinesContext.Airports.Select(a => a.Code).ToList();
        try
        {
            foreach (Airport a in airportRecords)
            {
                if (!existingAirportCodes.Any(c => c == a.Code))
                {
                    _airlinesContext.Airports.Add(a);
                }
            }
            _airlinesContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            // would have proper logging
            Console.WriteLine(e);
            return false;
        }
        
    }

    public bool bulkInsertCarrier(IEnumerable<Carrier> carrierRecords)
    {
        try
        {
            List<string> existingCarriernames = _airlinesContext.Carriers.Select(a => a.Name).ToList();
            foreach (Carrier c in carrierRecords)
            {
                if (!existingCarriernames.Any(r => r == c.Name))
                {
                    _airlinesContext.Carriers.Add(c);
                }
            }
            this._airlinesContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            // would have proper logging
            Console.WriteLine(e);
            return false;
        }
    }

    public bool bulkInsertFlight(IEnumerable<Flight> flightRecords)
    {
        try
        {
            this._airlinesContext.Flights.AddRange(flightRecords);
            this._airlinesContext.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            // would have proper logging
            Console.WriteLine(e);
            return false;
        }
    }

    public List<Airport> getAirports()
    {
        // Code is a unique column
        return this._airlinesContext.Airports.ToList();
    }
    
    public List<Carrier> getCarrierIdByName(string name)
    {
        // Code is a unique column
        return this._airlinesContext.Carriers.ToList();
    }

    public List<AirportVM> getAirportData()
    {
        return this._airlinesContext.Airports.Include(e => e.Flights)
            .Select(r => new AirportVM
            {
                Id = r.Id,
                Code = r.Code,
                Name = r.Name,
                Flights = r.Flights.Select(f => new FlightsVM
                {
                    Id = f.Id,
                    Cancelled = f.Cancelled,
                    Delayed = f.Delayed,
                    Diverted = f.Diverted,
                    OnTime = f.OnTime,
                    Total = f.Total
                })
                .ToList()
                
            })
            .ToList();
    }

    public bool updateAirline(AirportVM airportVm)
    {
        Airport record = this._airlinesContext.Airports.Find(airportVm.Id);
        if (record != null)
        {
            record.Code = airportVm.Code;
            record.Name = airportVm.Name;
            this._airlinesContext.SaveChanges();
        }
        return true;
    }
}