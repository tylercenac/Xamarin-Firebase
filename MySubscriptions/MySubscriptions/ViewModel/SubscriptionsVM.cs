using MySubscriptions.Model;
using MySubscriptions.ViewModel.Helpers;
using System.Collections.ObjectModel;
using System;


namespace MySubscriptions.ViewModel
{
    public class SubscriptionsVM
    {

        public ObservableCollection<Subscription> Subscriptions { get; set; }

        public SubscriptionsVM()
        {

            Subscriptions = new ObservableCollection<Subscription>();

        }


        public async void ReadSubscriptions()
        {

            var subscriptions = await DatabaseHelper.ReadSubscriptions();

            Subscriptions.Clear();
            foreach(var s in subscriptions)
            {
                Subscriptions.Add(s);
            }

        }
    }
}
