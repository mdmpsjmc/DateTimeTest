using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeTest.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string RM2Number { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DOB { get; set; }
    }
}
