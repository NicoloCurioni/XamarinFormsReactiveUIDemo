using System;
using System.Collections.Generic;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using XamarinFormsReactiveUIDemo.ViewModels;

namespace XamarinFormsReactiveUIDemo.Pages
{
    public partial class FirstPage : ReactiveContentPage<FirstViewModel>
    {
        public FirstPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = new FirstViewModel();
        }
    }
}
