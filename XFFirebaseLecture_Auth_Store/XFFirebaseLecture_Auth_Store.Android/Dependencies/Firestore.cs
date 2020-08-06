﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Service.VR;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using Java.Util;
using Xamarin.Essentials;
using XFFirebaseLecture_Auth_Store.Models;
using XFFirebaseLecture_Auth_Store.ViewModels.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(XFFirebaseLecture_Auth_Store.Droid.Dependencies.Firestore))]
namespace XFFirebaseLecture_Auth_Store.Droid.Dependencies
{
    public class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        List<Subscription> subscriptions;
        bool hasReadSubscriptions = false;

        public Firestore()
        {
            subscriptions = new List<Subscription>();
        }

        public Task<bool> DeleteSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public bool InsertSubscription(Subscription subscription)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions");
                var subscriptionDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"author",Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                    {"name",subscription.Name },
                    {"isActive",subscription.IsActive },
                    {"subscribedDate",DateDateTimeToNativeDate(subscription.SubscribedDate)},
                };
                collection.Add(subscriptionDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IList<Subscription>> ReadSubscriptions()
        {
            hasReadSubscriptions = false;

            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions");
            var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            query.Get().AddOnCompleteListener(this);

            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadSubscriptions)
                {
                    break;
                }
            }

            return subscriptions;
        }

        public Task<bool> UpdateSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        private static Date DateDateTimeToNativeDate(DateTimeOffset date)
        {
            long dateTimeUtcAsMilliseconds = (long)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return new Date(dateTimeUtcAsMilliseconds);
        }

        private static DateTime NativeDateToDateTime(Date date)
        {
            //TODO:System.TiemZone is obsolete. refactor later.
            DateTime reference = System.TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1979, 1, 1, 0, 0, 0));
            return reference.AddMilliseconds(date.Time);

        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;

                subscriptions.Clear();
                foreach (var doc in documents.Documents)
                {
                    Subscription subscription = new Subscription
                    {
                        IsActive = (bool)doc.Get("isActive"),
                        Name = doc.Get("name").ToString(),
                        UserId = doc.Get("author").ToString(),
                        SubscribedDate = NativeDateToDateTime(doc.Get("subscribedDate") as Date),
                    };

                    subscriptions.Add(subscription);
                }
            }
            else
            {
                subscriptions.Clear();
            }

            hasReadSubscriptions = true;
        }
    }
}