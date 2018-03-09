using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTC_CRM_DataAccess.Interfaces
{
    interface IHydratable
    {
        void Hydrate(IDbConnection db);
        void HydratedPersist(IDbConnection db);
    }
}
