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
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(v => v.Id == id);

            if(order == null)
                return HttpNotFound();
            
            return View(order);
        }
        public ActionResult Update(Order order)
        {
            var orderInDb = _dbContext.Orders.SingleOrDefault(v => v.Id == order.Id);
            if (orderInDb == null)
                return HttpNotFound();

            orderInDb.AccountName = order.AccountName;
            orderInDb.PickUpTime = order.PickUpTime;
            orderInDb.Items = order.Items;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(v => v.Id == id);

            if (order == null)
                return HttpNotFound();

            return View(order);
        }
        public ActionResult DoDelete(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(v => v.Id == id);
            if (order == null)
                return HttpNotFound();
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}