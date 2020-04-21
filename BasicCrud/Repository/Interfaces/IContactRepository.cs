using BasicCrud.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrud.Repository.Interfaces
{
   
        public interface IContactRepository
        {
            Task<Contact> SendMessage(Contact contact);
            Task<Contact> Subscribe(string address);
        }
    }

