USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_CustomerUsers]    Script Date: 3/7/2018 7:03:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_CustomerUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
	[LastModified] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_CustomerUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_CustomerUsers]  WITH CHECK ADD  CONSTRAINT [FK_AA_CustomerUsers_AA_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AA_Customers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AA_CustomerUsers] CHECK CONSTRAINT [FK_AA_CustomerUsers_AA_Customers]
GO

ALTER TABLE [dbo].[AA_CustomerUsers]  WITH CHECK ADD  CONSTRAINT [FK_AA_CustomerUsers_AA_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AA_CustomerUsers] CHECK CONSTRAINT [FK_AA_CustomerUsers_AA_Users]
GO

