using FirstResponseMAUI.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FirstResponseMAUI.Services.Ticket
{
    public interface ITicketService
    {
        Task<bool> AddTicketAsync(TicketModel ticket);
    }
}
