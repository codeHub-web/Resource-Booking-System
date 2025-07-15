using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Internal_Resource_Booking_System.Data
{
    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {   
                                                        // Loads configuration from appsettings.json file
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("ConnectionToDbServer");

            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            //used to generate migrations and apply them to DB
            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
