using appGestionTickets.Models;
using System.Collections.Generic;

namespace appGestionTickets.ViewModels
{
    public class TicketViewModel
    {
        public Tickets Ticket { get; set; }
        public List<Responsable> lstResponsables { get; set; }
        public List<Usuario> lstUsuarios { get; set; }
        public List<Estado> lstEstados { get; set; }
    }
}