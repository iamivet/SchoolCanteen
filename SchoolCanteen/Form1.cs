using SchoolCanteen.Controllers;
using SchoolCanteen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SchoolCanteen
{
    public partial class Form1 : Form
    {
        private FoodTypeController foodTypeController = new FoodTypeController();
        private FoodController foodController = new FoodController();
        public Form1()
        {

            InitializeComponent();
            cmbFoodTypes.DataSource = foodTypeController.GetAllFoodTypes();
            LoadFoodCards();
        }

        private void cmbFoodTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadFoodCards()
        {
            List<Food> foods = foodController.GetFoods();

            foreach (var food in foods)
            {
                FoodCard foodCard = new FoodCard();

                foodCard.Width = 360;
                foodCard.Height = 100;

                foodCard.FoodUpdate += OnFoodUpdate;
                foodCard.FoodDeleted += OnFoodDeleted;


                foodCard.SetData(food);
                flowLayoutPanelFoods.Controls.Add(foodCard);
            }
        }

        private void OnFoodDeleted(FoodCard foodCard)
        {
            flowLayoutPanelFoods.Controls.Remove(foodCard);
            foodCard.Dispose();
        }

        private void OnFoodUpdate(FoodCard foodCard)
        {


            try
            {
                int id = foodCard.FoodId;
                var updatedFood = foodController.GetFoodById(id);

                if (updatedFood != null)
                {
                    foodCard.RefreshData(updatedFood);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
