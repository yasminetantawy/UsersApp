using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UsersApp.Business.Validations.Rules
{
    public class IsValidMobileRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }
        public bool Check(string value)
        {
           
           
           if (!string.IsNullOrEmpty(value))
            {
                return value.Length >= 11;
            }
            else
            {
                return false;
            }
        }
    }
}
