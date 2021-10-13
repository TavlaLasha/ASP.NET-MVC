using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using OurFirstWebApplication.Models;
//using OurFirstWebApplication.ServiceReference1;


namespace OurFirstWebApplication.Controllers
{
    public class SubjectController : Controller
    {
        //ServiceReference1.Service1Client myService = new ServiceReference1.Service1Client();

        // GET: Country
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    List<SubjectViewModel> model = new List<SubjectViewModel>();

        //    var serviceModel = myService.GetAllCountry();

        //    foreach (var item in serviceModel)
        //    {
        //        SubjectViewModel obj = new SubjectViewModel();
        //        obj.Name = item.Name;
        //        obj.Description = item.Description;
        //        obj.Code = item.Code;
        //        obj.Credits = item.Credits;
        //        obj.Hours = item.Hours;
        //        model.Add(obj);

        //    }
        //    return View(model);
        //}
        //-------------------------------------------------------------------------------------------
        //public ActionResult Index()
        //{
        //    // GET: Subject


        //    IEnumerable<SubjectViewModel> model = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:53338/api/");
        //        //HTTP GET
        //        var responseTask = client.GetAsync("model");
        //        responseTask.Wait();

        //        var result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<IList<SubjectViewModel>>();
        //            readTask.Wait();
        //            model = readTask.Result;
        //        }
        //        else //web api sent error response 
        //        {
        //            model = Enumerable.Empty<SubjectViewModel>();
        //            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
        //        }
        //    }
        //    return View(model);
        //------------------------------------------------------------------------------------
        //public ActionResult Index()
        //{
        //    var model = new List<SubjectViewModel>() {
        //            new SubjectViewModel()
        //            {
        //                Name = "C Sharp",
        //                Description = "C# is an object-oriented programming language...",
        //                Code = "1",
        //                Credits = 3,
        //                Hours = 2
        //            },
        //            new SubjectViewModel()
        //            {
        //                Name = "Asp.Net",
        //                Description = "ASP.NET is an open-source,...",
        //                Code = "2",
        //                Credits = 6,
        //                Hours = 3
        //            }
        //        };
        //    return View(model);
        //}
        public ActionResult Index(int? id)
        {
            var model = new List<SubjectViewModel>()
            {
                new SubjectViewModel
                {
                    ID = 1,
                    Name = "C Sharp",
                    Description = "C# is an object-oriented programming language...",
                    Code = "1",
                    Credits = 3,
                    Hours = 2
                },
                new SubjectViewModel
                {
                    ID = 2,
                    Name = "Asp.Net",
                    Description = "ASP.NET is an open-source,...",
                    Code = "2",
                    Credits = 6,
                    Hours = 3
                }

            };
            if (id.HasValue)
            {
                if (model.Any(i => i.ID == id.Value))
                    return View(model.Where(i => i.ID == id.Value));
                return View(new List<SubjectViewModel>());
            }
            return View(model);
        }


        // GET: Subject/Details/5

        public ActionResult Details(int id)
        {
            if (id == 1)
                return View(new SubjectViewModel
                {
                    ID = 1,
                    Name = "C Sharp",
                    Description = "C# is an object-oriented programming language...",
                    Code = "1",
                    Credits = 3,
                    Hours = 2
                });

            if (id == 2)
                return View(new SubjectViewModel
                {
                    ID = 2,
                    Name = "Asp.Net",
                    Description = "ASP.NET is an open-source,...",
                    Code = "2",
                    Credits = 6,
                    Hours = 3
                });
            return View();
        }


       // GET: Subject/Create
       //[HttpGet]

        public ActionResult Create()
        {
            
            return View();

        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                    return View();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            } 
            
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Subject/Edit/5
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

        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subject/Delete/5
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
