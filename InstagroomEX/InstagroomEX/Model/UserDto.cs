using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstagroomEX.Model
{
    public class UserDto : BindableBase
    {
        private int _id;
        private string _googleID;
        private string _username;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _email;
        private string _userAvatar;
        private string _imagePath;
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        #region Properties
        public string ImagePath
        {
            get { return _imagePath; }
            set { SetProperty(ref _imagePath, value); }
        }
        public string UserAvatar
        {
            get { return _userAvatar; }
            set { SetProperty(ref _userAvatar, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                SetProperty(ref _lastName, value);
                RaisePropertyChanged(nameof(FullName));
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                SetProperty(ref _firstName, value);
                RaisePropertyChanged(nameof(FullName));
            }
        }
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public string GoogleID
        {
            get { return _googleID; }
            set { SetProperty(ref _googleID, value); }
        }
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        #endregion 

    }
}
