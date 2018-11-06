﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GenericBizRunner;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Auth.Web.Helpers
{
    public static class ValidationHelper
    {
        /// <summary>
        /// This transfers error messages from the ValidationResult collection to the MVC modelState error dictionary.
        /// It looks for errors that have member names corresponding to the properties in the displayDto.
        /// This means that errors associated with a field on display will show next to the name. 
        /// Other errors will be shown in the ValidationSummary
        /// </summary>
        /// <param name="status">The status that came back from the BizRunner</param>
        /// <param name="modelState">The MVC modelState to add errors to</param>
        /// <param name="displayDto">This is the Dto that will be used to display the error messages</param>
        public static void CopyErrorsToModelState<T>(this IStatusGeneric status, ModelStateDictionary modelState, T displayDto)
        {
            if (!status.HasErrors) return;

            var namesThatWeShouldInclude = PropertyNamesInDto(displayDto);
            foreach (var error in status.Errors)
            {
                if (!error.MemberNames.Any())
                    modelState.AddModelError("", error.ErrorMessage);
                else
                    foreach (var errorKeyName in error.MemberNames)
                        modelState.AddModelError(
                            (namesThatWeShouldInclude.Any(x => x == errorKeyName) ? errorKeyName : ""),
                            error.ErrorMessage);
            }
        }

        /// <summary>
        /// This copies errors for general display where we are not returning to a page with the fields on them
        /// </summary>
        /// <param name="status"></param>
        /// <param name="modelState"></param>
        public static void CopyErrorsToModelState(this IStatusGeneric status, ModelStateDictionary modelState)
        {
            if (!status.HasErrors) return;

            foreach (var error in status.Errors)
                modelState.AddModelError("", error.ErrorMessage);
        }

        //-----------------------------------------------------------------------------------
        //private methods

        private static IList<string> PropertyNamesInDto<T>(T objectToCheck)
        {
            return
                objectToCheck.GetType()
                             .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                             .Select(x => x.Name)
                             .ToList();
        }
    }
}
