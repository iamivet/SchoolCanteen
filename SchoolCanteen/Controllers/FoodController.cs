using SchoolCanteen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCanteen.Controllers
{
    public class FoodController
    {
        private SchoolCanteenDbContext dbContext;

        public FoodController()
        {
            dbContext = new SchoolCanteenDbContext();
        }

        public List<Food> GetFoods()
        {
            return dbContext.Foods.ToList();
        }

        public void DeleteFood(string foodName)
        {
            var food = dbContext.Foods.FirstOrDefault(f => f.Name == foodName);
            if (food != null)
            {
                dbContext.Foods.Remove(food);
                dbContext.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("Food isn't found");
            }
        }
    }
}
