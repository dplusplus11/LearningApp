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
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: categories
        public ViewResult Index()
        {
            var categories = _context.Categories.ToList();
            var courses = _context.Courses.ToList();

            if (User.IsInRole(RoleName.CanManageCourses))
                return View("Index", categories);
            else
                return View("List", categories);

        }
        //GET: One category
        public ActionResult CategoryInfo(int id)
        {
            var courses = _context.Courses.Where(c => c.CategoryId == id).ToList();
            var category = _context.Categories.SingleOrDefault(s => s.Id == id);
           

            if (category == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CategoryViewModel
            {
                Category = category,
                Courses = courses
            };

            if (User.IsInRole(RoleName.CanManageCourses))
                return View("CategoryInfo", viewModel);
            else
                return View("ReadOnlyInfo", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult New()
        {
            var courses = _context.Courses.ToList();

            var newCategory = new CategoryViewModel
            {
                Category= new Category(),
                Courses = courses
            };
            
            
            return View("CategoryForm", newCategory);
        }


        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(s => s.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            
            var viewModel = new CategoryViewModel
            {
                Category = category,
                Courses = _context.Courses.ToList()
            };
            

            return View("CategoryForm", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(s => s.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            
            return View("Delete", category);
        }
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult DeletionConfirmed(int id)
        {
            var category = _context.Categories.SingleOrDefault(s => s.Id == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var deletedCategory = _context.Categories.Remove(category);

            _context.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCourses)]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CategoryViewModel
                {
                    Category = category,
                    Courses = _context.Courses.ToList()
                };
                return View("CategoryForm", viewModel);
            }


            if (category.Id == 0)
                _context.Categories.Add(category);
            else
            {
                var categoryInDb = _context.Categories.Single(c => c.Id == category.Id);
                categoryInDb.Name = category.Name;
                categoryInDb.Description = category.Description;
                categoryInDb.WhatWillYouLearn = category.WhatWillYouLearn;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }

        
    }
}