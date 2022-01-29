using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UsersApp.Business.Validations.Rules
{
    class IsValidEmailRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var HasArabicCharacters = new Regex("[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc]");
                if (HasArabicCharacters.IsMatch(value.ToString()))
                    return false;
                else
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(value);
                    return match.Success;
                }
            }
            else
                return false;

        }
    }
}
