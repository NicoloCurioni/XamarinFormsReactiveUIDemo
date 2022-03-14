using System;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace XamarinFormsReactiveUIDemo.ViewModels
{
    public class SecondViewModel : ReactiveObject, IRoutableViewModel
    {

        public string UrlPathSegment => "Second Page";

        public IScreen HostScreen { get; }

        public SecondViewModel(string message, Color color, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Message = message;
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
    }
}
