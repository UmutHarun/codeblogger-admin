using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessages();

        void AddMessage(Message message);

        Message GetMessageByID(int id);

        void RemoveMessage(Message message);

        void EditMessage(Message message);

        List<Message> SentMessages();

        int GetUnreadCount();
    }
}
