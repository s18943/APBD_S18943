using System.Linq;
using Cw10.DTOs.Requests;
using Cw10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cw10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // SqlConnection client = new SqlConnection("Data Source=context-mssql; Initial Catalog=s18943; Integrated Security=True");
        // SqlCommand com = new SqlCommand();
        private readonly s18943Context _context = new s18943Context();

        public StudentsController(DbContext context) => _context = (s18943Context)context;

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_context.Student.ToList());
        }

        [HttpPost("Modify")]
        public IActionResult ModifyStudent(PostStudentRequest req)
        {
            var student = _context.Student.Where(d => d.IndexNumber == req.IndexNumber).First();

            student.FirstName = req.FirstName==null?student.FirstName:req.FirstName;
            student.LastName = req.LastName == null ? student.LastName : req.LastName;
            student.BirthDate = req.BirthDate == null ? student.BirthDate : req.BirthDate;

            _context.Attach(student);
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string index)
        {
            var d = new Student
            {
                IndexNumber = index
            };
            _context.Attach(d);
            _context.Remove(d);
            _context.Entry(d).State = EntityState.Deleted;
            _context.SaveChanges();

            return Ok();
        }
    }
}