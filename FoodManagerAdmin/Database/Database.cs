using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using FoodManagerAdmin.Model;

namespace FoodManagerAdmin.Database
{
    class Database
    {
        public MySqlConnection conn;
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        public DataTable table = new DataTable();

        private List<string> list = new List<string>();
        private List<Food> ListFood = new List<Food>();
        public Database()
        {
            try
            {
                string host = "localhost";
                int port = 3306;
                string database = "food";
                string username = "root";
                string password = "";
                String connString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
                conn = new MySqlConnection(connString);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Дар пайвастшави хатоги мавҷуд"+ex.Message);
            }
        }
        public List<Food> GetAllFood()
        {
            ListFood.Clear();
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("select id,name,price,typesFood,date,descr,image from food_table", conn))
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Food food = new Food();
                        food.Id = reader.GetUInt16(0);
                        food.Name = reader.GetString(1);
                        food.Price = reader.GetDouble(2);
                        food.Typefood = reader.GetString(3);
                        food.DateTime = reader.GetDateTime(4);
                        food.Descr = reader.GetString(5);

                        food.Image = (byte[])reader["image"];

                        ListFood.Add(food);
                    }
                    conn.Close();
                    return ListFood;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return null;

        }

        public void SaveFood(Food food)
        {
            try
            {   
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO food_table(name, price,typesFood,image,date,descr) VALUES(@name, @price,@typesFood,@image,@date,@descr)", conn))
                { 
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = food.Name;
                    cmd.Parameters.Add("@price", MySqlDbType.Double).Value = food.Price;
                    cmd.Parameters.Add("@descr", MySqlDbType.VarChar).Value = food.Descr;
                    cmd.Parameters.Add("@typesFood", MySqlDbType.VarChar).Value = food.Typefood;
                    cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = food.Image;
                    cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = food.DateTime;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }


        }
        public void UpdateFood(int id, string name, Double price, string typefood, string descr, byte[] image)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("UPDATE food_table SET name=@name,price=@price,typesFood=@typesFood,descr=@descr,image=@image WHERE id = @id", conn))
                {
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@price", MySqlDbType.Int16).Value = price;
                    cmd.Parameters.Add("@descr", MySqlDbType.VarChar).Value = descr;
                    cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
                    cmd.Parameters.Add("@typesFood", MySqlDbType.VarChar).Value = typefood;
                    cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
        public void DeleteFoodByID(int id)
        {
            try
            {
              using (MySqlCommand cmd = new MySqlCommand("DELETE from food_table  WHERE id = @id", conn))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = id;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public List<string> GetFoodTypes()
        {
            try
            {
                list.Clear();

                using (MySqlCommand cmd = new MySqlCommand("select * from types_food", conn))
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(reader[1].ToString());
                    }

                    conn.Close();
                    return list;
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message+"\n Ба база пайваст нест");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return null;
        }
    }
}


