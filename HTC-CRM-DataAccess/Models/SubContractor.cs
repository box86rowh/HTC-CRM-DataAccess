using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data;

namespace HTC_CRM_DataAccess.Models
{
    [Table("AA_SubContractors")]
    public class SubContractor
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string OfficeStreetAddress { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeState { get; set; }
        public string OfficeZip { get; set; }
        public string ShipToStreetAddress { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToZip { get; set; }
        //InsuranceCertificat would go here
        public Nullable<DateTime> InsuranceExpiration { get; set; }
        public bool HasUnion { get; set; }
        public bool InstallsCarpet { get; set; }
        public bool InstallsResilient { get; set; }
        public bool InstallsSheetVinyl { get; set; }
        public bool InstallsSelfLeveling { get; set; }
        public bool InstallsCeramic { get; set; }
        public bool HasTruck { get; set; }
        public bool HasDockDoor { get; set; }
        public bool HasOverheadDoor { get; set; }
        public bool RecyclesCarpet { get; set; }
        public bool ChargesOvertimeNight { get; set; }
        public bool AgreedToTerms { get; set; }
        public int NumRideOnMachines { get; set; }
        public int NumWalkBehindMachines { get; set; }
        public int NumCarpetPullerMachines { get; set; }
        public int NumCrews { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }

        [Computed]
        public string FullOfficeAddress
        {
            get
            {

                string OfficeAddr = OfficeStreetAddress + " " + OfficeCity + ", " + OfficeState + " " + OfficeZip;
                return OfficeAddr;
            }
            set { }
        }

        [Computed]
        public string FullShipToAddress
        {
            get
            {
                string ShipToAddr = ShipToStreetAddress + " " + ShipToCity + ", " + ShipToState + " " + ShipToZip;
                return ShipToAddr;
            }
            set { }

        }

        public static IEnumerable<SubContractor> GetAll(IDbConnection db)
        {
            return db.GetAll<SubContractor>().Where(i => i.IsDeleted == false);
        }

        public static IEnumerable<SubContractor> GetAll(IDbConnection db, bool IncludeDeletes)
        {
            if(IncludeDeletes)
            {
                return db.GetAll<SubContractor>();
            }
            else
            {
                return db.GetAll<SubContractor>().Where(i => i.IsDeleted == false);
            }
        }

        public static SubContractor GetById(IDbConnection db, int id)
        {
            return db.Get<SubContractor>(id);
        }

        public bool Persist(IDbConnection db)
        {
            if (Id > 0)
            {
                db.Update<SubContractor>(this);
                return true;
            }
            else
            {
                db.Insert<SubContractor>(this);
                return false;
            }
        }
    }
}
