using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace FirstResponseMAUI.Models
{
    public class IncidentTypeData
    {
        public string Icon { get; set; }

        public string Pin { get; set; }

        public IncidentType IncidentType { get; set; }

        public bool IsPriority { get; set; }

        public Color Color { get; set; }
    }
}
