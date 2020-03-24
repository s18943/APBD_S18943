using System;
using System.Collections.Generic;
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
        [HttpGet]
        public string GetStudent()
        {
            return "Kowalsky, Riko, Szkiper";
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
                return Ok("Kowalsky");
            else if (id == 2)
                return Ok("Riko");

            return NotFound("Nie znaleziono studenta");
        }
        [HttpGet("{orderBy}")]
        public string GetStudent(string orderBy)
        {
            return $"Kowalsky, Riko, Szkiper sortowanie={orderBy}";
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        //[HttpPut]
        //[HttpDelete]
    }
}