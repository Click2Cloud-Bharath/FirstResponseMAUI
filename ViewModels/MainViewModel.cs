using System.Threading.Tasks;
using FirstResponseMAUI.Models;
using FirstResponseMAUI.ViewModels.Base;
// using FirstResponseMAUI.Services.Responder;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
// using FirstResponseMAUI.Services.Authentication;
using FirstResponseMAUI.Helpers;
// using FirstResponseMAUI.Services.Incidents;
// using FirstResponseMAUI.Services.Heatmap;
using Microsoft.Maui.Networking;

namespace FirstResponseMAUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserRole _selectedUser;
        private bool _heatMap;
        private bool _forceNavigation;
        private bool _incidentToggleButtonChecked;
        private bool _responderToggleButtonChecked;
        private IncidentListViewModel _incidentListViewModel;
        private ResponderListViewModel _responderListViewModel;
        private IncidentDetailViewModel _incidentDetailViewModel;
        private ObservableCollection<Geoposition> _heatData;

        // private IResponderService _responderService;
        // private IHeatmapService _heatmapService;

        public MainViewModel(
            /*IResponderService responderService, IAuthenticationService authenticationService,                   
            IIncidentsService incidentsService, IHeatmapService heatmapService*/)
        {
            // _responderService = responderService;
            // _heatmapService = heatmapService;

            IncidentToggleButtonChecked = true;
            ResponderToggleButtonChecked = false;

            _incidentListViewModel = new IncidentListViewModel(/*incidentsService*/);
            _responderListViewModel = new ResponderListViewModel(/*_responderService*/);
            _incidentDetailViewModel = new IncidentDetailViewModel();

            MessagingCenter.Subscribe<IncidentModel>(this, MessengerKeys.NavigateToCurrentIncident, (incident) => ForceNavigation = true);
        }

        public UserRole SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                SetProperty(ref _selectedUser, value);
            }
        }

        public bool HeatMap
        {
            get
            {
                return _heatMap;
            }
            set
            {
                SetProperty(ref _heatMap, value);
            }
        }

        public bool ForceNavigation
        {
            get
            {
                return _forceNavigation;
            }
            set
            {
                SetProperty(ref _forceNavigation, value);
            }
        }

        public bool IncidentToggleButtonChecked
        {
            get
            {
                return _incidentToggleButtonChecked;
            }
            set
            {
                SetProperty(ref _incidentToggleButtonChecked, value);
            }
        }

        public bool ResponderToggleButtonChecked
        {
            get
            {
                return _responderToggleButtonChecked;
            }
            set
            {
                SetProperty(ref _responderToggleButtonChecked, value);
            }
        }

        public IncidentListViewModel IncidentListViewModel
        {
            get
            {
                return _incidentListViewModel;
            }
            set
            {
                SetProperty(ref _incidentListViewModel, value);
            }
        }

        public ResponderListViewModel ResponderListViewModel
        {
            get
            {
                return _responderListViewModel;
            }
            set
            {
                SetProperty(ref _responderListViewModel, value);
            }
        }

        public IncidentDetailViewModel IncidentDetailViewModel
        {
            get
            {
                return _incidentDetailViewModel;
            }
            set
            {
                SetProperty(ref _incidentDetailViewModel, value);
            }
        }        

        public ObservableCollection<Geoposition> HeatData
        {
            get
            {
                return _heatData;
            }
            set
            {
                SetProperty(ref _heatData, value);
            }
        }

        public ICommand SelectorCommand => new Command<string>(Selector);
        public ICommand PowerBICommand => new Command(PowerBI);
        public ICommand LogoutCommand => new Command(LogoutAsync);

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            await _incidentListViewModel.InitializeAsync(null);
            await _responderListViewModel.InitializeAsync(null);

            if (navigationData is UserRole)
            {
                SelectedUser = navigationData as UserRole;
            }

            // HeatData = await _heatmapService.GetHeatmapPointsAsync();

            IsBusy = false;
        }

        private void Selector(string parameter)
        {
            if(parameter.Equals("Incidents"))
            {
                IncidentToggleButtonChecked = true;
                ResponderToggleButtonChecked = false;
            }
            else
            {
                IncidentToggleButtonChecked = false;
                ResponderToggleButtonChecked = true;
            }
        }

        private async void PowerBI()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                // await NavigationService.NavigateToPopupAsync<PowerBIViewModel>(true);
            }
            else
            {
                // await DialogService.ShowAlertAsync("No internet connection available!", "Oops!", "Ok");
            }
        }

        private async void LogoutAsync()
        {
            // Settings.RemoveCurrentUser();
            // await NavigationService.NavigateToAsync<LoginViewModel>();
            // await NavigationService.RemoveBackStackAsync();
        }
    }
}
