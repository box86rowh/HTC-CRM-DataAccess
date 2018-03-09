using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using HTC_CRM_DataAccess.Interfaces;
using TypeLite;

namespace HTC_CRM_DataAccess.Models
{
    [TsClass]
    [Table("AA_CustomerContacts")]
    public class CustomerContact : BusinessObject, IDeletable
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }

        public static IEnumerable<CustomerContact> GetByCustomerId(IDbConnection db, int custId)
        {
            return db.Query<CustomerContact>(@"select * from AA_CustomerContacts where CustomerId = @id", new { id = custId });
        }
    }

}
