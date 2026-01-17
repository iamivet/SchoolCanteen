using System.Data.Entity;

namespace SchoolCanteen.Data
{
    public class SchoolCanteenDbContext : DbContext
    {
        public SchoolCanteenDbContext() : base("name=SchoolCanteenDbConnectionString")
        {
        }
        
            
        
    }
}
