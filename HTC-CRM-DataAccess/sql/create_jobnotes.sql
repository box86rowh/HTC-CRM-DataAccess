USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_JobNotes]    Script Date: 2/18/2018 4:12:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_JobNotes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Note] [varchar](max) NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[WhenCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_AA_JobNotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_JobNotes] ADD  CONSTRAINT [DF_AA_JobNotes_LastModified]  DEFAULT (getdate()) FOR [LastModified]
GO

ALTER TABLE [dbo].[AA_JobNotes] ADD  CONSTRAINT [DF_AA_JobNotes_WhenCreated]  DEFAULT (getdate()) FOR [WhenCreated]
GO

ALTER TABLE [dbo].[AA_JobNotes]  WITH CHECK ADD  CONSTRAINT [FK_JobNotes_Jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[AA_Jobs] ([Id])
GO

ALTER TABLE [dbo].[AA_JobNotes] CHECK CONSTRAINT [FK_JobNotes_Jobs]
GO

ALTER TABLE [dbo].[AA_JobNotes]  WITH CHECK ADD  CONSTRAINT [FK_JobNotes_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[AA_JobNotes] CHECK CONSTRAINT [FK_JobNotes_Users]
GO

