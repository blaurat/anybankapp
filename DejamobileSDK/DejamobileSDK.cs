using DejamobileSDK.Models;
using DejamobileSDK.Services;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Ioc;
using System.Linq;

namespace DejamobileSDK
{
    public class DejamobileSDK
    {
        public void Initialise(string localStorageFilePath)
        {
            DependencyService.Register<DejamobileBackEnd.DejamobileBackEnd>();
            DependencyService.Get<DejamobileBackEnd.DejamobileBackEnd>().Initialise();

            DependencyService.Register<LocalStorage>();
            DependencyService.Get<LocalStorage>().Connect(localStorageFilePath);

            DependencyService.Get<LocalStorage>().Connection.CreateTable<DigitizedCard>(SQLite.CreateFlags.AllImplicit);
            DependencyService.Get<LocalStorage>().Connection.CreateTable<DigitizedCardAnalytic>(SQLite.CreateFlags.AllImplicit);
            DependencyService.Get<LocalStorage>().Connection.CreateTable<UserProfile>(SQLite.CreateFlags.AllImplicit);

            DependencyService.Register<IDigitizedCardService, DigitizedCardService>();
            DependencyService.Register<IUserService, UserService>();

            DependencyService.Get<IDigitizedCardService>().Initialise();

            // Initial User
            DependencyService.Get<IUserService>().Enroll(new UserProfile() { ClientNumber = "1", Email = "user1@bank1.com", Phone = "+33212345678" });

            SimpleIoc.Default.Register(() => DependencyService.Get<IUserService>().GetAll().FirstOrDefault());
        }
    }
}
