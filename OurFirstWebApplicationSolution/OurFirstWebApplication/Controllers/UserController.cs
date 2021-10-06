using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplicationService.Models;

namespace OurFirstWebApplication.Controllers
{
    public class UserController : Controller
    {
        static HttpClient client = new HttpClient();
        // GET: User
        public ActionResult Index()
        {
            string IndexURL = "http://localhost:53338/api/User";
            HttpResponseMessage response = client.GetAsync(IndexURL).Result;

            List<UserViewModel> ct = new List<UserViewModel>();

            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<List<UserViewModel>>(response.Content.ReadAsStringAsync().Result);
            }
            return View(ct);
        }

        // GET: User/Details/5
        public ActionResult Details(int IDNumber)
        {
            string DetailsURL = "http://localhost:53338/api/User?IDNumber=";
            HttpResponseMessage response = client.GetAsync(DetailsURL + IDNumber).Result;

            UserViewModel ct = new UserViewModel();

            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<UserViewModel>(response.Content.ReadAsStringAsync().Result);
            }
            return View(ct);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "FirstName, LastName, IDNumber, PhoneNumber, Email, Password")] UserViewModel user)
        {
            try
            {
                string output = JsonConvert.SerializeObject(user);
                var stringContent = new StringContent(output, UnicodeEncoding.UTF8, "application/json");

                string CreateURL = "http://localhost:53338/api/User";
                HttpResponseMessage response = client.PostAsync(CreateURL, stringContent).Result;
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
