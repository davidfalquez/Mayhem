USE [Mayhem]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Incident_Dispatcher_DispatcherId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Incident]'))
ALTER TABLE [dbo].[Incident] DROP CONSTRAINT [FK_Incident_Dispatcher_DispatcherId]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Incident_PrimaryIncident_PrimaryIncidentId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Incident]'))
ALTER TABLE [dbo].[Incident] DROP CONSTRAINT [FK_Incident_PrimaryIncident_PrimaryIncidentId]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Incident_SecondaryIncident_SecondaryIncidentId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Incident]'))
ALTER TABLE [dbo].[Incident] DROP CONSTRAINT [FK_Incident_SecondaryIncident_SecondaryIncidentId]
GO

USE [Mayhem]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SecondaryIncident_Channel_ChannelId]') AND parent_object_id = OBJECT_ID(N'[dbo].[SecondaryIncident]'))
ALTER TABLE [dbo].[SecondaryIncident] DROP CONSTRAINT [FK_SecondaryIncident_Channel_ChannelId]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SecondaryIncident_DispatcherId]') AND parent_object_id = OBJECT_ID(N'[dbo].[SecondaryIncident]'))
ALTER TABLE [dbo].[SecondaryIncident] DROP CONSTRAINT [FK_SecondaryIncident_DispatcherId]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SecondaryIncident_Shift_ShiftId]') AND parent_object_id = OBJECT_ID(N'[dbo].[SecondaryIncident]'))
ALTER TABLE [dbo].[SecondaryIncident] DROP CONSTRAINT [FK_SecondaryIncident_Shift_ShiftId]
GO

USE [Mayhem]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PrimaryIncident_Channel_ChannelId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PrimaryIncident]'))
ALTER TABLE [dbo].[PrimaryIncident] DROP CONSTRAINT [FK_PrimaryIncident_Channel_ChannelId]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PrimaryIncident_Dispatcher_DispatcherId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PrimaryIncident]'))
ALTER TABLE [dbo].[PrimaryIncident] DROP CONSTRAINT [FK_PrimaryIncident_Dispatcher_DispatcherId]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PrimaryIncident_Shift_ShiftId]') AND parent_object_id = OBJECT_ID(N'[dbo].[PrimaryIncident]'))
ALTER TABLE [dbo].[PrimaryIncident] DROP CONSTRAINT [FK_PrimaryIncident_Shift_ShiftId]
GO

USE [Mayhem]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Dispatcher_DispatcherId]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_Dispatcher_DispatcherId]
GO

USE [Mayhem]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Dispatcher_RoleType_RoleTypeId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Dispatcher]'))
ALTER TABLE [dbo].[Dispatcher] DROP CONSTRAINT [FK_Dispatcher_RoleType_RoleTypeId]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[RoleType]    Script Date: 02/21/2012 12:53:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleType]') AND type in (N'U'))
DROP TABLE [dbo].[RoleType]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[RoleType]    Script Date: 02/21/2012 12:53:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RoleType](
	[RoleTypeId] [int] IDENTITY(1,1) NOT NULL,
	[RoleDescription] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoleType] PRIMARY KEY CLUSTERED 
