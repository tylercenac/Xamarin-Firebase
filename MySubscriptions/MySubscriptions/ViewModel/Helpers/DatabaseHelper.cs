using MySubscriptions.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySubscriptions.ViewModel.Helpers
{

    public interface IFirestore
    {
        bool InsertSubscription(Subscription subscription);
        Task<bool> DeleteSubscription(Subscription subscription);
        Task<bool> UpdateSubscription(Subscription subscription);
        Task<IList<Subscription>> ReadSubscription();
    }

    public class DatabaseHelper
    {

        private static IFirestore firestore;

        public Task<bool> DeleteSubscription(Subscription subscription)
        {
            return firestore.DeleteSubscription(subscription);
        }

        public bool InsertSubscription(Subscription subscription)
        {
            return firestore.InsertSubscription(subscription);
        }

        public Task<IList<Subscription>> ReadSubscriptions()
        {
            return firestore.ReadSubscription();
        }

        public Task<bool> UpdateSubscription(Subscription subscription)
        {
            return firestore.UpdateSubscription(subscription);
        }
    }
}
