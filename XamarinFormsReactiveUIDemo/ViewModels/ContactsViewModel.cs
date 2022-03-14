using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using XamarinFormsReactiveUIDemo.Models;

namespace XamarinFormsReactiveUIDemo.ViewModels
{
    public class ContactsViewModel : ReactiveObject
    {
        private List<Contact> _samples = new List<Contact>
        {
            new Contact { FullName = "Mario Rossi", Email = "mariotest.rossi@test.com", Phone = "0001234567" },
            new Contact { FullName = "John Appleseed", Email = "john.applessed@gmail.com", Phone = "0001234567" },
            new Contact { FullName = "Tim Cook", Email = "t.cook@yapple.com", Phone = "0001234567" }
        };

        public ContactsViewModel()
        {
            _contacts = new ObservableCollection<Contact>(_samples);

            this.WhenAnyValue(vm => vm.SearchQuery)
                .Subscribe(query =>
                {
                    var filteredContacts = _samples.Where(c => c.FullName.Contains(query) || c.Phone.Contains(query) || c.Email.Contains(query)).ToList();

                    Contacts = new ObservableCollection<Contact>(filteredContacts);
                });
        }

        #region
        private string _searchQuery = "";

        public string SearchQuery
        {
            get => _searchQuery;
            set { this.RaiseAndSetIfChanged(ref _searchQuery, value); }
        }
        #endregion

        private ObservableCollection<Contact> _contacts;

        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set { this.RaiseAndSetIfChanged(ref _contacts, value); }
        }
    }
}