(
	[RoleTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO [Mayhem].[dbo].[RoleType]
           ([RoleDescription])
     VALUES
           ('Administrator')
GO

INSERT INTO [Mayhem].[dbo].[RoleType]
           ([RoleDescription])
     VALUES
           ('Evaluator')
GO

INSERT INTO [Mayhem].[dbo].[RoleType]
           ([RoleDescription])
     VALUES
           ('Dispatcher')
GO

INSERT INTO [Mayhem].[dbo].[RoleType]
           ([RoleDescription])
     VALUES
           ('Developer')
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[Dispatcher]    Script Date: 02/21/2012 12:58:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dispatcher]') AND type in (N'U'))
DROP TABLE [dbo].[Dispatcher]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[Dispatcher]    Script Date: 02/21/2012 12:58:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Dispatcher](
	[DispatcherId] [varchar](100) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[RoleTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Dispatcher] PRIMARY KEY CLUSTERED 
(
	[DispatcherId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Dispatcher]  WITH CHECK ADD  CONSTRAINT [FK_Dispatcher_RoleType_RoleTypeId] FOREIGN KEY([RoleTypeId])
REFERENCES [dbo].[RoleType] ([RoleTypeId])
GO

ALTER TABLE [dbo].[Dispatcher] CHECK CONSTRAINT [FK_Dispatcher_RoleType_RoleTypeId]
GO

INSERT INTO [Mayhem].[dbo].[Dispatcher]
           ([DispatcherId]
           ,[FirstName]
           ,[LastName]
           ,[RoleTypeId])
     VALUES
           ('PIRAS_DEVELOPER'
           ,'PIRAS DEV'
           ,'DEVELOPER'
           ,4)
GO




USE [Mayhem]
GO

/****** Object:  Table [dbo].[User]    Script Date: 02/21/2012 13:08:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[User]    Script Date: 02/21/2012 13:08:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ValidUser] [bit] NOT NULL,
	[DispatcherId] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Dispatcher_DispatcherId] FOREIGN KEY([DispatcherId])
REFERENCES [dbo].[Dispatcher] ([DispatcherId])
GO

ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Dispatcher_DispatcherId]
GO

INSERT INTO [Mayhem].[dbo].[User]
           ([Username]
           ,[Password]
           ,[ValidUser]
           ,[DispatcherId])
     VALUES
           ('PirasDev'
           ,'PirasDev'
           ,1
           ,'PIRAS_DEVELOPER')
GO



USE [Mayhem]
GO

/****** Object:  Table [dbo].[Shift]    Script Date: 02/21/2012 13:13:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shift]') AND type in (N'U'))
DROP TABLE [dbo].[Shift]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[Shift]    Script Date: 02/21/2012 13:13:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Shift](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[ShiftName] [varchar](100) NOT NULL,
	[ShiftAbbreviation] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[Channel]    Script Date: 02/21/2012 13:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel]') AND type in (N'U'))
DROP TABLE [dbo].[Channel]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[Channel]    Script Date: 02/21/2012 13:23:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Channel](
	[ChannelId] [int] IDENTITY(1,1) NOT NULL,
	[ChannelName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Channel] PRIMARY KEY CLUSTERED 
(
	[ChannelId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

INSERT INTO [Mayhem].[dbo].[Channel]
           ([ChannelName])
     VALUES
           ('Channel A')
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[PrimaryIncident]    Script Date: 02/21/2012 13:45:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncident]') AND type in (N'U'))
DROP TABLE [dbo].[PrimaryIncident]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[PrimaryIncident]    Script Date: 02/21/2012 13:45:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PrimaryIncident](
	[PrimaryIncidentId] uniqueidentifier NOT NULL,
	[ChannelId] [int] NOT NULL,
	[DispatcherId] [varchar](100) NOT NULL,
	[ShiftId] [int] NOT NULL,
	[DateTime] [datetime] NULL,
	[ToneAlertUsed] [bit] NULL,
	[Priority] [bit] NULL,
	[Sunstar3DigitNumber] [bit] NULL,
	[Location] [bit] NULL,
	[MapGrid] [bit] NULL,
	[NatureOfCall] [bit] NULL,
	[SSTacChannel] [bit] NULL,
	[PertinentIntRouting] [bit] NULL,
	[InfoGivenOutOfOrder] [bit] NULL,
	[DisplayedServiceAttitude] [varchar](50) NULL,
	[UsedCorrectVolumeTone] [varchar](50) NULL,
	[UsedProhibitedBehavior] [bit] NULL,
 CONSTRAINT [PK_PrimaryIncident] PRIMARY KEY CLUSTERED 
(
	[PrimaryIncidentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PrimaryIncident]  WITH CHECK ADD  CONSTRAINT [FK_PrimaryIncident_Channel_ChannelId] FOREIGN KEY([ChannelId])
REFERENCES [dbo].[Channel] ([ChannelId])
GO

ALTER TABLE [dbo].[PrimaryIncident] CHECK CONSTRAINT [FK_PrimaryIncident_Channel_ChannelId]
GO

ALTER TABLE [dbo].[PrimaryIncident]  WITH CHECK ADD  CONSTRAINT [FK_PrimaryIncident_Dispatcher_DispatcherId] FOREIGN KEY([DispatcherId])
REFERENCES [dbo].[Dispatcher] ([DispatcherId])
GO

ALTER TABLE [dbo].[PrimaryIncident] CHECK CONSTRAINT [FK_PrimaryIncident_Dispatcher_DispatcherId]
GO

ALTER TABLE [dbo].[PrimaryIncident]  WITH CHECK ADD  CONSTRAINT [FK_PrimaryIncident_Shift_ShiftId] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([ShiftId])
GO

ALTER TABLE [dbo].[PrimaryIncident] CHECK CONSTRAINT [FK_PrimaryIncident_Shift_ShiftId]
GO



USE [Mayhem]
GO

/****** Object:  Table [dbo].[SecondaryIncident]    Script Date: 02/21/2012 14:06:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecondaryIncident]') AND type in (N'U'))
DROP TABLE [dbo].[SecondaryIncident]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[SecondaryIncident]    Script Date: 02/21/2012 14:06:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SecondaryIncident](
	[SecondaryIncidentId] uniqueidentifier NOT NULL,
	[ChannelId] [int] NOT NULL,
	[DispatcherId] [varchar](100) NOT NULL,
	[ShiftId] [int] NOT NULL,
	[DateTime] [datetime] NULL,
	[Sunstar3DigitNumber] [bit] NULL,
	[NatureOfCall] [bit] NULL,
	[Location] [bit] NULL,
	[MapGrid] [bit] NULL,
	[FDUnitsAndTacCh] [bit] NULL,
	[ScriptingDocumented] [bit] NULL,
	[SevenMin] [bit] NULL,
	[TwelveMin] [bit] NULL,
	[ETALocationAsked] [bit] NULL,
	[ETADocumented] [bit] NULL,
	[ProactiveRoutingGiven] [varchar](50) NULL,
	[CorrectRouting] [varchar](50) NULL,
	[RoutingDocumented] [bit] NULL,
	[PreArrivalGiven] [bit] NULL,
	[EMDDocumented] [bit] NULL,
	[DisplayedServiceAttitude] [varchar](50) NULL,
	[UsedCorrectVolumeTone] [varchar](50) NULL,
	[UsedProhibitedBehavior] [bit] NULL,
	[PatchedChannels] [bit] NULL,
	[Phone] [bit] NULL,
 CONSTRAINT [PK_SecondaryIncident] PRIMARY KEY CLUSTERED 
(
	[SecondaryIncidentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SecondaryIncident]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryIncident_Channel_ChannelId] FOREIGN KEY([ChannelId])
REFERENCES [dbo].[Channel] ([ChannelId])
GO

ALTER TABLE [dbo].[SecondaryIncident] CHECK CONSTRAINT [FK_SecondaryIncident_Channel_ChannelId]
GO

ALTER TABLE [dbo].[SecondaryIncident]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryIncident_DispatcherId] FOREIGN KEY([DispatcherId])
REFERENCES [dbo].[Dispatcher] ([DispatcherId])
GO

ALTER TABLE [dbo].[SecondaryIncident] CHECK CONSTRAINT [FK_SecondaryIncident_DispatcherId]
GO

ALTER TABLE [dbo].[SecondaryIncident]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryIncident_Shift_ShiftId] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shift] ([ShiftId])
GO

ALTER TABLE [dbo].[SecondaryIncident] CHECK CONSTRAINT [FK_SecondaryIncident_Shift_ShiftId]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[Incident]    Script Date: 02/21/2012 14:16:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incident]') AND type in (N'U'))
DROP TABLE [dbo].[Incident]
GO

USE [Mayhem]
GO

/****** Object:  Table [dbo].[Incident]    Script Date: 02/21/2012 14:16:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Incident](
	[IncidentId] [varchar](50) NOT NULL,
	[PrimaryIncidentId] uniqueidentifier NULL,
	[SecondaryIncidentId] uniqueidentifier NULL,
	[EvaluatorId] [varchar](100) NOT NULL,
	[EntryDate] [datetime] NULL,
	[LastUpdated] [datetime] NULL,
	[PrimaryIncidentScore] [int] NULL,
	[PrimaryIncidentScorePercent] [float] NULL,
	[SecondaryIncidentScore] [int] NULL,
	[SecondaryIncidentScorePercent] [float] NULL,
 CONSTRAINT [PK_Incident] PRIMARY KEY CLUSTERED 
(
	[IncidentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Incident]  WITH CHECK ADD  CONSTRAINT [FK_Incident_Dispatcher_DispatcherId] FOREIGN KEY([EvaluatorId])
REFERENCES [dbo].[Dispatcher] ([DispatcherId])
GO

ALTER TABLE [dbo].[Incident] CHECK CONSTRAINT [FK_Incident_Dispatcher_DispatcherId]
GO

ALTER TABLE [dbo].[Incident]  WITH CHECK ADD  CONSTRAINT [FK_Incident_PrimaryIncident_PrimaryIncidentId] FOREIGN KEY([PrimaryIncidentId])
REFERENCES [dbo].[PrimaryIncident] ([PrimaryIncidentId])
GO

ALTER TABLE [dbo].[Incident] CHECK CONSTRAINT [FK_Incident_PrimaryIncident_PrimaryIncidentId]
GO

ALTER TABLE [dbo].[Incident]  WITH CHECK ADD  CONSTRAINT [FK_Incident_SecondaryIncident_SecondaryIncidentId] FOREIGN KEY([SecondaryIncidentId])
REFERENCES [dbo].[SecondaryIncident] ([SecondaryIncidentId])
GO

ALTER TABLE [dbo].[Incident] CHECK CONSTRAINT [FK_Incident_SecondaryIncident_SecondaryIncidentId]
GO



----------------------------------------------------- Stored Procedures -------------------------------------------------

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[DispatcherInsert]    Script Date: 02/21/2012 15:18:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dispatcher_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Dispatcher_Insert]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[DispatcherInsert]    Script Date: 02/21/2012 15:18:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Dispatcher_Insert] 
	(
			@DispatcherId varchar(100)
           ,@FirstName varchar(100)
           ,@LastName varchar(100)
           ,@RoleTypeId int
     )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [Mayhem].[dbo].[Dispatcher]
           ([DispatcherId]
           ,[FirstName]
           ,[LastName]
           ,[RoleTypeId])
     VALUES
           (@DispatcherId
           ,@FirstName
           ,@LastName
           ,@RoleTypeId)
END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Dispatcher_SelectAll]    Script Date: 02/21/2012 15:20:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dispatcher_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Dispatcher_SelectAll]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Dispatcher_SelectAll]    Script Date: 02/21/2012 15:20:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Dispatcher_SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [DispatcherId]
      ,[FirstName]
      ,[LastName]
      ,[RoleTypeId]
  FROM [Mayhem].[dbo].[Dispatcher]
  WHERE RoleTypeId <> 4


END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[DispatcherSelectById]    Script Date: 02/21/2012 15:24:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dispatcher_SelectById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Dispatcher_SelectById]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[DispatcherSelectById]    Script Date: 02/21/2012 15:24:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Dispatcher_SelectById]
	(
		@DispatcherId varchar(100)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT [DispatcherId]
      ,[FirstName]
      ,[LastName]
      ,[RoleTypeId]
  FROM [Mayhem].[dbo].[Dispatcher]
  WHERE [DispatcherId] = @DispatcherId


END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Dispatcher_Update]    Script Date: 02/21/2012 15:27:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dispatcher_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Dispatcher_Update]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Dispatcher_Update]    Script Date: 02/21/2012 15:27:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Dispatcher_Update] 
	(
	   @DispatcherId varchar(100)
      ,@FirstName varchar(100)
      ,@LastName varchar(100)
      ,@RoleTypeId int
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [Mayhem].[dbo].[Dispatcher]
   SET [DispatcherId] = @DispatcherId
      ,[FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[RoleTypeId] = @RoleTypeId
 WHERE [DispatcherId] = @DispatcherId


END

GO


USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Dispatcher_Delete]    Script Date: 02/21/2012 15:32:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dispatcher_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Dispatcher_Delete]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Dispatcher_Delete]    Script Date: 02/21/2012 15:32:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Dispatcher_Delete]
	(
		@DispatcherId varchar(100)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [Mayhem].[dbo].[Dispatcher]
      WHERE [DispatcherId] = @DispatcherId


END

GO


USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[RoleType_SelectAll]    Script Date: 02/21/2012 15:33:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleType_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RoleType_SelectAll]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[RoleType_SelectAll]    Script Date: 02/21/2012 15:33:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RoleType_SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [RoleTypeId]
      ,[RoleDescription]
  FROM [Mayhem].[dbo].[RoleType]

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_SelectAll]    Script Date: 02/21/2012 15:35:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shift_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Shift_SelectAll]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_SelectAll]    Script Date: 02/21/2012 15:35:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shift_SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ShiftId]
      ,[ShiftName]
      ,[ShiftAbbreviation]
  FROM [Mayhem].[dbo].[Shift]
END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_SelectById]    Script Date: 02/24/2012 22:58:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shift_SelectById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Shift_SelectById]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_SelectById]    Script Date: 02/24/2012 22:58:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shift_SelectById]
(
	@ShiftId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ShiftId]
      ,[ShiftName]
      ,[ShiftAbbreviation]
  FROM [Mayhem].[dbo].[Shift]
  WHERE [ShiftId] = @ShiftId
END


GO



USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_Update]    Script Date: 02/21/2012 15:38:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shift_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Shift_Update]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_Update]    Script Date: 02/21/2012 15:38:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shift_Update]
(
	   @ShiftId int
	  ,@ShiftName varchar(100)
      ,@ShiftAbbreviation varchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [Mayhem].[dbo].[Shift]
   SET [ShiftName] = @ShiftName
      ,[ShiftAbbreviation] = @ShiftAbbreviation
 WHERE [ShiftId] = @ShiftId

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_Delete]    Script Date: 02/21/2012 15:40:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shift_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Shift_Delete]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_Delete]    Script Date: 02/21/2012 15:40:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shift_Delete]
(
	@ShiftId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM [Mayhem].[dbo].[Shift]
      WHERE [ShiftId] = @ShiftId

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_Insert]    Script Date: 02/21/2012 15:42:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shift_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Shift_Insert]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Shift_Insert]    Script Date: 02/21/2012 15:42:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Shift_Insert]
	(
		    @ShiftName varchar(100)
           ,@ShiftAbbreviation varchar(100)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [Mayhem].[dbo].[Shift]
           ([ShiftName]
           ,[ShiftAbbreviation])
     VALUES
           (@ShiftName
           ,@ShiftAbbreviation)

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_SelectAll]    Script Date: 02/21/2012 15:43:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Channel_SelectAll]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_SelectAll]    Script Date: 02/21/2012 15:43:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Channel_SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [ChannelId]
      ,[ChannelName]
  FROM [Mayhem].[dbo].[Channel]

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_SelectById]    Script Date: 02/24/2012 20:52:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel_SelectById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Channel_SelectById]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_SelectById]    Script Date: 02/24/2012 20:52:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Channel_SelectById]
(
	@ChannelId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [ChannelId]
      ,[ChannelName]
  FROM [Mayhem].[dbo].[Channel]
  WHERE [ChannelId] = @ChannelId
  

END


GO



USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_Update]    Script Date: 02/21/2012 15:46:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Channel_Update]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_Update]    Script Date: 02/21/2012 15:46:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Channel_Update]
(
	@ChannelId int
	,@ChannelName varchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [Mayhem].[dbo].[Channel]
    SET [ChannelName] = @ChannelName
    WHERE [ChannelId] = @ChannelId


END

GO


USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_Delete]    Script Date: 02/21/2012 15:48:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Channel_Delete]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_Delete]    Script Date: 02/21/2012 15:48:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Channel_Delete]
(
	@ChannelId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DELETE FROM [Mayhem].[dbo].[Channel]
      WHERE [ChannelId] = @ChannelId


END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_Insert]    Script Date: 02/21/2012 15:50:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Channel_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Channel_Insert]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Channel_Insert]    Script Date: 02/21/2012 15:50:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Channel_Insert]
(
	@ChannelName varchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [Mayhem].[dbo].[Channel]
           ([ChannelName])
     VALUES
           (@ChannelName)

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_Insert]    Script Date: 02/21/2012 15:54:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncident_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrimaryIncident_Insert]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_Insert]    Script Date: 02/21/2012 15:54:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrimaryIncident_Insert]
 (		
            @PrimaryIncidentId uniqueidentifier
           ,@ChannelId int
           ,@DispatcherId varchar(100)
           ,@ShiftId int
           ,@DateTime datetime
           ,@ToneAlertUsed bit
           ,@Priority bit
           ,@Sunstar3DigitNumber bit
           ,@Location bit
           ,@MapGrid bit
           ,@NatureOfCall bit
           ,@SSTacChannel bit
           ,@PertinentIntRouting bit
           ,@InfoGivenOutOfOrder bit
           ,@DisplayedServiceAttitude varchar(50)
           ,@UsedCorrectVolumeTone varchar(50)
           ,@UsedProhibitedBehavior bit)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [Mayhem].[dbo].[PrimaryIncident]
           ([PrimaryIncidentId]
		   ,[ChannelId]
           ,[DispatcherId]
           ,[ShiftId]
           ,[DateTime]
           ,[ToneAlertUsed]
           ,[Priority]
           ,[Sunstar3DigitNumber]
           ,[Location]
           ,[MapGrid]
           ,[NatureOfCall]
           ,[SSTacChannel]
           ,[PertinentIntRouting]
           ,[InfoGivenOutOfOrder]
           ,[DisplayedServiceAttitude]
           ,[UsedCorrectVolumeTone]
           ,[UsedProhibitedBehavior])
     VALUES
           (
		    @PrimaryIncidentId
		   ,@ChannelId
           ,@DispatcherId
           ,@ShiftId
           ,@DateTime
           ,@ToneAlertUsed
           ,@Priority
           ,@Sunstar3DigitNumber
           ,@Location
           ,@MapGrid
           ,@NatureOfCall
           ,@SSTacChannel
           ,@PertinentIntRouting
           ,@InfoGivenOutOfOrder
           ,@DisplayedServiceAttitude
           ,@UsedCorrectVolumeTone
           ,@UsedProhibitedBehavior)


END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_Update]    Script Date: 02/21/2012 15:58:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncident_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrimaryIncident_Update]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_Update]    Script Date: 02/21/2012 15:58:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrimaryIncident_Update]
 (		   
            @PrimaryIncidentId uniqueidentifier
           ,@ChannelId int
           ,@DispatcherId varchar(100)
           ,@ShiftId int
           ,@DateTime datetime
           ,@ToneAlertUsed bit
           ,@Priority bit
           ,@Sunstar3DigitNumber bit
           ,@Location bit
           ,@MapGrid bit
           ,@NatureOfCall bit
           ,@SSTacChannel bit
           ,@PertinentIntRouting bit
           ,@InfoGivenOutOfOrder bit
           ,@DisplayedServiceAttitude varchar(50)
           ,@UsedCorrectVolumeTone varchar(50)
           ,@UsedProhibitedBehavior bit)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [Mayhem].[dbo].[PrimaryIncident]
   SET [ChannelId] = @ChannelId
      ,[DispatcherId] = @DispatcherId
      ,[ShiftId] = @ShiftId
      ,[DateTime] = @DateTime
      ,[ToneAlertUsed] = @ToneAlertUsed
      ,[Priority] = @Priority
      ,[Sunstar3DigitNumber] = @Sunstar3DigitNumber
      ,[Location] = @Location
      ,[MapGrid] = @MapGrid
      ,[NatureOfCall] = @NatureOfCall
      ,[SSTacChannel] = @SSTacChannel
      ,[PertinentIntRouting] = @PertinentIntRouting
      ,[InfoGivenOutOfOrder] = @InfoGivenOutOfOrder
      ,[DisplayedServiceAttitude] = @DisplayedServiceAttitude
      ,[UsedCorrectVolumeTone] = @UsedCorrectVolumeTone
      ,[UsedProhibitedBehavior] = @UsedProhibitedBehavior
 WHERE [PrimaryIncidentId] = @PrimaryIncidentId



END


GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_Delete]    Script Date: 02/21/2012 16:00:00 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncident_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrimaryIncident_Delete]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_Delete]    Script Date: 02/21/2012 16:00:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrimaryIncident_Delete]
(
	@PrimaryIncidentId uniqueidentifier
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [Mayhem].[dbo].[PrimaryIncident]
    WHERE [PrimaryIncidentId] = @PrimaryIncidentId

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_SelectById]    Script Date: 02/21/2012 16:07:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncident_SelectById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrimaryIncident_SelectById]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_SelectById]    Script Date: 02/21/2012 16:07:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrimaryIncident_SelectById]
(
     @PrimaryIncidentId uniqueidentifier
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [PrimaryIncidentId]
      ,[ChannelId]
      ,[DispatcherId]
      ,[ShiftId]
      ,[DateTime]
      ,[ToneAlertUsed]
      ,[Priority]
      ,[Sunstar3DigitNumber]
      ,[Location]
      ,[MapGrid]
      ,[NatureOfCall]
      ,[SSTacChannel]
      ,[PertinentIntRouting]
      ,[InfoGivenOutOfOrder]
      ,[DisplayedServiceAttitude]
      ,[UsedCorrectVolumeTone]
      ,[UsedProhibitedBehavior]
  FROM [Mayhem].[dbo].[PrimaryIncident]
  WHERE [PrimaryIncidentId] = @PrimaryIncidentId

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_SelectByDateRange]    Script Date: 02/21/2012 16:10:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncident_SelectByDateRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrimaryIncident_SelectByDateRange]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_SelectByDateRange]    Script Date: 02/21/2012 16:10:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrimaryIncident_SelectByDateRange]
(
     @BeginDate datetime
     ,@EndDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [PrimaryIncidentId]
      ,[ChannelId]
      ,[DispatcherId]
      ,[ShiftId]
      ,[DateTime]
      ,[ToneAlertUsed]
      ,[Priority]
      ,[Sunstar3DigitNumber]
      ,[Location]
      ,[MapGrid]
      ,[NatureOfCall]
      ,[SSTacChannel]
      ,[PertinentIntRouting]
      ,[InfoGivenOutOfOrder]
      ,[DisplayedServiceAttitude]
      ,[UsedCorrectVolumeTone]
      ,[UsedProhibitedBehavior]
  FROM [Mayhem].[dbo].[PrimaryIncident]
  WHERE [DateTime] >= @BeginDate
  AND [DateTime] <= @EndDate

END


GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_Insert]    Script Date: 02/21/2012 16:15:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecondaryIncident_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SecondaryIncident_Insert]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_Insert]    Script Date: 02/21/2012 16:15:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SecondaryIncident_Insert]
(
			@SecondaryIncidentId uniqueidentifier
		   ,@ChannelId int
           ,@DispatcherId varchar(100)
           ,@ShiftId int
           ,@DateTime datetime
           ,@Sunstar3DigitNumber bit
           ,@NatureOfCall bit
           ,@Location bit
           ,@MapGrid bit
           ,@FDUnitsAndTacCh bit
           ,@ScriptingDocumented bit
           ,@SevenMin bit
           ,@TwelveMin bit
           ,@ETALocationAsked bit
           ,@ETADocumented bit
           ,@ProactiveRoutingGiven varchar(50)
           ,@CorrectRouting varchar(50)
           ,@RoutingDocumented bit
           ,@PreArrivalGiven bit
           ,@EMDDocumented bit
           ,@DisplayedServiceAttitude varchar(50)
           ,@UsedCorrectVolumeTone varchar(50)
           ,@UsedProhibitedBehavior bit
           ,@PatchedChannels bit
           ,@Phone bit
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [Mayhem].[dbo].[SecondaryIncident]
           (
		    [SecondaryIncidentId]
		   ,[ChannelId]
           ,[DispatcherId]
           ,[ShiftId]
           ,[DateTime]
           ,[Sunstar3DigitNumber]
           ,[NatureOfCall]
           ,[Location]
           ,[MapGrid]
           ,[FDUnitsAndTacCh]
           ,[ScriptingDocumented]
           ,[SevenMin]
           ,[TwelveMin]
           ,[ETALocationAsked]
           ,[ETADocumented]
           ,[ProactiveRoutingGiven]
           ,[CorrectRouting]
           ,[RoutingDocumented]
           ,[PreArrivalGiven]
           ,[EMDDocumented]
           ,[DisplayedServiceAttitude]
           ,[UsedCorrectVolumeTone]
           ,[UsedProhibitedBehavior]
           ,[PatchedChannels]
           ,[Phone])
     VALUES
           (
			@SecondaryIncidentId
		   ,@ChannelId
           ,@DispatcherId
           ,@ShiftId
           ,@DateTime
           ,@Sunstar3DigitNumber
           ,@NatureOfCall
           ,@Location
           ,@MapGrid
           ,@FDUnitsAndTacCh
           ,@ScriptingDocumented
           ,@SevenMin
           ,@TwelveMin
           ,@ETALocationAsked
           ,@ETADocumented
           ,@ProactiveRoutingGiven
           ,@CorrectRouting
           ,@RoutingDocumented
           ,@PreArrivalGiven
           ,@EMDDocumented
           ,@DisplayedServiceAttitude
           ,@UsedCorrectVolumeTone
           ,@UsedProhibitedBehavior
           ,@PatchedChannels
           ,@Phone)

END

GO


USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_Update]    Script Date: 02/21/2012 16:18:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecondaryIncident_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SecondaryIncident_Update]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_Update]    Script Date: 02/21/2012 16:18:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SecondaryIncident_Update]
(
            @SecondaryIncidentId uniqueidentifier
		   ,@ChannelId int
           ,@DispatcherId varchar(100)
           ,@ShiftId int
           ,@DateTime datetime
           ,@Sunstar3DigitNumber bit
           ,@NatureOfCall bit
           ,@Location bit
           ,@MapGrid bit
           ,@FDUnitsAndTacCh bit
           ,@ScriptingDocumented bit
           ,@SevenMin bit
           ,@TwelveMin bit
           ,@ETALocationAsked bit
           ,@ETADocumented bit
           ,@ProactiveRoutingGiven varchar(50)
           ,@CorrectRouting varchar(50)
           ,@RoutingDocumented bit
           ,@PreArrivalGiven bit
           ,@EMDDocumented bit
           ,@DisplayedServiceAttitude varchar(50)
           ,@UsedCorrectVolumeTone varchar(50)
           ,@UsedProhibitedBehavior bit
           ,@PatchedChannels bit
           ,@Phone bit
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [Mayhem].[dbo].[SecondaryIncident]
   SET [ChannelId] = @ChannelId
      ,[DispatcherId] = @DispatcherId
      ,[ShiftId] = @ShiftId
      ,[DateTime] = @DateTime
      ,[Sunstar3DigitNumber] = @Sunstar3DigitNumber
      ,[NatureOfCall] = @NatureOfCall
      ,[Location] = @Location
      ,[MapGrid] = @MapGrid
      ,[FDUnitsAndTacCh] = @FDUnitsAndTacCh
      ,[ScriptingDocumented] = @ScriptingDocumented
      ,[SevenMin] = @SevenMin
      ,[TwelveMin] = @TwelveMin
      ,[ETALocationAsked] = @ETALocationAsked
      ,[ETADocumented] = @ETADocumented
      ,[ProactiveRoutingGiven] = @ProactiveRoutingGiven
      ,[CorrectRouting] = @CorrectRouting
      ,[RoutingDocumented] = @RoutingDocumented
      ,[PreArrivalGiven] = @PreArrivalGiven
      ,[EMDDocumented] = @EMDDocumented
      ,[DisplayedServiceAttitude] = @DisplayedServiceAttitude
      ,[UsedCorrectVolumeTone] = @UsedCorrectVolumeTone
      ,[UsedProhibitedBehavior] = @UsedProhibitedBehavior
      ,[PatchedChannels] = @PatchedChannels
      ,[Phone] = @Phone
 WHERE [SecondaryIncidentId] = @SecondaryIncidentId

END


GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_Delete]    Script Date: 02/21/2012 16:20:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecondaryIncident_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SecondaryIncident_Delete]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_Delete]    Script Date: 02/21/2012 16:20:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SecondaryIncident_Delete]
(
	@SecondaryIncidentId uniqueidentifier
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [Mayhem].[dbo].[SecondaryIncident]
      WHERE [SecondaryIncidentId] = @SecondaryIncidentId

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_SelectById]    Script Date: 02/21/2012 16:23:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecondaryIncident_SelectById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SecondaryIncident_SelectById]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_SelectById]    Script Date: 02/21/2012 16:23:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SecondaryIncident_SelectById]
(
    @SecondaryIncidentId uniqueidentifier
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [SecondaryIncidentId]
      ,[ChannelId]
      ,[DispatcherId]
      ,[ShiftId]
      ,[DateTime]
      ,[Sunstar3DigitNumber]
      ,[NatureOfCall]
      ,[Location]
      ,[MapGrid]
      ,[FDUnitsAndTacCh]
      ,[ScriptingDocumented]
      ,[SevenMin]
      ,[TwelveMin]
      ,[ETALocationAsked]
      ,[ETADocumented]
      ,[ProactiveRoutingGiven]
      ,[CorrectRouting]
      ,[RoutingDocumented]
      ,[PreArrivalGiven]
      ,[EMDDocumented]
      ,[DisplayedServiceAttitude]
      ,[UsedCorrectVolumeTone]
      ,[UsedProhibitedBehavior]
      ,[PatchedChannels]
      ,[Phone]
  FROM [Mayhem].[dbo].[SecondaryIncident]
  WHERE [SecondaryIncidentId] = @SecondaryIncidentId


END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_SelectByDateRange]    Script Date: 02/21/2012 16:26:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecondaryIncident_SelectByDateRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SecondaryIncident_SelectByDateRange]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncident_SelectByDateRange]    Script Date: 02/21/2012 16:26:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SecondaryIncident_SelectByDateRange]
(
     @BeginDate datetime
     ,@EndDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [SecondaryIncidentId]
      ,[ChannelId]
      ,[DispatcherId]
      ,[ShiftId]
      ,[DateTime]
      ,[Sunstar3DigitNumber]
      ,[NatureOfCall]
      ,[Location]
      ,[MapGrid]
      ,[FDUnitsAndTacCh]
      ,[ScriptingDocumented]
      ,[SevenMin]
      ,[TwelveMin]
      ,[ETALocationAsked]
      ,[ETADocumented]
      ,[ProactiveRoutingGiven]
      ,[CorrectRouting]
      ,[RoutingDocumented]
      ,[PreArrivalGiven]
      ,[EMDDocumented]
      ,[DisplayedServiceAttitude]
      ,[UsedCorrectVolumeTone]
      ,[UsedProhibitedBehavior]
      ,[PatchedChannels]
      ,[Phone]
  FROM [Mayhem].[dbo].[SecondaryIncident]
  WHERE [DateTime] >= @BeginDate
  AND [DateTime] <= @EndDate


END


GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_SelectAll]    Script Date: 02/21/2012 16:29:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incident_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Incident_SelectAll]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_SelectAll]    Script Date: 02/21/2012 16:29:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Incident_SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [IncidentId]
      ,[PrimaryIncidentId]
      ,[SecondaryIncidentId]
      ,[EvaluatorId]
      ,[EntryDate]
      ,[LastUpdated]
      ,[PrimaryIncidentScore]
      ,[PrimaryIncidentScorePercent]
      ,[SecondaryIncidentScore]
      ,[SecondaryIncidentScorePercent]
  FROM [Mayhem].[dbo].[Incident]

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[IncidentSelectByDateRange]    Script Date: 02/21/2012 16:31:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incident_SelectByDateRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Incident_SelectByDateRange]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[IncidentSelectByDateRange]    Script Date: 02/21/2012 16:31:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Incident_SelectByDateRange]
(
     @BeginDate datetime
     ,@EndDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [IncidentId]
      ,[PrimaryIncidentId]
      ,[SecondaryIncidentId]
      ,[EvaluatorId]
      ,[EntryDate]
      ,[LastUpdated]
      ,[PrimaryIncidentScore]
      ,[PrimaryIncidentScorePercent]
      ,[SecondaryIncidentScore]
      ,[SecondaryIncidentScorePercent]
  FROM [Mayhem].[dbo].[Incident]
  WHERE [EntryDate] >= @BeginDate
  AND [EntryDate] <= @EndDate
END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_Update]    Script Date: 02/21/2012 16:37:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incident_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Incident_Update]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_Update]    Script Date: 02/21/2012 16:37:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Incident_Update] 
(
	   @IncidentId varchar(50)
      ,@PrimaryIncidentId uniqueidentifier
      ,@SecondaryIncidentId uniqueidentifier
      ,@EvaluatorId varchar(100)
      ,@EntryDate datetime
      ,@LastUpdated datetime
      ,@PrimaryIncidentScore int
      ,@PrimaryIncidentScorePercent float
      ,@SecondaryIncidentScore int
      ,@SecondaryIncidentScorePercent float
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE [Mayhem].[dbo].[Incident]
   SET [PrimaryIncidentId] = @PrimaryIncidentId
      ,[SecondaryIncidentId] = @SecondaryIncidentId
      ,[EvaluatorId] = @EvaluatorId
      ,[EntryDate] = @EntryDate
      ,[LastUpdated] = @LastUpdated
      ,[PrimaryIncidentScore] = @PrimaryIncidentScore
      ,[PrimaryIncidentScorePercent] = @PrimaryIncidentScorePercent
      ,[SecondaryIncidentScore] = @SecondaryIncidentScore
      ,[SecondaryIncidentScorePercent] = @SecondaryIncidentScorePercent
 WHERE [IncidentId] = @IncidentId

END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_Delete]    Script Date: 02/21/2012 16:40:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncident_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrimaryIncident_Delete]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncident_Delete]    Script Date: 02/21/2012 16:40:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrimaryIncident_Delete]
(
	@PrimaryIncidentId uniqueidentifier
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [Mayhem].[dbo].[PrimaryIncident]
    WHERE [PrimaryIncidentId] = @PrimaryIncidentId

END


GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_Insert]    Script Date: 02/21/2012 16:42:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incident_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Incident_Insert]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_Insert]    Script Date: 02/21/2012 16:42:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Incident_Insert]
	(
	   @IncidentId varchar(50)
      ,@PrimaryIncidentId uniqueidentifier
      ,@SecondaryIncidentId uniqueidentifier
      ,@EvaluatorId varchar(100)
      ,@EntryDate datetime
      ,@LastUpdated datetime
      ,@PrimaryIncidentScore int
      ,@PrimaryIncidentScorePercent float
      ,@SecondaryIncidentScore int
      ,@SecondaryIncidentScorePercent float
      )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [Mayhem].[dbo].[Incident]
           ([IncidentId]
           ,[PrimaryIncidentId]
           ,[SecondaryIncidentId]
           ,[EvaluatorId]
           ,[EntryDate]
           ,[LastUpdated]
           ,[PrimaryIncidentScore]
           ,[PrimaryIncidentScorePercent]
           ,[SecondaryIncidentScore]
           ,[SecondaryIncidentScorePercent])
     VALUES
           (@IncidentId
      ,@PrimaryIncidentId
      ,@SecondaryIncidentId
      ,@EvaluatorId
      ,@EntryDate
      ,@LastUpdated
      ,@PrimaryIncidentScore
      ,@PrimaryIncidentScorePercent
      ,@SecondaryIncidentScore
      ,@SecondaryIncidentScorePercent)


END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_Delete]    Script Date: 02/22/2012 18:48:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incident_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Incident_Delete]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_Delete]    Script Date: 02/22/2012 18:48:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Incident_Delete] 
(
	@IncidentId varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   DELETE FROM [Mayhem].[dbo].[Incident]
      WHERE [IncidentId] = @IncidentId
END

GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_SelectById]    Script Date: 02/25/2012 11:47:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Incident_SelectById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Incident_SelectById]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Incident_SelectById]    Script Date: 02/25/2012 11:47:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Incident_SelectById]
(
	@IncidentId varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [IncidentId]
      ,[PrimaryIncidentId]
      ,[SecondaryIncidentId]
      ,[EvaluatorId]
      ,[EntryDate]
      ,[LastUpdated]
      ,[PrimaryIncidentScore]
      ,[PrimaryIncidentScorePercent]
      ,[SecondaryIncidentScore]
      ,[SecondaryIncidentScorePercent]
  FROM [Mayhem].[dbo].[Incident]
  WHERE [IncidentId] = @IncidentId

END


GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncidentReport_Dispatcher_SelectByDateRange]    Script Date: 03/02/2012 12:54:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncidentReport_Dispatcher_SelectByDateRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrimaryIncidentReport_Dispatcher_SelectByDateRange]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncidentReport_Dispatcher_SelectByDateRange]    Script Date: 03/02/2012 12:54:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrimaryIncidentReport_Dispatcher_SelectByDateRange]
(
     @BeginDate datetime
     ,@EndDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT p.[DispatcherId]
		,d.FirstName
		,d.LastName
      ,SUM(CAST(ToneAlertUsed as int)) as ToneAlertUsed
      ,SUM(CAST(Priority as int)) as Priority
      ,SUM(CAST(Sunstar3DigitNumber as int)) as Sunstar3DigitNumber
      ,SUM(CAST(Location as int)) as Location
      ,SUM(CAST(MapGrid as int)) as MapGrid
      ,SUM(CAST(NatureOfCall as int)) as NatureOfCall
      ,SUM(CAST(SSTacChannel as int)) as SSTacChannel
      ,SUM(CAST(PertinentIntRouting as int)) as PertinentIntRouting
      ,SUM(CAST(InfoGivenOutOfOrder as int)) as InfoGivenOutOfOrder
      ,SUM(CAST(UsedProhibitedBehavior as int)) as UsedProhibitedBehavior
      ,(select count(DisplayedServiceAttitude) from PrimaryIncident p2 where p.dispatcherid = p2.dispatcherId and DisplayedServiceAttitude like 'Correct') as DisplayedServiceAttitude_Correct
      ,(select count(DisplayedServiceAttitude) from PrimaryIncident p2 where p.dispatcherid = p2.dispatcherId and DisplayedServiceAttitude like 'INCoRrect') as DisplayedServiceAttitude_Incorrect
      ,(select count(DisplayedServiceAttitude) from PrimaryIncident p2 where p.dispatcherid = p2.dispatcherId and DisplayedServiceAttitude like 'Minor') as DisplayedServiceAttitude_Minor
      ,(select count(UsedCorrectVolumeTone) from PrimaryIncident p2 where p.dispatcherid = p2.dispatcherId and UsedCorrectVolumeTone like 'Correct') as UsedCorrectVolumeTone_Correct
      ,(select count(UsedCorrectVolumeTone) from PrimaryIncident p2 where p.dispatcherid = p2.dispatcherId and UsedCorrectVolumeTone like 'INCoRrect') as UsedCorrectVolumeTone_Incorrect
      ,(select count(UsedCorrectVolumeTone) from PrimaryIncident p2 where p.dispatcherid = p2.dispatcherId and UsedCorrectVolumeTone like 'Minor') as UsedCorrectVolumeTone_Minor
      ,SUM(i.PrimaryIncidentScorePercent) as TotalScore
      ,count(*) as CallCount
  FROM PrimaryIncident p
  Join Dispatcher d on p.DispatcherId = d.DispatcherId
  join Incident i on i.PrimaryIncidentId = p.primaryincidentid
  WHERE [DateTime] >= @BeginDate
  AND [DateTime] <= @EndDate
  group by p.dispatcherId, firstname, lastname
END


GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncidentReport_Evaluator_SelectByDateRange]    Script Date: 03/04/2012 10:34:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrimaryIncidentReport_Evaluator_SelectByDateRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrimaryIncidentReport_Evaluator_SelectByDateRange]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[PrimaryIncidentReport_Evaluator_SelectByDateRange]    Script Date: 03/04/2012 10:34:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PrimaryIncidentReport_Evaluator_SelectByDateRange]
(
     @BeginDate datetime
     ,@EndDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT i.[EvaluatorId] as DispatcherId
		,d.FirstName
		,d.LastName
      ,SUM(CAST(ToneAlertUsed as int)) as ToneAlertUsed
      ,SUM(CAST(Priority as int)) as Priority
      ,SUM(CAST(Sunstar3DigitNumber as int)) as Sunstar3DigitNumber
      ,SUM(CAST(Location as int)) as Location
      ,SUM(CAST(MapGrid as int)) as MapGrid
      ,SUM(CAST(NatureOfCall as int)) as NatureOfCall
      ,SUM(CAST(SSTacChannel as int)) as SSTacChannel
      ,SUM(CAST(PertinentIntRouting as int)) as PertinentIntRouting
      ,SUM(CAST(InfoGivenOutOfOrder as int)) as InfoGivenOutOfOrder
      ,SUM(CAST(UsedProhibitedBehavior as int)) as UsedProhibitedBehavior
      ,(select count(DisplayedServiceAttitude) from PrimaryIncident p2 join incident i2 on i2.PrimaryIncidentId = p2.primaryincidentid  where i2.EvaluatorId = i.EvaluatorId and DisplayedServiceAttitude like 'Correct') as DisplayedServiceAttitude_Correct
      ,(select count(DisplayedServiceAttitude) from PrimaryIncident p2 join incident i2 on i2.PrimaryIncidentId = p2.primaryincidentid  where i2.EvaluatorId = i.EvaluatorId and DisplayedServiceAttitude like 'INCoRrect') as DisplayedServiceAttitude_Incorrect
      ,(select count(DisplayedServiceAttitude) from PrimaryIncident p2 join incident i2 on i2.PrimaryIncidentId = p2.primaryincidentid  where i2.EvaluatorId = i.EvaluatorId and DisplayedServiceAttitude like 'Minor') as DisplayedServiceAttitude_Minor
      ,(select count(UsedCorrectVolumeTone) from PrimaryIncident p2 join incident i2 on i2.PrimaryIncidentId = p2.primaryincidentid  where i2.EvaluatorId = i.EvaluatorId and UsedCorrectVolumeTone like 'Correct') as UsedCorrectVolumeTone_Correct
      ,(select count(UsedCorrectVolumeTone) from PrimaryIncident p2 join incident i2 on i2.PrimaryIncidentId = p2.primaryincidentid  where i2.EvaluatorId = i.EvaluatorId and UsedCorrectVolumeTone like 'INCoRrect') as UsedCorrectVolumeTone_Incorrect
      ,(select count(UsedCorrectVolumeTone) from PrimaryIncident p2 join incident i2 on i2.PrimaryIncidentId = p2.primaryincidentid  where i2.EvaluatorId = i.EvaluatorId and UsedCorrectVolumeTone like 'Minor') as UsedCorrectVolumeTone_Minor
      ,SUM(i.PrimaryIncidentScorePercent) as TotalScore
      ,count(*) as CallCount
  FROM PrimaryIncident p
  join Incident i on i.PrimaryIncidentId = p.primaryincidentid
  Join Dispatcher d on i.EvaluatorId = d.DispatcherId
  WHERE [DateTime] >= @BeginDate
  AND [DateTime] <= @EndDate
  group by i.EvaluatorId, firstname, lastname
  
END


GO



USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncidentReport_Dispatcher_SelectByDateRange]    Script Date: 03/07/2012 12:31:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecondaryIncidentReport_Dispatcher_SelectByDateRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SecondaryIncidentReport_Dispatcher_SelectByDateRange]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncidentReport_Dispatcher_SelectByDateRange]    Script Date: 03/07/2012 12:31:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SecondaryIncidentReport_Dispatcher_SelectByDateRange]
(
     @BeginDate datetime
     ,@EndDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     SELECT s.[DispatcherId]
		,d.FirstName
		,d.LastName
      ,SUM(CAST(Sunstar3DigitNumber as int)) as Sunstar3DigitNumber
      ,SUM(CAST(NatureOfCall as int)) as NatureOfCall
      ,SUM(CAST(Location as int)) as Location
      ,SUM(CAST(MapGrid as int)) as MapGrid
      ,SUM(CAST(FDUnitsAndTacCh as int)) as FDUnitsAndTacCh
      ,SUM(CAST(ScriptingDocumented as int)) as ScriptingDocumented
      ,SUM(CAST(SevenMin as int)) as SevenMin
      ,SUM(CAST(TwelveMin as int)) as TwelveMin
      ,SUM(CAST(ETALocationAsked as int)) as ETALocationAsked
      ,SUM(CAST(ETADocumented as int)) as ETADocumented
      ,SUM(CAST(RoutingDocumented as int)) as RoutingDocumented
      ,SUM(CAST(PreArrivalGiven as int)) as PreArrivalGiven
      ,SUM(CAST(EMDDocumented as int)) as EMDDocumented
      ,SUM(CAST(UsedProhibitedBehavior as int)) as UsedProhibitedBehavior
      ,SUM(CAST(PatchedChannels as int)) as PatchedChannels
      ,SUM(CAST(Phone as int)) as Phone
      
      ,(select count(ProactiveRoutingGiven) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and ProactiveRoutingGiven like 'Yes') as ProactiveRoutingGiven_Yes
      ,(select count(ProactiveRoutingGiven) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and ProactiveRoutingGiven like 'No') as ProactiveRoutingGiven_No
      ,(select count(ProactiveRoutingGiven) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and ProactiveRoutingGiven like 'NA') as ProactiveRoutingGiven_NA
      ,(select count(CorrectRouting) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and CorrectRouting like 'Yes') as CorrectRouting_Yes
      ,(select count(CorrectRouting) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and CorrectRouting like 'No') as CorrectRouting_No
      ,(select count(CorrectRouting) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and CorrectRouting like 'NA') as CorrectRouting_NA
      
      
      ,(select count(DisplayedServiceAttitude) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and DisplayedServiceAttitude like 'Correct') as DisplayedServiceAttitude_Correct
      ,(select count(DisplayedServiceAttitude) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and DisplayedServiceAttitude like 'INCoRrect') as DisplayedServiceAttitude_Incorrect
      ,(select count(DisplayedServiceAttitude) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and DisplayedServiceAttitude like 'Minor') as DisplayedServiceAttitude_Minor
      ,(select count(UsedCorrectVolumeTone) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and UsedCorrectVolumeTone like 'Correct') as UsedCorrectVolumeTone_Correct
      ,(select count(UsedCorrectVolumeTone) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and UsedCorrectVolumeTone like 'INCoRrect') as UsedCorrectVolumeTone_Incorrect
      ,(select count(UsedCorrectVolumeTone) from SecondaryIncident s2 where s.dispatcherid = s2.dispatcherId and UsedCorrectVolumeTone like 'Minor') as UsedCorrectVolumeTone_Minor
      ,SUM(i.SecondaryIncidentScorePercent) as TotalScore
      ,count(*) as CallCount
  FROM SecondaryIncident s
  Join Dispatcher d on s.DispatcherId = d.DispatcherId
  join Incident i on i.SecondaryIncidentId = s.SecondaryIncidentId
  WHERE [DateTime] >= @BeginDate
  AND [DateTime] <= @EndDate
  group by s.dispatcherId, firstname, lastname
END



GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncidentReport_Evaluator_SelectByDateRange]    Script Date: 03/07/2012 13:17:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SecondaryIncidentReport_Evaluator_SelectByDateRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SecondaryIncidentReport_Evaluator_SelectByDateRange]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[SecondaryIncidentReport_Evaluator_SelectByDateRange]    Script Date: 03/07/2012 13:17:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SecondaryIncidentReport_Evaluator_SelectByDateRange]
(
     @BeginDate datetime
     ,@EndDate datetime
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     SELECT i.[EvaluatorId] as DispatcherId
		,d.FirstName
		,d.LastName
      ,SUM(CAST(Sunstar3DigitNumber as int)) as Sunstar3DigitNumber
      ,SUM(CAST(NatureOfCall as int)) as NatureOfCall
      ,SUM(CAST(Location as int)) as Location
      ,SUM(CAST(MapGrid as int)) as MapGrid
      ,SUM(CAST(FDUnitsAndTacCh as int)) as FDUnitsAndTacCh
      ,SUM(CAST(ScriptingDocumented as int)) as ScriptingDocumented
      ,SUM(CAST(SevenMin as int)) as SevenMin
      ,SUM(CAST(TwelveMin as int)) as TwelveMin
      ,SUM(CAST(ETALocationAsked as int)) as ETALocationAsked
      ,SUM(CAST(ETADocumented as int)) as ETADocumented
      ,SUM(CAST(RoutingDocumented as int)) as RoutingDocumented
      ,SUM(CAST(PreArrivalGiven as int)) as PreArrivalGiven
      ,SUM(CAST(EMDDocumented as int)) as EMDDocumented
      ,SUM(CAST(UsedProhibitedBehavior as int)) as UsedProhibitedBehavior
      ,SUM(CAST(PatchedChannels as int)) as PatchedChannels
      ,SUM(CAST(Phone as int)) as Phone
      
      ,(select count(ProactiveRoutingGiven) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and ProactiveRoutingGiven like 'Yes') as ProactiveRoutingGiven_Yes
      ,(select count(ProactiveRoutingGiven) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and ProactiveRoutingGiven like 'No') as ProactiveRoutingGiven_No
      ,(select count(ProactiveRoutingGiven) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and ProactiveRoutingGiven like 'NA') as ProactiveRoutingGiven_NA
      ,(select count(CorrectRouting) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and CorrectRouting like 'Yes') as CorrectRouting_Yes
      ,(select count(CorrectRouting) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and CorrectRouting like 'No') as CorrectRouting_No
      ,(select count(CorrectRouting) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and CorrectRouting like 'NA') as CorrectRouting_NA
      
      
      ,(select count(DisplayedServiceAttitude) from SecondaryIncident s2  join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and DisplayedServiceAttitude like 'Correct') as DisplayedServiceAttitude_Correct
      ,(select count(DisplayedServiceAttitude) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and DisplayedServiceAttitude like 'INCoRrect') as DisplayedServiceAttitude_Incorrect
      ,(select count(DisplayedServiceAttitude) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and DisplayedServiceAttitude like 'Minor') as DisplayedServiceAttitude_Minor
      ,(select count(UsedCorrectVolumeTone) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and UsedCorrectVolumeTone like 'Correct') as UsedCorrectVolumeTone_Correct
      ,(select count(UsedCorrectVolumeTone) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and UsedCorrectVolumeTone like 'INCoRrect') as UsedCorrectVolumeTone_Incorrect
      ,(select count(UsedCorrectVolumeTone) from SecondaryIncident s2 join incident i2 on i2.SecondaryIncidentId = s2.secondaryincidentid where i2.EvaluatorId = i.EvaluatorId and UsedCorrectVolumeTone like 'Minor') as UsedCorrectVolumeTone_Minor
      ,SUM(i.SecondaryIncidentScorePercent) as TotalScore
      ,count(*) as CallCount
  FROM SecondaryIncident s
  join Incident i on i.SecondaryIncidentId = s.SecondaryIncidentId
  Join Dispatcher d on i.EvaluatorId = d.DispatcherId
  WHERE [DateTime] >= @BeginDate
  AND [DateTime] <= @EndDate
  group by i.EvaluatorId, firstname, lastname
END



GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_SelectByUsernamePassword]    Script Date: 03/09/2012 10:39:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectByUsername]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_SelectByUsername]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_SelectByUsernamePassword]    Script Date: 03/09/2012 10:39:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_SelectByUsername]
(
     @Username varchar(50)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [Username]
      ,[Password]
      ,[ValidUser]
      ,u.[DispatcherId]
      ,[FirstName]
      ,[LastName]
      ,d.[RoleTypeId]
      ,r.[RoleDescription]
  FROM [User] u
  Join [Dispatcher] d on d.DispatcherId = u.dispatcherid
  join RoleType r on r.roletypeid = d.roletypeid
  WHERE [Username] like @Username

END



GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 03/09/2012 14:14:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_Insert]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 03/09/2012 14:14:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_Insert] 
	(
			@Username varchar(50)
           ,@Password varchar(50)
           ,@ValidUser bit
           ,@DispatcherId varchar(100)
     )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    INSERT INTO [Mayhem].[dbo].[User]
           ([Username]
           ,[Password]
           ,[ValidUser]
           ,[DispatcherId])
     VALUES
           (@Username
           ,@Password
           ,@ValidUser
           ,@DispatcherId)


END


GO


USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Dispatcher_SelectByUsername]    Script Date: 03/09/2012 18:12:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dispatcher_SelectByUsername]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Dispatcher_SelectByUsername]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[Dispatcher_SelectByUsername]    Script Date: 03/09/2012 18:12:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Dispatcher_SelectByUsername]
	(
		@Username varchar(50)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT d.[DispatcherId]
      ,[FirstName]
      ,[LastName]
      ,[RoleTypeId]
  FROM [Dispatcher] d
  join [User] u on d.dispatcherid = u.dispatcherid
  where u.username like @Username


END


GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 03/10/2012 18:55:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_Update]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 03/10/2012 18:55:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_Update] 
	(
			@Username varchar(50)
           ,@Password varchar(50)
           ,@ValidUser bit
     )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   UPDATE [Mayhem].[dbo].[User]
   SET [Password] = @Password
      ,[ValidUser] = @ValidUser
 WHERE [Username] = @Username




END



GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_SelectByDispatcherId]    Script Date: 03/10/2012 19:00:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_SelectByDispatcherId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_SelectByDispatcherId]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_SelectByDispatcherId]    Script Date: 03/10/2012 19:00:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_SelectByDispatcherId]
(
     @DispatcherId varchar(100)
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [Username]
      ,[Password]
      ,[ValidUser]
      ,u.[DispatcherId]
      ,[FirstName]
      ,[LastName]
      ,d.[RoleTypeId]
      ,r.[RoleDescription]
  FROM [User] u
  Join [Dispatcher] d on d.DispatcherId = u.dispatcherid
  join RoleType r on r.roletypeid = d.roletypeid
  WHERE u.[DispatcherId] like @DispatcherId

END




GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 03/10/2012 20:09:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[User_Delete]
GO

USE [Mayhem]
GO

/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 03/10/2012 20:09:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[User_Delete] 
	(
			@Username varchar(50)
     )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  DELETE FROM [Mayhem].[dbo].[User]
       WHERE [Username] = @Username




END




GO

