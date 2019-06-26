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
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: courses
        public ViewResult Index()
        {
            var courses = _context.Courses.ToList();

            if (User.IsInRole(RoleName.CanManageCourses))
                return View("List", courses);
            else
                return View("ReadOnlyList", courses);
        }
        //GET: One course
        public ActionResult Details(int id)
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == id);

            if (course == null)
            {
                return HttpNotFound();
            }
            if (User.IsInRole(RoleName.CanManageCourses))
                return View("Details", course);
            else
                return View("ReadOnlyCourse", course);
        }
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult New()
        {
            var newCourse = new CourseViewModel()
            {
                Course = new Course(),
                Categories = _context.Categories.ToList(),
                Languages = _context.Languages.ToList()
            }; 

            return View("Form", newCourse);
        }


        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            }

            var newCourse = new CourseViewModel()
            {
                Course = course,
                Categories = _context.Categories.ToList(),
                Languages = _context.Languages.ToList()
            };

            return View("Form", newCourse);
        }
        public ActionResult Delete(int id)
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            }

            return View("Delete", course);
        }
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult DeletionConfirmed(int id)
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            }
            var deletedCourse = _context.Courses.Remove(course);

            _context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult Save(Course course)
        {
            if (!ModelState.IsValid)
            {
                var newCourse = new CourseViewModel()
                {
                    Course = new Course(),
                    Categories = _context.Categories.ToList(),
                    Languages = _context.Languages.ToList()
                };
                return View("Form", newCourse);
            }


            if (course.Id == 0)
                _context.Courses.Add(course);
            else
            {
                var courseInDb = _context.Courses.Single(c => c.Id == course.Id);
                courseInDb.Name = course.Name;
                courseInDb.Introduction = course.Introduction;
                courseInDb.WhyLearn = course.WhyLearn;
                courseInDb.TakeAwaySkills = course.TakeAwaySkills;
                courseInDb.Prerequisites = course.Prerequisites;
                courseInDb.LanguageId = course.LanguageId;
                courseInDb.CategoryId = course.CategoryId;
                courseInDb.TimeToComplete = course.TimeToComplete;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
        public ActionResult Update(int id)
        {
            var course = _context.Courses.SingleOrDefault(s => s.Id == id);
            if (course == null)
            {
                return HttpNotFound();
            }

            var newCourse = new CourseViewModel()
            {
                Course = course,
                Categories = _context.Categories.ToList(),
                Languages = _context.Languages.ToList()
            };

            return View("Update", newCourse);
        }
        public ActionResult Upload()
        {
            var newCourse = new CourseViewModel()
            {
                Course = new Course(),
                Categories = _context.Categories.ToList(),
                Languages = _context.Languages.ToList()
            };

            return View("Upload", newCourse);
        }


    }
}