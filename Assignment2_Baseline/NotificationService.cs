using System;

namespace Assignment2_Baseline
{
    /// <summary>
    /// Handles notifications to the researcher about the evaluation result.
    /// </summary>
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

        public void SendNotification()
        {
            if (Program.EnableLogging)
            {
                Console.WriteLine("Notification sent to researcher");
            }
        }
    }
}