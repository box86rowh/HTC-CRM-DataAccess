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
    [Table("AA_SubContractorJobs")]
    public class SubContractorJob : BusinessObject, IDeletable
    {
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

    }
}
