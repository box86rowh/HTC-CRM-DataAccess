using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data;
using HTC_CRM_DataAccess.Interfaces;
using TypeLite;

namespace HTC_CRM_DataAccess.Models
{
    [TsClass]
    [Table("AA_Proposals")]
    public class Proposal : BusinessObject, IDeletable
    {
        public int CustomerId { get; set; }
        public string ProjectName { get; set; }
        public int AddressId { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
