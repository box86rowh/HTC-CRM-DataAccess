using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data;
using HTC_CRM_DataAccess.Interfaces;

namespace HTC_CRM_DataAccess.Models
{
    [Table("AA_Jobs")]
    public class Job : BusinessObject<Job>, IDeletable
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public int ProjectManagerId { get; set; }
        public int AccountManagerId { get; set; }
        public decimal EstimatedCost { get; set; }
        public string EstimationNotes { get; set; }
        public decimal POCost { get; set; }
        public string POStatus { get; set; }
        public string VarianceNotes { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool IsDeleted { get; set; }

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

        [Computed]
        public decimal Variance
        {
            get
            {
                if(EstimatedCost == 0)
                {
                    return 0;
                } 
                else
                {
                    return POCost - EstimatedCost;
                }
            }

            set { }
        }
    }
}
