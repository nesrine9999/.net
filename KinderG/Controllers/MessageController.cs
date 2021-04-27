using KinderG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;



namespace KinderG.Controllers
{
    public class MessageController : Controller
    {
        public const int V = 2;
        public const int W = 1;

        public  ActionResult Index()
        {
            IEnumerable<Message> message = null;
           
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/listerMessages/2/1");
                var responseTask = client.GetAsync("http://localhost:8081/SpringMVC/servlet/listerMessages/2/1");
                responseTask.Wait();
                var result = responseTask.Result;
 
                if (result.IsSuccessStatusCode)
                {

                  
                    var readJob = result.Content.ReadAsAsync<IList<Message>>();
                    readJob.Wait();
                    message = readJob.Result;

                }
                else {
                    message = Enumerable.Empty<Message>();
                    ModelState.AddModelError(string.Empty, "server occured");
                }
            }
            return View(message);
          
        }



        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(Message customer ,long idU , long autreId)
        {
            using (var client = new HttpClient())
            {




                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var postJob = client.PostAsJsonAsync<Message>("addMessageAs/"+idU + "/" + autreId, customer);
                postJob.Wait();
                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Server occured ");
            return View(customer);
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



       
        public ActionResult Delete(long id)
        {
            using (var client = new HttpClient())
            {




                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var deleteJob = client.DeleteAsync("deleteMessageById/"+id);
                deleteJob.Wait();
                var result = deleteJob.Result;
               
                if (result.IsSuccessStatusCode)
                    
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

        public ActionResult ListUser()
        {

            // Session["auth"] = 15;
            IEnumerable<User> users = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                //HTTP GET
                var responseTask = client.GetAsync("getAllUsers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<User>>();
                    readTask.Wait();

                    users = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    users = Enumerable.Empty<User>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(users);

        }










    }
}
