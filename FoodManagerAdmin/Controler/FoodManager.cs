using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodManagerAdmin.Controler
{
    class FoodManager
    {
        private Database.Database database = new Database.Database();

    
        public void add(string name, double price, string descr, string typefood,Byte[] img, DateTime dateTime)
        {

            Model.Food food = new Model.Food();
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
        public void DataUpdate(int id,string name, double price, string descr, string typefood,byte[] image)
        {

            Model.Food food = new Model.Food();
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

            Model.Food food = new Model.Food();
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
        public object  ReadData()
        {

            database.ReadData();
            object _table = database.table;
            return _table;
        }

        public List<string> ShowTypeFood()
        {
            database.GetTypeFood();
          List<string> list =  database.list;
            return list;
        }
       
    }
}

