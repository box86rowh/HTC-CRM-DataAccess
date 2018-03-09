USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_CustomerContacts]    Script Date: 3/7/2018 7:02:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_CustomerContacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Title] [varchar](50) NULL,
	[Phone] [varchar](13) NOT NULL,
	[Email] [varchar](255) NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_CustomerContacts] ADD  CONSTRAINT [DF_AA_Contacts_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_CustomerContacts] ADD  CONSTRAINT [DF_AA_Contacts_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

ALTER TABLE [dbo].[AA_CustomerContacts] ADD  CONSTRAINT [DF_AA_Contacts_WhenCreated]  DEFAULT (getdate()) FOR [WhenCreated]
GO

ALTER TABLE [dbo].[AA_CustomerContacts]  WITH CHECK ADD  CONSTRAINT [FK_AA_Contacts_AA_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AA_Customers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AA_CustomerContacts] CHECK CONSTRAINT [FK_AA_Contacts_AA_Customers]
GO

