using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        SqlConnection client = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True");
        SqlCommand com = new SqlCommand();
            
        [HttpGet]
        public string GetStudent()
        {
           
                com.Connection = client;
                com.CommandText = "Select * FROM Student s " +
                                  "JOIN Enrollment e ON e.IdEnrollment=s.IdEnrollment " +
                                  "JOIN Studies t ON t.IdStudy=e.IdStudy";

                client.Open();
                var dr = com.ExecuteReader();
                List<Student> students = new List<Student>();
                string result = "";
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.Imie = dr["FirstName"].ToString(); 
                    st.Nazwisko = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString().Remove(10);
                    st.IdEnrollment = dr["IdEnrollment"].ToString();
                    st.Study = dr["Name"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    students.Add(st);
                    result += st.Imie + " " + st.Nazwisko + " " + st.BirthDate + " " + st.Study + " " + st.Semester + "\n";
                }
                return result;
            
            //return "Nie znaleziono studentow";
        }

        [HttpGet]
        public string GetStudent(string orderBy)
        {
            return $"Kowalsky, Riko, Szkiper sortowanie={orderBy}";
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            //using (var client = new SqlConnection("Data Source = db - mssql; Initial Catalog = s18943; Integrated Security = True"))
            //using (var com = new SqlCommand())
            //{
            string Ska = "s" + id;
                com.Connection = client;
                com.CommandText = "Select * FROM Student s " +
                                  "JOIN Enrollment e ON e.IdEnrollment=s.IdEnrollment " +
                                  "JOIN Studies t ON t.IdStudy=e.IdStudy " + 
                                  " WHERE s.IndexNumber=@id";
                com.Parameters.AddWithValue("id", Ska);

                client.Open();
                var dr = com.ExecuteReader();
                List<Enrollment> enroliments = new List<Enrollment>();
                string result = "";
            while (dr.Read())
            {
                var en = new Enrollment();
                en.IdEnrollment = dr["IdEnrollment"].ToString();
                en.Semestr = dr["Semester"].ToString();
                en.IdStudy = dr["IdStudy"].ToString();
                en.StartDate = dr["StartDate"].ToString().Remove(10);
                result += id + " " + en.Semestr + " " + dr["Name"].ToString() + " " + en.StartDate + "\n";
            }
            if (result != "")
                return Ok(result);
            return NotFound("Nie znaleziono studenta");
        }
        //[HttpGet("{orderBy}")]
        //public string GetStudent(string orderBy)
        //{
        //    return $"Kowalsky, Riko, Szkiper sortowanie={orderBy}";
        //}
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        //Data Source = db - mssql; Initial Catalog = s18943; Integrated Security = True
        [HttpPut("{id}")]
        public IActionResult updateStudent(int id)
        {
            if (id == 18943)
            {
                return Ok("(Put)Sukces");
            }
            return NotFound("Nie znaleziono studenta");
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id)
        {
            if (id == 18943)
            {
                return Ok("(Delete)Sukces");
            }
            return NotFound("Nie znaleziono studenta");
        }
    }
}