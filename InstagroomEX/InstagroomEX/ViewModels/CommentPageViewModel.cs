using InstagroomEX.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InstagroomEX.ViewModels
{
    public class CommentPageViewModel : ViewModelBase
    {
        private readonly IUserDataService _userDataService;

        private UserDto currentUser;
        public UserDto CurrentUser
        {
            get { return currentUser; }
            set { SetProperty(ref currentUser, value); }
        }

        private ObservableCollection<string> _someUserComment;
        public ObservableCollection<string> SomeUserComment
        {
            get { return _someUserComment; }
            set { SetProperty(ref _someUserComment, value); }
        }
        public CommentPageViewModel(INavigationService navigationService, IUserDataService userDataService) :
            base(navigationService)
        {
            _userDataService = userDataService;
            CurrentUser = _userDataService.CurrentUser;


            SomeUserComment = new ObservableCollection<string>();

            SomeUserComment.Add("Its amaizing");
            SomeUserComment.Add("Great!");
            SomeUserComment.Add("OMG!");
            SomeUserComment.Add("Wooooooooooooow!");
        }
    }
}
