IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Beer]') AND type in (N'U'))
	CREATE TABLE [dbo].[Beer](
		[BeerId] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](100) NOT NULL,
		[Description] [nvarchar](4000) NULL,
		[Picture] [nvarchar](4000) NULL,
		[AlcoholPercentageByVolume] [decimal](18, 2) NULL,
		[DrinkBy] [datetime] NOT NULL,
		[IsConsumed] [bit] NOT NULL,
		CONSTRAINT [PK_Beer] PRIMARY KEY CLUSTERED ([BeerId] ASC))
	GO
GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Beer_IsConsumed]') AND type = 'D')
	ALTER TABLE [dbo].[Beer] ADD  CONSTRAINT [DF_Beer_IsConsumed]  DEFAULT ((0)) FOR [IsConsumed]
GO