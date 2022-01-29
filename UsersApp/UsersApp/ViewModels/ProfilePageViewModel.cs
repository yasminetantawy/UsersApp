using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApp.Models;

namespace UsersApp.ViewModels
{
    public class ProfilePageViewModel : BindableBase, INavigationAware
    {
        INavigationService NavigationService;
        private UserModel selectedUser;
        public UserModel SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                SetProperty(ref selectedUser, value);
            }
        }
        public DelegateCommand GoBackCommand { get; set; }
        public ProfilePageViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            GoBackCommand = new DelegateCommand(async () => await GoBack());
        }

        private async Task GoBack()
        {
            await NavigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
           if (parameters!=null && parameters.ContainsKey("SelectedUser"))
            {
                SelectedUser = parameters["SelectedUser"] as UserModel;
            }
        }
    }
}
