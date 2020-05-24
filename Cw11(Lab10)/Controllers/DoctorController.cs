using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11_Lab10_.Models;
using Cw11_Lab10_.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw11_Lab10_.Controllers
{
    [Route("api/Doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        public readonly IDoctorDbService _context;
        public DoctorController(IDoctorDbService context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetDoctor()
        {
            return Ok(_context.GetDoctors());
        }
        [HttpPost("AddDoctor/{Doctor}")]
        public IActionResult AddDoctor(Doctor doctor)
        {
            return Ok(_context.AddDoctors(doctor));
        }
        [HttpPost("ModifyDoctor/{Doctor}")]
        public IActionResult UpdateDoctor(Doctor doctor)
        {
            string response = _context.UpdateDoctor(doctor);
            if (response.Equals("Doctor updated"))
                return Ok(response);
            else
                return BadRequest(response);
        }
        [HttpDelete("DeleteDoctor/{IdDoctor}")]
        public IActionResult DeleteDoctor(int IdDoctor)
        {
            string response = _context.DeleteDoctor(IdDoctor);
            if (response.Equals("Succesefuly deleted"))
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}