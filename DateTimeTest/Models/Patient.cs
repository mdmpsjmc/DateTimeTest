using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeTest.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [StringLength(12)]
        public string RM2Number { get; set; }
        [StringLength(12)]
        public string NHSNumber { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        public DateTime? DOB { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
    }
}
