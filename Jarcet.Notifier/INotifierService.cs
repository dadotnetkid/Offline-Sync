using System.Net.Mail;

namespace Jarcet.Notifier
{
    public interface INotifierService
    {
        void SendEmail(string to, string subject, string body);
        void SendText();

    }
}