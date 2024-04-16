using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal _IMessageDal)
        {
            _messageDal = _IMessageDal;
        }
        public void AddMessage(Message message)
        {
            _messageDal.Insert(message);
        }

        public void EditMessage(Message message)
        {
            _messageDal.Update(message);
        }

        public Message GetMessageByID(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetMessages()
        {
            return _messageDal.List(x => x.ReceiverMail == "gizem@gmail.com");
        }

        public List<Message> SentMessages()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public void RemoveMessage(Message message)
        {
            _messageDal.Delete(message);
        }

        public int GetUnreadCount()
        {
           return _messageDal.GetList().Where(x => x.Read == false).Count();
        }
    }
}
