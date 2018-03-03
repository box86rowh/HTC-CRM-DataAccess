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
        public string CustName { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeFax { get; set; }
        public string OfficeStreetAddress { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeState { get; set; }
        public string OfficeZip { get; set; }
        public string ShipToStreetAddress { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToZip { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ValidToDate { get; set; }
        public int MasterId { get; set; }

        [Computed]
        public string FullOfficeAddress
        {
            get {

                string officeAddr = OfficeStreetAddress + " " + OfficeCity + ", " + OfficeState + " " + OfficeZip;
                return officeAddr;
            }
            set { }
        }

        [Computed]
        public string FullShipToAddress
        {
            get
            {
                string shipToAddr = ShipToStreetAddress + " " + ShipToCity + ", " + ShipToState + " " + ShipToZip;
                return shipToAddr;
            }
            set { }
            
        }
    }
}
