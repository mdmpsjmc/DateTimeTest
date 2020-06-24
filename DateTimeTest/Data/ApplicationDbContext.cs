using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateTimeTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DateTimeTest.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}

        public DbSet<Patient> Patients { get; set; }
    }
}
