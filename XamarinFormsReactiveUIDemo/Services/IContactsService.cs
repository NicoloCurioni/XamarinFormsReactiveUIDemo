using System;
using System.Collections.Generic;
using XamarinFormsReactiveUIDemo.Models;

namespace XamarinFormsReactiveUIDemo.Services
{
    public interface IContactsService
    {
        IEnumerable<Contact> GetAllContacts();
    }

    public class StaticContactsService : IContactsService
    {
        private List<Contact> _samples = new List<Contact>
        {
            new Contact { FullName = "Mario Rossi", Email = "mariotest.rossi@test.com", Phone = "0001234567" },
            new Contact { FullName = "John Appleseed", Email = "john.applessed@gmail.com", Phone = "0001234567" },
            new Contact { FullName = "Tim Cook", Email = "t.cook@yapple.com", Phone = "0001234567" }
        };

        public IEnumerable<Contact> GetAllContacts()
        {
            return _samples;
        }
    }
}
