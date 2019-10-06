using AnyBankApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AnyBankApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class UserProfilePage : ContentPage
    {
        UserProfileViewModel viewModel;

        public UserProfilePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new UserProfileViewModel();
        }

        private void UserProfilePage_Appearing(object sender, System.EventArgs e)
        {
            viewModel.LoadUserProfileCommand.Execute(null);
        }
    }
}