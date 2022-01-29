using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsersApp.Business.Validations
{
    public class ValidatableObject<T> : BindableBase, IValidatable<T>
    {
        private Action callBack;
        public ValidatableObject(Action callBack = null)
        {
            this.callBack = callBack;
        }

        public List<IValidationRule<T>> Validations { get; } = new List<IValidationRule<T>>();
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsValid { get; set; } = false;

        public bool CleanOnChange { get; set; } = false;

        T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;

                if (CleanOnChange)
                    IsValid = true;

                RaisePropertyChanged();
                callBack?.Invoke();
            }
        }
        private string errorMsg = string.Empty;

        public string ErrorMsg
        {
            get { return errorMsg; }
            set { SetProperty(ref errorMsg, value); }
        }

        private int errorState;

        public int ErrorState
        {
            get { return errorState; }
            set { SetProperty(ref errorState, value); }
        }


        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();

            IsValid = !Errors.Any();

            ErrorMsg = !IsValid ? Errors[0] : string.Empty;

            return IsValid;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

    }
}
