using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurpleOnion.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Brand { get; set; }
        public Type Type { get; set; }
        public Stock Stock { get; set; }
        public String Price { get; set; }  
    }
    public enum Stock
    {
        Low,
        Medium,
        High
    }

    public enum Type
    {
        Produce,
        Jarred,
        Boxed
    }
}