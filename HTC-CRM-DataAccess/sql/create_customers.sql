USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_Customers]    Script Date: 3/7/2018 7:02:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](255) NOT NULL,
	[Phone] [varchar](13) NULL,
	[Fax] [varchar](13) NULL,
	[EmailAddress] [varchar](255) NULL,
	[PhysicalAddressId] [int] NULL,
	[MailingAddressId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
	[ValidToDate] [datetime] NOT NULL,
	[MasterId] [int] NOT NULL,
 CONSTRAINT [PK_AA_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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

ALTER TABLE [dbo].[AA_Customers]  WITH CHECK ADD  CONSTRAINT [FK_AA_Customers_AA_Addresses] FOREIGN KEY([MailingAddressId])
REFERENCES [dbo].[AA_Addresses] ([Id])
GO

ALTER TABLE [dbo].[AA_Customers] CHECK CONSTRAINT [FK_AA_Customers_AA_Addresses]
GO

ALTER TABLE [dbo].[AA_Customers]  WITH CHECK ADD  CONSTRAINT [FK_AA_Customers_AA_Addresses2] FOREIGN KEY([PhysicalAddressId])
REFERENCES [dbo].[AA_Addresses] ([Id])
GO

ALTER TABLE [dbo].[AA_Customers] CHECK CONSTRAINT [FK_AA_Customers_AA_Addresses2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'foreign key to user table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_Customers'
GO

