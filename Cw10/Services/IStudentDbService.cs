using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw10.DTOs.Requests;
using Cw10.DTOs.Responses;
using Cw10.Models;

namespace Cw10.Services
{
    public interface IStudentDbService
    {
        EnrollStudentResponse EnrollStudent(EnrollStudentRequest request);
        PromoteStudentResponse PromoteStudents(PromoteStudentRequest request);
        Student GetStudent(string index);
    }
}
