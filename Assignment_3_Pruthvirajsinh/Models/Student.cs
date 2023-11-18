using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_3_Pruthvirajsinh.Models
{
    /// <summary>
    /// Represents a student in the school application with basic information such as student ID, first name, last name, student number, and enrollment date.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the unique identifier for the student.
        /// </summary>
        public int studentid;

        /// <summary>
        /// Gets or sets the first name of the student.
        /// </summary>
        public string studentfname;

        /// <summary>
        /// Gets or sets the last name of the student.
        /// </summary>
        public string studentlname;

        /// <summary>
        /// Gets or sets the unique student number.
        /// </summary>
        public string studentnumber;

        /// <summary>
        /// Gets or sets the date when the student enrolled.
        /// </summary>
        public DateTime? enroldate;
    }
}
