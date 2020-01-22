using Acr.UserDialogs;
using InstagroomEX.Contracts;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstagroomEX.ViewModels
{
    public class EditProfileViewModel : ViewModelBase
    {
        private readonly IWorkWithPhotoService _workWithPhotoService;
        private readonly IUserDataService _userDataService;
        private readonly IValidationService _validationService;

        private DelegateCommand _takePhoto;
        private DelegateCommand _openGallery;

        private string _email;
        private string _currentPassword;
        private string _newPassword;
        private string _username;

        #region
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public string NewPassword
        {
            get { return _newPassword; }
            set { SetProperty(ref _newPassword, value); }
        }
        public string CurrentPassword
        {
            get { return _currentPassword; }
            set { SetProperty(ref _currentPassword, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        #endregion

        private string _previewImagePath;
        public string PreviewImagePath
        {
            get { return _previewImagePath; }
            set { SetProperty(ref _previewImagePath, value); }
        }

        private DelegateCommand _saveChanges;
        public DelegateCommand SaveChanges =>
            _saveChanges ?? (_saveChanges = new DelegateCommand(ExecuteSaveChanges));

        void ExecuteSaveChanges()
        {
            if (!String.IsNullOrEmpty(Email))
            {
                if(_userDataService.CurrentUser.Email.Equals(Email))
                {
                    UserDialogs.Instance.Toast("Email match");
                    return;
                }
                else if(!_validationService.ValidateEmail(Email))
                {
                    UserDialogs.Instance.Toast("Wrong email");
                    return;
                }
                else
                {
                    //проверка имейл
                    _userDataService.CurrentUser.Email = this.Email;
                }
            }
            if (!String.IsNullOrEmpty(Username))
            {
                if (_userDataService.CurrentUser.Username.Equals(Username))
                {
                    UserDialogs.Instance.Toast("Username match");
                    return;
                }
                else
                {
                    _userDataService.CurrentUser.Username = this.Username;
                }
            }
            if (!String.IsNullOrEmpty(NewPassword))
            {
                if (String.IsNullOrEmpty(CurrentPassword))
                {
                    UserDialogs.Instance.Toast("Enter your current password");
                    return;
                }
                else
                {
                    if(_userDataService.CurrentUser.Password.Equals(CurrentPassword) &&
                        !_userDataService.CurrentUser.Password.Equals(NewPassword))
                    {
                        _userDataService.CurrentUser.Password = this.NewPassword;
                    }
                    else
                    {
                        UserDialogs.Instance.Toast("Enter the correct password");
                        return;
                    }
                }
            }

            _userDataService.UpdateUserAsync(_userDataService.CurrentUser);//cause my team lead said so
        }

        public DelegateCommand OpenGallery =>
            _openGallery ?? (_openGallery = new DelegateCommand(ExecuteOpenGallery));
        public DelegateCommand TakePhoto =>
            _takePhoto ?? (_takePhoto = new DelegateCommand(ExecuteTakePhoto));

        async void ExecuteOpenGallery()
        {
            PreviewImagePath = await _workWithPhotoService.PickPhoto();
        }
        async void ExecuteTakePhoto()
        {
            PreviewImagePath = await _workWithPhotoService.TakePhoto();
        }



        public EditProfileViewModel(INavigationService navigationService, IWorkWithPhotoService workWithPhotoService,
            IUserDataService userDataService, IValidationService validationService) :
            base(navigationService)
        {
            _workWithPhotoService = workWithPhotoService;
            _userDataService = userDataService;
            _validationService = validationService;
        }
    }
}
