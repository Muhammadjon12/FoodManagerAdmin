using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagerAdmin.Model
{
  public class Food
    {
        //TODO:Use capital letter for properties
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string typefood { get; set; }
        public DateTime DateTime { get; set; }
        public string descr { get; set; }
        //TODO:Rename to FoodType (You can use Enum if you want)
        public string typefood { get; set; }
        public Byte[] image { get; set; }
    }
}
