using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using LearningApp.ViewModels;


namespace LearningApp.Controllers
{
    public class EnrolmentsController : Controller
    {
        private ApplicationDbContext _context;
        public EnrolmentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: enrols
        [Authorize]
        public ViewResult Index()
        {
            List<Enrolment> enrols = _context.Enrolments.Include(c => c.Course).Include(s=> s.Student).Include(p=> p.Plan).ToList();

            return View(enrols);
        }
        //GET: One enrolment
        [Authorize]
        public ActionResult Details(int sid, int cid)
        {
            var enrolment = _context.Enrolments.SingleOrDefault(s => s.StudentID == sid && s.CourseID == cid);

            if (enrolment == null)
            {
                return HttpNotFound();
            }
            return View(enrolment);
        }
        [Authorize]
        public ActionResult New()
        {
            var students = _context.Students.ToList();
            var courses = _context.Courses.ToList();
            var plans = _context.Plans.ToList();
            var newEnrol = new EnrolmentViewModel
            {
                Enrolment = new Enrolment(),
                Students = students,
                Courses = courses,
                Plans = plans
            };
            return View("Form", newEnrol);
        }

        [Authorize]
        public ActionResult Edit(int sid, int cid)
        {
            var enrolment = _context.Enrolments.SingleOrDefault(s => s.StudentID == sid && s.CourseID == cid);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            var newEnrol = new EnrolmentViewModel
            {
                Enrolment = enrolment,
                Students = _context.Students.ToList(),
                Courses = _context.Courses.ToList(),
                Plans = _context.Plans.ToList()
            };

            return View("Form", newEnrol);
        }
        [Authorize]
        public ActionResult Delete(int sid, int cid)
        {
            var enrolment = _context.Enrolments.Include(i=>i.Student).SingleOrDefault(s => s.StudentID == sid && s.CourseID == cid);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            
            return View("Delete", enrolment);
        }
        [Authorize]
        public ActionResult DeletionConfirmed(int sid, int cid)
        {
            var enrolment = _context.Enrolments.SingleOrDefault(s => s.StudentID == sid && s.CourseID == cid);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            var deletedEnrolment = _context.Enrolments.Remove(enrolment);

            _context.SaveChanges();
            return RedirectToAction("Index", "Enrolments");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(Enrolment enrolment)
        {
            if (!ModelState.IsValid)
            {
                var newEnrol = new EnrolmentViewModel
                {
                    Enrolment = enrolment,
                    Students = _context.Students.ToList(),
                    Courses = _context.Courses.ToList(),
                    Plans = _context.Plans.ToList(),
                };
                return View("Form", newEnrol);
            }

            var enrolmentInDb = _context.Enrolments.SingleOrDefault(c => c.StudentID == enrolment.StudentID && c.CourseID == enrolment.CourseID);
            if (enrolmentInDb == null)
                _context.Enrolments.Add(enrolment);
            else
            {
                enrolmentInDb.StudentID = enrolment.StudentID;
                enrolmentInDb.CourseID = enrolment.CourseID;
                enrolmentInDb.PlanID = enrolment.PlanID;
                enrolmentInDb.EnrolledAt = enrolment.EnrolledAt == null ? DateTime.Now.Date : enrolment.EnrolledAt;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Enrolments");
        }

    }
}