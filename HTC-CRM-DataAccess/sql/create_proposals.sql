USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_Proposals]    Script Date: 3/7/2018 7:04:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_Proposals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ProjectName] [varchar](255) NOT NULL,
	[AddressId] [int] NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AA_Proposals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_Proposals]  WITH CHECK ADD  CONSTRAINT [FK_AA_Proposals_AA_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[AA_Addresses] ([Id])
GO

ALTER TABLE [dbo].[AA_Proposals] CHECK CONSTRAINT [FK_AA_Proposals_AA_Addresses]
GO

ALTER TABLE [dbo].[AA_Proposals]  WITH CHECK ADD  CONSTRAINT [FK_AA_Proposals_AA_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AA_Customers] ([Id])
GO

ALTER TABLE [dbo].[AA_Proposals] CHECK CONSTRAINT [FK_AA_Proposals_AA_Customers]
GO

