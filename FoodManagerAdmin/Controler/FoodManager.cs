using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoodManagerAdmin.Model;

namespace FoodManagerAdmin.Controler
{
//TODO:Rename Controler to Controller (double "L")
//TODO:Remove empty lines please.

    class FoodManager
    {
        private Database.Database database = new Database.Database();

    //TODO: Please name methods with capital letter
        public void add(string name, double price, string descr, string typefood,Byte[] img, DateTime dateTime)
        {

            Food food = new Food();
            try
            {
                food.name = name;
                food.price = price;
                food.descr = descr;
                food.typefood = typefood;
                food.image = img;
                food.DateTime = dateTime;
                database.Create(food);

                MessageBox.Show("Бо мувофақият сабт шуд");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }
        //TODO: Please rename method to more meaningful name
        public void DataUpdate(int id,string name, double price, string descr, string typefood,byte[] image)
        {
//TODO: make some validation before passing data to the database

            Food food = new Food();

            try
            {
                food.id = id;
                food.name = name;
                food.price = price;
                food.descr = descr;
                food.typefood = typefood;
                food.image = image;

                database.UpdateData(food);
                MessageBox.Show("Бо мувофақият Ислох шуд");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }
        
        public void ClearData(int id)
        {

           Food food = new Food();
            try
            {
                food.id = id;

                database.DeleteData(food);
                MessageBox.Show("Бо мувофақият Хориҷ шуд");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }

    

        //public object  ReadData()
        //{

        //    database.ReadData();
        //    object _table = database.table;
        //    return _table;
        //}

        public List<string> ShowFoodTypes()

        {
            database.GetTypeFood();
          List<string> list =  database.list;
            return list;
        }

        public List<Food> GetAllData()
        {
            database.GetAllFood();
          List<Food> _GetAllFood =  database.ListFood;
            return _GetAllFood;
        }
       
    }
}

