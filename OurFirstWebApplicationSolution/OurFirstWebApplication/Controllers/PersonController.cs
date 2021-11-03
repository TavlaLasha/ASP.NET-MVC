﻿using Models.DataViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OurFirstWebApplication.Controllers
{
    public class PersonController : Controller
    {
        static HttpClient client = new HttpClient();
        string BaseURL = ConfigurationManager.AppSettings["personService"] + "/person";

        // GET: Person
        public ActionResult Index()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"{BaseURL}").Result;
                List<PersonDTO> ct = new List<PersonDTO>();
                if (response.IsSuccessStatusCode)
                {
                    ct = JsonConvert.DeserializeObject<List<PersonDTO>>(response.Content.ReadAsStringAsync().Result);
                }
                return View(ct);
            }
            catch (Exception ex)
            {
                return new HttpNotFoundResult();
            }
        }

        // GET: Person/Details/5
        public ActionResult Details(int? pn)
        {
            if (pn == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            HttpResponseMessage response = client.GetAsync(BaseURL + "?PN=" + pn).Result;
            PersonDTO ct = new PersonDTO();
            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<PersonDTO>(response.Content.ReadAsStringAsync().Result);
            }
            return View(ct);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, PersonDTO person)
        {
            ViewBag.ErrorMessage = "";
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მონაცემები არავალიდურია!");

                MemoryStream target = new MemoryStream();
                file.InputStream.CopyTo(target);
                person.Photo = target.ToArray();

                string output = JsonConvert.SerializeObject(person);
                var stringContent = new StringContent(output, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(BaseURL, stringContent).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "დამატების დროს მოხდა შეცდომა. ბოდიშს გიხდით";
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? pn)
        {
            if (pn == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            HttpResponseMessage response = client.GetAsync(BaseURL + "?PN=" + pn).Result;

            PersonDTO ct;

            if (response.IsSuccessStatusCode)
            {
                ct = JsonConvert.DeserializeObject<PersonDTO>(response.Content.ReadAsStringAsync().Result);
                return View(ct);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int? pn, [Bind(Include = "FirstName, LastName, Email, Password")] PersonDTO person)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მონაცემები არავალიდურია!");

                string output = JsonConvert.SerializeObject(person);
                var stringContent = new StringContent(output, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(BaseURL + "?PN=" + pn, stringContent).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int pn)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int pn, FormCollection collection)
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
