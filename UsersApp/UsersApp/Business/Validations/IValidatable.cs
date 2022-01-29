using System;
using System.Collections.Generic;
using System.Text;

namespace UsersApp.Business.Validations
{
    public interface IValidatable<T>
    {
        List<IValidationRule<T>> Validations { get; }
        List<string> Errors { get; set; }
        bool Validate();
        bool IsValid { get; set; }
        //ValidationStatus State { get; set; }
    }
}
