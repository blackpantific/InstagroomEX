using Prism;
using Prism.Ioc;
using InstagroomEX.ViewModels;
using InstagroomEX.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InstagroomEX.Services;
using InstagroomEX.Contracts;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace InstagroomEX
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/WelcomeView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IValidationService, ValidationService>();
            containerRegistry.RegisterSingleton<IUserDataService, UserDataService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<WelcomeView, WelcomeViewModel>();
            containerRegistry.RegisterForNavigation<RegistrationView, RegistrationViewModel>();
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<MasterTabbedPageView, MasterTabbedPageViewModel>();

        }
    }
}
