using Assignment_3_Pruthvirajsinh.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Assignment_3_Pruthvirajsinh.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Add a new teacher to the database.
        /// </summary>
        /// <param name="newTeacher">The Teacher object representing the new teacher.</param>
        /// <returns>HttpResponseMessage indicating the result of the operation.</returns>
        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public HttpResponseMessage AddTeacher([FromBody] Teacher newTeacher)
        {
            // Validation checks for new teacher data.
            if (string.IsNullOrWhiteSpace(newTeacher.teacherfname) ||
                string.IsNullOrWhiteSpace(newTeacher.teacherlname) ||
                string.IsNullOrWhiteSpace(newTeacher.employeenumber) ||
                !IsSalaryValid(newTeacher.salary) ||
        newTeacher.HireDate == null)
            {
                // Return a BadRequest response if validation fails.
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please provide all required information, and ensure that the salary is a valid positive number.");
            }

            // Create an instance of a connection.
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection between the web server and database.
            Conn.Open();

            // Establish a new command (query) for our database.
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL QUERY
            cmd.CommandText = "INSERT INTO teachers (teacherfname, teacherlname, employeenumber, salary) VALUES (@TeacherFname, @TeacherLname, @EmployeeNumber, @Salary)";
            cmd.Parameters.AddWithValue("@TeacherFname", newTeacher.teacherfname);
            cmd.Parameters.AddWithValue("@TeacherLname", newTeacher.teacherlname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", newTeacher.employeenumber);
            cmd.Parameters.AddWithValue("@Salary", newTeacher.salary);
            cmd.Parameters.AddWithValue("@HireDate", newTeacher.HireDate);
            cmd.Prepare();

            // Execute the SQL query to insert the new teacher.
            cmd.ExecuteNonQuery();

            // Close the database connection.
            Conn.Close();

            // Return a successful response if everything is fine.
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// Validate if the salary is a positive number.
        /// </summary>
        /// <param name="salary">The salary to validate.</param>
        /// <returns>True if the salary is valid, false otherwise.</returns>
        private bool IsSalaryValid(double salary)
        {
            // Example: Salary should be greater than 0.
            return salary > 0;
        }

        /// <summary>
        /// Delete a teacher from the database.
        /// </summary>
        /// <param name="id">The ID of the teacher to delete.</param>
        /// <returns>HttpResponseMessage indicating the result of the operation.</returns>
        [HttpDelete]
        public HttpResponseMessage DeleteTeacher(int id)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            // SQL QUERY to delete a teacher based on teacherid.
            cmd.CommandText = "DELETE FROM teachers WHERE teacherid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            // Execute the SQL query to delete the teacher.
            int rowsAffected = cmd.ExecuteNonQuery();

            // Close the database connection.
            Conn.Close();

            // Check if deletion was successful and return an appropriate response.
            if (rowsAffected > 0)
            {
                // Deletion successful
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                // Deletion failed, return an appropriate response
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// List teachers based on a search key.
        /// </summary>
        /// <param name="SearchKey">The search key to filter teachers.</param>
        /// <returns>An IEnumerable of Teacher objects that match the search criteria.</returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey = null)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            // SQL QUERY to select teachers based on the search key.
            cmd.CommandText = "SELECT * FROM teachers WHERE LOWER(teacherfname) LIKE LOWER(@key) OR LOWER(teacherlname) LIKE LOWER(@key) OR LOWER(CONCAT(teacherfname, ' ', teacherlname)) LIKE LOWER(@key)";
            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Teacher> Teachers = new List<Teacher>();

            // Iterate through the result set and populate the Teachers list.
            while (ResultSet.Read())
            {
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeId = ResultSet["employeenumber"].ToString();
                double Salary = Convert.ToDouble(ResultSet["salary"]);

                Teacher NewTeacher = new Teacher
                {
                    teacherid = TeacherId,
                    teacherfname = TeacherFname,
                    teacherlname = TeacherLname,
                    employeenumber = EmployeeId,
                    salary = Salary
                };

                Teachers.Add(NewTeacher);
            }

            // Close the database connection.
            Conn.Close();

            return Teachers;
        }

        /// <summary>
        /// Find a teacher by ID.
        /// </summary>
        /// <param name="id">The ID of the teacher to find.</param>
        /// <returns>A Teacher object representing the found teacher.</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            // SQL QUERY to select a teacher based on teacherid.
            cmd.CommandText = "SELECT * FROM teachers WHERE teacherid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Populate the NewTeacher object with data from the result set.
            while (ResultSet.Read())
            {
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeId = ResultSet["employeenumber"].ToString();
                double Salary = Convert.ToDouble(ResultSet["salary"]);

                NewTeacher = new Teacher
                {
                    teacherid = TeacherId,
                    teacherfname = TeacherFname,
                    teacherlname = TeacherLname,
                    employeenumber = EmployeeId,
                    salary = Salary
                };
            }

            // Close the database connection.
            Conn.Close();

            return NewTeacher;
        }
    }
}
