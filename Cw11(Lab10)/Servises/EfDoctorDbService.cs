using Cw11_Lab10_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11_Lab10_.Servises
{
    public class EfDoctorDbService : IDoctorDbService
    {
        public readonly HospitalDbContext _context;
        public EfDoctorDbService(HospitalDbContext context)
        {
            _context = context;
        }

        string IDoctorDbService.AddDoctors(Doctor doctor)
        {
            if (_context.Doctors.Find(doctor.IdDoctor, doctor.LastName, doctor.FirstName, doctor.Email) == null)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return "Succesefully Added";
            }
            return "Failed to Add";
        }

        string IDoctorDbService.DeleteDoctor(int idDoctor)
        {
            var doc = _context.Doctors.Where(p => p.IdDoctor == idDoctor).FirstOrDefault();
            if (doc == null) return "Wrong ID";
            _context.Doctors.Remove(doc);
            _context.SaveChanges();
            return "Succesefuly deleted";
        }

        IEnumerable<Doctor> IDoctorDbService.GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        string IDoctorDbService.UpdateDoctor(Doctor doctor)
        {
            var doc = _context.Doctors.Where(p => p.IdDoctor == doctor.IdDoctor).FirstOrDefault();
            if (doc == null) return "Incorrect doctor ID";
            if (doctor.FirstName != null) doc.FirstName = doctor.FirstName;
            if (doctor.LastName != null) doc.LastName = doctor.LastName;
            if (doctor.Email != null) doc.Email = doctor.Email;
            _context.SaveChanges();
            return "Doctor updated";
        }
    }
}
