using Domain;
using System;
using System.Collections.Generic;
using Service.Converters;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dto = Service.Dto;

namespace WebApi.Controllers
{
    [RoutePrefix("clients")]
    public class ClientController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();

        [Route]
        public IHttpActionResult GetAll(UserSortType sort = UserSortType.Id)
        {
            switch (sort)
            {
                case UserSortType.Id:
                    return this.Ok(Context.Clients.ToList().Select(i => ClientConverter.ToDto(i)));
                case UserSortType.Name:
                    return this.Ok(Context.Clients.ToList().Select(i => ClientConverter.ToDto(i)).OrderBy(i => i.Name));
                default:
                    return this.Ok(Context.Clients);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            Client client = Context.Clients.FirstOrDefault(i => i.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(client);
            }
        }

        [Route]
        public IHttpActionResult Post(Dto.Client client)
        {
            Client domain = new Client(client.Name, client.Gender, client.MailAddress, client.Occupation, client.UserName);
            Context.Clients.Add(domain);
            Context.SaveChanges();
            client = ClientConverter.ToDto(domain);
            return Created(this.Request.RequestUri.AbsolutePath + "/" + client.Id, client);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Dto.Client client)
        {
            Client existing = Context.Clients.FirstOrDefault(i => i.Id == id);
            if(existing == null)
            {
                return NotFound();
            }
            else
            {
                existing.UpdateClient(client.MailAddress, client.Occupation, client.UserName);
                return Ok(existing);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            Client existing = Context.Clients.FirstOrDefault(i => i.Id == id);
            if(existing == null)
            {
                return NotFound();
            }
            else
            {
         //       Database.Remove(existing);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("{id:int}/tickets")]
        public IHttpActionResult GetAllTickets(int id)
        {
            Client existing = Context.Clients.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                var tickets = Context.Tickets;
                //var tickets = Database.Tickets.Where(i => i.ClientId == id);
                if (tickets == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(tickets);
                }
            }
        }


        [Route("{id:int}/tickets/{tickettype:int}")]
        public IHttpActionResult GetTickets(int id, int tickettype)
        {
            Client existing = Context.Clients.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                var tickets = existing.Tickets;
                if (tickets == null)
                {
                    return NotFound();
                }
                else
                {
                    if (!Enum.IsDefined(typeof(TicketType), tickettype))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return this.Ok(tickets.Where(i => i.TicketType == (TicketType)tickettype));
                    }
                    return Ok(tickets);
                }
            }
        }

    }
}
