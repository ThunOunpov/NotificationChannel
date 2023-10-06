using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Notification
{
    public class NotificationChannel
    {
        public string Name { get; set; }
        public List<NotificationTitle> NotificationTitles { get; set; }
        public List<NotificationChannel> NotificationChannels { get; set; }
        public List<string> Channeltypes = new List<string>();
        public NotificationChannel()
        {
            NotificationTitles = new List<NotificationTitle>();
            Channeltypes = new List<string>();
            NotificationChannels= new List<NotificationChannel>();
            // add notification channel.
            Channeltypes.Add(NoficationChanneType.BE);
            Channeltypes.Add(NoficationChanneType.FE);
            Channeltypes.Add(NoficationChanneType.QA);
            Channeltypes.Add(NoficationChanneType.Urgent);

        }
    }
    public class NoficationChanneType
    {
        public const string BE = "BE";
        public const string FE = "FE";
        public const string QA = "QA";
        public const string Urgent = "Urgent";

    }
}
