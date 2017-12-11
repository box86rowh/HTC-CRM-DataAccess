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
    class SubContractorJobTests
    {
        [Test]
        public void SubJobDBOperationsTest()
        {
            IDbConnection db = DBConnection.GetConnection();

            SubContractorJob s1 = new SubContractorJob()
            {
                Id = 1,
                SubContractorId = 5,
                JobId = 9,
                StartDate = DateTime.Today,
                EndDate = null,
                EstimatedCost = 30000,
                ActualCost = 15000
            };


            SubContractorJob s2 = new SubContractorJob()
            {
                Id = 2,
                SubContractorId = 6,
                JobId = 9,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(5),
                EstimatedCost = 12000,
                ActualCost = 15000

            };

            SubContractorJob s3 = new SubContractorJob()
            {
                Id = 3,
                SubContractorId = 6,
                JobId = 8,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(10),
                EstimatedCost = 20000,
                ActualCost = 18000,
                IsDeleted = true
            };

            //what is the value of IsDeleted by default?
            TestContext.Out.WriteLine("Value of IsDeleted: " + s2.IsDeleted);

            s1.Persist<SubContractorJob>(db);
            s2.Persist<SubContractorJob>(db);
            s3.Persist<SubContractorJob>(db);

        }

        [Test]
        public void SubJobGetTests()
        {
            IDbConnection db = DBConnection.GetConnection();

            IEnumerable<SubContractorJob> scj1 = SubContractorJob.GetAll<SubContractorJob>(db);
            IEnumerable<SubContractorJob> scj2 = SubContractorJob.GetAll<SubContractorJob>(db, false);
            IEnumerable<SubContractorJob> scj3 = SubContractorJob.GetAll<SubContractorJob>(db, true);

            Assert.AreEqual(2, scj1.Count());
            Assert.AreEqual(2, scj2.Count());
            Assert.AreEqual(3, scj3.Count());

            //test parent GetById method
            SubContractorJob s = SubContractorJob.GetById<SubContractorJob>(db, 1);
            Assert.AreEqual(5, s.SubContractorId);

            //parent GetAll method
            IEnumerable<SubContractorJob> subJobs1 = SubContractorJob.GetAll<SubContractorJob>(db);
            IEnumerable<SubContractorJob> subJobs2 = SubContractorJob.GetAll<SubContractorJob>(db, false);
            IEnumerable<SubContractorJob> subJobs3 = SubContractorJob.GetAll<SubContractorJob>(db, true);

            Assert.AreEqual(2, subJobs1.Count());
            Assert.AreEqual(2, subJobs2.Count());
            Assert.AreEqual(3, subJobs3.Count());

        }

        [Test]
        public void SubJobDurationTest()
        {
            IDbConnection db = DBConnection.GetConnection();

            SubContractorJob s = SubContractorJob.GetById<SubContractorJob>(db, 3);
            Assert.AreEqual(10, s.DurationInDays);
            Assert.AreNotEqual(9, s.DurationInDays);
        }
    }
}
