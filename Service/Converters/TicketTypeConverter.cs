using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;

namespace Service.Converters
{
    public static class TicketTypeConverter
    {
        public static Dto.TicketType ToDto(Dmn.TicketType domain)
        {
            return new Dto.TicketType()
            {
                Id = (int)domain,
                Name = domain.ToString()
            };
        }
    }
}
