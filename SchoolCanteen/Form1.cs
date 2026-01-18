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

            LoadFoodTypes();
            cmbFoodTypes.DisplayMember = "Name";
            cmbFoodTypes.ValueMember = "Id";
            
            LoadFoodCards();
        }

        private void LoadFoodTypes()
        {
            cmbFoodTypes.DataSource = foodTypeController.GetAllFoodTypes();
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

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            flowLayoutPanelFoods.Visible = false;
            btnAddFood.Visible = false;

            lblCalories.Visible = true;
            lblName.Visible = true;
            lblPrice.Visible = true;
            lblType.Visible = true;

            cmbFoodTypes.Visible = true;

            txtCalories.Visible = true;
            txtName.Visible = true;
            txtPrice.Visible = true;

            btnAdd.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Въведете име!");
                    txtName.Focus();
                    return;
                }

                if (cmbFoodTypes.SelectedItem == null)
                {
                    MessageBox.Show("Моля изберете тип храна!");
                    return;
                }
                if (!int.TryParse(txtCalories.Text, out int calories))
                {
                    MessageBox.Show("Моля въведете валидни калории!");
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Моля въведете валидна цена!");
                    return;
                }

                foodController.AddFood(txtName.Text, calories, price, (foodTypeController.GetById((int)cmbFoodTypes.SelectedValue).Id));

                LoadFoodCards();


                flowLayoutPanelFoods.Visible = true;
                btnAddFood.Visible = true;

                lblCalories.Visible = false;
                lblName.Visible = false;
                lblPrice.Visible = false;
                lblType.Visible = false;

                cmbFoodTypes.Visible = false;

                txtCalories.Visible = false;
                txtName.Visible = false;
                txtPrice.Visible = false;

                btnAdd.Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
