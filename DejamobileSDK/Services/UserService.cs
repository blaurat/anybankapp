using DejamobileSDK.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DejamobileSDK.Services
{
    public class UserService : IUserService
    {
        public void Enroll(UserProfile userProfile)
        {
            DependencyService.Get<LocalStorage>().Connection.InsertOrReplace(userProfile);
        }

        public List<UserProfile> GetAll()
        {
            return DependencyService.Get<LocalStorage>().Connection.Table<UserProfile>().OrderBy(x => x.ClientNumber).ToList();
        }
    }
}
