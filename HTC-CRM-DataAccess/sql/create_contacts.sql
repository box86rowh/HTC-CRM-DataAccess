USE [HTCCRMPortal]
GO

/****** Object:  Table [dbo].[AA_Contacts]    Script Date: 12/1/2017 8:53:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AA_Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustId] [int] NOT NULL,
	[ContactName] [varchar](255) NOT NULL,
	[ContactTitle] [varchar](50) NULL,
	[ContactPhone] [varchar](13) NOT NULL,
	[ContactEmail] [varchar](255) NULL,
	[IsDeleted] [bit] NOT NULL CONSTRAINT [DF_AA_Contacts_IsDeleted]  DEFAULT ((0)),
 CONSTRAINT [PK_AA_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AA_Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Customer] FOREIGN KEY([CustId])
REFERENCES [dbo].[AA_Customers] ([Id])
GO

ALTER TABLE [dbo].[AA_Contacts] CHECK CONSTRAINT [FK_Customer]
GO

