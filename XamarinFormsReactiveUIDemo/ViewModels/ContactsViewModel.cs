﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;
using XamarinFormsReactiveUIDemo.Models;
using XamarinFormsReactiveUIDemo.Services;

namespace XamarinFormsReactiveUIDemo.ViewModels
{
    public class ContactsViewModel : ReactiveObject
    {
        private IContactsService _contactsService;

        public ContactsViewModel(IContactsService contactsService = null)
        {
            _contactsService = contactsService ?? (IContactsService)Splat.Locator.Current.GetService(typeof(IContactsService));

            var allContacts = _contactsService.GetAllContacts();
            _contacts = new ObservableCollection<Contact>(allContacts);

            this.WhenAnyValue(vm => vm.SearchQuery)
                .Throttle(TimeSpan.FromSeconds(1))
                .Subscribe(query =>
                {
                    var filteredContacts = allContacts.Where(c => c.FullName.Contains(query) || c.Phone.Contains(query) || c.Email.Contains(query)).ToList();

                    Contacts = new ObservableCollection<Contact>(filteredContacts);
                });

            this.WhenAnyValue(vm => vm.Contacts)
                .Select(contacts =>
                {
                    if (Contacts.Count == allContacts.Count())
                        return "No filter applied";

                    return $"{Contacts.Count} result have been found in for '{SearchQuery}'";
                })
                .ToProperty(this, vm => vm.SearchResult, out _searchResult);

            ClearCommand = ReactiveCommand.Create(ClearSearch);

            // Handle the Expectations
            ClearCommand.ThrownExceptions.Subscribe(ex =>
            {
                Debug.WriteLine(ex.Message);
            });
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

        #region Commands

        public ReactiveCommand<Unit, Unit> ClearCommand { get; }
        #endregion

        #region Methods

        private void ClearSearch()
        {
            throw new Exception("Sample Expectation");
            //SearchQuery = string.Empty;
        }
        #endregion
    }
}
