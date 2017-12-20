using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTC_CRM_DataAccess.Interfaces
{
    interface IHistoricalData
    {
        DateTime ValidToDate { get; set; }
        int MasterId { get; set; }
    }
}
