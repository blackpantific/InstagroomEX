using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InstagroomEX.ViewModels
{
    public class SearchPageViewModel : ViewModelBase
    {

        private DelegateCommand _filterComand;
        public DelegateCommand FilterComand =>
            _filterComand ?? (_filterComand = new DelegateCommand(ExecuteFilterComand));

        private ObservableCollection<string> _listUsers;

        public ObservableCollection<string> ListUsers
        {
            get { return _listUsers; }
            set { SetProperty(ref _listUsers, value); }
        }

        void ExecuteFilterComand()
        {

        }

        public SearchPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            ListUsers = new ObservableCollection<string>();

            ListUsers.Add("Huayra1");
            ListUsers.Add("Huayra2");
            ListUsers.Add("Huayra3");
        }
    }
}
