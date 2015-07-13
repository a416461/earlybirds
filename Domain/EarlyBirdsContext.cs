using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Domain
{
    public class EarlyBirdsContext: DbContext

    { 

        public EarlyBirdsContext() : base("EarlyBirds") { }

  
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public IEnumerable<TicketType> TicketTypes = Enum.GetValues(typeof(TicketType)).Cast<TicketType>().ToList();
    }
}
