// using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, buttonLabel);
        }
        public Task<bool> ConfirmAsync(string message, string title)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, "Yes", "No");
        }

        public void ShowLocalNotification(string message, Action action)
        {
            /*
            UserDialogs.Instance.Toast(new ToastConfig(message)
                    .SetDuration(TimeSpan.FromSeconds(10))
                    .SetAction(x => x
                        .SetAction(action)));
            */
        }
    }
}
