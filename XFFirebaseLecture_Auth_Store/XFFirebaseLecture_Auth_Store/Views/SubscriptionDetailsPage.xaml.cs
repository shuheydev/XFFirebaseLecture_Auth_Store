using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFirebaseLecture_Auth_Store.Models;
using XFFirebaseLecture_Auth_Store.ViewModels;

namespace XFFirebaseLecture_Auth_Store.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubscriptionDetailsPage : ContentPage
    {
        SubscriptionDetailsViewModel vm;
        public SubscriptionDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as SubscriptionDetailsViewModel;
        }

        public SubscriptionDetailsPage(Subscription selectedSubscription)
        {
            InitializeComponent();

            vm = Resources["vm"] as SubscriptionDetailsViewModel;
            vm.Subscription = selectedSubscription;
        }
    }
}