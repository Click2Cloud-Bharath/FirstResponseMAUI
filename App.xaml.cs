using FirstResponseMAUI.Views;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
        }
    }
}
