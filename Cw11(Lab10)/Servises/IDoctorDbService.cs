using Cw11_Lab10_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11_Lab10_.Servises
{
    public interface IDoctorDbService
    {

        internal string AddDoctors(Doctor doctor);

        internal string UpdateDoctor(Doctor doctor);

        internal string DeleteDoctor(int idDoctor);

        internal IEnumerable<Doctor> GetDoctors();
    }
}
