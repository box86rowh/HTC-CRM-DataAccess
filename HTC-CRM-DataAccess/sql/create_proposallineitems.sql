USE [DNNDev]
GO

/****** Object:  Table [dbo].[AA_ProposalLineItems]    Script Date: 3/7/2018 7:04:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AA_ProposalLineItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProposalId] [int] NOT NULL,
	[Content] [varchar](max) NOT NULL,
 CONSTRAINT [PK_AA_ProposalLineItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AA_ProposalLineItems]  WITH CHECK ADD  CONSTRAINT [FK_AA_ProposalLineItem_AA_Proposals] FOREIGN KEY([ProposalId])
REFERENCES [dbo].[AA_Proposals] ([Id])
GO

ALTER TABLE [dbo].[AA_ProposalLineItems] CHECK CONSTRAINT [FK_AA_ProposalLineItem_AA_Proposals]
GO

