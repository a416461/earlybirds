using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Database
    {
       
        private static readonly SqlDatabase db = new SqlDatabase(ConfigurationManager.ConnectionStrings["EarlyBirds"].ConnectionString);
        //public static List<Client> Clients
        //{
        //    get
        //    {
        //        DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Clients");
        //        return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i => {
        //            int id = (int)i["Id"];
        //            string name = (string)i["Name"];
        //            GenderType gender = (GenderType)i["GenderId"];
        //            string email = (string)i["EmailAddress"];
        //            string occupation = (string)i["Occupation"];
        //            string username = (string)i["username"];
        //            string password = (string)i["password"];
        //            return new Client(id,name, gender, email,occupation,username,password);
        //        }).ToList();
        //    }
        //}
        
        //public static List<Ticket> Tickets
        //{
        //    get
        //    {
        //        DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Tickets");
        //        return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i => {
        //            int id = (int)i["Id"];
        //            int? clientid = i["ClientId"] == DBNull.Value ? null : (int?)i["ClientId"];
        //            string title = (string)i["Title"];
        //            string description = (string)i["Description"];
        //            TicketType ticketType = (TicketType)i["TicketTypeId"];
        //            DateTime creationDate = (DateTime)i["CreationDate"];
        //            int priority =(int)i["Priority"];
        //            TicketStatus status = (TicketStatus)i["TicketStatusId"];
        //            string solution = (string)i["Solution"];
        //            return new Ticket(id, clientid, title, description,ticketType, creationDate, priority,status,solution);
        //        }).ToList();
        //    }
        //}

        //public static void Delete(Ticket existing)
        //{
        //    DbCommand cmd = db.GetSqlStringCommand(string.Format("Delete from Tickets where Id = {0}", existing.Id));
        //    db.ExecuteNonQuery(cmd);
        //}

        //public static void Update(int id, Ticket ticket)
        //{
        //    DbCommand cmd =
        //    db.GetSqlStringCommand(string.Format(" UPDATE Tickets set AssignedToUserId={0},Priority={1},Title='{2}',Description='{3}',Solution='{4}',TicketTypeId={5},TicketStatusId={6} WHERE Id = {7}", ticket.AssignedToUserId,ticket.Priority,ticket.Title,ticket.Description,ticket.Solution,(int)ticket.TicketType,(int)ticket.Status, id));
        //    db.ExecuteNonQuery(cmd);
        //}

        //public static void Insert(Client client)
        //{
        //    //DbCommand cmd =
        //    //   db.GetSqlStringCommand(string.Format(@"Insert into Clients(Name, GenderId, EmailAddress, Occupation, Username, Password) OUTPUT INSERTED.Id
        //    //   VALUES ('{0}',{1},'{2}','{3}','{4}','{5}')", client.Name, (int)client.Gender,client.MailAddress,client.Occupation,client.UserName,client.Password));
        //    //int id = (int)db.ExecuteScalar(cmd);
        //    //client.SetId(id);

        //    DbCommand cmd = db.GetStoredProcCommand("dbo.INSERTCLIENT");
        //    db.AddInParameter(cmd, "@Name", DbType.String, client.Name);
        //    db.AddInParameter(cmd, "@GenderId", DbType.Int32, (int)client.Gender);
        //    db.AddInParameter(cmd, "@EmailAddress", DbType.String, client.MailAddress);
        //    db.AddInParameter(cmd, "@Occupation", DbType.String, client.Occupation);
        //    db.AddInParameter(cmd, "@Username", DbType.String, client.UserName);
        //    db.AddInParameter(cmd, "@password", DbType.String, client.Password);
        //    int id = (int)db.ExecuteScalar(cmd);
        //    client.SetId(id);
        //}

        //public static void Insert(User user)
        //{
        //    DbCommand cmd =
        //       db.GetSqlStringCommand(string.Format(@"Insert into Clients(Name,GenderId, EmailAddress, Occupation, Username, Password) OUTPUT INSERTED.Id
        //       VALUES ('{0}',{1},'{2}','{3}','{4}','{5}')", user.Name, (int)user.Gender, user.MailAddress, user.Occupation, user.UserName, user.Password));
        //    int id = (int)db.ExecuteScalar(cmd);
        //    user.SetId(id);
        //}

        //public static void Insert(Ticket newTicket)
        //{
        //    DbCommand cmd =
        //        db.GetSqlStringCommand(string.Format("Insert into Tickets( ClientId, Title, Description, TicketTypeId) VALUES ({0}, '{1}', '{2}',{3})", newTicket.ClientId, newTicket.Title, newTicket.Description, (int)(newTicket.TicketType)));
        //    db.ExecuteNonQuery(cmd);
        //}

        //public static List<User> Users
        //{
        //    get
        //    {
        //        DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM Users");
        //        return db.ExecuteDataSet(cmd).Tables[0].AsEnumerable().Select(i => {
        //            int id = (int)i["Id"];
        //            string name = (string)i["Name"];
        //            GenderType gender = (GenderType)i["GenderId"];
        //            string email = (string)i["EmailAddress"];
        //            string occupation = (string)i["Occupation"];
        //            string username = (string)i["username"];
        //            string password = (string)i["password"];
        //            return new User(id, name, gender, email, occupation, username, password);
        //        }).ToList();


        //        //DataSet ds = db.ExecuteDataSet(cmd);                               //method 2
        //        //List<User> users = new List<User>();

        //        //foreach (DataRow dr in ds.Tables[0].Rows)
        //        //{
        //        //    int? id = dr["Id"] == DBNull.Value ? null : (int?)dr["Id"];
        //        //    User user = new User();
        //        //    users.Add(user);
        //        //}

        //        //return users;
        //    }
        //}

        //public static List<TicketType> TicketTypes = Enum.GetValues(typeof(TicketType)).Cast<TicketType>().ToList();
        
    }
}
