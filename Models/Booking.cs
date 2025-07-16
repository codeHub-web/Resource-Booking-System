using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal_Resource_Booking_System.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
       
        public int ResourceId { get; set; }

        [ForeignKey("ResourceId")]
        [Required]
        public Resource Resource { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string BookedBy {  get; set; }

        [Required]
        public string Purpose {  get; set; }
    }



}
