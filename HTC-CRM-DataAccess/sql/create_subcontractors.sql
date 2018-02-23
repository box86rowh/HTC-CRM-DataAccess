USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_SubContractors]    Script Date: 2/18/2018 4:13:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_SubContractors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CompanyName] [varchar](255) NOT NULL,
	[OfficeStreetAddress] [varchar](255) NOT NULL,
	[OfficeCity] [varchar](50) NOT NULL,
	[OfficeState] [varchar](2) NOT NULL,
	[OfficeZip] [varchar](20) NOT NULL,
	[ShipToStreetAddress] [varchar](255) NOT NULL,
	[ShipToCity] [varchar](50) NOT NULL,
	[ShipToState] [varchar](2) NOT NULL,
	[ShipToZip] [varchar](20) NOT NULL,
	[InsuranceCertificateId] [int] NULL,
	[InsuranceExpiration] [date] NULL,
	[HasUnion] [bit] NOT NULL,
	[InstallsCarpet] [bit] NOT NULL,
	[InstallsResilient] [bit] NOT NULL,
	[InstallsSheetVinyl] [bit] NOT NULL,
	[InstallsSelfLeveling] [bit] NOT NULL,
	[InstallsCeramic] [bit] NOT NULL,
	[HasTruck] [bit] NOT NULL,
	[HasDockDoor] [bit] NOT NULL,
	[HasOverheadDoor] [bit] NOT NULL,
	[RecyclesCarpet] [bit] NOT NULL,
	[ChargesOvertimeNight] [bit] NOT NULL,
	[AgreedToTerms] [bit] NOT NULL,
	[NumRideOnMachines] [int] NOT NULL,
	[NumWalkBehindMachines] [int] NOT NULL,
	[NumCarpetPullerMachines] [int] NOT NULL,
	[NumCrews] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[Notes] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_SubContractors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_HasUnion]  DEFAULT ((0)) FOR [HasUnion]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_InstallsCarpet]  DEFAULT ((0)) FOR [InstallsCarpet]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_InstallsResilient]  DEFAULT ((0)) FOR [InstallsResilient]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_InstallsSheetVinyl]  DEFAULT ((0)) FOR [InstallsSheetVinyl]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_InstallsSelfLeveling]  DEFAULT ((0)) FOR [InstallsSelfLeveling]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_InstallsCeramic]  DEFAULT ((0)) FOR [InstallsCeramic]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_HasTruck]  DEFAULT ((0)) FOR [HasTruck]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_HasDockDoor]  DEFAULT ((0)) FOR [HasDockDoor]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_HasOverheadDoor]  DEFAULT ((0)) FOR [HasOverheadDoor]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_RecyclesCarpet]  DEFAULT ((0)) FOR [RecyclesCarpet]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_ChargesOvertimeNight]  DEFAULT ((0)) FOR [ChargesOvertimeNight]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_AgreedToTerms]  DEFAULT ((0)) FOR [AgreedToTerms]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_NumRideOnMachines]  DEFAULT ((0)) FOR [NumRideOnMachines]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_NumWalkBehindMachines]  DEFAULT ((0)) FOR [NumWalkBehindMachines]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_NumCarpetPullerMachines]  DEFAULT ((0)) FOR [NumCarpetPullerMachines]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_NumCrews]  DEFAULT ((0)) FOR [NumCrews]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_Rating]  DEFAULT ((0)) FOR [Rating]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

ALTER TABLE [dbo].[AA_SubContractors] ADD  CONSTRAINT [DF_AA_SubContractors_WhenCreated]  DEFAULT (getdate()) FOR [WhenCreated]
GO

ALTER TABLE [dbo].[AA_SubContractors]  WITH CHECK ADD  CONSTRAINT [FK_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[AA_SubContractors] CHECK CONSTRAINT [FK_Users]
GO

ALTER TABLE [dbo].[AA_SubContractors]  WITH CHECK ADD  CONSTRAINT [CK_Rating] CHECK  (([Rating]=(5) OR [Rating]=(4) OR [Rating]=(3) OR [Rating]=(2) OR [Rating]=(1) OR [Rating]=(0)))
GO

ALTER TABLE [dbo].[AA_SubContractors] CHECK CONSTRAINT [CK_Rating]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Check for valid ratings' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SubContractors', @level2type=N'CONSTRAINT',@level2name=N'CK_Rating'
GO

