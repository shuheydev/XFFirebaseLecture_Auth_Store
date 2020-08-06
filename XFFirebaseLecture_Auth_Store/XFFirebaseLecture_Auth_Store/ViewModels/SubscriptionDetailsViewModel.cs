using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XFFirebaseLecture_Auth_Store.Models;
using XFFirebaseLecture_Auth_Store.ViewModels.Helpers;

namespace XFFirebaseLecture_Auth_Store.ViewModels
{
    public class SubscriptionDetailsViewModel : INotifyPropertyChanged
    {
        private Subscription _subscription;
        public Subscription Subscription
        {
            get { return _subscription; }
            set
            {
                _subscription = value;
                Name = _subscription.Name;
                IsActive = _subscription.IsActive;
                OnPropertyChanged(nameof(Subscription));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.Subscription.Name = _name;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Subscription));
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                this.Subscription.IsActive = _isActive;
                OnPropertyChanged(nameof(IsActive));
                OnPropertyChanged(nameof(Subscription));
            }
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public SubscriptionDetailsViewModel()
        {
            UpdateCommand = new Command(Update, UpdateCanExecute);
            DeleteCommand = new Command(Delete);
        }

        private bool UpdateCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        private void Update(object parameter)
        {
            DatabaseHelper.UpdateSubscription(this.Subscription);
        }

        private void Delete(object parameter)
        {
            DatabaseHelper.DeleteSubscription(this.Subscription);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
