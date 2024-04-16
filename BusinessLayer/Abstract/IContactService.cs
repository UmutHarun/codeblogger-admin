using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContacts();

        void AddContact(Contact contact);

        Contact GetContactByID(int id);

        void RemoveContact(Contact contact);

        void EditContact(Contact contact);

        public List<Contact> GetListById(int id);
    }
}
