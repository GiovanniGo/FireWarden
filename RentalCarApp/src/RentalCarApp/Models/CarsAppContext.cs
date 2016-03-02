using Microsoft.Data.Entity;

namespace RentalCarApp.Models
{
    public class CarsAppContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
