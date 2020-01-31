using Acr.UserDialogs;
using InstagroomEX.Contracts;
using InstagroomEX.Helpers;
using InstagroomEX.Mapper;
using InstagroomEX.Model;
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
        private readonly IGoogleManager _googleManager;
        private readonly IValidationService _validationService;

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
            _googleManager.Login(OnLoginComplete);
        }

        private async void OnLoginComplete(UserDto googleUser, string message)
        {
            if(googleUser != null)
            {
                await _userDataService.AddUserAsync(googleUser);
                googleUser = await _userDataService.GetUserByGoogleIDAsync(googleUser.GoogleID);


                _userDataService.CurrentUser = googleUser;
                SettingsHelper.UserId = googleUser.ID;

                UserDialogs.Instance.Toast(_validationService.RemarkRegistrationCompletedSuccessfully);

                await NavigationService.NavigateAsync("/NavigationPage/MasterTabbedPageView");
            }
            else
            {
                await UserDialogs.Instance.AlertAsync(message, "Warning", "OK");
            }
        }

        public LoginViewModel(INavigationService navigationService, IUserDataService userDataService, 
            IGoogleManager googleManager, IValidationService validationService) :
            base(navigationService)
        {
            _userDataService = userDataService;
            _googleManager = googleManager;
            _validationService = validationService;
        }
    }
}
