using System;
using System.Windows.Input;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace XamarinFormsReactiveUIDemo.ViewModels
{
    public class FirstViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "First page";

        public IScreen HostScreen { get; }

        public FirstViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            NavigateCommand = ReactiveCommand.CreateFromObservable(() =>
            {
                return HostScreen.Router.Navigate.Execute(new SecondViewModel(Message));
            });
        }

        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set { this.RaiseAndSetIfChanged(ref _message, value); }
        }

        private Color _color;

        public Color color
        {
            get => _color;
            set { this.RaiseAndSetIfChanged(ref _color, value); }
        }

        public ICommand NavigateCommand { get; }
    }
}
