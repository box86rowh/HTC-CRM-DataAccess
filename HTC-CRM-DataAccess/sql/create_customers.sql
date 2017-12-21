USE [HTCCRMPortal]
GO

/****** Object:  Table [dbo].[AA_Customers]    Script Date: 12/20/2017 6:05:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CustName] [varchar](255) NOT NULL,
	[OfficePhone] [varchar](13) NULL,
	[OfficeFax] [varchar](13) NULL,
	[OfficeStreetAddress] [varchar](255) NULL,
	[OfficeCity] [varchar](255) NULL,
	[OfficeState] [varchar](2) NULL,
	[OfficeZip] [varchar](20) NULL,
	[ShipToStreetAddress] [varchar](255) NULL,
	[ShipToCity] [varchar](255) NULL,
	[ShipToState] [varchar](2) NULL,
	[ShipToZip] [varchar](20) NULL,
	[Notes] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
	[ValidToDate] [datetime] NOT NULL,
	[MasterId] [int] NOT NULL,
 CONSTRAINT [PK_AA_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_Customers] ADD  CONSTRAINT [DF_AA_Customers_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_Customers] ADD  CONSTRAINT [DF_AA_Customers_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

ALTER TABLE [dbo].[AA_Customers] ADD  CONSTRAINT [DF_AA_Customers_WhenCreated]  DEFAULT (getdate()) FOR [WhenCreated]
GO

ALTER TABLE [dbo].[AA_Customers] ADD  CONSTRAINT [DF_AA_Customers_ValidToDate]  DEFAULT ('9999-12-31') FOR [ValidToDate]
GO

ALTER TABLE [dbo].[AA_Customers] ADD  CONSTRAINT [DF_AA_Customers_MasterId]  DEFAULT ((0)) FOR [MasterId]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'foreign key to user table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_Customers'
GO

