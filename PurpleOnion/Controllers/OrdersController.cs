using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PurpleOnion.Models;
using System.Net.Mail;

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
        [Authorize(Roles = "User, Employee, Admin")]
        public ActionResult New()
        {
            return View();
        }
        [Authorize(Roles = "User, Employee, Admin")]
        public ActionResult Add(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return RedirectToAction("OrderConfirm");
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
        public ActionResult OrderConfirm()
        {
            SendEmail(User.Identity.Name);
            //return RedirectToAction("Index", "Surveys");


            

            return View();




        }
        public void SendEmail(string email)
        {
            string x = "purpleonionwv@gmail.com";//User.Identity.Name; //This will be the string that needs to be replaced
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            //     mail.To.Add("Another Email ID where you wanna send same email");
            mail.From = new MailAddress("purpleonionwv@gmail.com");
            mail.Subject = "Order Confirmation";

            string Body = "Hello! We have recieved your order and should have it ready to be picked up";
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("purpleonionwv@gmail.com", "farmfreshgoods!");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e) { }
        }
    }
}