using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Ticket
    {

        public Ticket(int? clientId, string title, string description, TicketType type)
        {
            this.ClientId = clientId;
            this.Title = title;
            this.Description = description;
            this.TicketType = type;
            this.CreationDate = DateTime.UtcNow;
            this.Priority = 0;
        }

        //public Ticket(int id, int? clientId, string title, string description, TicketType type, DateTime creationdate, int priority, TicketStatus ticketStatus, string solution)
        //{
        //    this.Id = id;
        //    this.ClientId = clientId;
        //    this.Title = title;
        //    this.Description = description;
        //    this.TicketType = type;
        //    this.CreationDate = creationdate;
        //    this.Priority = priority;
        //    this.Solution = solution;
        //    this.Status = ticketStatus;
        //}

            public Ticket()
        {

        }

        public void UpdateTicket(int? assignedToUserId,int priority, string title, string description, string solution,TicketType type, TicketStatus status)
        {
            this.AssignedToUserId = assignedToUserId;
            this.Title = title;
            this.Description = description;
            this.Solution = solution;
            this.TicketType = type;
            this.Status = status;
            this.Priority = priority;

            if (this.Status == TicketStatus.Processed)
            {
                this.SendEmailToClient();
            }
        }

        private void SendEmailToClient()
        {
           // throw new NotImplementedException();
        }

        public int Id { get; private set; }
        public int? ClientId { get; private set; }
        public int Priority { get; private set; }
        public TicketType TicketType { get; set; }
        public DateTime CreationDate { get; private set; }
        public DateTime ExpirationDate {
            get
            {
                return CreationDate.AddDays(30);
            }
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Solution { get; private set; }
        public TicketStatus Status { get; private set; }
        public int? AssignedToUserId { get; private set; }
        [ForeignKey("AssignedToUserId")]
        public User AssignedToUser { get; private set; }
    }
}
