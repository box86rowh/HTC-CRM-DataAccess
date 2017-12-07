using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data;

namespace HTC_CRM_DataAccess.Models
{
    [Table("AA_SubContractorJobs")]
    public class SubContractorJob
    {
        [Key]
        public int Id { get; set; }
        public int SubContractorId { get; set; }
        public int JobId { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Nullable<decimal> EstimatedCost { get; set; }
        public Nullable<decimal> ActualCost { get; set; }
        public bool IsDeleted { get; set; }

        [Computed]
        public int DurationInDays
        {
            get
            {
                if (EndDate.Equals(null))
                {
                    return Convert.ToInt32((DateTime.Today - StartDate).TotalDays);
                }
                else
                {

                    return Convert.ToInt32((Convert.ToDateTime(EndDate) - StartDate).TotalDays);
                }
            }

            set { }
        }

        public static IEnumerable<SubContractorJob> GetAll(IDbConnection db)
        {
            return db.GetAll<SubContractorJob>().Where(i => i.IsDeleted == false);
        }

        public static IEnumerable<SubContractorJob> GetAll(IDbConnection db, bool IncludeDeletes)
        {
            if (IncludeDeletes)
            {
                return db.GetAll<SubContractorJob>();
            }
            else
            {
                return db.GetAll<SubContractorJob>().Where(i => i.IsDeleted == false);
            }
        }

        public static SubContractorJob GetById(IDbConnection db, int id)
        {
            return db.Get<SubContractorJob>(id);
        }

        public bool Persist(IDbConnection db)
        {
            if (Id > 0)
            {
                db.Update<SubContractorJob>(this);
                return true;
            }
            else
            {
                db.Insert<SubContractorJob>(this);
                return false;
            }
        }
    }
}
