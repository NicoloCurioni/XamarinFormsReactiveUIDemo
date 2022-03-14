using System;
using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;
using Splat;
using XamarinFormsReactiveUIDemo.Models;
using XamarinFormsReactiveUIDemo.Services;

namespace XamarinFormsReactiveUIDemo.ViewModels
{
    public class CollectionViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "Collections";

        public IScreen HostScreen { get; }

        private readonly IContactsService _contactsService;

        public CollectionViewModel(IScreen screen = null, IContactsService contactsService = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            _contactsService = contactsService ?? Locator.Current.GetService<IContactsService>();

            _contacts.AddRange(_contactsService.GetAllContacts());

            _contacts.Connect().Bind(out _contactsList).Subscribe();

            _contacts.ReplaceAt(2, new Contact
            {
                FullName = "John Test",
                Email = "replace.test@me.com",
                Phone = "1234",
            });

            //_contacts.Move(0, 3);
        }

        private SourceList<Contact> _contacts = new SourceList<Contact>();

        private readonly ReadOnlyObservableCollection<Contact> _contactsList;

        public ReadOnlyObservableCollection<Contact> Contacts => _contactsList;
    }
}
