using SchoolCanteen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCanteen.Controllers
{
    public class FoodTypeController
    {
        private SchoolCanteenDbContext dbContext;

        public FoodTypeController()
        {
            dbContext = new SchoolCanteenDbContext();
        }

        public List<string> GetAllFoodTypes()
        {
            return dbContext.FoodTypes
                .Select(f => f.Name)
                .ToList();
        }
    }
}
