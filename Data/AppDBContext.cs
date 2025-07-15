using Internal_Resource_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Internal_Resource_Booking_System.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) //This class facilitates communication between entity framework and DB Server
        {
        
        }
        public virtual DbSet<Resource> Resources {  get; set; } //These are mapped as tables in the database
        public virtual DbSet<Booking> Bookings { get; set; }

    }
}
