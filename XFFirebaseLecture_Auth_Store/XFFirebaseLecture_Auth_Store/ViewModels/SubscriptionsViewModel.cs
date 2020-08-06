using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XFFirebaseLecture_Auth_Store.Models;
using XFFirebaseLecture_Auth_Store.ViewModels.Helpers;
using XFFirebaseLecture_Auth_Store.Views;

namespace XFFirebaseLecture_Auth_Store.ViewModels
{
    public class SubscriptionsViewModel : INotifyPropertyChanged
    {
        private Subscription _selectedSubscription;

        public Subscription SelectedSubscription
        {
            get { return _selectedSubscription; }
            set
            {
                _selectedSubscription = value;
                OnPropertyChanged(nameof(SelectedSubscription));
                if (SelectedSubscription != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new SubscriptionDetailsPage(this.SelectedSubscription));
                }
            }
        }

        public ObservableCollection<Subscription> Subscriptions { get; set; }

        public SubscriptionsViewModel()
        {
            Subscriptions = new ObservableCollection<Subscription>();
        }

        public async Task ReadSubscriptions()
        {
            var subscriptions = await DatabaseHelper.ReadSubscriptions();

            Subscriptions.Clear();//講義ではここでクリアしていた.確認済み.
            foreach (var s in subscriptions)
            {
                this.Subscriptions.Add(s);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
