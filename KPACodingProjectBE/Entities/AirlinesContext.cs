using KPACodingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace KPACodingProject.Entities
{
    public class AirlinesContext : DbContext
    {
        public AirlinesContext(DbContextOptions<AirlinesContext> options) : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Airport_Carrier> Airport_Carriers { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}