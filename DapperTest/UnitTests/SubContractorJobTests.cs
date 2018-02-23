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
                SubContractorId = 5,
                JobId = 9,
                StartDate = DateTime.Today,
                EndDate = null,
                EstimatedCost = 30000,
                ActualCost = 15000,
                WhenCreated = SubContractorJob.GetById<SubContractorJob>(db, 1).WhenCreated
            };


            SubContractorJob s2 = new SubContractorJob()
            {
                SubContractorId = 6,
                JobId = 9,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(5),
                EstimatedCost = 12000,
                ActualCost = 15000,
                WhenCreated = SubContractorJob.GetById<SubContractorJob>(db, 2).WhenCreated
            };

            SubContractorJob s3 = new SubContractorJob()
            {
                SubContractorId = 6,
                JobId = 8,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(10),
                EstimatedCost = 20000,
                ActualCost = 18000,
                IsDeleted = true,
                WhenCreated = SubContractorJob.GetById<SubContractorJob>(db, 3).WhenCreated
            };

            //what is the value of IsDeleted by default?
            TestContext.Out.WriteLine("Value of IsDeleted: " + s2.IsDeleted);

            SubContractorJob.Persist<SubContractorJob>(db, s1);
            SubContractorJob.Persist<SubContractorJob>(db, s2);
            SubContractorJob.Persist<SubContractorJob>(db, s3);

        }

        [Test]
        public void SubJobGetTests()
        {


        }

        [Test]
        public void SubJobDurationTest()
        {
            
        }
    }
}
