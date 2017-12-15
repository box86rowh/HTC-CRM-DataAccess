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
    public abstract class BusinessObject<T>
    {
        [Key]
        public int Id { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime WhenCreated { get; set; }

        public static T GetById<T>(IDbConnection db, int id)
            where T : BusinessObject<T>
        {
            return db.Get<T>(id);
        }

        public static IEnumerable<T> GetAll<T>(IDbConnection db)
            where T : BusinessObject<T>
        {
            return GetAll<T>(db, false);
        }

        public static IEnumerable<T> GetAll<T>(IDbConnection db, bool includeDeletes)
            where T : BusinessObject<T>
        {
            var isDeletable = typeof(IDeletable).IsAssignableFrom(typeof(T));
            return db.GetAll<T>().Where(i => !isDeletable || (!(i as IDeletable).IsDeleted || includeDeletes));
        }

        public bool Persist<T>(IDbConnection db)
        {
            LastModified = DateTime.Now;

            if (Id > 0)
            {
                db.Update(this);
                return true;
            }
            else
            {
                WhenCreated = DateTime.Now;
                db.Insert(this);
                return false;
            }
        }

    }
}

