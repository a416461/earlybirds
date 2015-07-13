using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service.Dto
{
    public class Client
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public DateTime RegistrationDate { get;  set; }
        public GenderType Gender { get; set; }
        public string MailAddress { get; set; }
        public string Occupation { get; set; }
        public string UserName { get; set; }

    }
}
