using Acr.UserDialogs;
using FFImageLoading.Forms;
using InstagroomEX.Contracts;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace InstagroomEX.ViewModels
{
    public class AddPhotoPageViewModel : ViewModelBase
    {
        private readonly IWorkWithPhotoService _workWithPhotoService;

        private DelegateCommand _takePhoto;
        private DelegateCommand _openGallery;
        private DelegateCommand _post;

        private string _previewImagePath;
        private string _userDescription;
        public string PreviewImagePath
        {
            get { return _previewImagePath; }
            set { SetProperty(ref _previewImagePath, value); }
        }
        public string UserDescription
        {
            get { return _userDescription; }
            set { SetProperty(ref _userDescription, value); }
        }


        public DelegateCommand Post =>
            _post ?? (_post = new DelegateCommand(ExecutePost));
        public DelegateCommand OpenGallery =>
            _openGallery ?? (_openGallery = new DelegateCommand(ExecuteOpenGallery));
        public DelegateCommand TakePhoto =>
            _takePhoto ?? (_takePhoto = new DelegateCommand(ExecuteTakePhoto));
        void ExecutePost()
        {

        }
        async void ExecuteOpenGallery()
        {
             PreviewImagePath = await _workWithPhotoService.PickPhoto();
        }
        async void ExecuteTakePhoto()
        {
            PreviewImagePath = await _workWithPhotoService.TakePhoto();
        }

        public AddPhotoPageViewModel(INavigationService navigationService, IWorkWithPhotoService workWithPhotoService) :
            base(navigationService)
        {
            _workWithPhotoService = workWithPhotoService;
            PreviewImagePath = String.Empty;
            
        }
    }
}
