using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw10.DTOs.Requests
{
    public class PostStudentRequest
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public DateTime BirthDate { get; internal set; }
        public string IndexNumber { get; internal set; }
    }
}
