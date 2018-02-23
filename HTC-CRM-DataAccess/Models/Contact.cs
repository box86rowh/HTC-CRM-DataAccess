﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using HTC_CRM_DataAccess.Interfaces;

namespace HTC_CRM_DataAccess.Models
{
    [Table("AA_Contacts")]
    public class Contact : BusinessObject, IDeletable
    {
        public int CustId { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public bool IsDeleted { get; set; }

        public static IEnumerable<Contact> GetByCustomerId(IDbConnection db, int custId)
        {
            return db.Query<Contact>(@"select * from AA_Contacts where CustId = @id", new { id = custId });
        }
    }

}
