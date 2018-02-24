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
    [Table("AA_SubContractors")]
    public class SubContractor : BusinessObject, IDeletable
    {
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
        public int InsuranceCertificateId { get; set; } //this will be an id associated with a file
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

                string officeAddr = OfficeStreetAddress + " " + OfficeCity + ", " + OfficeState + " " + OfficeZip;
                return officeAddr;
            }
            set { }
        }

        [Computed]
        public string FullShipToAddress
        {
            get
            {
                string shipToAddr = ShipToStreetAddress + " " + ShipToCity + ", " + ShipToState + " " + ShipToZip;
                return shipToAddr;
            }
            set { }

        }
    }
}
