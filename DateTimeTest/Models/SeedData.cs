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
                    new Patient { FirstName = "John", LastName = "Cooley", DOB = DateTime.Parse("02/01/1954"), RM2Number = "RM212345",NHSNumber="65437652",Gender="M" },
                    new Patient { FirstName = "Jane", LastName = "Wilson", DOB = DateTime.Parse("24/12/1972"), RM2Number = "RM246537", NHSNumber = "45876763", Gender = "F" },
                    new Patient { FirstName = "Peter", LastName = "Anderson", DOB = DateTime.Parse("12/07/1962"), RM2Number = "RM298674", NHSNumber = "7645342", Gender = "M" },
                    new Patient { FirstName = "Susan", LastName = "Smith", DOB = DateTime.Parse("03/04/1947"), RM2Number = "RM2146394", NHSNumber = "9452453", Gender = "F" },
                    new Patient { FirstName = "Mary", LastName = "Sanderson", DOB = DateTime.Parse("19/11/1959"), RM2Number = "RM2864562", NHSNumber = "775781384", Gender = "F", },
                    new Patient { FirstName = "Anne", LastName = "Smith", DOB = DateTime.Parse("27/10/1972"), RM2Number = "RM2777774", NHSNumber = "2626254363", Gender = "M" },
                    new Patient { FirstName = "Andrew", LastName = "Jones", DOB = DateTime.Parse("11/11/2011"), RM2Number = "RM2176543", NHSNumber = "58245364", Gender = "M" },
                    new Patient { FirstName = "Anne", LastName = "Jones", DOB = DateTime.Parse("27/03/1962"), RM2Number = "RM2146394", NHSNumber = "456254363", Gender = "F" },
                    new Patient { FirstName = "Susan", LastName = "George", DOB = DateTime.Parse("03/04/1952"), RM2Number = "RM2146332", NHSNumber = "5562596363", Gender = "F" },
                    new Patient { FirstName = "James", LastName = "Page", DOB = DateTime.Parse("25/12/2001"), RM2Number = "RM213425", NHSNumber = "456254363", Gender = "M" },
                    new Patient { FirstName = "Stephen", LastName = "Lucas", DOB = DateTime.Parse("18/09/1971"), RM2Number = "RM2654564", NHSNumber = "456254363", Gender = "M" },
                    new Patient { FirstName = "Julian", LastName = "Parsley", DOB = DateTime.Parse("22/11/1959"), RM2Number = "RM2146394", NHSNumber = "8975634", Gender = "M" },
                    new Patient { FirstName = "Steven", LastName = "Smith", DOB = DateTime.Parse("08/03/1979"), RM2Number = "RM2576534", NHSNumber = "4556548733", Gender = "M" },
                    new Patient { FirstName = "Emma", LastName = "Todd", DOB = DateTime.Parse("12/08/1982"), RM2Number = "RM2786543", NHSNumber = "456763542", Gender = "F" },
                    new Patient { FirstName = "John", LastName = "Cooley", DOB = DateTime.Parse("02/01/1954"), RM2Number = "RM212345", NHSNumber = "65437652", Gender = "M" },
                    new Patient { FirstName = "Jane", LastName = "Wilson", DOB = DateTime.Parse("24/12/1972"), RM2Number = "RM246537", NHSNumber = "45876763", Gender = "F" },
                    new Patient { FirstName = "Peter", LastName = "Anderson", DOB = DateTime.Parse("12/07/1962"), RM2Number = "RM298674", NHSNumber = "7645342", Gender = "M" },
                    new Patient { FirstName = "Susan", LastName = "Smith", DOB = DateTime.Parse("03/04/1947"), RM2Number = "RM2146394", NHSNumber = "9452453", Gender = "F" },
                    new Patient { FirstName = "Mary", LastName = "Sanderson", DOB = DateTime.Parse("19/11/1959"), RM2Number = "RM2864562", NHSNumber = "775781384", Gender = "F", },
                    new Patient { FirstName = "Anne", LastName = "Smith", DOB = DateTime.Parse("27/10/1972"), RM2Number = "RM2777774", NHSNumber = "2626254363", Gender = "M" },
                    new Patient { FirstName = "Andrew", LastName = "Jones", DOB = DateTime.Parse("11/11/2011"), RM2Number = "RM2176543", NHSNumber = "58245364", Gender = "M" },
                    new Patient { FirstName = "Hilary", LastName = "Thompson", DOB = DateTime.Parse("27/03/1962"), RM2Number = "RM2146394", NHSNumber = "456254363", Gender = "F" },
                    new Patient { FirstName = "Alison", LastName = "Shoe", DOB = DateTime.Parse("03/04/1952"), RM2Number = "RM2186453", NHSNumber = "7846534", Gender = "F" },
                    new Patient { FirstName = "Paul", LastName = "Schofieldf", DOB = DateTime.Parse("09/12/1976"), RM2Number = "RM213425", NHSNumber = "456254363", Gender = "M" },
                    new Patient { FirstName = "Michael", LastName = "Simpson", DOB = DateTime.Parse("23/05/1977"), RM2Number = "RM2654564", NHSNumber = "456254363", Gender = "M" },
                    new Patient { FirstName = "Henry", LastName = "Johnson", DOB = DateTime.Parse("28/07/1967"), RM2Number = "RM2146394", NHSNumber = "7563452", Gender = "M" },
                    new Patient { FirstName = "Harry", LastName = "Hill", DOB = DateTime.Parse("12/02/1947"), RM2Number = "RM2576534", NHSNumber = "4556548733", Gender = "M" },
                    new Patient { FirstName = "Chloe", LastName = "Queend", DOB = DateTime.Parse("26/09/1987"), RM2Number = "RM28657345", NHSNumber = "46756343", Gender = "F" }
                    );
            };
            context.SaveChanges();
        }
    }
}
