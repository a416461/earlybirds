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

    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private EarlyBirdsContext Context = new EarlyBirdsContext();

        [Route]
        public IHttpActionResult GetAll(UserSortType sort = UserSortType.Id)
        {
            switch (sort)
            {
                case UserSortType.Id:
                    return this.Ok(Context.Users.OrderBy(i => i.Id));
                case UserSortType.Name:
                    return this.Ok(Context.Users.OrderBy(i => i.Name));
                case UserSortType.Priority:
                    return this.Ok(Context.Users.OrderBy(i => i.MemberPriority));
                case UserSortType.Memberage:
                    return this.Ok(Context.Users.OrderByDescending(i => i.MemberAge));
                default:
                    return this.Ok(Context.Users);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            User user = Context.Users.FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            User user = Context.Users.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return this.Ok(user);
            }
        }

        [Route]
        public IHttpActionResult Post(User user)
        {
            //Database.Insert(user);
            Context.Users.Add(user);
            Context.SaveChanges();
            return Created(this.Request.RequestUri.AbsolutePath + "/" + user.Id, user);
        }

        [Route("{id:int}")]
        public IHttpActionResult Put(int id, User user)
        {
            User existing = Context.Users.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                existing.UpdateUser(user.Name);
                return Ok(existing);
            }
        }

        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            User existing = Context.Users.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                Context.Users.Remove(existing);
                Context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        [Route("{id:int}/tickets")]
        public IHttpActionResult GetAllTickets(int id)
        {
            User existing = Context.Users.FirstOrDefault(i => i.Id == id);
            if(existing == null)
            {
                return NotFound();
            }
            else
            {
                var tickets = Context.Tickets.Where(i => i.AssignedToUserId == id);
                if(tickets == null)
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
            User existing = Context.Users.FirstOrDefault(i => i.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            else
            {
                var tickets = existing.Tickets;
               // var tickets = Database.Tickets.Where(i => i.AssignedToUserId == id);
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
