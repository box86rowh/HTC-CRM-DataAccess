using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTC_CRM_DataAccess.Models;
using HTC_CRM_DataAccess.Connections;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DapperTest
{
    class TestCustomers
    {
        static void Main(string[] args)
        {
            IDbConnection db = DBConnection.GetConnection();

            //Customer c = new Customer()
            //{
            //    UserId = 123,
            //    CustName = "ABC Corporation",
            //    OfficePhone = "207-123-4567",
            //    OfficeFax = null,
            //    OfficeStreetAddress = "123 Main Street",
            //    OfficeCity = "Portland",
            //    OfficeState = "ME",
            //    OfficeZip = "04240",
            //    ShipToStreetAddress = "456 Park Ave",
            //    ShipToCity = "Auburn",
            //    ShipToState = "ME",
            //    ShipToZip = "04210",
            //    Notes = null

            //};

            ////insert a new customer
            //c.Persist(db);

            //insert a corresponding contact

            Customer c2 = Customer.GetById<Customer>(db, 1);

            Contact contact = new Contact()
            {
                CustId = c2.Id,
                ContactName = "Chuck Norris",
                ContactTitle = "Facilities Manager",
                ContactPhone = "555-555-5555",
                ContactEmail = "cnorris@company.com"
            };


            contact.Persist<Contact>(db);

            //attempt to insert a contact for a customer that does not exist

            //Contact contact2 = new Contact()
            //{
            //    CustId = 999,
            //    ContactName = "Chuck Norris",
            //    ContactTitle = "Facilities Manager",
            //    ContactPhone = "555-555-5555",
            //    ContactEmail = "cnorris@company.com"
            //};

            //db.Insert<Contact>(contact2);

            //update an existing customer

            //test persist method
            //Customer c3 = db.Get<Customer>(3);
            //c3.IsDeleted = true;

            //Customer c3 = new Customer()
            //{
            //    UserId = 789,
            //    CustName = "Acme, Inc",
            //    OfficePhone = "207-123-4567",
            //    OfficeFax = null,
            //    OfficeStreetAddress = "123 Oak Street",
            //    OfficeCity = "Portland",
            //    OfficeState = "ME",
            //    OfficeZip = "04240",
            //    ShipToStreetAddress = "456 Park Ave",
            //    ShipToCity = "Auburn",
            //    ShipToState = "ME",
            //    ShipToZip = "04210",
            //    Notes = "New customer - started 11/28/17"
            //};

            //if (c3.Persist(db))
            //{
            //    Console.WriteLine("Existing record updated");
            //}
            //else
            //{
            //    Console.WriteLine("New record inserted");
            //}
            //Console.Read();

        }
    }
}
