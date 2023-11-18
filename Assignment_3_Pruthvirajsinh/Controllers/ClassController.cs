using Assignment_3_Pruthvirajsinh.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_3_Pruthvirajsinh.Controllers
{
    /// <summary>
    /// Controller responsible for handling actions related to classes.
    /// Manages views for listing all classes and displaying details of a specific class.
    /// </summary>
    public class ClassController : Controller
    {
        /**
         * Displays the index view for the Class controller.
         *
         * @return ActionResult: The ActionResult for the Index view.
         */
        public ActionResult Index()
        {
            return View();
        }

        /**
         * Displays a list of classes based on the provided search key.
         *
         * @param SearchKey: The search key to filter classes (default is null).
         * @return ActionResult: The ActionResult for the List view with the filtered classes.
         */
        public ActionResult List(string SearchKey = null)
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Class> Classes = controller.ListClasses(SearchKey);
            return View(Classes);
        }

        /**
         * Displays the details of a specific class.
         *
         * @param id: The ID of the class to show details for.
         * @return ActionResult: The ActionResult for the Show view with details of the specified class.
         */
        public ActionResult Show(int id)
        {
            ClassDataController controller = new ClassDataController();
            Class NewClass = controller.FindClass(id);

            return View(NewClass);
        }
    }
}
