using System;
using System.Collections.Generic;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using XamarinFormsReactiveUIDemo.ViewModels;

namespace XamarinFormsReactiveUIDemo.Pages
{
    public partial class SecondPage : ReactiveContentPage<SecondViewModel>
    {
        public SecondPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = new SecondViewModel(null);
        }
    }
}
