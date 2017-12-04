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
    [Table("AA_Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
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

        [Computed]
        public string FullOfficeAddress
        {
            get {

                string OfficeAddr = OfficeStreetAddress + " " + OfficeCity + ", " + OfficeState + " " + OfficeZip;
                return OfficeAddr;
            }
            set { }
        }

        [Computed]
        public string FullShipToAddress
        {
            get
            {
                string ShipToAddr = ShipToStreetAddress + " " + ShipToCity + ", " + ShipToState + " " + ShipToZip;
                return ShipToAddr;
            }
            set { }
            
        }

        public static IEnumerable<Customer> GetAll(IDbConnection db)
        {
            return db.GetAll<Customer>().Where(i => i.IsDeleted == false);
        }

        public static Customer GetById(IDbConnection db, int id)
        {
            Customer c = db.Get<Customer>(id);
            if (c.IsDeleted)
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
            if(Id > 0)
            {
                db.Update<Customer>(this);
                return true;
            }
            else
            {
                db.Insert<Customer>(this);
                return false;
            }
        }
    }
}
