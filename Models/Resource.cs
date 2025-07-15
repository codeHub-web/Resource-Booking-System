using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Internal_Resource_Booking_System.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ResourceName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
