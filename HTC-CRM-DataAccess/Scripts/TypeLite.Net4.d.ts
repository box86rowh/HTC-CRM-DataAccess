
 
 

 

/// <reference path="Enums.ts" />

declare namespace HTC_CRM_DataAccess.Models {
	interface BusinessObject {
		Id: number;
		LastModified: Date;
		WhenCreated: Date;
	}
	interface Contact extends HTC_CRM_DataAccess.Models.BusinessObject {
		ContactEmail: string;
		ContactName: string;
		ContactPhone: string;
		ContactTitle: string;
		CustId: number;
		IsDeleted: boolean;
	}
	interface Customer extends HTC_CRM_DataAccess.Models.BusinessObject {
		CustName: string;
		FullOfficeAddress: string;
		FullShipToAddress: string;
		IsDeleted: boolean;
		MasterId: number;
		Notes: string;
		OfficeCity: string;
		OfficeFax: string;
		OfficePhone: string;
		OfficeState: string;
		OfficeStreetAddress: string;
		OfficeZip: string;
		ShipToCity: string;
		ShipToState: string;
		ShipToStreetAddress: string;
		ShipToZip: string;
		ValidToDate: Date;
	}
	interface CustomerUser extends HTC_CRM_DataAccess.Models.BusinessObject {
		CustomerId: number;
		UserId: number;
	}
	interface Job extends HTC_CRM_DataAccess.Models.BusinessObject {
		AccountManagerId: number;
		City: string;
		CompletionDate: Date;
		CustomerId: number;
		Description: string;
		DurationInDays: number;
		EstimatedCost: number;
		EstimationNotes: string;
		IsDeleted: boolean;
		Latitude: number;
		Longitude: number;
		MasterId: number;
		Name: string;
		POCost: number;
		POStatus: string;
		ProjectManagerId: number;
		StartDate: Date;
		State: string;
		StreetAddress: string;
		ValidToDate: Date;
		Variance: number;
		VarianceNotes: string;
		Zip: string;
	}
	interface JobNote extends HTC_CRM_DataAccess.Models.BusinessObject {
		JobId: number;
		Note: string;
		UserId: number;
	}
	interface SubContractor extends HTC_CRM_DataAccess.Models.BusinessObject {
		AgreedToTerms: boolean;
		ChargesOvertimeNight: boolean;
		CompanyName: string;
		FullOfficeAddress: string;
		FullShipToAddress: string;
		HasDockDoor: boolean;
		HasOverheadDoor: boolean;
		HasTruck: boolean;
		HasUnion: boolean;
		InstallsCarpet: boolean;
		InstallsCeramic: boolean;
		InstallsResilient: boolean;
		InstallsSelfLeveling: boolean;
		InstallsSheetVinyl: boolean;
		InsuranceCertificateId: number;
		InsuranceExpiration: Date;
		IsDeleted: boolean;
		Notes: string;
		NumCarpetPullerMachines: number;
		NumCrews: number;
		NumRideOnMachines: number;
		NumWalkBehindMachines: number;
		OfficeCity: string;
		OfficeState: string;
		OfficeStreetAddress: string;
		OfficeZip: string;
		Rating: number;
		RecyclesCarpet: boolean;
		ShipToCity: string;
		ShipToState: string;
		ShipToStreetAddress: string;
		ShipToZip: string;
		UserId: number;
	}
	interface SubContractorJob extends HTC_CRM_DataAccess.Models.BusinessObject {
		ActualCost: number;
		DurationInDays: number;
		EndDate: Date;
		EstimatedCost: number;
		IsDeleted: boolean;
		JobId: number;
		StartDate: Date;
		SubContractorId: number;
	}
}


