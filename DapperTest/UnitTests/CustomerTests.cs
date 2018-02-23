using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HTC_CRM_DataAccess.Models;
using HTC_CRM_DataAccess.Connections;
using System.Data;

namespace DapperTest.UnitTests
{
    [TestFixture]
    class CustomerTests
    {
        [Test]
        public void CustomerDBOperationsTest()
        {
            IDbConnection db = DBConnection.GetConnection();
            Customer c = Customer.GetById<Customer>(db, 2);

            c.CustName = "XYZ Corporation";
            Customer.Persist<Customer>(db, c);
        }
     }
}
