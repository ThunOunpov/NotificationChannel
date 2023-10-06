using System;
using System.Collections.Generic;
using System.Linq;
using Notification.Notification;

namespace Notification
{
    class Program
    {

        static NotificationChannel channel = new NotificationChannel();
        static List<string> channelTypes = channel.Channeltypes;
        static void Main(string[] args)
        {

            // add notification channel.
            channelTypes.ForEach(x => channel.NotificationChannels.Add(new NotificationChannel { Name = x }));

        Start:
            Console.WriteLine("Please input notification title:");
            string notificationTitle = Console.ReadLine();

            // Parse the notification title and get the list of tags.
            List<string> tags = ParseNotificationTitle(notificationTitle);

            // display message error the console.
            string messageError = "Output receive channels:";
            string text = string.Empty;
            List<NotificationChannel> channels = channel.NotificationChannels.Where(w => tags.Where(x => x == w.Name).Any()).ToList();
            foreach (NotificationChannel notificationChannel in channels)
            {
                text += $" {notificationChannel.Name},";
            }
            if (!string.IsNullOrEmpty(text))
                text = text.Remove(text.Length - 1, 1);
            Console.WriteLine(messageError + text);
        Decision:
            Console.WriteLine(format: "Do you want test other case - Yes/No?");
            string userDecision = Console.ReadLine();
            switch (userDecision.ToUpper())
            {
                case "YES":
                    goto Start;
                case "NO":
                    break;
                default:
                    goto Decision;
            }
            Console.ReadKey();
        }

        static List<string> ParseNotificationTitle(string notificationTitle)
        {
            List<string> tags = new List<string>();
            char[] spearator = { '[', ']', ' ' };

            string[] splitTitle = notificationTitle.Split(spearator);

            foreach (string tag in splitTitle)
            {
                tags.Add(tag.Trim());
            }
            // Remove any empty strings from the list.
            tags.RemoveAll(string.IsNullOrEmpty);

            return tags;
        }

    }
}
