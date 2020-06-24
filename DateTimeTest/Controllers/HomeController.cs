using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateTimeTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DateTimeTest.Controllers
{
    public class HomeController:Controller
    {
        private IPatientRepository repository;

        public HomeController(IPatientRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Patients);
        }
    }
}
