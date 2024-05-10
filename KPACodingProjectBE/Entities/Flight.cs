using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPACodingProject.Entities
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Cancelled { get; set; }

        [Required]
        public int Delayed { get; set; }

        [Required]
        public int Diverted { get; set; }

        [Required]
        public int OnTime { get; set; }

        [Required]
        public int Total { get; set; }

        [ForeignKey("Airport")]
        public int AirportId { get; set; }

        public Airport Airport { get; set; }
    }
}