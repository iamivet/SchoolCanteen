using SchoolCanteen.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolCanteen
{
    public partial class FoodCard : UserControl
    {
        public FoodCard()
        {
            InitializeComponent();
        }

        private void FoodCard_Load(object sender, EventArgs e)
        {

        }

        public void SetData(Food food)
        {
            lblFoodName.Text = food.Name;
            lblCalories.Text = $"{food.Calories} kcal";
            lblPrice.Text = $"{food.Price:C}";
        }
    }
}
