using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividuelltDatabasProjektTess.Models
{
    public class StudentInfoDto
    {
        public int StudentID { get; set; }
        public long SocialSecurityNumber { get; set; }
        public string Class { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
