﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFFirebaseLecture_Auth_Store.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegisterLabel_Tapped(object sender, EventArgs e)
        {
            registerStackLayout.IsVisible = true;
            loginStackLayout.IsVisible = false;
        }

        private void LoginLabel_Tapped(object sender, EventArgs e)
        {
            registerStackLayout.IsVisible = false;
            loginStackLayout.IsVisible = true;
        }
    }
}