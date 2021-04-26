using KinderG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace KinderG.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(Product usr)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");

                var responseTask = client.PutAsJsonAsync(string.Format("director/updateProduct/", usr.id), usr);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = string.Format("User: {0} is successfully edited", usr.id);
                    TempData["SuccessMessage"] = string.Format("User: {0} is successfully edited", usr.nomProd);
                }
                else
                {

                }
                return View(usr);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("director/deleteProduct/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    TempData["msg"] = "<script>alert('Change succesfully');</script>";
                }
            }

            return RedirectToAction("ListUsers");
        }
        public ActionResult ListUsers()
        {

            IList<Product> usr = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                var responseTask = client.GetAsync("director/getAllProduct");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {


                    var readJob = result.Content.ReadAsAsync<IList<Product>>();
                    //readJob.Wait();
                    usr = readJob.Result;

                }
            }
            return View(usr);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

     
       

       

    }
}
