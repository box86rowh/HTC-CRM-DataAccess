USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_Contacts]    Script Date: 2/18/2018 4:11:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustId] [int] NOT NULL,
	[ContactName] [varchar](255) NOT NULL,
	[ContactTitle] [varchar](50) NULL,
	[ContactPhone] [varchar](13) NOT NULL,
	[ContactEmail] [varchar](255) NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_Contacts] ADD  CONSTRAINT [DF_AA_Contacts_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_Contacts] ADD  CONSTRAINT [DF_AA_Contacts_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

ALTER TABLE [dbo].[AA_Contacts] ADD  CONSTRAINT [DF_AA_Contacts_WhenCreated]  DEFAULT (getdate()) FOR [WhenCreated]
GO

