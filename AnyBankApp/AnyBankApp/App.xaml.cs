using Xamarin.Forms;
using AnyBankApp.Services;
using AnyBankApp.Views;

namespace AnyBankApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<DejamobileSDK.DejamobileSDK>();
            string LocalStoragePath = DependencyService.Get<IFileHelper>().GetDownloadFilePath(string.Empty, "LocalStorage.sqlite");
            DependencyService.Get<DejamobileSDK.DejamobileSDK>().Initialise(LocalStoragePath);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
