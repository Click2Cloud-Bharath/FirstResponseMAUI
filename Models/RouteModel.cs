using System.Collections.Generic;

namespace FirstResponseMAUI.Models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public IList<Geoposition> RoutePoints { get; set; }
    }
}
