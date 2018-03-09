using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data;
using HTC_CRM_DataAccess.Interfaces;
using Dapper;
using TypeLite;

namespace HTC_CRM_DataAccess.Models
{
    [TsClass]
    [Table("AA_Jobs")]
    public class Job : BusinessObject, IDeletable, IHistoricalData
    {
    
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int ProjectManagerId { get; set; }
        public int AccountManagerId { get; set; }
        public int AddressId { get; set; }
        public decimal EstimatedCost { get; set; }
        public string EstimationNotes { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ValidToDate { get; set; }
        public int MasterId { get; set; }

        [Computed]
        public int DurationInDays
        {
            get
            {
                if(CompletionDate.Equals(Convert.ToDateTime("12/31/9999")))
                {
                    return Convert.ToInt32((DateTime.Today - StartDate).TotalDays);
                }
                else
                {

                    return Convert.ToInt32((CompletionDate - StartDate).TotalDays);
                }
            }

            set { }
        }


        public static IEnumerable<Job> GetByCustomerId(IDbConnection db, int custId)
        {
            return db.Query<Job>(@"select * from AA_Jobs where CustomerId = @id", new { id = custId });
        }

        public static IEnumerable<Job> GetBySubContractorId(IDbConnection db, int custId)
        {   
            return db.Query<Job>(@"select j.* from AA_Jobs j Inner Join AA_SubContractorJobs s on s.JobId = j.Id where CustomerId = @id", new { id = custId });
        }
    }
}
