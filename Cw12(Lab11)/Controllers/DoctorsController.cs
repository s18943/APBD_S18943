using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw12_Lab11_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cw12_Lab11_.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            var db = new HospitalDbContext();
            var doctors = db.Doctors.ToList();

            return View(doctors);
        }

        public IActionResult GetDetails(int id)
        {
            var db = new HospitalDbContext();
            var doctor = db.Doctors.FirstOrDefault(d => d.IdDoctor == id);

            return View(doctor);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(doctor);
            }
            var db = new HospitalDbContext();
            db.Doctors.Add(doctor);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}