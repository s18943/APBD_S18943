using Cw10.DTOs.Requests;
using Cw10.DTOs.Responses;
using Cw10.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw10.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {
        private readonly s18943Context _context = new s18943Context();

        public SqlServerStudentDbService(DbContext context)
        {
            _context = (s18943Context)context;
        }
        public EnrollStudentResponse EnrollStudent(EnrollStudentRequest request)
        {
        EnrollStudentResponse res;

        var studies = _context.Studies.Where(s => s.Name.Equals(request.Studies))
                                     .FirstOrDefault();
            if (studies == null)
                return null;

        var enr = _context.Enrollment.Where(s => s.IdStudy == studies.IdStudy && s.Semester == 1)
                                           .OrderBy(s => s.StartDate)
                                           .First();

        if (enr == null)
        {
            enr = new Enrollment
            {
                IdEnrollment = _context.Enrollment.OrderBy(e => e.IdEnrollment)
                                            .Last().IdEnrollment + 1,
                Semester = 1,
                IdStudy = studies.IdStudy,
                StartDate = DateTime.Today
            };
            _context.Attach(enr);
            _context.Entry(enr).State = EntityState.Modified;
        }
        var student = new Student
        {
            IndexNumber = request.IndexNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            IdEnrollment = enr.IdEnrollment
        };
        _context.Attach(student);
        _context.Entry(student).State = EntityState.Modified;
        _context.SaveChanges();

        res = new EnrollStudentResponse(enr);
        return res;
    }

        public PromoteStudentResponse PromoteStudents(PromoteStudentRequest request)
        {
        var lastEn = (from e in _context.Enrollment
                      join s in _context.Studies on e.IdStudy equals s.IdStudy
                      where e.Semester == request.Semester && s.Name.Equals(request.Studies)
                      select e).FirstOrDefault(); ;
            if (lastEn == null)
                return null;
        var enr = _context.Enrollment.Where(e => e.Semester == lastEn.Semester + 1)
                                      .Join(_context.Studies, e => e.IdEnrollment, s => s.IdStudy, (e, s) => new { e.IdEnrollment, e.Semester, e.IdStudy, e.StartDate })
                                      .FirstOrDefault();
        if (enr == null)
        {
            enr = new
            {
                IdEnrollment = _context.Enrollment.OrderBy(e => e.IdEnrollment)
                                            .Last().IdEnrollment + 1,
                Semester = lastEn.Semester + 1,
                lastEn.IdStudy,
                StartDate = DateTime.Today
            };
            _context.Attach(enr);
            _context.Entry(enr).State = EntityState.Modified;
        }
        var updateStudents = _context.Student.Where(s => s.IdEnrollment == lastEn.IdEnrollment);
        foreach (var s in updateStudents)
        {
            s.IdEnrollment = enr.IdEnrollment;
        }
        _context.Attach(updateStudents);
        _context.Entry(updateStudents).State = EntityState.Modified;
        _context.SaveChanges();

            var res = new PromoteStudentResponse(enr);
        return  res;
    }

        public Student GetStudent(string indexNumber)
        {
          
            return null;
        }
    }
}
