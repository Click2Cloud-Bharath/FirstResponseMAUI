using FirstResponseMAUI.Helpers;
using FirstResponseMAUI.Models;
// using FirstResponseMAUI.Services.Incidents;
using FirstResponseMAUI.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.ViewModels
{
    public class IncidentListViewModel : ViewModelBase
    {
        private IncidentModel _selectedIncident;
        private ObservableCollection<IncidentModel> _incidentList;

        // private IIncidentsService _incidentsService;

        public IncidentListViewModel(/*IIncidentsService incidentsService*/) {
            // _incidentsService = incidentsService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            // IncidentList = await _incidentsService.GetIncidentsAsync();

            MessagingCenter.Subscribe<ViewModelBase>(this, MessengerKeys.CloseIncident, CloseIncidentRequestReceived);
            await base.InitializeAsync(navigationData);
        }

        public ObservableCollection<IncidentModel> IncidentList
        {
            get { return _incidentList ?? new ObservableCollection<IncidentModel>(); }
            set
            {
                SetProperty(ref _incidentList, value);
            }
        }

        public IncidentModel SelectedIncident
        {
            get { return _selectedIncident; }
            set
            {
                if (_selectedIncident != value)
                {
                    SetProperty(ref _selectedIncident, value);
                    PublishSelectedItemChanged();
                }
            }
        }

        public void AddIncident(IncidentModel incident)
        {
            if (IncidentList.All(x => x.Id != incident.Id))
            {
                IncidentList.Add(incident);
            }
        }

        public void RemoveIncident(IncidentModel incident)
        {
            if (IncidentList.Contains(incident))
            {
                IncidentList.Remove(incident);
            }
        }

        private void PublishSelectedItemChanged()
        {
            MessagingCenter.Send(this, MessengerKeys.SelectedIncidentChanged);
        }

        private void CloseIncidentRequestReceived(ViewModelBase vm)
        {
            SelectedIncident = null;
        }
    }
}
