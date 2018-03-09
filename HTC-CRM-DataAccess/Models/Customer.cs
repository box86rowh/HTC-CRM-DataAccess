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
    [Table("AA_Customers")]
    public class Customer : BusinessObject, IDeletable, IHistoricalData
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public int PhysicalAddressId { get; set; }
        public int MailingAddressId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ValidToDate { get; set; }
        public int MasterId { get; set; }

        [Computed]
        public Address MailingAddress { get; set; }

        [Computed]
        public Address PhysicalAddress { get; set; }

    }
}
