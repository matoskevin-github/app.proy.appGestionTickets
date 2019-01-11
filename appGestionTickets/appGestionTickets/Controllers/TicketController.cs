using appGestionTickets.Models;
using appGestionTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appGestionTickets.Controllers
{
    public class TicketController : Controller
    {
        private cnxTicketsBD oContext;
        // GET: Ticket

        public TicketController()
        {
            oContext = new cnxTicketsBD();
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Tickets> listado = oContext.Tickets.ToList();
            return View(listado);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            var viewModel = new TicketViewModel();
            viewModel.lstResponsables = oContext.Responsable.ToList();
            viewModel.lstEstados = oContext.Estado.ToList();
            viewModel.lstUsuarios = oContext.Usuario.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Nuevo(Tickets ticket)
        {
            oContext.Tickets.Add(ticket);
            oContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Detalle(int IdTicket)
        {
            var viewModel = new TicketViewModel();
            viewModel.Ticket = oContext.Tickets.FirstOrDefault(t => t.IdTicket == IdTicket);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Actualizar(int IdTicket)
        {
            var viewModel = new TicketViewModel();
            viewModel.Ticket = oContext.Tickets.FirstOrDefault( x=> x.IdTicket == IdTicket);
            viewModel.lstResponsables = oContext.Responsable.ToList();
            viewModel.lstEstados = oContext.Estado.ToList();
            viewModel.lstUsuarios = oContext.Usuario.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Actualizar(Tickets ticket)
        {
            /*oContext.Tickets.Add(tickets);*/
            oContext.Entry(ticket).State = EntityState.Modified;
            oContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Eliminar(int IdTicket)
        {
            var Ticket = oContext.Tickets.FirstOrDefault(x => x.IdTicket == IdTicket);
            oContext.Tickets.Remove(Ticket);
            oContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}