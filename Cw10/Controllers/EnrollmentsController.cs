using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cw10.Models;
using Cw10.DTOs.Requests;
using Cw10.DTOs.Responses;
using Cw10.Services;

namespace Cw10.Controllers
{
    [Route("api/Enrollment")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentDbService _service;

        public EnrollmentsController(IStudentDbService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            EnrollStudentResponse response = _service.EnrollStudent(request);
            if (response != null)
                return Ok(response);
            return BadRequest(400);
        }

        [HttpPost("{promotions}")]
        public IActionResult PromoteStudents(PromoteStudentRequest request)
        {
            PromoteStudentResponse result = _service.PromoteStudents(request);
            if (result != null)
                return Ok(result);
            return BadRequest(404);

        }
    }
}
