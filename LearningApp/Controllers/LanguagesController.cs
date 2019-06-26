using LearningApp.Models;
using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningApp.Controllers
{
    public class LanguagesController : Controller
    {
        private ApplicationDbContext _context;
        public LanguagesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: languages
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ViewResult Index()
        {
            var languages = _context.Languages.ToList();
            var courses = _context.Courses.ToList();


            return View(languages);
        }
        //GET: One language
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult Details(int id)
        {
            var language = _context.Languages.SingleOrDefault(s => s.Id == id);

            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult New()
        {
            var courses = _context.Courses.ToList();

            var newlanguage = new LanguageViewModel
            {
                Language = new Language(),
                Courses = courses
            };


            return View("LanguageForm", newlanguage);
        }


        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult Edit(int id)
        {
            var language = _context.Languages.SingleOrDefault(s => s.Id == id);
            if (language == null)
            {
                return HttpNotFound();
            }

            var viewModel = new LanguageViewModel
            {
                Language = language,
                Courses = _context.Courses.ToList()
            };


            return View("LanguageForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult Delete(int id)
        {
            var language = _context.Languages.SingleOrDefault(s => s.Id == id);
            if (language == null)
            {
                return HttpNotFound();
            }

            return View("Delete", language);
        }
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult DeletionConfirmed(int id)
        {
            var language = _context.Languages.SingleOrDefault(s => s.Id == id);
            if (language == null)
            {
                return HttpNotFound();
            }
            var deletedlanguage = _context.Languages.Remove(language);

            _context.SaveChanges();
            return RedirectToAction("Index", "Languages");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult Save(Language language)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LanguageViewModel
                {
                    Language = language,
                    Courses = _context.Courses.ToList()
                };
                return View("LanguageForm", viewModel);
            }


            if (language.Id == 0)
                _context.Languages.Add(language);
            else
            {
                var languageInDb = _context.Languages.Single(c => c.Id == language.Id);
                languageInDb.Name = language.Name;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Languages");
        }

    }
}