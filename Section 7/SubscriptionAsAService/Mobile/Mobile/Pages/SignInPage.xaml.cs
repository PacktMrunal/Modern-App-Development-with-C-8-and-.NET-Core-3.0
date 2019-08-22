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
    public partial class SignInPage : ContentPage
    {
        private IAuthService _authService;

        public SignInViewModel Vm { get; set; }

        public SignInPage()
        {
            InitializeComponent();
            _authService = DependencyService.Resolve<IAuthService>(DependencyFetchTarget.GlobalInstance);
            Vm = new SignInViewModel(_authService);
            BindingContext = Vm;
        }
    }
}