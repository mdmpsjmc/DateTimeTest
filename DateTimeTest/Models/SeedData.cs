using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using DateTimeTest.Data;

namespace DateTimeTest.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Patients.Any())
            {
                context.Patients.AddRange(
                    new Patient { FirstName = "John", LastName = "Cooley", DOB = DateTime.Parse("02/01/1954"), RM2Number = "RM212345" },
                    new Patient { FirstName = "Jane", LastName = "Wilson", DOB = DateTime.Parse("24/12/1972"), RM2Number = "RM246537" },
                    new Patient { FirstName = "Peter", LastName = "Anderson", DOB = DateTime.Parse("12/07/1962"), RM2Number = "RM298674" },
                    new Patient { FirstName = "Susan", LastName = "Smith", DOB = DateTime.Parse("03/04/1947"), RM2Number = "RM2146394" },
                    new Patient { FirstName = "Mary", LastName = "Sanderson", DOB = DateTime.Parse("19/11/1959"), RM2Number = "RM2864562" },
                    new Patient { FirstName = "Anne", LastName = "Smith", DOB = DateTime.Parse("27/10/1972"), RM2Number = "RM2777774" },
                    new Patient { FirstName = "Andrew", LastName = "Jones", DOB = DateTime.Parse("11/11/2011"), RM2Number = "RM2176543" },
                    new Patient { FirstName = "Anne", LastName = "Jones", DOB = DateTime.Parse("27/03/1962"), RM2Number = "RM2146394" },
                    new Patient { FirstName = "Susan", LastName = "George", DOB = DateTime.Parse("03/04/1952"), RM2Number = "RM2146332" },
                    new Patient { FirstName = "James", LastName = "Page", DOB = DateTime.Parse("25/12/2001"), RM2Number = "RM213425" },
                    new Patient { FirstName = "Stephen", LastName = "Lucas", DOB = DateTime.Parse("18/09/1971"), RM2Number = "RM2654564" },
                    new Patient { FirstName = "Julian", LastName = "Parsley", DOB = DateTime.Parse("22/11/1959"), RM2Number = "RM2146394" }
                    );
            };
            context.SaveChanges();
        }
    }
}
