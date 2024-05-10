namespace KPACodingProject.Handlers;

public interface IUploadJsonFileHandler
{
    public bool bulkUploadAirportData(IFormFile airports);
}