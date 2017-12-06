using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurpleOnion.Models
{
    public class CartSystem
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public List<String> Items {get; set;}

    }
}