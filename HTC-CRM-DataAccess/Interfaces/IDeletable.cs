using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTC_CRM_DataAccess.Interfaces
{
    interface IDeletable
    {
         bool IsDeleted { get; set; }
    }
}
