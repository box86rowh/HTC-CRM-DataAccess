use HTCCRMPortal
select *
from dbo.AA_Customers;

select *
from dbo.AA_Contacts;

select *
from dbo.AA_Customers cu
left join dbo.AA_Contacts co on co.CustId = cu.Id;

select *
from dbo.AA_Jobs;

/*insert test users for integration testing*/
insert into dbo.Users
(
	Username,
	FirstName,
	LastName,
	IsSuperUser,
	AffiliateId,
	Email,
	DisplayName,
	UpdatePassword,
	LastIPAddress,
	IsDeleted,
	CreatedByUserID,
	CreatedOnDate,
	LastModifiedByUserID,
	LastModifiedOnDate,
	PasswordResetToken,
	PasswordResetExpiration
)
values
(
	'TestUser',
	'John',
	'Smith',
	0,
	null,
	'johnsmith@domain.com',
	'John Smith',
	0,
	null,
	0,
	null,
	CURRENT_TIMESTAMP,
	null,
	CURRENT_TIMESTAMP,
	null,
	null

);

insert into dbo.Users
(
	Username,
	FirstName,
	LastName,
	IsSuperUser,
	AffiliateId,
	Email,
	DisplayName,
	UpdatePassword,
	LastIPAddress,
	IsDeleted,
	CreatedByUserID,
	CreatedOnDate,
	LastModifiedByUserID,
	LastModifiedOnDate,
	PasswordResetToken,
	PasswordResetExpiration
)
values
(
	'TestAM',
	'Moe',
	'Howard',
	0,
	null,
	'moehoward@domain.com',
	'Moe Howard',
	0,
	null,
	0,
	null,
	CURRENT_TIMESTAMP,
	null,
	CURRENT_TIMESTAMP,
	null,
	null

);

select *
from dbo.Users;


select *
from dbo.AA_SubContractors;

delete from dbo.AA_SubContractors;

select *
from dbo.AA_SubContractorJobs;

select *
from dbo.AA_SubContractorJobs scj
inner join dbo.AA_Jobs j on j.Id = scj.JobId
inner join dbo.AA_SubContractors s on s.Id = scj.SubContractorId;