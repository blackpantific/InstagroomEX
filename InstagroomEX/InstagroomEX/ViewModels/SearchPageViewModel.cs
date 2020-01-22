using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstagroomEX.ViewModels
{
    public class SearchPageViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        public SearchPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {

        }
    }
}
