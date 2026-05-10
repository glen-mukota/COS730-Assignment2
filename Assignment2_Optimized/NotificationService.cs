using System;

namespace Assignment2_Optimized
{
    internal class NotificationService
    {
        public void NotifyAcceptance()
        {
            Console.WriteLine("Accepted");
            SendNotification();
        }

        public void NotifyRejection()
        {
            Console.WriteLine("Rejected");
            SendNotification();
        }

        public void NotifyRevision()
        {
            Console.WriteLine("Revision required");
            SendNotification();
        }

        public void SendNotification()
        {
            Console.WriteLine("Notification sent to researcher");
        }
    }
}