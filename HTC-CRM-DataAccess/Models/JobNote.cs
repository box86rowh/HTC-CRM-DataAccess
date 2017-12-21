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
    [Table("AA_JobNotes")]
    public class JobNote
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
        
    }
}
