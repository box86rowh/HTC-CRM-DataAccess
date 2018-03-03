using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using TypeLite;

namespace HTC_CRM_DataAccess.Models
{
    [TsClass]
    [Table("AA_CustomerUsers")]
    public class CustomerUser : BusinessObject
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
    }
}
