using Assignment_3_Pruthvirajsinh.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_3_Pruthvirajsinh.Controllers
{
    /// <summary>
    /// ApiController for managing class data, including listing classes and retrieving class details.
    /// </summary>
    public class ClassDataController : ApiController
    {
        // Instance of the SchoolDbContext for database access.
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Retrieves a list of classes based on the provided search key.
        /// </summary>
        /// <param name="SearchKey">The search key to filter classes (default is null).</param>
        /// <returns>IEnumerable<Class>: List of classes matching the search criteria.</returns>
        [HttpGet]
        [Route("api/ClassData/ListClasses/{SearchKey?}")]
        public IEnumerable<Class> ListClasses(string SearchKey = null)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM classes WHERE lower(classname) LIKE lower(@key) OR lower(classcode) LIKE lower(@key)";
            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Class> Classes = new List<Class>();

            while (ResultSet.Read())
            {
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassName = ResultSet["classname"].ToString();
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);

                Class NewClass = new Class
                {
                    classid = ClassId,
                    classname = ClassName,
                    classcode = ClassCode,
                    teacherid = TeacherId
                };

                Classes.Add(NewClass);
            }

            Conn.Close();
            return Classes;
        }

        /// <summary>
        /// Retrieves the details of a specific class.
        /// </summary>
        /// <param name="id">The ID of the class to retrieve details for.</param>
        /// <returns>Class: Details of the specified class.</returns>
        [HttpGet]
        public Class FindClass(int id)
        {
            Class NewClass = new Class();
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM classes WHERE classid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassName = ResultSet["classname"].ToString();
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);

                NewClass = new Class
                {
                    classid = ClassId,
                    classname = ClassName,
                    classcode = ClassCode,
                    teacherid = TeacherId
                };
            }

            Conn.Close();
            return NewClass;
        }
    }
}
