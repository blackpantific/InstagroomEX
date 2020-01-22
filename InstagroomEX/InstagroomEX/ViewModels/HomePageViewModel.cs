using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstagroomEX.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {

        private string _label = "Posts from people you're following will appear here \n Use the search tab to find people to follow";
        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }
        public HomePageViewModel(INavigationService navigationService) :
            base(navigationService)
        {

        }
    }
}
