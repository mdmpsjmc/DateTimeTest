using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateTimeTest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using DateTimeTest.Models.ViewModels.DataTables;
using DateTimeTest.Infrastructure;

namespace DateTimeTest.Controllers.DataTables
{
    public class DataTablePatientsController : DataTablesController
    {
        
            public DataTablePatientsController(ApplicationDbContext context)
            {
                _dbContext = context;
                _list = new List<dynamic>();
            }
        
        
        virtual public IActionResult Load()
        {
            Action queriesAction = () =>
              {
                  var patientData = QueryPatientData();

                  _list = QueryPatientData().ToList<dynamic>();
              };

            return LoadData(queriesAction);
        }

        private IQueryable<PatientDataTableViewModel> QueryPatientData()
            {
            return (from patient in _dbContext.Patients
                    select new PatientDataTableViewModel()
                    {
                        ID = patient.PatientID,
                        RM2Number = patient.RM2Number,
                        LastName=patient.LastName,
                        FirstName=patient.FirstName,
                        DOB=DateHelper.DateTimeToUnixTimestamp(patient.DOB)
                    });
            }

    }
}
