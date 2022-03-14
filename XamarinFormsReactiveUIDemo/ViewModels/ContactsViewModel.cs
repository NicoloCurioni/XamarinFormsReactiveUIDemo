using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
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
                .Throttle(TimeSpan.FromSeconds(1))
                .Subscribe(query =>
                {
                    var filteredContacts = _samples.Where(c => c.FullName.Contains(query) || c.Phone.Contains(query) || c.Email.Contains(query)).ToList();

                    Contacts = new ObservableCollection<Contact>(filteredContacts);
                });

            this.WhenAnyValue(vm => vm.Contacts)
                .Select(contacts =>
                {
                    if (Contacts.Count == _samples.Count)
                        return "No filter applied";

                    return $"{Contacts.Count} result have been found in for '{SearchQuery}'";
                }) 
                .ToProperty(this, vm => vm.SearchResult, out _searchResult);     
        }

        #region Properties
        private string _searchQuery = "";

        public string SearchQuery
        {
            get => _searchQuery;
            set { this.RaiseAndSetIfChanged(ref _searchQuery, value); }
        }

        private readonly ObservableAsPropertyHelper<string> _searchResult;

        public string SearchResult => _searchResult.Value;

        private ObservableCollection<Contact> _contacts;

        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set { this.RaiseAndSetIfChanged(ref _contacts, value); }
        }
        #endregion
    }
}
