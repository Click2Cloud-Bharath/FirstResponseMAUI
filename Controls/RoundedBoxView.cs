using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace FirstResponseMAUI.Controls
{
    // In MAUI, we can use Border or Frame with rounded corners instead of custom BoxView
    // This control is kept for compatibility but could be replaced with Border
    public class RoundedBoxView : BoxView
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), 
                typeof(double), typeof(RoundedBoxView), default(double));

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty BorderThicknessProperty =
            BindableProperty.Create(nameof(BorderThickness),
                typeof(int), typeof(RoundedBoxView), 0);

        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        public static readonly BindableProperty RoundedBackgroudColorProperty =  
            BindableProperty.Create(nameof(RoundedBackgroudColor),
                typeof(Color), typeof(RoundedBoxView), Colors.White);

        public Color RoundedBackgroudColor
        {
            get { return (Color)GetValue(RoundedBackgroudColorProperty); }
            set { SetValue(RoundedBackgroudColorProperty, value); }
        }
    }
}
