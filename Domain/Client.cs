using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client
    {

        public ICollection<Ticket> Tickets { get; protected set; }

        public Client(string name, GenderType gender, string mail, string occupation, string username)
        {
            this.Name = name;
            this.RegistrationDate = DateTime.Now;
            this.Gender = gender;
            this.MailAddress = mail;
            this.Occupation = occupation;
            this.UserName = username;
        }

        //public Client(int id, string name, GenderType gender, string mail, string occupation, string username, string password)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.RegistrationDate = DateTime.Now;
        //    this.Gender = gender;
        //    this.MailAddress = mail;
        //    this.Occupation = occupation;
        //    this.UserName = username;
        //    this.Password = password;
        //}
        public Client ()
        { }

        public void UpdateClient(string mail, string occupation, string username)
        {
            this.MailAddress = mail;
            this.Occupation = occupation;
            this.UserName = username;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        private MemberPriorityType? _MemberPriority;
        public MemberPriorityType MemberPriority
        {
            get
            {
                if (this._MemberPriority == null)
                {
                    if (this.MemberAge.Days < 30)
                    {
                        this._MemberPriority = MemberPriorityType.normal;
                    }
                    if (this.MemberAge.Days < 60)
                    {
                        this._MemberPriority = MemberPriorityType.important;
                    }
                    else
                    {
                        this._MemberPriority = MemberPriorityType.VIP;
                    }
                }
                return this._MemberPriority.Value;
            }
        }

        private TimeSpan? _MemberAge;
        public TimeSpan MemberAge
        {
            get
            {
                if (this._MemberAge == null)
                {
                    this._MemberAge = DateTime.Now - this.RegistrationDate;
                }
                return this._MemberAge.Value;
            }
        }

        public GenderType Gender { get; private set; }
        public string MailAddress { get; private set; }
        public string Occupation { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public bool Login(string username, string password)
        {
            return this.IsCombinationValid(username, password);
        }

        private bool IsCombinationValid(string username, string password)
        {
            return this.UserName == username && this.Password == password;
        }

        internal void SetId(int id)
        {
            this.Id = id;
        }
    }
}
