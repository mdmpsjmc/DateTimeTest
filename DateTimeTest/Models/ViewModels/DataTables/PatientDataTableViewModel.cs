using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeTest.Models.ViewModels.DataTables
{
    public class PatientDataTableViewModel
    {
        public int ID { get; set; }
        public string RM2Number { get; set; }
        public string NHSNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{dd-MM-yyy}")]
        public double? DOB { get; set; }
        public string Gender { get; set; }
    }
}
