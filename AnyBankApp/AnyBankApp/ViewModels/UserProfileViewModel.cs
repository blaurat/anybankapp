using DejamobileSDK.Models;
using DejamobileSDK.Services;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AnyBankApp.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        public UserProfile UserProfile { get; set; }

        public ICommand SaveCommand { get; }

        public ICommand LoadUserProfileCommand { get; set; }

        public UserProfileViewModel()
        {
            Title = "User Profile";

            LoadUserProfileCommand = new Command(ExecuteLoadUserProfileCommand);
            SaveCommand = new Command(ExecuteSaveCommand);
        }

        void ExecuteLoadUserProfileCommand()
        {
            UserProfile = DependencyService.Get<IUserService>().GetAll().FirstOrDefault();
            OnPropertyChanged("UserProfile");
        }

        private void ExecuteSaveCommand()
        {
            DependencyService.Get<IUserService>().Enroll(UserProfile);
        }
    }
}