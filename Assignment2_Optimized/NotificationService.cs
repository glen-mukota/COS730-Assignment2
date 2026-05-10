using System;

namespace Assignment2_Optimized
{
    internal class NotificationService
    {
        public void NotifyAcceptance()
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Accepted");
                SendNotification();
            }
        }

        public void NotifyRejection()
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Rejected");
                SendNotification();
            }
        }

        public void NotifyRevision()
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Revision required");
                SendNotification();
            }
        }

        private void SendNotification()
        {
            if (Program.EnableLogging)
                Console.WriteLine("Notification sent to researcher");
        }
    }
}