using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KPACodingProject.Models;

namespace KPACodingProject.Entities
{
    [Table("Airport")]
    public class Airport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Flight> Flights { get; set; }
    }
}