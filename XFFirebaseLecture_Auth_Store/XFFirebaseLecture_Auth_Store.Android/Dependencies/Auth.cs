using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using XFFirebaseLecture_Auth_Store.ViewModels.Helpers;

namespace XFFirebaseLecture_Auth_Store.Droid.Dependencies
{
    public class Auth : IAuth
    {
        public Task<bool> AuthenticateUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentUserId()
        {
            throw new NotImplementedException();
        }

        public bool IsAuthenticated()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUser(string name, string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

                var profileUpdates = new Firebase.Auth.UserProfileChangeRequest.Builder();
                profileUpdates.SetDisplayName(name);
                var build = profileUpdates.Build();

                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
                await user.UpdateProfileAsync(build);

                return true;
            }
            catch(FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception();
            }
        }
    }
}