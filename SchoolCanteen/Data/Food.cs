using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCanteen.Data
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public decimal Price { get; set; }
        public int FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
    }
}
