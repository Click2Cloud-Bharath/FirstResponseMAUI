using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Views
{
    public partial class ResponderListPaneView : ContentView
    {
        public static readonly BindableProperty SelectedIncidentCommandProperty =
            BindableProperty.Create("SelectedIncidentCommand",
                typeof(ICommand), typeof(ResponderListPaneView), default(ICommand),
                BindingMode.TwoWay);

        public ICommand SelectedIncidentCommand
        {
            get { return (ICommand)base.GetValue(SelectedIncidentCommandProperty); }
            set { base.SetValue(SelectedIncidentCommandProperty, value); }
        }

        public ResponderListPaneView()
        {
            InitializeComponent();
        }
    }
}
