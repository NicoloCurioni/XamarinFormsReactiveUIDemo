using System;
using System.Collections.Generic;
using ReactiveUI;
using ReactiveUI.XamForms;
using XamarinFormsReactiveUIDemo.ViewModels;

namespace XamarinFormsReactiveUIDemo.Pages
{
    public partial class CommandBindPage : ReactiveContentPage<CommandBindViewModel>
    {
        public CommandBindPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = new CommandBindViewModel();

            this.BindCommand(ViewModel, vm => vm.TestCommand, page => page.slider, nameof(slider.ValueChanged));
        }
    }
}
