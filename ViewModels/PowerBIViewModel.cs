using FirstResponseMAUI.Helpers;
using FirstResponseMAUI.ViewModels.Base;
// using Rg.Plugins.Popup.Services;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.ViewModels
{
    public class PowerBIViewModel : ViewModelBase
    {
        // public string PowerBIUrl = $"{Settings.ServiceEndpoint}/PowerBi";

        public string PowerBIPageURL
        {
            get { return ""; /*PowerBIUrl;*/ }
        }

        public ICommand ClosePopupCommand => new Command(ClosePopup);

        private async void ClosePopup()
        {
            // await PopupNavigation.PopAllAsync(true);
        }
    }
}
