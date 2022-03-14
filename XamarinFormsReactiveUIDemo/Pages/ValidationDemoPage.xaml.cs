using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using XamarinFormsReactiveUIDemo.ViewModels;

namespace XamarinFormsReactiveUIDemo.Pages
{
    public partial class ValidationDemoPage : ReactiveContentPage<ValidationDemoViewModel>
    {
        public ValidationDemoPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = new ValidationDemoViewModel();

            this.WhenActivated(d =>
            {
                this.BindValidation(ViewModel, vm => vm.Birthdate, page => page.validationLabel.Text).DisposeWith(d);
            });
        }
    }
}
