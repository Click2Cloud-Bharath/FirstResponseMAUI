using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Controls
{
    public partial class ImageButton : Grid
    {
        public static readonly BindableProperty ImageButtonCommandProperty =
            BindableProperty.Create(nameof(ImageButtonCommand), typeof(ICommand), typeof(ImageButton), default(ICommand));

        public ICommand ImageButtonCommand
        {
            get { return (ICommand)GetValue(ImageButtonCommandProperty); }
            set { SetValue(ImageButtonCommandProperty, value); }
        }

        public static readonly BindableProperty ImageButtonTextProperty =
            BindableProperty.Create(nameof(ImageButtonText), typeof(string), typeof(ImageButton), default(string));

        public string ImageButtonText
        {
            get { return (string)GetValue(ImageButtonTextProperty); }
            set { SetValue(ImageButtonTextProperty, value); }
        }

        public ImageButton()
        {
            InitializeComponent();
        }
    }
}
