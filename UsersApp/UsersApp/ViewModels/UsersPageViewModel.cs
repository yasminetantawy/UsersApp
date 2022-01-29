using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UsersApp.Business.Services;
using UsersApp.Models;
using UsersApp.Views;
using Xamarin.Essentials;

namespace UsersApp.ViewModels
{
    public class UsersPageViewModel : BindableBase, INavigationAware
    {
        INavigationService NavigationService;
        UsersService UsersService;

        private ObservableCollection<UserModel> usersList;
        public ObservableCollection<UserModel> UsersList
        {
            get
            {
                return usersList;
            }
            set
            {
                SetProperty(ref usersList, value);
            }
        }
        public DelegateCommand<object> UserSelectedCommand { get; set; }
        public UsersPageViewModel(INavigationService navigationService, UsersService usersService)
        {
            NavigationService = navigationService;
            UsersService = usersService;
            UserSelectedCommand = new DelegateCommand<object>(UserSelected);

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetUsers();
        }



        private void UserSelected(object obj)
        {
            NavigationService.NavigateAsync(nameof(ProfilePage), new NavigationParameters() { { "SelectedUser", obj } });
        }

        private async Task GetUsers()
        {
            bool IsInernetAvailable = CheckInternetConnectivity();
            if (!IsInernetAvailable)
            {              
                await App.Current.MainPage.DisplayAlert("No Available Internet", "Please make sure that you are connected to the internet", "OK");
                return;
            }
            try
            {
                var Obj = await UsersService.GetUsers();
                UsersList = new ObservableCollection<UserModel>(Obj.data);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Sorry, Someting went wrong", "OK");
            }

        }
        public bool CheckInternetConnectivity()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                return true;
            }
            else if (current == NetworkAccess.ConstrainedInternet)
            {                
                return false;
            }
            else if (current == NetworkAccess.Local)
            {
                //Local network access only.
                return false;
            }
            else if (current == NetworkAccess.None)
            {
                //No connectivity is available.
                return false;
            }
            else if (current == NetworkAccess.Unknown)
            {
                //Unable to determine internet connectivity.
                return false;
            }
            else
                return false;
        }
    }
}