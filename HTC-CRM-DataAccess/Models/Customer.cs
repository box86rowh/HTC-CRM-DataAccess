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
    public class Customer : BusinessObject, IDeletable, IHistoricalData, IHydratable
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

        public void Hydrate(IDbConnection db)
        {
            MailingAddress = Address.GetById<Address>(db, MailingAddressId);
            PhysicalAddress = Address.GetById<Address>(db, PhysicalAddressId);
        }

        public void HydratedPersist(IDbConnection db)
        {
            Address.Persist<Address>(db, MailingAddress);
            MailingAddressId = MailingAddress.Id;

            Address.Persist<Address>(db, PhysicalAddress);
            PhysicalAddressId = PhysicalAddress.Id;
        }
    }
}
