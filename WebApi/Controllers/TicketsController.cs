using Domain;
using Service.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dmn = Domain;
using Dto = Service.Dto;

namespace WebApi.Controllers
{   
    [RoutePrefix("tickets")]
    public class TicketsController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();


        [Route]
        public IHttpActionResult GetAll(TicketSortType sort = TicketSortType.Id)
        {
            switch (sort)
            {
                case TicketSortType.Id:
                    return this.Ok(Context.Tickets.OrderBy(i => i.Id));
                case TicketSortType.TicketStatus:
                    return this.Ok(Context.Tickets.OrderBy(i => i.Status));
                case TicketSortType.TicketType:
                    return this.Ok(Context.Tickets.OrderBy(i => i.TicketType));
                default:
                    return this.Ok(Context.Tickets);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Dmn.Ticket ticket = Context.Tickets.FirstOrDefault(i => i.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            else
            {
                return this.Ok(TicketConverter.ToDto(ticket));
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            Ticket existing = Context.Tickets.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                Context.Tickets.Remove(existing);
                Context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.Ticket ticket)
        {
            Dmn.Ticket existing = Context.Tickets.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else if (existing.Status == TicketStatus.Processed)
            {
                return BadRequest();
            }
            else
            {
                existing.UpdateTicket(ticket.AssignedToUserId, ticket.Priority, ticket.Title, ticket.Description, ticket.Solution, ticket.TicketType, ticket.Status);
                Context.SaveChanges();
                return Ok(TicketConverter.ToDto(existing));
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Ticket ticket)
        {
            Dmn.Ticket newTicket = new Dmn.Ticket(ticket.ClientId, ticket.Title, ticket.Description, ticket.TicketType);

            Context.Tickets.Add(newTicket);
            Context.SaveChanges();
            return Created(this.Request.RequestUri.AbsolutePath + "/" + ticket.Id, TicketConverter.ToDto(newTicket));
        }
    }
}
