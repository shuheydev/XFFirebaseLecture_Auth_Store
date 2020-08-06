using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XFFirebaseLecture_Auth_Store.Models;
using XFFirebaseLecture_Auth_Store.ViewModels.Helpers;

namespace XFFirebaseLecture_Auth_Store.ViewModels
{
    public class SubscriptionsViewModel
    {
        public ObservableCollection<Subscription> Subscriptions { get; set; }

        public SubscriptionsViewModel()
        {
            Subscriptions = new ObservableCollection<Subscription>();
        }

        public async Task ReadSubscriptions()
        {
            Subscriptions.Clear();

            var subscriptions = await DatabaseHelper.ReadSubscriptions();

            foreach (var s in subscriptions)
            {
                this.Subscriptions.Add(s);
            }
        }
    }
}
