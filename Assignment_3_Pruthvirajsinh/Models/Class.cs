using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3_Pruthvirajsinh.Models
{
    /// <summary>
    /// Represents a class in the school application with basic information such as class ID, name, code, and teacher ID.
    /// </summary>
    public class Class
    {
        /// <summary>
        /// Gets or sets the unique identifier for the class.
        /// </summary>
        public int classid;

        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        public string classname;

        /// <summary>
        /// Gets or sets the code associated with the class.
        /// </summary>
        public string classcode;

        /// <summary>
        /// Gets or sets the unique identifier of the teacher associated with the class.
        /// </summary>
        public int teacherid;
    }
}
