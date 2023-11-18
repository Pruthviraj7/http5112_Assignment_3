using Assignment_3_Pruthvirajsinh.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Assignment_3_Pruthvirajsinh.Controllers
{
    /// <summary>
    /// Controller handling student data.
    /// </summary>
    public class StudentDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Get a list of students based on a search key.
        /// </summary>
        /// <param name="SearchKey">The search key for filtering students.</param>
        /// <returns>List of students.</returns>
        [HttpGet]
        [Route("api/StudentData/ListStudents/{SearchKey?}")]
        public IEnumerable<Student> ListStudents(string SearchKey = null)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM students WHERE lower(studentfname) LIKE lower(@key) OR lower(studentlname) LIKE lower(@key) OR lower(concat(studentfname, ' ', studentlname)) LIKE lower(@key)";
            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();
            List<Student> Students = new List<Student>();

            while (ResultSet.Read())
            {
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrollDate = Convert.ToDateTime(ResultSet["enroldate"]);

                Student NewStudent = new Student
                {
                    studentid = StudentId,
                    studentfname = StudentFname,
                    studentlname = StudentLname,
                    studentnumber = StudentNumber,
                    enroldate = EnrollDate
                };

                Students.Add(NewStudent);
            }

            Conn.Close();
            return Students;
        }

        /// <summary>
        /// Get details of a specific student.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>Details of the student.</returns>
        [HttpGet]
        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM students WHERE studentid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = ResultSet["studentfname"].ToString();
                string StudentLname = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrollDate = Convert.ToDateTime(ResultSet["enroldate"]);

                NewStudent = new Student
                {
                    studentid = StudentId,
                    studentfname = StudentFname,
                    studentlname = StudentLname,
                    studentnumber = StudentNumber,
                    enroldate = EnrollDate
                };
            }

            Conn.Close();
            return NewStudent;
        }
    }
}
