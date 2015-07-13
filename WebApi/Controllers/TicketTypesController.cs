using Domain;
using Service.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("ticket-types")]
    public class TicketTypesController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();

        [Route]
        public IHttpActionResult Get()
        {
            return Ok(Context.TicketTypes.Select(i => TicketTypeConverter.ToDto(i)));
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            if (!Enum.IsDefined(typeof(TicketType), id))
            {
                return NotFound();
            }
            else
            {
                return Ok(TicketTypeConverter.ToDto((TicketType)id));
            }
        }

        [Route("{id:int}/tickets")]
        public IHttpActionResult GetTickets(int id)
        {
            TicketType type =Context.TicketTypes.FirstOrDefault(i => (int)i == id);
            if (!Enum.IsDefined(typeof(TicketType), id))
            {
                return NotFound();
            }
            else
            {
                return Ok(Context.Tickets.Where(i => i.TicketType == type)
                                        .Select(j => TicketConverter.ToDto(j)));
            }
        }
    }
}
