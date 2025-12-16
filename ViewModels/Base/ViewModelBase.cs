using FirstResponseMAUI.Helpers;
// using FirstResponseMAUI.Services.Dialog;
// using FirstResponseMAUI.Services.Navigation;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FirstResponseMAUI.ViewModels.Base
{
    public abstract class ViewModelBase : ObservableObject
    {
        // protected readonly IDialogService DialogService;
        // protected readonly INavigationService NavigationService;

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

        public ViewModelBase()
        {
            // DialogService = ViewModelLocator.Instance.Resolve<IDialogService>();
            // NavigationService = ViewModelLocator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
