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

        public void DeleteFood(int foodId)
        {

            var food = dbContext.Foods.FirstOrDefault(f => f.Id == foodId);
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

        public void EditFood(int foodId,string foodName,string calories,string price)
        {
          
            var food = dbContext.Foods.FirstOrDefault(f => f.Id == foodId);

            if (food != null)
            {
                food.Name = foodName;
                food.Calories = int.Parse(calories);
                food.Price = decimal.Parse(price);

                dbContext.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("Food isn't found");
            }

        }


        public Food GetFoodById(int id)
        {
            var food= dbContext.Foods.AsNoTracking().FirstOrDefault(f => f.Id == id);

            if (food != null)
            {
                return food;
            }
            else
            {
                throw new NullReferenceException("Food isn't found");
            }
        }
    }
}
