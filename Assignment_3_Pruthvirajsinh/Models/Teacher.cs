using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3_Pruthvirajsinh.Models
{
    /// <summary>
    /// Represents a teacher in the school application with basic information such as teacher ID, first name, last name, employee number, salary, and associated class ID.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Gets or sets the unique identifier for the teacher.
        /// </summary>
        public int teacherid;

        /// <summary>
        /// Gets or sets the first name of the teacher.
        /// </summary>
        public string teacherfname;

        /// <summary>
        /// Gets or sets the last name of the teacher.
        /// </summary>
        public string teacherlname;

        /// <summary>
        /// Gets or sets the unique employee number for the teacher.
        /// </summary>
        public string employeenumber;

        /// <summary>
        /// Gets or sets the salary of the teacher.
        /// </summary>
        public decimal salary;

        /// <summary>
        /// Gets or sets the ID of the associated class (nullable).
        /// </summary>
        public int? ClassId;
    }
}
