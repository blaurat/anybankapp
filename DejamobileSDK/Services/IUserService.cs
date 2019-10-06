using DejamobileSDK.Models;
using System.Collections.Generic;

namespace DejamobileSDK.Services
{
    public interface IUserService
    {
        void Enroll(UserProfile userProfile);

        List<UserProfile> GetAll();
    }
}
