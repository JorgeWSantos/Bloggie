using Bloggie.Enum;

namespace Bloggie.Models.ViewModels
{
    public class Notification
    {
        public string message { get; set; }
        public NotificationType type { get; set; }
    }
}
