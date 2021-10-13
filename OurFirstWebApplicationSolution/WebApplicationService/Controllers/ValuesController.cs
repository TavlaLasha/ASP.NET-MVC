using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationService.EF;
using WebApplicationService.Models;



namespace WebApplicationService.Controllers
{

    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult GetAllStudents()
        {
            IList<SubjectViewModel> subjects = null;

            using (LCContext ctx = new LCContext())
            {
                subjects = ctx.Subjects.Select(i => new SubjectViewModel()
                {
                    Name = i.Name,
                    Description = i.Description,
                    Code = i.Code,
                    Credits = i.Credits,
                    Hours = i.Hours
                }).ToList<SubjectViewModel>();
            }
            return (IHttpActionResult)subjects;
        }
        // GET api/values/5
        public SubjectViewModel Get(int ID)
        {
            using (LCContext db = new LCContext())
            {
                return db.Subjects.Where(i => i.ID.Equals(ID)).Select(i => new SubjectViewModel
                {
                    ID = i.ID,
                    Name = i.Name,
                    Description = i.Description,
                    Code = i.Code,
                    Credits = i.Credits,
                    Hours = i.Hours

                }).FirstOrDefault();
            }

        }


        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        public void Post([FromBody] SubjectViewModel svm)
        {
            using (LCContext db = new LCContext())
            {
                Subject Subject = new Subject
                {
                    ID = svm.ID,
                    Name = svm.Name,
                    Description = svm.Description,
                    Code = svm.Code,
                    Credits = svm.Credits,
                    Hours = svm.Hours


                };
                db.Subjects.Add(Subject);
                db.SaveChanges();
            }

        }
        // PUT api/values/5
        public void Put(int ID, [FromBody] SubjectViewModel svm)
        {
            using (LCContext db = new LCContext())
            {
                if (!db.Subjects.Any(i => i.ID.Equals(ID)))
                    throw new Exception($"ვერ მოიძებნა ID:{ID}");
                var s = db.Subjects.Where(i => i.ID.Equals(ID)).First();
                s.Name = svm.Name;
                s.Description = svm.Description;
                s.Code = svm.Code;
                s.Credits = svm.Credits;
                s.Hours = svm.Hours;
                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(int ID)
        {
            using (LCContext db = new LCContext())
            {
                if (!db.Subjects.Any(i => i.ID.Equals(ID)))
                    throw new Exception($"ვერ მოიძებნა ID:{ID}");

                var s = db.Subjects.Where(i => i.ID.Equals(ID)).First();
                db.Subjects.Remove(s);

                db.SaveChanges();
            }
        }
    }
}
