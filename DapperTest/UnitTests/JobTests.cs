using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using HTC_CRM_DataAccess.Models;
using HTC_CRM_DataAccess.Connections;
using System.Data;
using MiniProfiler.Integrations;

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
                Longitude = 0
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

            //IDbConnection db = DBConnection.GetConnection();
            var factory = new SqlServerDbConnectionFactory("Data Source=.;Initial Catalog=HTCCRMPortal;Integrated Security=True;");
            using (var db = DbConnectionFactoryHelper.New(factory, CustomDbProfiler.Current))
            {

                Job job1 = new Job()
                {
                    //Id = 4,
                    CustomerId = 1,
                    Name = "XYZ Corp Carpet Install",
                    Description = "Replacing carpet in XYZ corporate offices",
                    StartDate = Convert.ToDateTime("11/29/2017"),
                    CompletionDate = Convert.ToDateTime("12/31/9999"),
                    ProjectManagerId = 1,
                    AccountManagerId = 2,
                    EstimatedCost = 25000.0000M,
                    EstimationNotes = null,
                    POCost = 20000.0000M,
                    POStatus = "Not Paid",
                    VarianceNotes = "",
                    StreetAddress = "253 Hotel Road",
                    City = "Auburn",
                    State = "ME",
                    Zip = "04210",
                    Latitude = 0,
                    Longitude = 0,
                    IsDeleted = true,
                    WhenCreated = Job.GetById<Job>(db, 4).WhenCreated,
                    ValidToDate = Convert.ToDateTime("9999-12-31")
                    //MasterId = 4
                };

                //Console.WriteLine(job1.MasterId);

                //Job.Persist<Job>(db, job1);
                // Console.WriteLine("SQL statement: " + CustomDbProfiler.Current.ProfilerContext.GetCommands());
                //Job job2 = Job.GetById<Job>(db, 4);

                //job2.Name = "ABC Carpet Install";
                // job2.Persist<Job>(db);

                //IEnumerable<Job> jobs1 = Job.GetAll<Job>(db);
                //IEnumerable<Job> jobs2 = Job.GetAll<Job>(db, false, false);
                //IEnumerable<Job> jobs3 = Job.GetAll<Job>(db, true, true);
                //IEnumerable<Job> jobs4 = Job.GetAll<Job>(db, true, false);

                //Assert.AreEqual(18, jobs1.Count());
                //Assert.AreEqual(18, jobs2.Count());
                //Assert.AreEqual(21, jobs3.Count());
                //Assert.AreEqual(19, jobs4.Count());

                var jobs = Job.GetBySubContractorId(db, 1);
            }
        }

        [Test]
        public void JobHistoryTest()
        {

        }
    }
}
