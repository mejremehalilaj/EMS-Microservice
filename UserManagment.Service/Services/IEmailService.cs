using UserManagment.Service.Models;

namespace UserManagment.Service.Services
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
