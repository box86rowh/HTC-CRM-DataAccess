USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_Jobs]    Script Date: 2/18/2018 4:12:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_Jobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[StartDate] [date] NOT NULL,
	[CompletionDate] [date] NULL,
	[ProjectManagerId] [int] NOT NULL,
	[AccountManagerId] [int] NOT NULL,
	[EstimatedCost] [decimal](19, 4) NULL,
	[EstimationNotes] [varchar](max) NULL,
	[POCost] [decimal](19, 4) NOT NULL,
	[POStatus] [varchar](50) NOT NULL,
	[Variance] [decimal](19, 4) NULL,
	[VarianceNotes] [varchar](max) NULL,
	[StreetAddress] [varchar](255) NOT NULL,
	[City] [varchar](255) NOT NULL,
	[State] [varchar](2) NOT NULL,
	[Zip] [varchar](20) NOT NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
	[ValidToDate] [datetime] NOT NULL,
	[MasterId] [int] NOT NULL,
 CONSTRAINT [PK_AA_Jobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_Jobs] ADD  CONSTRAINT [DF_AA_Jobs_CompletionDate]  DEFAULT ('9999-12-31') FOR [CompletionDate]
GO

ALTER TABLE [dbo].[AA_Jobs] ADD  CONSTRAINT [DF_AA_Jobs_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_Jobs] ADD  CONSTRAINT [DF_AA_Jobs_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

ALTER TABLE [dbo].[AA_Jobs] ADD  CONSTRAINT [DF_AA_Jobs_WhenCreated]  DEFAULT (getdate()) FOR [WhenCreated]
GO

ALTER TABLE [dbo].[AA_Jobs] ADD  CONSTRAINT [DF_AA_Jobs_ValidToDate]  DEFAULT ('9999-12-31') FOR [ValidToDate]
GO

ALTER TABLE [dbo].[AA_Jobs] ADD  CONSTRAINT [DF_AA_Jobs_MasterId]  DEFAULT ((0)) FOR [MasterId]
GO

ALTER TABLE [dbo].[AA_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_AccountManager] FOREIGN KEY([AccountManagerId])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[AA_Jobs] CHECK CONSTRAINT [FK_AccountManager]
GO

ALTER TABLE [dbo].[AA_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[AA_Customers] ([Id])
GO

ALTER TABLE [dbo].[AA_Jobs] CHECK CONSTRAINT [FK_Customers]
GO

ALTER TABLE [dbo].[AA_Jobs]  WITH CHECK ADD  CONSTRAINT [FK_ProjectManager] FOREIGN KEY([ProjectManagerId])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[AA_Jobs] CHECK CONSTRAINT [FK_ProjectManager]
GO

ALTER TABLE [dbo].[AA_Jobs]  WITH CHECK ADD  CONSTRAINT [CK_POStatus] CHECK  (([POStatus]='Paid in Full' OR [POStatus]='Partially Paid' OR [POStatus]='Not Paid'))
GO

ALTER TABLE [dbo].[AA_Jobs] CHECK CONSTRAINT [CK_POStatus]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ensures the account manager is a valid user' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_Jobs', @level2type=N'CONSTRAINT',@level2name=N'FK_AccountManager'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Foreign key to Customers table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_Jobs', @level2type=N'CONSTRAINT',@level2name=N'FK_Customers'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ensures project manager is a valid user' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_Jobs', @level2type=N'CONSTRAINT',@level2name=N'FK_ProjectManager'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Limits the POStatus field to valid values' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_Jobs', @level2type=N'CONSTRAINT',@level2name=N'CK_POStatus'
GO

