using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplicationService.EF;
using WebApplicationService.Models;

namespace WebApplicationService.Controllers
{
    public class SubjectController : ApiController
    {
        //private LCContext db = new LCContext();

        // GET: api/Subject
        public IHttpActionResult GetAllStudents(bool includeAddress = false)
        {
            IList<SubjectViewModel> subjects = null;

            using (var ctx = new SchoolDBEntities())
            { 
                return ctx.Subjects.Select(i => new SubjectViewModel()
                {
                    Name = i.Name,
                    Description = i.Description,
                    Code = i.Code,
                    Credits = i.Credits,
                    Hours = i.Hours
                }).ToList<StudentViewModel>();
            }
  
        }
        //public IQueryable<SubjectViewModel> GetSubjectViewModels()
        //{
        //    using (LCContext db = new LCContext())
        //    {
        //        return db.Subjects.Select(i => new SubjectViewModel
        //        {
        //            Name = i.Name,
        //            Description = i.Description,
        //            Code = i.Code,
        //            Credits = i.Credits,
        //            Hours = i.Hours
        //        }).ToList();
        //    }
        //}

        // GET: api/Subject/5
        [ResponseType(typeof(SubjectViewModel))]
        public IHttpActionResult GetSubjectViewModel(int id)
        {
            SubjectViewModel subjectViewModel = db.SubjectViewModels.Find(id);
            if (subjectViewModel == null)
            {
                return NotFound();
            }

            return Ok(subjectViewModel);
        }

        // PUT: api/Subject/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubjectViewModel(int id, SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectViewModel.ID)
            {
                return BadRequest();
            }

            db.Entry(subjectViewModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectViewModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Subject
        [ResponseType(typeof(SubjectViewModel))]
        public IHttpActionResult PostSubjectViewModel(SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubjectViewModels.Add(subjectViewModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subjectViewModel.ID }, subjectViewModel);
        }

        // DELETE: api/Subject/5
        [ResponseType(typeof(SubjectViewModel))]
        public IHttpActionResult DeleteSubjectViewModel(int id)
        {
            SubjectViewModel subjectViewModel = db.SubjectViewModels.Find(id);
            if (subjectViewModel == null)
            {
                return NotFound();
            }

            db.SubjectViewModels.Remove(subjectViewModel);
            db.SaveChanges();

            return Ok(subjectViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectViewModelExists(int id)
        {
            return db.SubjectViewModels.Count(e => e.ID == id) > 0;
        }
    }
}