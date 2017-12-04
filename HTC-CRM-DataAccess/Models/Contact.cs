using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace HTC_CRM_DataAccess.Models
{
    [Table("AA_Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public int CustId { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone  { get; set; }
        public string ContactEmail { get; set; }
        public bool IsDeleted { get; set; }

        public static IEnumerable<Contact> GetAll(IDbConnection db)
        {
            return db.GetAll<Contact>().Where(i => i.IsDeleted == false);
        }

        public static Contact GetById(IDbConnection db, int id)
        {
            Contact c = db.Get<Contact>(id);
            if(c.IsDeleted)
            {
                return null;
            }
            else
            {
                return c;
            }
        }

        public bool Persist(IDbConnection db)
        {
            if (Id > 0)
            {
                db.Update<Contact>(this);
                return true;
            }
            else
            {
                db.Insert<Contact>(this);
                return false;
            }
        }
    }
}
