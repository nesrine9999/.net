using KinderG.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;


namespace KinderG.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
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

        public ActionResult Parents()
        {

            // Session["auth"] = 15;
            IEnumerable<User> users = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                //HTTP GET
                var responseTask = client.GetAsync("getAllParents");
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


        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Create(Message message , HttpPostedFileBase file,long id )
        {
            message.picture = file.FileName;
            //message.picture = "~/Content/Upload/"+file.FileName;
            using (var client = new HttpClient())
            {
                


                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
      
                var postJob = client.PostAsJsonAsync<Message>("addMessageAs/6/"+id.ToString(), message);
                postJob.Wait();
                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Server occured ");
            return View(message);
        }
        // GET: Users/Create
        public ActionResult CreateM()
        {
            return View();
        }



        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult CreateM(Message message, long id ,String email)
        {
            MailMessage mm = new MailMessage("nesrinezouaoui583@gmail.com", email);
            mm.Subject = message.objectM;
            mm.Body = message.contentM;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("nesrinezouaoui583@gmail.com", "(!enirsen@gni@elcyc?tirpse!)");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
         

















            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");


                var postJob = client.PostAsJsonAsync<Message>("addMessageAs/1/" + id.ToString(), message);
                postJob.Wait();
                var postResult = postJob.Result;
                if (postResult.IsSuccessStatusCode)
                    return RedirectToAction("ListFriends");
            }
            ModelState.AddModelError(string.Empty, "Server occured ");
            return View(message);
        }

        /*  // GET: Users/Create
          public ActionResult Send()
          {
              return View();
          }*/

        public ActionResult Send(Invitation invitation,long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/");
                var postJob = client.PostAsJsonAsync<Invitation>("SpringMVC/servlet/SendInvitation/1/" + id.ToString(), invitation);
                postJob.Wait();
                var postResult = postJob.Result;
                
                if (postResult.IsSuccessStatusCode)

                {    
                    return RedirectToAction("ListInvitation"); }
                else { return RedirectToAction("ListInvitation"); }
            }
            ModelState.AddModelError(string.Empty, "Server occured ");
            return View(invitation);
        }

        public ActionResult Delete(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var deleteJob = client.DeleteAsync("deleteMessageById/" + id);
                deleteJob.Wait();
                var result = deleteJob.Result;

                if (result.IsSuccessStatusCode)

                    return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }



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
        public ActionResult Notification()
        {

            IEnumerable<Notification> notification = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:8081/SpringMVC/servlet/listerNotifications/1");
                var responseTask = client.GetAsync(" http://localhost:8081/SpringMVC/servlet/listerNotifications/1");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<Notification>>();
                    readJob.Wait();
                    notification = readJob.Result;

                }
                else
                {
                    notification = Enumerable.Empty<Notification>();
                    ModelState.AddModelError(string.Empty, "server occured");
                }
            }
            return View(notification);
        }
        public ActionResult ListReceiver()
        {

            IEnumerable<Invitation> invitation = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" http://localhost:8081/SpringMVC/servlet/listerInvitationRece/1");
                var responseTask = client.GetAsync(" http://localhost:8081/SpringMVC/servlet/listerInvitationRece/1");
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
        // GET: Invitation
        public ActionResult ListFriends()
        {

            IEnumerable<Invitation> invitation = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/getListAmis/1");
                var responseTask = client.GetAsync("http://localhost:8081/SpringMVC/servlet/getListAmis/1");
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

        public ActionResult List( long id)
        {
            IEnumerable<Message> message = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var responseTask = client.GetAsync("listerMessages/6/"+id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {


                    var readJob = result.Content.ReadAsAsync<IList<Message>>();
                    readJob.Wait();
                    message = readJob.Result;

                }
                else
                {
                    message = Enumerable.Empty<Message>();
                    ModelState.AddModelError(string.Empty, "server occured");
                }
            }
            return View(message);

        }
        public ActionResult ListM(long id)
        {
            IEnumerable<Message> message = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var responseTask = client.GetAsync("listerMessages/1/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {


                    var readJob = result.Content.ReadAsAsync<IList<Message>>();
                    readJob.Wait();
                    message = readJob.Result;

                }
                else
                {
                    message = Enumerable.Empty<Message>();
                    ModelState.AddModelError(string.Empty, "server occured");
                }
            }
            return View(message);

        }




        public ActionResult Deleteinv(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var deleteJob = client.DeleteAsync("deleteInvitationById/" + id);
                deleteJob.Wait();
                var result = deleteJob.Result;

                if (result.IsSuccessStatusCode)

                    return RedirectToAction("ListInvitation");
            }

            return RedirectToAction("ListInvitation");

        }
        public ActionResult deleteAmis(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var deleteJob = client.DeleteAsync("deleteAmis/" + id);
                deleteJob.Wait();
                var result = deleteJob.Result;

                if (result.IsSuccessStatusCode)

                    return RedirectToAction("ListInvitation");
            }

            return RedirectToAction("ListInvitation");

        }
        public ActionResult deleteNotification(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var deleteJob = client.DeleteAsync("deleteNotificationById/" + id);
                deleteJob.Wait();
                var result = deleteJob.Result;

                if (result.IsSuccessStatusCode)

                    return RedirectToAction("Notification");
            }

            return RedirectToAction("Notification");

        }

        public ActionResult Accept(long id)
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
        public ActionResult Accept(Invitation invitation, long id,long ids)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081/SpringMVC/servlet/");
                var putTask = client.PutAsJsonAsync<Invitation>("Accept/1/"+ids.ToString()+"/" + id.ToString(), invitation);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("ListInvitation");
                return View(invitation);
            }
        }
        public ActionResult sendmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sendmail(EmailClass ec,string email)
        {
            MailMessage mm = new MailMessage("nesrinezouaoui583@gmail.com" ,email);
            mm.Subject = ec.subject;
            mm.Body = ec.body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            NetworkCredential nc = new NetworkCredential("nesrinezouaoui583@gmail.com", "(!enirsen@gni@elcyc?tirpse!)");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail has been sent";

            return View();




        }



    }
}
