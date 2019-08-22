using Common.Services;
using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        private IAuthService _authService;

        public SignUpViewModel Vm
        {
            get;
            set;
        }

        public SignUpPage()
        {
            InitializeComponent();
            _authService = DependencyService.Resolve<IAuthService>(DependencyFetchTarget.GlobalInstance);
            Vm = new SignUpViewModel(_authService);
            BindingContext = Vm;
        }
    }
}