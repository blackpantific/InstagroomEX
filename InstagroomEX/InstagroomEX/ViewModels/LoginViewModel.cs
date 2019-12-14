using Acr.UserDialogs;
using InstagroomEX.Contracts;
using InstagroomEX.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstagroomEX.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IUserDataService _userDataService;

        private string _username;
        private string _password;

        #region Bindable Properties
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        #endregion

        private DelegateCommand _toRegistrationPage;
        private DelegateCommand _logIng;
        private DelegateCommand _logInViaGoogle;
        public DelegateCommand ToRegistrationPage =>
            _toRegistrationPage ?? (_toRegistrationPage = new DelegateCommand(ExecuteToRegistrationPage));
        public DelegateCommand LogIn =>
            _logIng ?? (_logIng = new DelegateCommand(ExecuteLogIn));
        public DelegateCommand LogInViaGoogle =>
            _logInViaGoogle ?? (_logInViaGoogle = new DelegateCommand(ExecuteLogInViaGoogle));

        async void ExecuteToRegistrationPage()
        {
            await NavigationService.NavigateAsync("/NavigationPage/WelcomeView/RegistrationView");
        }
        async void ExecuteLogIn()
        {
            if (String.IsNullOrWhiteSpace(Username))
            {
                UserDialogs.Instance.Toast("Please enter your username");
                return;
            }

            if (String.IsNullOrWhiteSpace(Password))
            {
                UserDialogs.Instance.Toast("Please enter your password");
                return;
            }

            var user = await _userDataService.GetUserByUsernameAsync(Username);

            if (user != null)
            {
                if (user.Password == Password)
                {
                    _userDataService.CurrentUser = user;
                    SettingsHelper.UserId = user.ID;
                    await NavigationService.NavigateAsync("/NavigationPage/MasterTabbedPageView");
                }
                else
                {
                    await UserDialogs.Instance.AlertAsync(ConstantHelper.PasswordIncorrectAlert, "Error", "OK");
                    Password = string.Empty;
                }
            }
            else
            {
                await UserDialogs.Instance.AlertAsync($"User \"{Username}\" does not exist. Try re-entering your credentials", "Error", "OK");
                Password = string.Empty;
            }

        }
        void ExecuteLogInViaGoogle()
        {

        }
        

        public LoginViewModel(INavigationService navigationService, IUserDataService userDataService) :
            base(navigationService)
        {
            _userDataService = userDataService;
        }
    }
}
