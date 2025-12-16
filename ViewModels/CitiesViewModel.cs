using System.Threading.Tasks;
using FirstResponseMAUI.ViewModels.Base;
using FirstResponseMAUI.Models;
using System.Collections.ObjectModel;
// using FirstResponseMAUI.Services.Cities;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using FirstResponseMAUI.Helpers;

namespace FirstResponseMAUI.ViewModels
{
    public class CitiesViewModel : ViewModelBase
    {
        private ObservableCollection<EventModel> _cities;
        private ConfigViewModel _configViewModel;

        // private ICitiesService _citiesService;

        public CitiesViewModel(/*ICitiesService citiesService*/)
        {
            // _citiesService = citiesService;

            ConfigViewModel = new ConfigViewModel();
        }

        public ObservableCollection<EventModel> Cities
        {
            get { return _cities; }
            set
            {
                SetProperty(ref _cities, value);
            }
        }

        public ConfigViewModel ConfigViewModel
        {
            get
            {
                return _configViewModel;
            }

            set
            {
                _configViewModel = value;
            }
        }

        public async override Task InitializeAsync(object navigationData)
        {
            // Cities = await _citiesService.GetEventsAsync();
            await base.InitializeAsync(navigationData);
        }

        public ICommand CitySelectedCommand => new Command<EventModel>(CitySelected);

        private async void CitySelected(EventModel selectedEvent)
        {
            /*
            if (ViewModelLocator.Instance.UseMockService && (selectedEvent.CityId != GlobalSetting.DefaultMockCityId))
            {
                if (!await DialogService.ConfirmAsync("Your current selection will disable mock mode, Are you sure?", "Mock Enabled"))
                {
                    return;
                }
                else
                {
                    ViewModelLocator.Instance.UseMockService = false;
                }
            }

            Settings.SelectedCity = selectedEvent.CityId;
            Settings.UserLatitude = selectedEvent.Latitude;
            Settings.UserLongitude = selectedEvent.Longitude;
            Settings.AmbulanceLatitude = selectedEvent.AmbulancePosition.Latitude;
            Settings.AmbulanceLongitude = selectedEvent.AmbulancePosition.Longitude;
            await NavigationService.NavigateToAsync<LoginViewModel>(selectedEvent);
            await NavigationService.RemoveBackStackAsync();
            */
        }
    }
}
