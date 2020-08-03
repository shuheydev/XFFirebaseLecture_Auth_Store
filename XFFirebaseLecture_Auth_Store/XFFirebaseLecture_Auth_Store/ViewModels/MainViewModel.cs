using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XFFirebaseLecture_Auth_Store.Models;

namespace XFFirebaseLecture_Auth_Store.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
                OnPropertyChanged("Greeting");
            }
        }

        private string _greeting;
        public string Greeting
        {
            get => $"Hello {_userName}";
        }


        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand ClearCommand { get; set; }



        public MainViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            Contacts.Add(new Contact
            {
                Name = "Shuhey Helohelo",
                Email = "shuhelohelo9999@helohelo.com",
            });
            Contacts.Add(new Contact
            {
                Name = "Toru Nakamoto",
                Email = "toru_nakamoto@helohelo.com",
            });

            ClearCommand = new Command(ClearUserName, ClearCanExecute);
        }


        private bool ClearCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(UserName);
        }

        private void ClearUserName(object parameter)
        {
            UserName = string.Empty;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
