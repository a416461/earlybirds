using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;

namespace Service.Converters
{
    public static class ClientConverter
    {
        public static Dto.Client ToDto(Dmn.Client domain)
        {
            return new Dto.Client()
            {
                Id = domain.Id,
                Name = domain.Name,
                RegistrationDate = domain.RegistrationDate,
                Gender = domain.Gender,
                MailAddress = domain.MailAddress,
                Occupation = domain.MailAddress,
                UserName = domain.UserName
            };
        }
    }
}
