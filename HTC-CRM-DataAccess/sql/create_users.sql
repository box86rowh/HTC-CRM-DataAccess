USE [HTCCRMPortal]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 12/1/2017 8:54:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[IsSuperUser] [bit] NOT NULL,
	[AffiliateId] [int] NULL,
	[Email] [nvarchar](256) NULL,
	[DisplayName] [nvarchar](128) NOT NULL,
	[UpdatePassword] [bit] NOT NULL,
	[LastIPAddress] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedByUserID] [int] NULL,
	[CreatedOnDate] [datetime] NULL,
	[LastModifiedByUserID] [int] NULL,
	[LastModifiedOnDate] [datetime] NULL,
	[PasswordResetToken] [uniqueidentifier] NULL,
	[PasswordResetExpiration] [datetime] NULL,
	[LowerEmail]  AS (lower([Email])) PERSISTED,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsSuperUser]  DEFAULT ((0)) FOR [IsSuperUser]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_DisplayName]  DEFAULT ('') FOR [DisplayName]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UpdatePassword]  DEFAULT ((0)) FOR [UpdatePassword]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

