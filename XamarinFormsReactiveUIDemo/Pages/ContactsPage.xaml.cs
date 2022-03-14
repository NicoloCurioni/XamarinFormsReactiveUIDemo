using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsReactiveUIDemo.ViewModels;

namespace XamarinFormsReactiveUIDemo.Pages
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
            BindingContext = new ContactsViewModel();
        }
    }
}
