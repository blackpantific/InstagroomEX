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
    public class WelcomeViewModel : ViewModelBase
    {
        private IUserDataService _userDataService;

        private DelegateCommand _toRegistrationPage;
        public DelegateCommand ToRegistrationPage =>
            _toRegistrationPage ?? (_toRegistrationPage = new DelegateCommand(ExecuteToRegistrationPage, CanExecuteToRegistrationPage));


        private DelegateCommand _toLoginPage;
        public DelegateCommand ToLoginPage =>
            _toLoginPage ?? (_toLoginPage = new DelegateCommand(ExecuteToLoginPage, CanExecuteToLoginPage));

        async void ExecuteToLoginPage()
        {
            await NavigationService.NavigateAsync("LoginView");
        }

        bool CanExecuteToLoginPage()
        {
            return true;
        }

        async void ExecuteToRegistrationPage()
        {
            await NavigationService.NavigateAsync("RegistrationView");
        }

        bool CanExecuteToRegistrationPage()
        {
            return true;
        }

        public WelcomeViewModel(INavigationService navigationService, IUserDataService userDataService) :
            base(navigationService)
        {
            _userDataService = userDataService;
        }

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            var savedUserId = SettingsHelper.UserId;
            if(savedUserId != -1)
            {
                var currentUser = await _userDataService.GetUserByIDAsync(savedUserId);
                if(currentUser == null)
                {
                    //Error
                }
                else
                {
                    _userDataService.CurrentUser = currentUser;
                    await NavigationService.NavigateAsync("/NavigationPage/MasterTabbedPageView");
                }
            }
            //проверкаfffffffffffffffffdfgjghjkl

            //var user = await _userDataService.GetUserByUsernameAsync(Username); только по ID
            // CurrentUser -> mastertabbedpage
            //preference
        }
    }
}
