using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Domain.Notifications
{
    public abstract class Notificable
    {
        public Notificable()
        {
            this.Notifications = new List<Notification>();
        }
        public List<Notification> Notifications { get; private set; }

        public void AddNotification(string key, string value)
        {
            this.Notifications.Add(new Notification(key, value));
        }
        public void AddRangeNotification(List<Notification> notifications)
        {
            this.Notifications.AddRange(notifications);
        }

        public void ClearNotification()
        {
            this.Notifications.Clear();
        }


        public bool IsValid
        {
            get { return this.Notifications.Count() == 0; }
        }

        public bool Invalid
        {
            get { return this.Notifications.Count() > 0; }
        }


        public abstract void Validate();
    }
}