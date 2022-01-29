using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersApp.Business.Validations;
using UsersApp.Business.Validations.Rules;
using UsersApp.Views;

namespace UsersApp.ViewModels
{
    public class SignupPageViewModel : BindableBase
    {
        INavigationService NavigationService;
        public SignupPageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Initialization();
            AddValidations();
            
        }

        #region Properties
        private ValidatableObject<string> email;
        public ValidatableObject<string> Email
        {
            get
            {
                return email;
            }
            set
            {
                SetProperty(ref email, value);
            }
        }
        private ValidatableObject<string> mobileNumber;
        public ValidatableObject<string> MobileNumber
        {
            get
            {
                return mobileNumber;
            }
            set
            {
                SetProperty(ref mobileNumber, value);
            }
        }
        private ValidatableObject<string> password;
        public ValidatableObject<string> Password
        {
            get
            {
                return password;
            }
            set
            {
                SetProperty(ref password, value);
            }
        }
        private ValidatableObject<string> confirmPassword;
        public ValidatableObject<string> ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                SetProperty(ref confirmPassword, value);
            }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                SetProperty(ref dateOfBirth, value);
            }
        }
        private bool isSignupButtonEnabled;
        public bool IsSignupButtonEnabled
        {
            get
            {
                return isSignupButtonEnabled;
            }
            set
            {
                SetProperty(ref isSignupButtonEnabled, value);
            }
        }
        #endregion
        #region Command
        public DelegateCommand ValidateEmailCommand { get; set; }
        public DelegateCommand ValidateMobileNumberCommand { get; set; }
        public DelegateCommand ValidatePasswordCommand { get; set; }
        public DelegateCommand ValidateConfirmPasswordCommand { get; set; }
        public DelegateCommand NavigateToUsersPageCommand { get; set; }

        #endregion

        #region Methods
        private void Initialization()
        {
            Email = new ValidatableObject<string>();
            MobileNumber = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();
            ConfirmPassword = new ValidatableObject<string>();
            ValidateEmailCommand = new DelegateCommand(ValidateEmail);
            ValidateMobileNumberCommand = new DelegateCommand(ValidateMobileNumber);
            ValidatePasswordCommand = new DelegateCommand(ValidatePassword);
            ValidateConfirmPasswordCommand = new DelegateCommand(ValidateConfirmPassword);
            NavigateToUsersPageCommand = new DelegateCommand(NavigateToUsersPage);
            DateOfBirth = DateTime.Now;
        }
        private void AddValidations()
        {
            Email.Validations.Add(new IsNotNullOrEmptyRule<string>() { ValidationMessage = "Email cannot be empty" });
            Email.Validations.Add(new IsValidEmailRule() { ValidationMessage = "Email pattern is not valid" });
            MobileNumber.Validations.Add(new IsNotNullOrEmptyRule<string>() { ValidationMessage = "Mobile Cannot be Empty" });
            MobileNumber.Validations.Add(new IsValidMobileRule() { ValidationMessage = "Mobile Number cannot be less than 11 numberss" });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string>() { ValidationMessage = "Password Cannot be Empty" });
            ConfirmPassword.Validations.Add(new IsNotNullOrEmptyRule<string>() { ValidationMessage = "Please Re-enter your Password" });
        }
        private void ValidateEmail()
        {
            Email.Validate();
            IsSignupButtonEnabled = Email.IsValid && MobileNumber.IsValid && Password.IsValid && ConfirmPassword.IsValid;
        }
        private void ValidateMobileNumber()
        {
            MobileNumber.Validate();
            IsSignupButtonEnabled = Email.IsValid && MobileNumber.IsValid && Password.IsValid && ConfirmPassword.IsValid;
        }
        private void ValidatePassword()
        {
            Password.Validate();
            IsSignupButtonEnabled = Email.IsValid && MobileNumber.IsValid && Password.IsValid && ConfirmPassword.IsValid;
        }
        private void ValidateConfirmPassword()
        {
            ConfirmPassword.Validate();
            if (ConfirmPassword.IsValid)
            {
                if (!ConfirmPassword.Value.Equals(Password.Value))
                {
                    ConfirmPassword.ErrorMsg = "Please make sure that you entered the same password";
                    ConfirmPassword.IsValid = false;
                }
            }
            IsSignupButtonEnabled = Email.IsValid && MobileNumber.IsValid && Password.IsValid && ConfirmPassword.IsValid;
        }
        private void NavigateToUsersPage()
        {
            NavigationService.NavigateAsync(nameof(UsersPage));
        } 
        #endregion

    }

}
