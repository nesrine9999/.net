using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using KinderG.Models;

namespace KinderG.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListOrder()
        {

            IList<Order> usr = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                var responseTask = client.GetAsync("director/getAllOrder");
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {


                    var readJob = result.Content.ReadAsAsync<IList<Order>>();
                    //readJob.Wait();
                    usr = readJob.Result;

                }
            }
            return View(usr);
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("director/deleteOrder/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    TempData["msg"] = "<script>alert('Change succesfully');</script>";
                }
            }

            return RedirectToAction("ListOrder");
        }
    }
    
    
}