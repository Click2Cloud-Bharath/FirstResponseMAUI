using FirstResponseMAUI.ViewModels.Base;
using CommunityToolkit.Maui.Views;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Services.Navigation
{
    public partial class NavigationService : INavigationService
    {

        public Task NavigateToPopupAsync<TViewModel>(bool animate) where TViewModel : ViewModelBase
        {
            return NavigateToPopupAsync<TViewModel>(null, animate);
        }

        public async Task NavigateToPopupAsync<TViewModel>(object parameter, bool animate) where TViewModel : ViewModelBase
        {
            var view = CreateAndBindView(typeof(TViewModel), parameter);
            
            if (view is BindableObject bindable && bindable.BindingContext is ViewModelBase viewModel)
            {
                await viewModel.InitializeAsync(parameter);
            }

            if (view is Popup popup)
            {
                Page mainPage = CurrentApplication.MainPage;
                if (mainPage != null)
                {
                    mainPage.ShowPopup(popup);
                }
            }
            else
            {
                throw new ArgumentException($"The type ${typeof(TViewModel)} is not a Popup type");
            }
        }
    }
}
