using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagerAdmin.Model
{
  public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Typefood { get; set; }
        public DateTime DateTime { get; set; }
        public string Descr { get; set; }
        public Byte[] Image { get; set; }
    }
}
