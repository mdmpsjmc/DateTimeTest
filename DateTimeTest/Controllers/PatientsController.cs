using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DateTimeTest.Data;
using DateTimeTest.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using DateTimeTest.Models;
using DateTimeTest.Helpers;
using System.ComponentModel;

namespace DateTimeTest.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PatientsController(ApplicationDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet, ActionName("Details")]
        public ActionResult Details(int patientID)
        {
            var patient = _dbContext.Patients
                .FirstOrDefault(p => p.PatientID.Equals(patientID));

            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = new PatientViewModel(patient);
                return PartialView(@"/Views/Patients/Details.cshtml", viewModel);
            }
        }
        [HttpGet, ActionName("Edit")]
        public IActionResult Edit(int patientID)
        {
            var patient = _dbContext.Patients
                .FirstOrDefault(p => p.PatientID.Equals(patientID));

            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = new PatientViewModel(patient);
                return PartialView(@"/Views/Patients/Edit/Edit.cshtml", viewModel.Patient);
            }
        }

        public IActionResult Update(NewPatientViewModel patient)
        {
            ModelState.Remove("PatientID");
            var newPatient = _mapper.Map<Patient>(patient);
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Patients.Update(newPatient);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("PatientID", "Please verify if a patient with this RM2 Number or NHS Number already exists in the database");
                    var errors = ModelStateHelper.Errors(ModelState);
                    return Json(new { errors = errors });
                }
            }
            else
            {
                var errors = ModelStateHelper.Errors(ModelState);
                return Json(new{ errors=errors});
            }
        }
                
    }

}
