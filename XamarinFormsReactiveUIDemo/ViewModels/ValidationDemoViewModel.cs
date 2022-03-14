using System;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;

namespace XamarinFormsReactiveUIDemo.ViewModels
{
    public class ValidationDemoViewModel : ReactiveObject, IValidatableViewModel
    {
        public ValidationContext ValidationContext { get; } = new ValidationContext();

        private DateTime _birthdayDate;

        public DateTime Birthdate
        {
            get => _birthdayDate;
            set { this.RaiseAndSetIfChanged(ref _birthdayDate, value); }
        }

        public ICommand SubmitCommand { get; }

        public ValidationDemoViewModel()
        {
            this.ValidationRule(vm => vm.Birthdate,
                value => value > new DateTime(1970, 1, 1) && value < new DateTime(1999, 12, 31), "Birthday should be between 1/1/1970 and 1999/12/31");

            var isValid = this.IsValid();

            SubmitCommand = ReactiveCommand.Create(() =>
            {
                Console.WriteLine($"{Birthdate} submitted!");
            }, isValid);
        }
    }
}
