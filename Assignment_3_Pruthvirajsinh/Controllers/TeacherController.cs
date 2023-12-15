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
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Displays the view for adding a new teacher.
        /// </summary>
        /// <returns>ActionResult: The ActionResult for the Add view.</returns>
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Handles the POST request for creating a new teacher.
        /// </summary>
        /// <param name="TeacherFname">The first name of the new teacher.</param>
        /// <param name="TeacherLname">The last name of the new teacher.</param>
        /// <param name="Employeenumber">The employee number of the new teacher.</param>
        /// <param name="Salary">The salary of the new teacher.</param>
        /// <returns>ActionResult: Redirects to the List action to show the updated list.</returns>
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

        /// <summary>
        /// Displays the view for updating an existing teacher.
        /// </summary>
        /// <param name="id">The ID of the teacher to update.</param>
        /// <returns>ActionResult: The ActionResult for the Update view with the details of the selected teacher.</returns>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        /// <summary>
        /// Handles the POST request for updating an existing teacher.
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="TeacherFname">The updated first name of the teacher</param>
        /// <param name="TeacherLname">The updated last name of the teacher</param>
        /// <param name="EmployeeNumber">The updated employee number of the teacher.</param>
        /// <param name="Salary">The updated salary of the teacher.</param>
        /// <returns>ActionResult: Redirects to the "Teacher Show" page of the updated teacher.</returns>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, double Salary)
        {
            Teacher TeacherInfo = new Teacher
            {
                teacherfname = TeacherFname,
                teacherlname = TeacherLname,
                employeenumber = EmployeeNumber,
                salary = Salary
            };

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }

        /// <summary>
        /// Deletes a teacher with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the teacher to delete.</param>
        /// <returns>ActionResult: Redirects to the List action to show the updated list.</returns>
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);

            return RedirectToAction("List");
        }

        /// <summary>
        /// Displays the Ajax_Update view for updating an existing teacher using AJAX.
        /// </summary>
        /// <param name="id">The ID of the teacher to update.</param>
        /// <returns>ActionResult: The ActionResult for the Ajax_Update view with the details of the selected teacher.</returns>
        public ActionResult Ajax_Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }
    }
}
