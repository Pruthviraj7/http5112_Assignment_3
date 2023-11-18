using Assignment_3_Pruthvirajsinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3_Pruthvirajsinh.Controllers
{
    /// <summary>
    /// Controller for managing student-related views and actions.
    /// </summary>
    public class StudentController : Controller
    {
        /// <summary>
        /// Default action for the Student controller. Renders the Index view.
        /// </summary>
        /// <returns>ActionResult: Result of rendering the Index view.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action for displaying a list of students with optional search functionality.
        /// </summary>
        /// <param name="SearchKey">The search key to filter students (default is null).</param>
        /// <returns>ActionResult: Result of rendering the List view with the list of students.</returns>
        public ActionResult List(string SearchKey = null)
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> Students = controller.ListStudents(SearchKey);
            return View(Students);
        }

        /// <summary>
        /// Action for displaying details of a specific student.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve details for.</param>
        /// <returns>ActionResult: Result of rendering the Show view with details of the specified student.</returns>
        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);

            return View(NewStudent);
        }
    }
}
