using DesktopApp.Services;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private IAuthService _authService;
        private PlansService _plansService;
        private ObservableCollection<Plan> _plans;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Plan> Plans
        {
            get
            {
                return _plans;
            }
            set
            {
                if (_plans != value)
                {
                    _plans = value;
                    NotifyPropertyChanged("Plans");
                }
            }
        }

        public DashboardViewModel(IAuthService authService, PlansService plansService)
        {
            _authService = authService;
            _plansService = plansService;
            _authService.AccessTokenChanged += _authService_AccessTokenChanged;
        }

        private async void _authService_AccessTokenChanged(object sender, EventArgs e)
        {
            string accessTokens = _authService.GetAccessToken();
            if (accessTokens != null && accessTokens.Length > 0)
            {
                await RefreshPlans();
            }
        }

        public async Task RefreshPlans()
        {
            Plans = new ObservableCollection<Plan>(await _plansService.All());
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
