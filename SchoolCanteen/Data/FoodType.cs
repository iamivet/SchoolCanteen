using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolCanteen.Data
{
    public class FoodType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
