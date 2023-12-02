using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please enter the first name.")]
        public string teacherfname;

        /// <summary>
        /// Gets or sets the last name of the teacher.
        /// </summary>
        [Required(ErrorMessage = "Please enter the last name.")]
        public string teacherlname;

        /// <summary>
        /// Gets or sets the employee number of the teacher.
        /// </summary>
        [Required(ErrorMessage = "Please enter the employee number.")]
        public string employeenumber;

        /// <summary>
        /// Gets or sets the salary of the teacher.
        /// </summary>
        [Required(ErrorMessage = "Please enter the salary.")]
        public double salary;

        /// <summary>
        /// Gets or sets the class ID associated with the teacher.
        /// </summary>
        public int? ClassId;

        [Required(ErrorMessage = "Please enter the hire date.")]
        public DateTime HireDate { get; set; } = DateTime.Now;
    }
}
