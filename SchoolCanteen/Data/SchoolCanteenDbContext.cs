using System.Data.Entity;

namespace SchoolCanteen.Data
{
    public class SchoolCanteenDbContext : DbContext
    {
        public SchoolCanteenDbContext() : base("name=SchoolCanteenDbConnectionString")
        {
        }
        
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }

    }
}
