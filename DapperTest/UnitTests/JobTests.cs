using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HTC_CRM_DataAccess.Models;
using HTC_CRM_DataAccess.Connections;
using System.Data;

namespace HTC_CRM_DataAccess.Tests
{
    [TestFixture]
    class JobTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void DaysInDurationTest()
        {
            IDbConnection db = DBConnection.GetConnection();

            Job job1 = new Job()
            {
                Id = 1,
                CustomerId = 1,
                Name = "XYZ Corp Carpet Install",
                Description = "Replacing carpet in XYZ corporate offices",
                StartDate = DateTime.Today.AddDays(-2),//Convert.ToDateTime("11/29/2017"),
                CompletionDate = Convert.ToDateTime("12/31/9999"),
                ProjectManagerId = 1,
                AccountManagerId = 1,
                EstimatedCost = 0,
                EstimationNotes = null,
                POCost = 20000,
                POStatus = "Not Paid",
                VarianceNotes = "",
                StreetAddress = "253 Hotel Road",
                City = "Auburn",
                State = "ME",
                Zip = "04210",
                Latitude = 0,
                Longitude = 0,
            };

           
            Assert.AreEqual(2, job1.DurationInDays);
            Assert.AreNotEqual(3, job1.DurationInDays);
            Assert.AreNotEqual(1, job1.DurationInDays);
        }

        [Test]
        public void VarianceTest()
        {
            Job job1 = new Job()
            {
                Id = 2,
                CustomerId = 1,
                Name = "XYZ Corp Carpet Install",
                Description = "Replacing carpet in XYZ corporate offices",
                StartDate = DateTime.Today.AddDays(-2),//Convert.ToDateTime("11/29/2017"),
                CompletionDate = Convert.ToDateTime("12/31/9999"),
                ProjectManagerId = 1,
                AccountManagerId = 1,
                EstimatedCost = 25000,
                EstimationNotes = null,
                POCost = 20000,
                POStatus = "Not Paid",
                VarianceNotes = "",
                StreetAddress = "253 Hotel Road",
                City = "Auburn",
                State = "ME",
                Zip = "04210",
                Latitude = 0,
                Longitude = 0,
                IsDeleted = true
            };

            Assert.AreEqual(-5000, job1.Variance);
        }

        [Test]
        public void JobsDBOperationsTest()
        {

            IDbConnection db = DBConnection.GetConnection();

            Job job1 = new Job()
            {
                Id = 3,
                CustomerId = 1,
                Name = "XYZ Corp Carpet Install",
                Description = "Replacing carpet in XYZ corporate offices",
                StartDate = DateTime.Today.AddDays(-2),//Convert.ToDateTime("11/29/2017"),
                CompletionDate = Convert.ToDateTime("12/31/9999"),
                ProjectManagerId = 1,
                AccountManagerId = 2,
                EstimatedCost = 25000,
                EstimationNotes = null,
                POCost = 20000,
                POStatus = "Not Paid",
                VarianceNotes = "",
                StreetAddress = "253 Hotel Road",
                City = "Auburn",
                State = "ME",
                Zip = "04210",
                Latitude = 0,
                Longitude = 0,
                IsDeleted = true
            };

            job1.Persist<Job>(db);

            IEnumerable<Job> jobs1 = Job.GetAll<Job>(db);
            IEnumerable<Job> jobs2 = Job.GetAll<Job>(db, false);
            IEnumerable<Job> jobs3 = Job.GetAll<Job>(db, true);

            Assert.AreEqual(19, jobs1.Count());
            Assert.AreEqual(19, jobs2.Count());
            Assert.AreEqual(20, jobs3.Count());
        }

    }
}
