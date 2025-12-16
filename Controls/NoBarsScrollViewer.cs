using Microsoft.Maui.Controls;

namespace FirstResponseMAUI.Controls
{
    public class NoBarsScrollViewer : ScrollView
    {
        public NoBarsScrollViewer()
        {
            // In MAUI, we can hide scrollbars using HorizontalScrollBarVisibility and VerticalScrollBarVisibility
            HorizontalScrollBarVisibility = ScrollBarVisibility.Never;
            VerticalScrollBarVisibility = ScrollBarVisibility.Never;
        }
    }
}
