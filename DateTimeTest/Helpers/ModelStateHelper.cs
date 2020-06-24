using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Threading.Tasks;

namespace DateTimeTest.Helpers
{
    public static class ModelStateHelper
    { 
         public static Hashtable Errors(ModelStateDictionary modelstate)
        {
            var errors = new Hashtable();
            if (!modelstate.IsValid)
            {
                foreach (var pair in modelstate)
                {
                    if (pair.Value.Errors.Count > 0)
                    {
                        errors[pair.Key] = pair.Value.Errors.Select(error => error.ErrorMessage).ToList();
                    }
                }
            }
            return errors;
        }
    }
}
