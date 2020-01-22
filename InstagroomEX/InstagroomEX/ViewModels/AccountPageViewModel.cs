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
    public class AccountPageViewModel : ViewModelBase
    {
        private IUserDataService _userDataService;

        private string _fullName;
        private string _posts;
        private string _followers;
        private string _following;
        private string _username;

        #region Properties
        public string Following
        {
            get { return _following; }
            set { SetProperty(ref _following, value); }
        }
        public string Followers
        {
            get { return _followers; }
            set { SetProperty(ref _followers, value); }
        }
        public string Posts
        {
            get { return _posts; }
            set { SetProperty(ref _posts, value); }
        }
        public string FullName
        {
            get { return _fullName; }
            set { SetProperty(ref _fullName, value); }
        }        
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        #endregion
        private DelegateCommand _logoutCommand;
        public DelegateCommand LogOutCommand =>
            _logoutCommand ?? (_logoutCommand = new DelegateCommand(ExecuteLogOutCommand));

        async void ExecuteLogOutCommand()
        {
            SettingsHelper.UserId = -1;
            _userDataService.CurrentUser = null;
            await NavigationService.NavigateAsync("/NavigationPage/WelcomeView");
        }

        private DelegateCommand _editProfileComand;
        public DelegateCommand EditProfileCommand =>
            _editProfileComand ?? (_editProfileComand = new DelegateCommand(ExecuteEditProfileCommand));

        async void ExecuteEditProfileCommand()
        {
            await NavigationService.NavigateAsync("/NavigationPage/MasterTabbedPageView?selectedTab=AccountPageView/EditProfileView");
        }

        public AccountPageViewModel(INavigationService navigationService, IUserDataService userDataService) :
            base(navigationService)
        {
            _userDataService = userDataService;

            FullName = _userDataService.GetUserFullName(_userDataService.CurrentUser);
            Username = "@"+ _userDataService.CurrentUser.Username;
        }
    }
}
