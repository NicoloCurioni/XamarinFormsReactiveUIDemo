using System;
using System.ComponentModel;

namespace XamarinFormsReactiveUIDemo
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
