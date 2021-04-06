using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagerAdmin.Model
{
  public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string typefood { get; set; }
        public DateTime DateTime { get; set; }
        public string descr { get; set; }
        public Byte[] image { get; set; }
    }
}
