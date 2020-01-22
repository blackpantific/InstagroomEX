using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstagroomEX.ViewModels
{
    public class NotificationPageViewModel : ViewModelBase
    {

        private string _label = "Your notifications will appear here";
        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }
        public NotificationPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {

        }
    }
}
