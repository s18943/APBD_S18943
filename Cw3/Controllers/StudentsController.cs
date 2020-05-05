using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cw3.DTOs.Requests;
using Cw3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cw3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // SqlConnection client = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True");
        // SqlCommand com = new SqlCommand();
        public IConfiguration Configuration { get; set; }
        public StudentsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(LoginRequestDto request)
        {
            Student student = new Student();
            using (var con = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                try
                {
                    com.CommandText = "SELECT * FROM Student WHERE IndexNumber=@login";
                    com.Parameters.AddWithValue("login", request.Login);
                    var dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Haslo, Configuration["Salt"]);
                       
                        if (!passwordHash.Equals(dr["Haslo"].ToString()))
                            return NotFound("wrong password");

                        student.IndexNumber = dr["IndexNumber"].ToString();
                        student.FirstName = dr["FirstName"].ToString();
                        student.refreshToken = Guid.NewGuid();

                        dr.Close();

                        com.CommandText = "UPDATE Student SET RFToken=@RFToken WHERE IndexNumber=@id";
                        com.Parameters.AddWithValue("RFToken", student.refreshToken);
                        com.Parameters.AddWithValue("id", student.IndexNumber);

                        dr = com.ExecuteReader();
                    }
                    else
                    {
                        dr.Close();
                        return NotFound();
                    }
                    dr.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    return BadRequest();
                }
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.IndexNumber),
                new Claim(ClaimTypes.Name, student.FirstName),
                new Claim(ClaimTypes.Role, "employee"),
                new Claim(ClaimTypes.Role, "student")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "Gakko",
                audience: "Students",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken = Guid.NewGuid()
            });
        }
        [HttpGet]
        public string GetStudent()
        {
            using (var client = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True"))
            using (var com = new SqlCommand())
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
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr.GetDateTime(3);
                    st.IdEnrollment = (int)dr["IdEnrollment"];
                    st.Studies = dr["Name"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    students.Add(st);
                    result += st.FirstName + " " + st.LastName + " " + st.BirthDate + " " + st.Studies + " " + st.Semester + "\n";
                }
                return result;
            }
            //return "Nie znaleziono studentow";
        }
        [HttpPost("updateToken/{token}")]
        public IActionResult renewBearerToken(String request)
        {
            Student student = new Student();
            using (var con = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                try
                {
                    com.CommandText = "SELECT * FROM Student WHERE RFToken=@RFT";
                    com.Parameters.AddWithValue("RFT", request);
                    var dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        student.IndexNumber = dr["IndexNumber"].ToString();
                        student.FirstName = dr["FirstName"].ToString();
                    }
                    dr.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    return BadRequest();
                }
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.IndexNumber),
                new Claim(ClaimTypes.Name, student.FirstName),
                new Claim(ClaimTypes.Role, "employee"),
                new Claim(ClaimTypes.Role, "student")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "Gakko",
                audience: "Students",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            }); ;
        }

    
    //[HttpGet]
    //public string GetStudent(string orderBy)
    //{
    //    return $"Kowalsky, Riko, Szkiper sortowanie={orderBy}";
    //}

    [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetStudent(int id)
        {
            using (var client = new SqlConnection("Data Source=db-mssql; Initial Catalog=s18943; Integrated Security=True"))
            using (var com = new SqlCommand())
            {
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
                    en.IdEnrollment = (int)dr["IdEnrollment"];
                    en.Semester = (int)dr["Semester"];
                    en.IdStudy = (int)dr["IdStudy"];
                    en.StartDate = (DateTime)dr["StartDate"];
                    result += id + " " + en.Semester + " " + dr["Name"].ToString() + " " + en.StartDate + "\n";
                }
                if (result != "")
                    return Ok(result);
                return NotFound("Nie znaleziono studenta");
            }
        }
        //[HttpGet("{orderBy}")]
        //public string GetStudent(string orderBy)
        //{
        //    return $"Kowalsky, Riko, Szkiper sortowanie={orderBy}";
        //}
        //[HttpPost]
        //public IActionResult CreateStudent(Student student)
        //{
        //    student.IndexNumber = $"s{new Random().Next(1, 20000)}";
        //    return Ok(student);
        //}

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