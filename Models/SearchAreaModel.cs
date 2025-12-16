namespace FirstResponseMAUI.Models
{
    public class SearchAreaModel
    {
        public Geoposition[] Polygon { get; set; }

        public TicketModel[] Tickets { get; set; }
    }
}
