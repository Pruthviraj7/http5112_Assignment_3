using Assignment_3_Pruthvirajsinh.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3_Pruthvirajsinh.Controllers
{
    /// <summary>
    /// Controller for handling actions related to teachers.
    /// Manages views for listing all teachers and displaying details of a specific teacher.
    /// </summary>
    public class TeacherController : Controller
    {
        // GET: Teacher
        /// <summary>
        /// Displays the index view for the Teacher controller.
        /// </summary>
        /// <returns>ActionResult: The ActionResult for the Index view.</returns>

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string Employeenumber, double Salary)
        {
            // Server-side validation
            if (string.IsNullOrWhiteSpace(TeacherFname) || string.IsNullOrWhiteSpace(TeacherLname) || string.IsNullOrWhiteSpace(Employeenumber) || (Salary == null || Salary <= 0))
            {
                ModelState.AddModelError("", "Please provide all required information.");
                return View("Add");
            }

            // Create a new Teacher object
            Teacher newTeacher = new Teacher
            {
                teacherfname = TeacherFname,
                teacherlname = TeacherLname,
                employeenumber = Employeenumber,
                salary = Salary
            };

            // Create an instance of TeacherDataController and add the new teacher
            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(newTeacher);

            // Redirect to the list action to show the updated list
            return RedirectToAction("List");
        }

        // Delete a teacher
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Author/List
        /// <summary>
        /// Displays a list of teachers based on the provided search key.
        /// </summary>
        /// <param name="SearchKey">The search key to filter teachers (default is null).</param>
        /// <returns>ActionResult: The ActionResult for the List view with the filtered teachers.</returns>
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            return View(Teachers);
        }

        // GET: /Author/Show/{id}
        /// <summary>
        /// Displays the details of a specific teacher.
        /// </summary>
        /// <param name="id">The ID of the teacher to show details for.</param>
        /// <returns>ActionResult: The ActionResult for the Show view with details of the specified teacher.</returns>
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }
    }
}
