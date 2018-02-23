USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_SubContractorJobs]    Script Date: 2/18/2018 4:13:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_SubContractorJobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubContractorId] [int] NOT NULL,
	[JobId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[EstimatedCost] [money] NULL,
	[ActualCost] [money] NULL,
	[IsDeleted] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_SubContractorJobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_SubContractorJobs] ADD  CONSTRAINT [DF_AA_SubContractorJobs_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[AA_SubContractorJobs] ADD  CONSTRAINT [DF_AA_SubContractorJobs_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

ALTER TABLE [dbo].[AA_SubContractorJobs] ADD  CONSTRAINT [DF_AA_SubContractorJobs_WhenCreated]  DEFAULT (getdate()) FOR [WhenCreated]
GO

ALTER TABLE [dbo].[AA_SubContractorJobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[AA_Jobs] ([Id])
GO

ALTER TABLE [dbo].[AA_SubContractorJobs] CHECK CONSTRAINT [FK_Jobs]
GO

ALTER TABLE [dbo].[AA_SubContractorJobs]  WITH CHECK ADD  CONSTRAINT [FK_SubContractor] FOREIGN KEY([SubContractorId])
REFERENCES [dbo].[AA_SubContractors] ([Id])
GO

ALTER TABLE [dbo].[AA_SubContractorJobs] CHECK CONSTRAINT [FK_SubContractor]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ensure the JobId matches to a valid job' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SubContractorJobs', @level2type=N'CONSTRAINT',@level2name=N'FK_Jobs'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ensures SubContractorId belongs to a valid SubContractor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AA_SubContractorJobs', @level2type=N'CONSTRAINT',@level2name=N'FK_SubContractor'
GO

