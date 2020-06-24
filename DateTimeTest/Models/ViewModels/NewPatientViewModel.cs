using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeTest.Models.ViewModels
{
    public class NewPatientViewModel
    {
        public int PatientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string NHSNumber { get; set; }
        public DateTime? DOB { get; set; }
        public string RM2Number { get; set; }
    }
}
