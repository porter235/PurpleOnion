using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PurpleOnion.Models;

namespace PurpleOnion.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _dbContext;

        public OrdersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Orders
        public ActionResult Index()
        {
            var orders = _dbContext.Orders.ToList();
            return View(orders);
        }
    }
}