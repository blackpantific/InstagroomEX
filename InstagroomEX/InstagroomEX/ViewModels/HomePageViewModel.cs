using FFImageLoading.Forms;
using InstagroomEX.Extentions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace InstagroomEX.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private IUserDataService _userDataService;


        private string _label = "Posts from people you're following will appear here \n Use the search tab to find people to follow";

        private string _userAvatarPath;
        public string UserAvatarPath
        {
            get { return _userAvatarPath; }
            set { SetProperty(ref _userAvatarPath, value); }
        }

        private string _postUserDescription;
        public string PostUserDescription
        {
            get { return _postUserDescription; }
            set { SetProperty(ref _postUserDescription, value); }
        }

        private string _numberOfComments;
        public string NumberOfComments
        {
            get { return _numberOfComments; }
            set { SetProperty(ref _numberOfComments, value); }
        }

        private string _hoursAgo;
        public string HoursAgo
        {
            get { return _hoursAgo; }
            set { SetProperty(ref _hoursAgo, value); }
        }

        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        private DelegateCommand _refreshCommand;

        private DelegateCommand _commentFFImageButtonCommand;
        public DelegateCommand CommentFFImageButtonCommand =>
            _commentFFImageButtonCommand ?? (_commentFFImageButtonCommand = new DelegateCommand(ExecuteCommentFFImageButtonCommand));

        async void ExecuteCommentFFImageButtonCommand()
        {
            await NavigationService.NavigateAsync("/NavigationPage/MasterTabbedPageView/CommentPageView");
        }
        public DelegateCommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new DelegateCommand(ExecuteRefreshCommand));

        private void ExecuteRefreshCommand()
        {
            // refresh posts feed command
            IsRefreshing = false;
        }

        private ObservableCollection<Image> images;
        public ObservableCollection<Image> Images
        {
            get { return images; }
            set { SetProperty(ref images, value); }
        }

        private ObservableCollection<string> imagesPath;
        public ObservableCollection<string> ImagesPath
        {
            get { return imagesPath; }
            set { SetProperty(ref imagesPath, value); }
        }

        private string _storyBorderColor;
        public string StoryBorderColor
        {
            get { return _storyBorderColor; }
            set { SetProperty(ref _storyBorderColor, value); }
        }

        private string _loadMoreUserDescription;
        public string LoadMoreUserDescription
        {
            get { return _loadMoreUserDescription; }
            set { SetProperty(ref _loadMoreUserDescription, value); }
        }

        private DelegateCommand _loadMoreUserDescriptionCommand;
        public DelegateCommand LoadMoreUserDescriptionCommand =>
            _loadMoreUserDescriptionCommand ?? (_loadMoreUserDescriptionCommand = new DelegateCommand(ExecuteLoadMoreUserDescriptionCommand));

        void ExecuteLoadMoreUserDescriptionCommand()
        {
            var a = 3 + 5;
        }

        public string allText;
        public HomePageViewModel(INavigationService navigationService, IUserDataService userDataService) :
            base(navigationService)
        {
            _userDataService = userDataService;
            UserAvatarPath = _userDataService.CurrentUser.ImagePath;



            Images = new ObservableCollection<Image>();
            ImagesPath = new ObservableCollection<string>();

            StoryBorderColor = Color.OrangeRed.ToString();

            Image image = new Image() { Source = "Huayra3.jpg" };

            Image image1 = new Image() { Source = "Huayra4.jpg" };

            Images.Add(image);
            Images.Add(image1);

            ImagesPath.Add("Huayra1.jpg");
            ImagesPath.Add("Huayra2.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");
            ImagesPath.Add("Huayra3.jpg");

            LoadMoreUserDescription = "(more)";

            PostUserDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            if (PostUserDescription.Length > 65)
            {
                allText = PostUserDescription;
                PostUserDescription = PostUserDescription.TruncateLongStringAtWord(65);
            }

            DateTime time1 = new DateTime(2020, 02, 8, 16, 0, 3);



                var time = DateTime.UtcNow;

            string fullTimeDescription = time.ToString();



             string str = time.ToString("G", new CultureInfo("de-DE"));

            DateTime dateTime = DateTime.ParseExact(str, "G", new CultureInfo("de-DE"));

            fullTimeDescription = dateTime.ToString();

            TimeSpan timeSpan = dateTime - time1;

            var _NumberOfComments = 50;

            NumberOfComments = $"View all ({_NumberOfComments}) comments";



            if (timeSpan.Days >= 8)
            {
                //25 march 2019
                HoursAgo = time.ToString("dd MMMM yyyy");
            }
            else
            {
                if (timeSpan.Days == 0)
                {
                    //n hours ago
                    if(timeSpan.Hours == 0)
                    {
                        HoursAgo = $"{timeSpan.Minutes} minutes ago";
                    }
                    else
                    {
                        HoursAgo = $"{timeSpan.Hours} hours ago";
                    }
                    
                }
                else
                {
                    //n days ago
                    HoursAgo = $"{timeSpan.Days} days ago";
                }
            }


        }

        
    }
}
