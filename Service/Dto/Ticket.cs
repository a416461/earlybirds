using Dmn = Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class Ticket
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public Dmn.TicketType TicketType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public Dmn.TicketStatus Status { get; set; }
        public int? AssignedToUserId { get; set; }
    }
}
