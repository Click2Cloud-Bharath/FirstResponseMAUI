using FirstResponseMAUI.Models;
using System;

namespace FirstResponseMAUI.Common
{
    public class IncidentEventArgs : EventArgs
    {
        public IncidentModel Incident { get; }

        public IncidentEventArgs(IncidentModel incident)
        {
            Incident = incident;
        }
    }
}
