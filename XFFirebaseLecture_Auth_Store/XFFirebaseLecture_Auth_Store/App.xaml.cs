﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFFirebaseLecture_Auth_Store.Views;

namespace XFFirebaseLecture_Auth_Store
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SubscriptionPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
