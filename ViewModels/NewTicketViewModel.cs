using System.Linq;
using FirstResponseMAUI.Models;
using FirstResponseMAUI.ViewModels.Base;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using System.Collections.Generic;
// using FirstResponseMAUI.Extensions;
// using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using FirstResponseMAUI.Helpers;
// using FirstResponseMAUI.Services.Ticket;

namespace FirstResponseMAUI.ViewModels
{
    public class NewTicketViewModel : ViewModelBase
    {
        
        private TicketModel _ticket;

        // private ITicketService _ticketService;

        private string _location;

        public List<string> TicketTypes { get; set; }

        public List<string> TrafficViolationTypes { get; set; }

        public TicketModel Ticket
        {
            get
            {
                return _ticket;
            }

            set
            {
                SetProperty(ref _ticket, value);
            }
        }

        public string Location
        {
            get
            {
                return _location;
            }

            set
            {
                SetProperty(ref _location, value);
            }
        }

        public NewTicketViewModel(/*ITicketService ticketService*/)
        {
            // _ticketService = ticketService;

            Ticket = new TicketModel() {
                DateCreated = DateTime.Now,
                // Officer = Settings.CurrentUser,
                // CityId = Settings.SelectedCity,
                Type = TicketType.Traffic.ToString()
            };

            TicketTypes = Enum.GetValues(typeof(TicketType)).Cast<TicketType>().Select(v => v.ToString()).ToList();
            // TrafficViolationTypes = Enum.GetValues(typeof(TrafficViolationType)).Cast<TrafficViolationType>().Select(v => v.ToString().ToFriendlyCase()).ToList();
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is IncidentModel)
            {
                IncidentModel incident = navigationData as IncidentModel;
                Location = incident.Address;
                _ticket.Latitude = incident.Latitude;
                _ticket.Longitude = incident.Longitude;
                _ticket.Driver = new DriverModel()
                {
                    Name = incident.Identities?.FirstOrDefault()?.Name
                };
                _ticket.Vehicle = new VehicleModel();
                OnPropertyChanged(nameof(Ticket));
            }

            return base.InitializeAsync(navigationData);
        }

        public ICommand ClosePopupCommand => new Command(ClosePopup);

        public ICommand SubmitTicketCommand => new Command(SubmitTicket);

        private async void SubmitTicket()
        {
            IsBusy = true;
            /*
            if (await _ticketService.AddTicketAsync(Ticket))
            {
                ClosePopup();
            }
            else
            {
                // notify error
                await DialogService.ShowAlertAsync("Error in the values submitted", "Processing Error", "Please Verify and try again");
            }
            */
            IsBusy = false;
        }

        private async void ClosePopup()
        {
            // await PopupNavigation.PopAllAsync(true);
        }
    }
}
