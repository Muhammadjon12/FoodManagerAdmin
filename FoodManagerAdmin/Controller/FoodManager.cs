using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodManagerAdmin.Model;

namespace FoodManagerAdmin.Controller
{
    class FoodManager
    {
        private Database.Database database = new Database.Database();

        public void Add(string name, double price, string descr, string typefood,Byte[] img, DateTime dateTime)
        {
            Food food = new Food();
            try
            {
                food.Name = name;
                food.Price = price;
                food.Descr = descr;
                food.Typefood = typefood;
                food.Image = img;
                food.DateTime = dateTime;
                database.SaveFood(food);

                MessageBox.Show("Бо мувофақият сабт шуд");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }
        public void UpdateFood(int id,string name, double price, string typefood, string descr,byte[] image)
        {
            if(id != 0 && name !="" && price != 0 && typefood !="" && descr != "")
            {
                database.UpdateFood(id, name, price, typefood, descr,image);
            }
            else
            {
                MessageBox.Show("Ҷойхои мавҷуд");
            }
               
        }
        public void DeleteFood(int id)
        {
            if (id > 0)
            {
                database.DeleteFoodByID(id);
            }
                
        }

        public List<string> GetFoodTypes()

        {
          List<string> list = database.GetFoodTypes();
            return list;
        }
        public List<Food> GetAllFood()
        {
            List<Food> getListFood = database.GetAllFood();
            return getListFood;
        }
       
    }
}

