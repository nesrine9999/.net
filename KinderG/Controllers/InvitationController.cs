using KinderG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;



namespace KinderG.Controllers
{
    public class InvitationController : Controller
    {
        // GET: Invitation
        public ActionResult ListInvitation()
        {

            IEnumerable<Invitation> invitation = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:8081/SpringMVC/servlet/listerInvitation/1");
                var responseTask = client.GetAsync(" http://localhost:8081/SpringMVC/servlet/listerInvitation/1");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {


                    var readJob = result.Content.ReadAsAsync<IList<Invitation>>();
                    readJob.Wait();
                    invitation = readJob.Result;

                }
                else
                {
                    invitation = Enumerable.Empty<Invitation>();
                    ModelState.AddModelError(string.Empty, "server occured");
                }
            }
            return View(invitation);
        }

        // GET: Invitation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Invitation/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(Invitation invitation )
        {
            using (var client = new HttpClient())
            {
                 client.BaseAddress = new Uri("http://localhost:8081/");
                var postJob = client.PostAsJsonAsync<Invitation>("SpringMVC/servlet/SendInvitation/1/2/", invitation);
                postJob.Wait();
                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                
                    return RedirectToAction("ListInvitation");
            }
            ModelState.AddModelError(string.Empty, "Server occured ");
            return View(invitation);
        }

       
        public ActionResult Edit(int id)
        {
            Invitation invitation = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var responseTask = client.GetAsync("findInvitationwithId/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Invitation>();
                    readTask.Wait();
                    invitation = readTask.Result;
                }
            }
            return View(invitation);
        }
        //a post to update
        [HttpPost]
        public ActionResult Edit(Invitation invitation)
        {
          using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var putTask = client.PutAsJsonAsync<Invitation>("Refuse/3/1/", invitation);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("ListInvitation");
                return View(invitation);
            }
        }

        // GET: Invitation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invitation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
