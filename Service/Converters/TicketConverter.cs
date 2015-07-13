using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;

namespace Service.Converters
{
    public static class TicketConverter
    {
        public static Dto.Ticket ToDto(Dmn.Ticket domain)
        {
            return new Dto.Ticket()
            {
                AssignedToUserId = domain.AssignedToUserId,
                ClientId = domain.ClientId,
                Description = domain.Description,
                ExpirationDate = domain.ExpirationDate,
                Id = domain.Id,
                Status = domain.Status,
                TicketType = domain.TicketType,
                Title = domain.Title,
                Solution = domain.Solution,
                Priority = domain.Priority
            };
        }
    }
}
