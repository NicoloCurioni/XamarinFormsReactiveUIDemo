using System;
using System.Diagnostics;
using System.Windows.Input;
using ReactiveUI;

namespace XamarinFormsReactiveUIDemo.ViewModels
{
    public class CommandBindViewModel : ReactiveObject
    {

        public ICommand TestCommand { get; }

        public CommandBindViewModel()
        {
            TestCommand = ReactiveCommand.Create(() =>
            {
                Console.WriteLine("Command execution");
            });
        }
    }
}
