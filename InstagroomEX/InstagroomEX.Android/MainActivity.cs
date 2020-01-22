using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.OS;
using FFImageLoading.Forms.Platform;
using InstagroomEX.Contracts;
using InstagroomEX.Droid.Services;
using Plugin.CurrentActivity;
using Prism;
using Prism.Ioc;

namespace InstagroomEX.Droid
{
    [Activity(Label = "InstagroomEX", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity/*, Android.App.Application.IActivityLifecycleCallbacks*/
    {

        internal static MainActivity Instance { get; private set; }
        internal static Context ActivityContext { get; private set; }
        
        private IGoogleManager _googleManagerService;//??incorrect naming
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            UserDialogs.Init(this);
            CrossCurrentActivity.Current.Init(this, bundle);//for using media plugin

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            CachedImageRenderer.Init(true);//for using FFImageLoading 
            Instance = this;

            ActivityContext = this;

            var container = (App.Current as PrismApplicationBase).Container;
            _googleManagerService = container.Resolve<IGoogleManager>();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if(requestCode == 1)
            {
                GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                _googleManagerService.OnAuthCompleted(result);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        //public void OnActivityResumed(Activity activity)
        //{
        //    ActivityContext = activity;
        //}

        //public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        //{
        //    ActivityContext = activity;
        //}
        //public void OnActivityStarted(Activity activity)
        //{
        //    ActivityContext = activity;
        //}
        //#region Activities
        //public void OnActivityDestroyed(Activity activity)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public void OnActivityPaused(Activity activity)
        //{
        //    throw new System.NotImplementedException();
        //}
        //public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        //{
        //    throw new System.NotImplementedException();
        //}
        //public void OnActivityStopped(Activity activity)
        //{
        //    throw new System.NotImplementedException();
        //}
        //#endregion
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
            containerRegistry.RegisterSingleton<ISQLiteConnectionService, SQLiteConnectionService>();
            containerRegistry.RegisterSingleton<IGoogleManager, GoogleManagerService>();
        }
    }
}

