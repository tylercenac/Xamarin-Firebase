﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using MySubscriptions.Model;
using MySubscriptions.ViewModel.Helpers;
using UIKit;


namespace MySubscriptions.iOS.Dependencies
{
    class Firestore : IFirestore
    {
        public Task<bool> DeleteSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public bool InsertSubscription(Subscription subscription)
        {

            try
            {
                var keys = new[]
                {
                    new NSString("author"),
                    new NSString("name"),
                    new NSString("isActive"),
                    new NSString("subscribedDate"),
                };

                var values = new NSObject[]
                {
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid),
                    new NSString(subscription.Name),
                    new NSNumber(subscription.IsActive),
                    DateTimeToNSDate(subscription.SubscribedDate)
                };

                var subscriptionDocument = new NSDictionary<NSString, NSObject>(keys, values);
                Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("subscriptions").AddDocument(subscriptionDocument);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public Task<IList<Subscription>> ReadSubscription()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        private static NSDate DateTimeToNSDate(DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
                date = DateTime.SpecifyKind(date, DateTimeKind.Local);
            return (NSDate)date;
        }

    }
}