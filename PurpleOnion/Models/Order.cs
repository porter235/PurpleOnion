using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurpleOnion.Models
{
    public class Order
    {
        public int Id { get; set; }
        public String AccountName { get; set; }
        public String PickUpTime { get; set; }
        public String Items { get; set; }
    }
}