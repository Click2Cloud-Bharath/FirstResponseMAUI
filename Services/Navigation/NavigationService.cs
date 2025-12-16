using FirstResponseMAUI.ViewModels;
using FirstResponseMAUI.ViewModels.Base;
using FirstResponseMAUI.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Services.Navigation
{
    public partial class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;
        protected readonly IServiceProvider _serviceProvider;

        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public Task InitializeAsync()
        {
            return NavigateToAsync<LoginViewModel>();
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PopAsync();
            }
            else if (CurrentApplication.MainPage is FlyoutPage flyoutPage && flyoutPage.Detail is NavigationPage detailNavigationPage)
            {
                await detailNavigationPage.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task RemoveBackStackAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var view = CreateAndBindView(viewModelType, parameter);
            
            if (view is Page page)
            {
                if (page is LoginView)
                {
                    CurrentApplication.MainPage = new NavigationPage(page);
                }
                else if (page is MainView)
                {
                    CurrentApplication.MainPage = page;
                }
                else if (CurrentApplication.MainPage is NavigationPage navigationPage)
                {
                    await navigationPage.PushAsync(page);
                }
                else if (CurrentApplication.MainPage is FlyoutPage flyoutPage && flyoutPage.Detail is NavigationPage detailNavigationPage)
                {
                    await detailNavigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new NavigationPage(page);
                }
            }

            if (view is BindableObject bindable && bindable.BindingContext is ViewModelBase viewModel)
            {
                await viewModel.InitializeAsync(parameter);
            }
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected object CreateAndBindView(Type viewModelType, object parameter)
        {
            Type viewType = GetPageTypeForViewModel(viewModelType);

            if (viewType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a view");
            }

            object view = _serviceProvider.GetService(viewType);
            if (view == null)
                view = Activator.CreateInstance(viewType);

            ViewModelBase viewModel = _serviceProvider.GetService(viewModelType) as ViewModelBase;
            if (view is BindableObject bindable)
            {
                bindable.BindingContext = viewModel;
            }

            return view;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(NewTicketViewModel), typeof(NewTicketPopupView));
            _mappings.Add(typeof(SuspectViewModel), typeof(SuspectPopupView));
            _mappings.Add(typeof(CitiesViewModel), typeof(CitiesView));
            _mappings.Add(typeof(LoginViewModel), typeof(LoginView));
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(PowerBIViewModel), typeof(PowerBIView));
        }
    }
}
