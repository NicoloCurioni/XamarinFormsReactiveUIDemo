using System;
using System.Collections.Generic;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using XamarinFormsReactiveUIDemo.ViewModels;

namespace XamarinFormsReactiveUIDemo.Pages
{
    public partial class CollectionPage : ReactiveContentPage<CollectionViewModel>
    {
        public CollectionPage()
        {
            InitializeComponent();
        }
    }
}
