using FFImageLoading.Forms;
using InstagroomEX.Contracts;
using InstagroomEX.Helpers;
using InstagroomEX.Model;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace InstagroomEX.ViewModels
{
    public class AccountPageViewModel : ViewModelBase, IActiveAware
    {
        private IUserDataService _userDataService;

        public ObservableCollection<Image> Images { get; set; } = new ObservableCollection<Image>();//it should be propp

        private string _buttonColor;
        public string ButtonColor
        {
            get { return _buttonColor; }
            set { SetProperty(ref _buttonColor, value); }
        }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }


        private UserDto _currentUser;

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }
        public UserDto CurrentUser
        {
            get { return _currentUser; }
            set { SetProperty(ref _currentUser, value); }
        }

        private DelegateCommand _refreshCommand;
        public DelegateCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExecuteRefreshCommand));

        //private DelegateCommand _updateImagesCommand;
        //public DelegateCommand UpdateImagesCommand =>
        //    _updateImagesCommand ?? (_updateImagesCommand = new DelegateCommand(ExecuteUpdateImagesCommand));

        //void ExecuteUpdateImagesCommand()
        //{
        //    if (IsActive)
        //    {

        //    }
        //}


        void ExecuteRefreshCommand()
        {
            // refresh posts feed command
            IsRefreshing = false;
        }

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

        public event EventHandler IsActiveChanged;

        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        private DelegateCommand _photoListSelectionChangeCommand;
        public DelegateCommand PhotoListSelectionChangeCommand =>
            _photoListSelectionChangeCommand ?? (_photoListSelectionChangeCommand = new DelegateCommand(ExecutePhotoListSelectionChangeCommand));

        void ExecutePhotoListSelectionChangeCommand()
        {
            var a = SelectedItem;
        }


        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        async void ExecuteEditProfileCommand()
        {
            await NavigationService.NavigateAsync("/NavigationPage/MasterTabbedPageView?selectedTab=AccountPageView/EditProfileView");
        }

        public AccountPageViewModel(INavigationService navigationService, IUserDataService userDataService) :
            base(navigationService)
        {
            _userDataService = userDataService;
            CurrentUser = userDataService.CurrentUser;

            if (String.IsNullOrEmpty(this.CurrentUser.ImagePath))
            {
                this.CurrentUser.ImagePath = "user_avatar.jpg";     
            }


            Image image = new Image() { Source = "Huayra3.jpg" };

            Image image1 = new Image() { Source = "Huayra4.jpg" };

            Image image2 = new Image() { Source = "Huayra2.jpg" };

            Images.Add(image);
            Images.Add(image1);
            Images.Add(image2);

            ButtonText = "Edit profile";
        }
    }
}
