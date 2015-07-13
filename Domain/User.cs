using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public ICollection<Ticket> Tickets { get; protected set; }

        //public IEnumerable<Ticket> Tickets
        //{
        //    get
        //    {
        //        return Context.Tickets.Where(i => i.AssignedToUserId == this.Id);
        //    }
        //}

        public User(string name, GenderType gender)
        {
            this.Name = name;
            this.Gender = gender;
            this.RegistrationDate = DateTime.Now;
        }

        //public User(int id, string name, GenderType gender, string mail, string occupation, string username, string password)
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

        public User()
        {

        }


        public void UpdateUser(string name)
        {
            this.Name = name;
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
        public GenderType Gender { get; set; }
        public string MailAddress { get; set; }
        public string Occupation { get; set; }
        public string UserName { get; set; }
        public string Password { get;private set; }

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
