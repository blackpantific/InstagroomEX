using InstagroomEX.Contracts;
using InstagroomEX.Helpers;
using InstagroomEX.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace InstagroomEX.ViewModels
{
    public class AccountPageViewModel : ViewModelBase
    {
        private IUserDataService _userDataService;


        private List<Image> _images;
        public List<Image> Images
        {
            get { return _images; }
            set { SetProperty(ref _images, value); }
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

        //private string _fullName;
        //private string _posts;
        //private string _followers;
        //private string _following;
        //private string _username;

        //#region Properties
        //public string Following
        //{
        //    get { return _following; }
        //    set { SetProperty(ref _following, value); }
        //}
        //public string Followers
        //{
        //    get { return _followers; }
        //    set { SetProperty(ref _followers, value); }
        //}
        //public string Posts
        //{
        //    get { return _posts; }
        //    set { SetProperty(ref _posts, value); }
        //}
        //public string FullName
        //{
        //    get { return _fullName; }
        //    set { SetProperty(ref _fullName, value); }
        //}        
        //public string Username
        //{
        //    get { return _username; }
        //    set { SetProperty(ref _username, value); }
        //}
        //#endregion

        private DelegateCommand _refreshCommand;
        public DelegateCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExecuteRefreshCommand));

        private DelegateCommand _updateImagesCommand;
        public DelegateCommand UpdateImagesCommand =>
            _updateImagesCommand ?? (_updateImagesCommand = new DelegateCommand(ExecuteUpdateImagesCommand));

        void ExecuteUpdateImagesCommand()
        {
            Image im = new Image();
            im.Source = "Huayra3.jpg";
            Image im7 = new Image();
            im7.Source = "Huayra1.jpg";
            
            Images.Add(im7);
            Images.Add(im7);
            Images.Add(im);
            Images.Add(im);
            Images.Add(im);
            Images.Add(im);
        }


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

            Images = new List<Image>();

            Image im = new Image();
            im.Source = "Huayra3.jpg";
            Images.Add(im);
            Image im1 = new Image();
            im1.Source = "Huayra1.jpg";
            Images.Add(im1);
            Image im2 = new Image();
            im2.Source = "Huayra4.jpg";
            Images.Add(im2);
            Image im3 = new Image();
            im3.Source = "Huayra3.jpg";
            Images.Add(im3);
            Image im4 = new Image();
            im4.Source = "Huayra1.jpg";
            Images.Add(im4);
            Image im5 = new Image();
            im5.Source = "Huayra4.jpg";
            Images.Add(im5);
            Image im6 = new Image();
            im6.Source = "Huayra3.jpg";
            Images.Add(im6);
            Image im7 = new Image();
            im7.Source = "Huayra1.jpg";
            Images.Add(im7);
            Images.Add(im7);
            Images.Add(im7);
            Images.Add(im7);
            Images.Add(im7);
            Images.Add(im7);
            Images.Add(im7);
            Images.Add(im);


            //Images.Add(im);
            //Images.Add(im);

        }
    }
}
