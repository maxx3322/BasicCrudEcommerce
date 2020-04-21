using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicCrud.Entities;
using BasicCrud.Repository.Interfaces;

namespace BasicCrud.Repository
{
    public class ContactRepository : IContactRepository
    {
        protected readonly AspnetRunContext _dbContext;

        public ContactRepository(AspnetRunContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Contact> SendMessage(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> Subscribe(string address)
        {
            // implement your business logic
            var newContact = new Contact();
            newContact.Email = address;
            newContact.Message = address;
            newContact.Name = address;

            _dbContext.Contacts.Add(newContact);
            await _dbContext.SaveChangesAsync();

            return newContact;
        }
    }
}
