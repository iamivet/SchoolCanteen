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

        public List<FoodType> GetAllFoodTypes()
        {
            return dbContext.FoodTypes
                .ToList();
        }

        public FoodType GetById(int id)
        {
            return dbContext.FoodTypes.Find(id);
        }
    }
}
