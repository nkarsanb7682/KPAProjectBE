using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KPACodingProject.Entities
{
    [Table("Airport_Carrier")]
    [PrimaryKey(nameof(Airport_Id), nameof(Carrier_Id))]
    public class Airport_Carrier
    {
        [ForeignKey("Airport")]
        public int Airport_Id { get; set; }
        
        [ForeignKey("Carrier")]
        public int Carrier_Id { get; set; }

        public Airport Airport { get; set; }
        public Carrier Carrier { get; set; }
    }
}