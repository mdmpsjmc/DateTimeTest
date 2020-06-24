using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeTest.Models
{
    public interface IPatientRepository
    {
        IQueryable<Patient> Patients { get; }
    }
}
