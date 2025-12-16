using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Controls
{
    public partial class CheckBox : Grid
    {
        public static readonly BindableProperty MarkedProperty =
            BindableProperty.Create(nameof(Marked), typeof(bool), typeof(CheckBox), default(bool), BindingMode.TwoWay, null, 
                OnMarkedChanged);

        private static void OnMarkedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var isMarked = (bool)newValue;
            ((CheckBox)bindable).MarkedImage.Opacity = isMarked ? 1 : 0;
        }

        public bool Marked
        {
            get { return (bool)GetValue(MarkedProperty); }
            set { SetValue(MarkedProperty, value); }
        }

        public static readonly BindableProperty SizeProperty =
            BindableProperty.Create(nameof(Size), typeof(int), typeof(CheckBox), 20);

        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        public CheckBox()
        {
            InitializeComponent();
            MarkedImage.Opacity = 0;
        }
    }
}
