using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Domain.Notifications
{
    public class Notification
    {
        public Notification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}