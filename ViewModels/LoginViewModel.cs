using FirstResponseMAUI.Helpers;
using FirstResponseMAUI.Models;
// using FirstResponseMAUI.Services.Authentication;
// using FirstResponseMAUI.Services.Cities;
using FirstResponseMAUI.ViewModels.Base;
// using Plugin.Connectivity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Networking;

namespace FirstResponseMAUI.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // private IAuthenticationService _authenticationService;

        // private readonly ICitiesService _citiesService;

        private EventModel _city;

        public EventModel City { 
            get
            {
                return _city;
            }
            set
            {
                SetProperty(ref _city, value);
            }
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public LoginViewModel(/*IAuthenticationService authenticationService, ICitiesService citiesService*/)
        {
            // _authenticationService = authenticationService;
            // _citiesService = citiesService;
        }

        public async override Task InitializeAsync(object navigationData)
        {
            if (navigationData is EventModel)
            {
                City = navigationData as EventModel;
            }
            else
            {
                /*
                var events = await _citiesService.GetEventsAsync();

                City = events
                    .Where(q => q.CityId == Settings.SelectedCity)
                    .FirstOrDefault();

                if(City == null)
                {
                    City = _citiesService.GetDefaultEvent(Settings.SelectedCity);
                }
                */
            }

            await base.InitializeAsync(navigationData);
        }

        public ICommand LoginCommand => new Command(LoginUser);
        public ICommand SelectCityCommand => new Command(SelectCity);

        private async void LoginUser()
        {
            IsBusy = true;

            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet /*|| ViewModelLocator.Instance.UseMockService*/)
                {
                    /*
                    UserRole user = await _authenticationService.LoginAsync(UserName, Password);
                    if (user != null)
                    {
                        await NavigationService.NavigateToAsync<MainViewModel>(user);
                    }
                    else
                    {
                        await DialogService.ShowAlertAsync("Invalid credentials", "Login failure", "Try again");
                    }
                    */
                }
                else
                {
                    // await DialogService.ShowAlertAsync("No internet connection available!", "Oops!", "Ok");
                }
            }

            IsBusy = false;
        }

        private void SelectCity()
        {
            // NavigationService.NavigateToAsync<CitiesViewModel>();
        }
    }
}
