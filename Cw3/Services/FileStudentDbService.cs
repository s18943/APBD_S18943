﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DTOs.Requests;
using Cw3.DTOs.Responses;
using Cw3.Models;

namespace Cw3.Services
{
    public class FileStudentDbService : IStudentDbService
    {
        public Student GetStudent(string index)
        {
            throw new NotImplementedException();
        }

        public PromoteStudentResponse PromoteStudents(PromoteStudentRequest request)
        {
            throw new NotImplementedException();
        }

        EnrollStudentResponse IStudentDbService.EnrollStudent(EnrollStudentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
