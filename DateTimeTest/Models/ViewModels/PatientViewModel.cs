using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeTest.Models.ViewModels
{
    public class PatientViewModel
    {
        public PatientViewModel(Patient patient)
        {
            Patient = patient;
        }

        public Patient Patient { get; set; }
    }
}
