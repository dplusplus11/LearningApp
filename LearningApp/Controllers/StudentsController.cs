using LearningApp.Models;
using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LearningApp.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;
        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Students
        [Authorize]
        public ViewResult Index()
        {
            var students = _context.Students.ToList();
            
            return View(students);
        }
        //GET: One Student
        [Authorize]
        public new ActionResult Profile(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            student.Joined = DateTime.Now;
            if(student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [Authorize]
        public ActionResult New()
        {
            
            var viewModel = new NewStudentViewModel
            {
                Student = new Student()
            };
            return View("New", viewModel);
        }
        

        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewStudentViewModel
            {
                Student = student
            };
            return View("Edit", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View("Delete", student);
        }
        [Authorize]
        public ActionResult DeletionConfirmed(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            var deletedStudent = _context.Students.Remove(student);

            _context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewStudentViewModel
                {
                    Student = student
                   

                };
                return View("New", viewModel);
            }


            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(c => c.Id == student.Id);
                studentInDb.Name = student.Name;
                studentInDb.Username = student.Username;
                studentInDb.Location = student.Location;
                studentInDb.GitHub = student.GitHub;
                studentInDb.BirthDate = student.BirthDate;
                studentInDb.Joined = DateTime.Now.Date;


            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }

    }

}