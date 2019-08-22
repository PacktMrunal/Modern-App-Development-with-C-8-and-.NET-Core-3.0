using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.ViewModels
{
    public class SignInCommand : ICommand
    {
        public SignInViewModel SignInViewModel { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await SignInViewModel.SignUserIn();
        }
    }

    public class SignInViewModel : INotifyPropertyChanged
    {
        private IAuthService _authService;
        private string _accessToken;

        public event PropertyChangedEventHandler PropertyChanged;

        public SignInCommand SignInCommand { get; set; }

        public string AccessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                if (_accessToken != value)
                {
                    _accessToken = value;
                    NotifyProeprtyChanged("AccessToken");
                }
            }
        }

        public UserSignInVM User { get; set; } = new UserSignInVM()
        {
            Email = "",
            Password = ""
        };

        public SignInViewModel(IAuthService authService)
        {
            _authService = authService;
            SignInCommand = new SignInCommand()
            {
                SignInViewModel = this
            };
        }

        public async Task SignUserIn()
        {
            AccessToken = await _authService.SignIn(User);
        }

        protected void NotifyProeprtyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
