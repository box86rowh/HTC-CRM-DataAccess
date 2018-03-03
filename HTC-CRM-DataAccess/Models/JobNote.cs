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
    [Table("AA_JobNotes")]
    public class JobNote : BusinessObject
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }

        public static IEnumerable<JobNote> GetByJobId(IDbConnection db, int jobId)
        {
            return db.Query<JobNote>(@"select * from AA_JobNotes where JobId = @id", new { id = jobId });
        }
    }
}
