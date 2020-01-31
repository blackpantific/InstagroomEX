using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InstagroomEX.Contracts;
using InstagroomEX.Model;
using Xamarin.Forms;

namespace InstagroomEX.Droid.Services
{
    public class GoogleManagerService : Java.Lang.Object, IGoogleManager, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        public Action<UserDto, string> _onLoginComplete;  //в случае ошибки попробовать паблик и в свойстве ниже тоже

        public static GoogleApiClient _googleApiClient;
        public UserDto CurrentUser { get; set; }

        public static GoogleManagerService Instance { get; private set; }



        public void Login(Action<UserDto, string> OnLoginComplete)
        {
            _onLoginComplete = OnLoginComplete;
            Intent signInIntent = Auth.GoogleSignInApi.GetSignInIntent(_googleApiClient);
            MainActivity.Instance.StartActivityForResult(signInIntent, 1);//костыль
            //_googleApiClient.Connect();
        }

        public void Logout()
        {
            _googleApiClient.Disconnect();
        }

        public void OnAuthCompleted(object result)
        {
            if (((GoogleSignInResult)result).IsSuccess)
            {
                GoogleSignInAccount account = ((GoogleSignInResult)result).SignInAccount;
                _onLoginComplete?.Invoke(CurrentUser, string.Empty);
            }
            else
            {
                _onLoginComplete?.Invoke(null, "An error occured!");
            }
        }


        public void OnConnected(Bundle connectionHint)
        {
            
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            _onLoginComplete?.Invoke(null, result.ErrorMessage);
        }

        public void OnConnectionSuspended(int cause)
        {
            _onLoginComplete?.Invoke(null, "Canceled!");
        }

        public GoogleManagerService()
        {
            Instance = this;

            CurrentUser = new UserDto();

            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                //.RequestIdToken("674374288476-paqqdnstn17dii7n81okj06l0r417vgv.apps.googleusercontent.com")
                .RequestEmail()
                .Build();

            _googleApiClient = new GoogleApiClient.Builder(MainActivity.ActivityContext)
                .AddConnectionCallbacks(this)
                .AddOnConnectionFailedListener(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                //.AddScope(new Scope(Scopes.Profile))
                .Build();
            _googleApiClient.Connect();
        }
    }
}