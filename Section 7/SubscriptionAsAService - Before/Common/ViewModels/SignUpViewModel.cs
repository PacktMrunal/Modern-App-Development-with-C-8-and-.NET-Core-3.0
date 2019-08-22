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
    public class SignUpCommand : ICommand
    {
        public SignUpViewModel Vm { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await Vm.SignUserUp();   
        }
    }

    public class SignUpViewModel : INotifyPropertyChanged
    {
        private IAuthService _authService;
        private string _accessToken;

        public event PropertyChangedEventHandler PropertyChanged;

        public SignUpCommand SignUpCommand { get; set; }

        public UserSignUpVM User { get; set; } = new UserSignUpVM()
        {
            FirstName = "",
            LastName = "",
            Email = "",
            Password = ""
        };

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
                    NotifyPropertyChanged("AccessToken");
                }
            }
        }

        public SignUpViewModel(IAuthService authService)
        {
            _authService = authService;
            SignUpCommand = new SignUpCommand()
            {
                Vm = this
            };
        }

        public async Task SignUserUp()
        {
           AccessToken = await _authService.SignUp(User);
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
