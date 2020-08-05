using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFirebaseLecture_Auth_Store.ViewModels;
using XFFirebaseLecture_Auth_Store.ViewModels.Helpers;

namespace XFFirebaseLecture_Auth_Store.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubscriptionsPage : ContentPage
    {
        SubscriptionsViewModel vm;

        public SubscriptionsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as SubscriptionsViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!Auth.IsAuthenticated())
            {
                await Task.Delay(300);
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await vm.ReadSubscriptions();
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewSubscriptionPage());
        }
    }
}