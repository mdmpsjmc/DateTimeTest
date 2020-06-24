using System;
using System.Collections.Generic;
using System.Linq;
using DateTimeTest.Data;
using System.Threading.Tasks;

namespace DateTimeTest.Models
{
    public class EFPatientRepository:IPatientRepository
    {
        private ApplicationDbContext context;

        public EFPatientRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Patient> Patients => context.Patients;
    }
}
