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

        [Authorize(Roles = "Admin, Employee")]

        public ActionResult Index()
        {
            var orders = _dbContext.Orders.ToList();
            return View(orders);
        }
        [Authorize(Roles = "User")]
        public ActionResult New()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public ActionResult Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Edit(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(v => v.Id == id);


            if (order == null)
                return HttpNotFound();

            return View(order);
        }
        //[Authorize(Roles = "Admin, Employee, User")]
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
        [Authorize(Roles = "Admin, Employee")]
        public ActionResult Delete(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(v => v.Id == id);

            if (order == null)
                return HttpNotFound();

            return View(order);
        }
        //[Authorize(Roles = "Admin, Employee")]
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