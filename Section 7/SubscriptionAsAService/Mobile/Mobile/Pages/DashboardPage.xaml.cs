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
    public partial class DashboardPage : ContentPage
    {
        private IAuthService _authService;
        private PlansService _plansService;

        public DashboardViewModel Vm { get; set; }

        public DashboardPage()
        {
            InitializeComponent();

            _authService = DependencyService.Resolve<IAuthService>(DependencyFetchTarget.GlobalInstance);
            _plansService = new PlansService(_authService);
            Vm = new DashboardViewModel(_authService, _plansService);
        }
    }
}