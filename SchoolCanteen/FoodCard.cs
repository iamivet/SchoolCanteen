using SchoolCanteen.Controllers;
using SchoolCanteen.Data;
using System;
using System.Windows.Forms;

namespace SchoolCanteen
{
    public partial class FoodCard : UserControl
    {
        private FoodController foodController = new FoodController();

        public event Action<FoodCard> FoodDeleted;
        public event Action<FoodCard> FoodUpdate;

        public int FoodId { get; set; }

        public FoodCard()
        {
            InitializeComponent();
        }

        private void FoodCard_Load(object sender, EventArgs e)
        {

        }

        public void SetData(Food food)
        {
            this.FoodId = food.Id;
            lblFoodName.Text = food.Name;
            lblCalories.Text = $"{food.Calories} kcal";
            lblPrice.Text = $"{food.Price} lv";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foodController.DeleteFood(this.FoodId);

                FoodDeleted?.Invoke(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtNewName.Text = lblFoodName.Text;
            txtNewCalories.Text=lblCalories.Text.Substring(0, lblCalories.Text.Length - 5);
            txtNewPrice.Text=lblPrice.Text.Substring(0, lblPrice.Text.Length - 3);

            txtNewName.Visible = true;
            txtNewCalories.Visible = true;
            txtNewPrice.Visible = true;
            btnUpdate.Visible = true;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                foodController.EditFood(this.FoodId,txtNewName.Text, txtNewCalories.Text, txtNewPrice.Text);

                FoodUpdate?.Invoke(this);

                txtNewName.Visible = false;
                txtNewCalories.Visible = false;
                txtNewPrice.Visible = false;
                btnUpdate.Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshData(Food food)
        {
            lblFoodName.Text = food.Name;
            lblCalories.Text = $"{food.Calories} kcal";
            lblPrice.Text = $"{food.Price} lv";
        }
    }
}
