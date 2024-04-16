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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal) 
        {
            _contactDal = contactDal;
        }

        public void AddContact(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void EditContact(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public Contact GetContactByID(int id)
        {
            return _contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetContacts()
        {
           return _contactDal.GetList();
        }

        public List<Contact> GetListById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(Contact contact)
        {
            _contactDal.Delete(contact);
        }
    }
}
