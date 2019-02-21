using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.CV.Models
{
    public class PersonalInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string StreetNo { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string GitHub { get; set; }
        public string LinkedIn { get; set; }
    }
}
