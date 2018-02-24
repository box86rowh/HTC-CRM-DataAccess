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
    class SubContractorTests
    {
        [Test]
        public void SubContractorDBOperationsTest()
        {
            IDbConnection db = DBConnection.GetConnection();
            SubContractor s = new SubContractor()
            {
                UserId = 1,
                CompanyName = "XYZ Carpet Installers",
                OfficeStreetAddress = "1000 Main Street",
                OfficeCity = "Sometown",
                OfficeState = "MA",
                OfficeZip = "9999",
                ShipToStreetAddress = "1000 Main Street",
                ShipToCity = "Sometown",
                ShipToState = "MA",
                ShipToZip = "9999",
                InsuranceCertificateId = 123,
                InsuranceExpiration = null,
                WhenCreated = SubContractor.GetById<SubContractor>(db, 5).WhenCreated
            };

            SubContractor s2 = new SubContractor()
            {
                UserId = 1,
                CompanyName = "ACME Carpet Removers",
                OfficeStreetAddress = "999 Main Street",
                OfficeCity = "Anytown",
                OfficeState = "MA",
                OfficeZip = "9999",
                ShipToStreetAddress = "999 Main Street",
                ShipToCity = "Anytown",
                ShipToState = "MA",
                ShipToZip = "9999",
                InsuranceCertificateId = 123,
                InsuranceExpiration = null,
                IsDeleted = true,
                WhenCreated = SubContractor.GetById<SubContractor>(db, 6).WhenCreated
            };

            SubContractor.Persist<SubContractor>(db, s);
            SubContractor.Persist<SubContractor>(db, s2);

            IEnumerable<SubContractor> contractors = SubContractor.GetAll<SubContractor>(db);

            Assert.AreEqual(1, contractors.Count());
        }
    }
}
