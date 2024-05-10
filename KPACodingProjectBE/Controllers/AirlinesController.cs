using System.Text.Json.Serialization;
using KPACodingProject.Entities;
using KPACodingProject.Handlers;
using KPACodingProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KPACodingProject.Controllers;

[ApiController]
[Route("api/airlines")]
public class AirlinesController : ControllerBase
{
    private readonly AirlinesContext _airlinesContext; // registered as scoped service in Program.cs
    private IUploadJsonFileHandler _uploadJsonFileHandler;
    private IGetAirportDataHandler _getAirportDataHandler;
    private IUpdateAirlineHandler _updateAirlineHandler;
    
    public AirlinesController(AirlinesContext airlinesContext,
        IUploadJsonFileHandler uploadJsonFileHandler,
        IGetAirportDataHandler getAirportDataHandler,
        IUpdateAirlineHandler updateAirlineHandler)
    {
        this._airlinesContext = airlinesContext;
        this._uploadJsonFileHandler = uploadJsonFileHandler;
        this._getAirportDataHandler = getAirportDataHandler;
        this._updateAirlineHandler = updateAirlineHandler;
    }
    
    [HttpPost(nameof(uploadJsonFile))]
    [EnableCors("airportDataPolicy")]
    public ActionResult<List<AirportData>> uploadJsonFile([FromForm] IFormFile airports)
    {
        try
        {
            this._uploadJsonFileHandler.bulkUploadAirportData(airports);
            return Ok(new { message = "File Uploaded Successfully" });
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        catch (JsonSerializationException e)
        {
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        catch (Exception e)
        {
            // Would use proper logging here. Logger would be a singleton
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet(nameof(getAirportData))]
    [EnableCors("airportDataPolicy")]
    public ActionResult<List<AirportVM>> getAirportData()
    {
        try
        {
            List<AirportVM> airportVm = _getAirportDataHandler.getAirportData();
            return Ok(airportVm);
        }
        catch (Exception e)
        {
            // Would use proper logging here. Logger would be a singleton
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut(nameof(updateAirline))]
    [EnableCors("airportDataPolicy")]
    public ActionResult<bool> updateAirline(AirportVM airportVm)
    {
        try
        {
            bool result = this._updateAirlineHandler.updateAirline(airportVm);
            return Ok(new { message = result });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut(nameof(updateFlight))]
    [EnableCors("airportDataPolicy")]
    public ActionResult<bool> updateFlight(FlightsVM flightsVm)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);   
    }
    
}