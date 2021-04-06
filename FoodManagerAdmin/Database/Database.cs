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

        public DataTable table = new DataTable();
        private DataSet set = new DataSet();

        public List<string> list = new List<string>();

        public List<Food> ListFood = new List<Food>();
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
            catch (Exception)
            {
                MessageBox.Show("Дар пайвастшави хатоги мавҷуд");
            }

        }
        public Food GetAllFood()
        {
            string query = "select id,name,price,typesFood,date,descr from food_table";
            using (MySqlCommand cmd = new MySqlCommand())
            {
                conn.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Food food = new Food();
                        food.id = reader.GetUInt16(0);
                        food.name = reader.GetString(1);
                        food.price = reader.GetDouble(2);
                        food.typefood = reader.GetString(3);
                        food.DateTime = reader.GetDateTime(4);
                        food.descr = reader.GetString(5);
                        food.image = reader.GetBytes((byte[]),6);
                      
                        ListFood.Add(food);
                    }
                    
                }
                conn.Close();

            }
            return null;
        }
        public void Create(Model.Food food)
        {
             //TODO:I think you should include conn to using if its possible (using(conn){...})
            using (MySqlCommand cmd = new MySqlCommand())
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO food_table(name, price,descr,typesFood,image,date) VALUES(@name, @price,@descr,@typesFood,@image,@date)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = food.name;
                cmd.Parameters.Add("@price", MySqlDbType.Double).Value = food.price;
                cmd.Parameters.Add("@descr", MySqlDbType.VarChar).Value = food.descr;
                cmd.Parameters.Add("@typesFood", MySqlDbType.VarChar).Value = food.typefood;
                cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = food.image;
                cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = food.DateTime;
                cmd.ExecuteNonQuery();
                conn.Close();

            }

        }

        public void UpdateData(Model.Food food)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                conn.Open();
                cmd.CommandText = "UPDATE food_table SET NAME=@name,price=@price,typesFood=@typesFood,descr=@descr,image=@image WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = food.name;
                cmd.Parameters.Add("@price", MySqlDbType.Int16).Value = food.price;
                cmd.Parameters.Add("@descr", MySqlDbType.VarChar).Value = food.descr;
                cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = food.descr;
                cmd.Parameters.Add("@typesFood", MySqlDbType.VarChar).Value = food.typefood;
                cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = food.id;

                    cmd.ExecuteNonQuery();
                conn.Close();
           }

         }
        public void DeleteData(Model.Food food)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                conn.Open();
                cmd.CommandText = "DELETE from food_table  WHERE id = @id";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@id", MySqlDbType.Int16).Value = food.id;

                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        //public void GetAllFood()
        //{
        //    conn.Open();
        //    table.Clear();

        //    string query = "select id,name,price,typesFood,date,descr,image from food_table";
        //    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
        //    adapter.Fill(set);

        //    table = set.Tables[0];
        //    conn.Close();

        //}

        public void GetTypeFood()
        {
            list.Clear();
            MySqlDataReader reader;
            string query = "select * from types_food";
            using (MySqlCommand cmd = new MySqlCommand())
            {
                conn.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    list.Add(reader[1].ToString());
                }
                conn.Close();
            }
           

        }


    }

    }


