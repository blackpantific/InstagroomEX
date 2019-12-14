using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace InstagroomEX.Helpers
{
    public static class SettingsHelper
    {
        private static string _userIdKey = "userIdKey";
        public static int UserId 
        { 
            get 
            {
                return Preferences.Get(_userIdKey, -1);
            }
            set 
            {
                Preferences.Set(_userIdKey, value);
            } 
        }
    }
}
