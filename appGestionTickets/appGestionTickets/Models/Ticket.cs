using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appGestionTickets.Models
{
    public class Ticket
    {
        public int IdTicket { get; set; }
        public DateTime  FechaGeneracion { get; set; }
        public string IdEstado { get; set; }
        public string IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public string IdResponsable { get; set; }
        public string Solucion { get; set; }
    }
}