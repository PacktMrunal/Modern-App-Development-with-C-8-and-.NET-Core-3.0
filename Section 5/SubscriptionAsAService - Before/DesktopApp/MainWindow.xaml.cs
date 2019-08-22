using DesktopApp.Services;
using DesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SignUpViewModel SignUpVm;
        public SignInViewModel SignInVm;
        public DashboardViewModel DashboardVm;

        private AuthService _authService = new AuthService();
        private PlansService _plansService;

        public MainWindow()
        {
            InitializeComponent();

            _plansService = new PlansService(_authService);

            SignUpVm = new SignUpViewModel(_authService);
            SignUpVm.PropertyChanged += AccessTokenChanged;
            SignInVm = new SignInViewModel(_authService);
            SignInVm.PropertyChanged += AccessTokenChanged;
            DashboardVm = new DashboardViewModel(_authService, _plansService);

            DataContext = SignInVm;
        }

        private void AccessTokenChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AccessToken")
            {
                string accessToken = _authService.GetAccessToken();
                if (accessToken != null && accessToken.Length > 0)
                {
                    DataContext = DashboardVm;
                }
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = SignUpVm;
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = SignInVm;
        }

        private void DashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_authService.GetAccessToken().Length > 0)
            {
                DataContext = DashboardVm;
            }
        }

        private void SubscriptionsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
