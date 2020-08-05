using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XFFirebaseLecture_Auth_Store.Models;
using XFFirebaseLecture_Auth_Store.ViewModels.Helpers;

namespace XFFirebaseLecture_Auth_Store.ViewModels
{
    public class NewSubscriptionViewModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        public ICommand SaveSubscriptionCommand { get; set; }

        public NewSubscriptionViewModel()
        {
            SaveSubscriptionCommand = new Command(SaveSubscription, SaveSubscriptionCanExecute);
        }

        private bool SaveSubscriptionCanExecute(object arg)
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        private void SaveSubscription(object parameter)
        {
            DatabaseHelper.InsertSubscription(new Subscription
            {
                IsActive = this.IsActive,
                Name = this.Name,
                UserId = Auth.GetCurrentUserId(),
                SubscribedDate = DateTime.Now,
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
