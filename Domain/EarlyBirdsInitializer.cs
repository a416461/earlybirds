using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Domain
{
    public class EarlyBirdsInitializer: DropCreateDatabaseIfModelChanges<EarlyBirdsContext>
    {
        protected override void Seed(EarlyBirdsContext context)
        {

            List<Client> Clients = GetClients();
            Clients.ForEach(i => context.Clients.Add(i));
            context.SaveChanges();

            List<Ticket> Tickets = GetTickets();
            Tickets.ForEach(i => context.Tickets.Add(i));
            context.SaveChanges();

            List<User> Users = GetUsers();
            Users.ForEach(i => context.Users.Add(i));
            context.SaveChanges();

        }
        private List<User> GetUsers()
        {
            return new List<User> {
                new User("user",GenderType.Female),
                new User("user1",GenderType.Male),
                new User("user2",GenderType.Male)
            };
        }

        private List<Ticket> GetTickets()
        {
            return new List<Ticket> {
                new Ticket(1,"Title1", "description1",TicketType.Complaint),
                new Ticket(2,"Title2", "description2",TicketType.Feature),
                new Ticket(3,"Title3", "description3",TicketType.Suggestion),
                new Ticket(4,"Title4", "description3",TicketType.Complaint),
                new Ticket(5,"Title5", "description3",TicketType.Complaint),
                new Ticket(4,"Title6", "description3",TicketType.Complaint),
                new Ticket(1,"Title7", "description3",TicketType.Feature),
                new Ticket(4,"Title8", "description3",TicketType.Complaint),
                new Ticket(4,"Title4", "description3",TicketType.Complaint),
                new Ticket(5,"Title5", "description3",TicketType.Complaint),
                new Ticket(4,"Title6", "description3",TicketType.Complaint),
                new Ticket(4,"Title4", "description3",TicketType.Complaint),
                new Ticket(5,"Title5", "description3",TicketType.Complaint),

            };
        }

        private List<Client> GetClients()
        {
            return new List<Client> {
                new Client("wang",GenderType.Female, "mail@mail.com", "teacher", "username"),
                new Client("dave", GenderType.Male, "mail@mail.com", "teacher", "username1"),
                new Client("Steve", GenderType.Male, "mail@mail.com", "teacher", "username2"),
                new Client("Linda", GenderType.Female, "mail@mail.com", "Professor", "username2"),
                new Client("John", GenderType.Male, "mail@mail.com", "teacher", "username2")

            };
        }
    }
}
