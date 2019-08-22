using Common.Services;
using Mobile.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        private IAuthService _authService;
        private IPlansService _plansService;

        public bool IsSignedIn
        {
            get
            {
                var accessToken = _authService.GetAccessToken();
                return accessToken != null && accessToken.Length > 0;
            }
        }

        public MainPage()
        {
            DependencyService.Register<IAuthService, AuthService>();
            DependencyService.Register<IPlansService, PlansService>();
            InitializeComponent();
            _authService = DependencyService.Resolve<IAuthService>(DependencyFetchTarget.GlobalInstance);
            _plansService = new PlansService(_authService);
            _authService.AccessTokenChanged += AccessTokenChanged;
        }

        private async void AccessTokenChanged(object sender, EventArgs e)
        {
            await GoToDashboard();
        }

        private async Task GoToDashboard()
        {
            if (IsSignedIn)
            {
                await Navigation.PushAsync(new DashboardPage());
            }
        }

        private async void SignUpBtn_Clicked(object sender, EventArgs e)
        {
            if (!IsSignedIn)
            {
                await Navigation.PushAsync(new SignUpPage());
            }
        }

        private async void SignInBtn_Clicked(object sender, EventArgs e)
        {
            if (!IsSignedIn)
            {
                await Navigation.PushAsync(new SignInPage());
            }
        }

        private async void DashboardBtn_Clicked(object sender, EventArgs e)
        {
            await GoToDashboard();
        }
    }
}
