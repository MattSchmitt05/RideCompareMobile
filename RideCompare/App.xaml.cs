using Prism;
using Prism.Ioc;
using Prism.Unity;
using RideCompare.ViewModels;
using RideCompare.Views;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: InternalsVisibleTo("RideCompare.Tests.AcceptanceTests")]
[assembly: InternalsVisibleTo("RideCompare.Tests.EndToEndTests")]
namespace RideCompare
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("/CustomNavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CustomNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LocationsPage, LocationsPageViewModel>();
            containerRegistry.RegisterForNavigation<BestRideDetailsPage, BestRideDetailsPageViewModel>();
        }
    }
}
