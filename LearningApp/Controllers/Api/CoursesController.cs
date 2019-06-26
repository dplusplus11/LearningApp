using LearningApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;

namespace LearningApp.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET:/api/courses
        [System.Web.Mvc.HttpGet]
        [Authorize(Roles = RoleName.CanManageCourses)]
        public IEnumerable<Course> Get()
        {
            return _context.Courses.ToList();

        }
        //GET:/api/course/1
        [ValidateAntiForgeryToken]
        public Course GetCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return course;
        }

        //POST: /api/courses
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCourses)]
        public HttpResponseMessage Post([FromBody] Course course)
        {
            try
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, course);
                message.Headers.Location = new Uri(Request.RequestUri + course.Id.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        //PUT: /api/courses/1
        [System.Web.Http.HttpPut]
        [Authorize(Roles = RoleName.CanManageCourses)]
        public HttpResponseMessage Put(int id, [FromBody]Course course)
        {
            try
            {
                var courseInDb = _context.Courses.FirstOrDefault(c => c.Id == id);
                if (courseInDb == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, "Course with id = " + id.ToString() + "not found."));
                }
                else
                {
                    courseInDb.Name = course.Name;
                    courseInDb.Introduction = course.Introduction;
                    courseInDb.WhyLearn = course.WhyLearn;
                    courseInDb.Prerequisites = course.Prerequisites;
                    courseInDb.TakeAwaySkills = course.TakeAwaySkills;
                    courseInDb.LanguageId = course.LanguageId;
                    courseInDb.CategoryId = course.CategoryId;
                    courseInDb.TimeToComplete = course.TimeToComplete;
                    courseInDb.ProCourse = course.ProCourse;
                    _context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, courseInDb);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        //DELETE: /api/courses/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCourses)]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var course = _context.Courses.SingleOrDefault(c => c.Id == id);
                if (course == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, "Course with id = " + id.ToString() + "not found."));
                }
                else
                {
                    _context.Courses.Remove(course);
                    _context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }





    }
}
