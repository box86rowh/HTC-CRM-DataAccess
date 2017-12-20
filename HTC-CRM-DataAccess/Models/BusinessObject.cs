using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data;
using HTC_CRM_DataAccess.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace HTC_CRM_DataAccess.Models
{
    public abstract class BusinessObject<T>
    {
        [Key]
        public int Id { get; set; }
        [XmlIgnore]
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
            where T : BusinessObject<T>
        {
            LastModified = DateTime.Now;

            //flag to indicate whether this object implements the IHistoricalData interface
            var maintainHistory = typeof(IHistoricalData).IsAssignableFrom(typeof(T));

            if (Id > 0)
            {
                //if we maintain history for this object...
                if (maintainHistory)
                {
                    //if the new incoming version of the record is the different than the one existing in the db...
                    if (!this.EqualsCurrentVersion<T>(db))
                    {
                        Console.WriteLine("objects are NOT equal");
                        T curr = GetById<T>(db, Id);
                        //set ValidToDate and MasterId fields appropriately for existing and new versions of the object
                        (curr as IHistoricalData).ValidToDate = DateTime.Now;
                        (this as IHistoricalData).MasterId = Id;
                        (curr as IHistoricalData).MasterId = Id;
                        curr.Id = 0;
                        //update the existing (now historical) version and insert the new version
                        db.Update(this);
                        db.Insert(curr);
                    }
                    else
                    {
                        Console.WriteLine("Objects ARE equal");
                        return true;
                    }
                }
                //if we are not maintaining history for this object...
                else
                {
                    Console.WriteLine("Not a historical data object");
                    db.Update(this);
                }
                return true;
            }
            //the record does not already exist in the db
            else
            {
                Console.WriteLine("object already exists in the db");
                WhenCreated = DateTime.Now;
                db.Insert(this);
                return false;
            }
        }


        public bool EqualsCurrentVersion<T>(IDbConnection db)
            where T : BusinessObject<T>
        {
            T curr = GetById<T>(db, Id);
            string newVersion = this.Serialize();
            string currVersion = curr.Serialize();
            return newVersion == currVersion;
        }

        private string Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, this);
                return sw.ToString();
            }
        }

    }
}

