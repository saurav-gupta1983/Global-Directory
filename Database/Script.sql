if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Birthsafter1989_MemberInfo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Birthsafter1989] DROP CONSTRAINT FK_Birthsafter1989_MemberInfo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ContactDetails_MemberInfo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ContactDetails] DROP CONSTRAINT FK_ContactDetails_MemberInfo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Deathsafter1989_MemberInfo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Deathsafter1989] DROP CONSTRAINT FK_Deathsafter1989_MemberInfo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_FamilyDetails_MemberInfo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[FamilyDetails] DROP CONSTRAINT FK_FamilyDetails_MemberInfo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_OffspringDetails_MemberInfo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[OffspringDetails] DROP CONSTRAINT FK_OffspringDetails_MemberInfo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_OtherDetails_MemberInfo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[OtherDetails] DROP CONSTRAINT FK_OtherDetails_MemberInfo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_PropertyDetails_MemberInfo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[PropertyDetails] DROP CONSTRAINT FK_PropertyDetails_MemberInfo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_SiblingDetails_MemberInfo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[SiblingDetails] DROP CONSTRAINT FK_SiblingDetails_MemberInfo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamilyKPIN]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[FamilyKPIN]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OrgChart]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[OrgChart]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Birthsafter1989]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Birthsafter1989]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ContactDetails]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ContactDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Deathsafter1989]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Deathsafter1989]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FamilyDetails]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[FamilyDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OffspringDetails]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OffspringDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[OtherDetails]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[OtherDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PropertyDetails]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PropertyDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SiblingDetails]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SiblingDetails]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AdminAccess]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AdminAccess]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ArchivedRequests]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ArchivedRequests]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Images]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Images]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MailList]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MailList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MemberInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MemberInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RequestforPublicMessage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[RequestforPublicMessage]
GO

CREATE TABLE [dbo].[AdminAccess] (
	[KPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[isAdmin] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ArchivedRequests] (
	[RequestId] [int] NULL ,
	[RequestedByKPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RequestedDate] [datetime] NULL ,
	[Subject] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Body] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[isApproved] [int] NULL ,
	[ApprovedByKPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ApprovedDate] [datetime] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Images] (
	[PinId] [int] NULL ,
	[Filename] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ContentType] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FileData] [image] NULL ,
	[FIlesize] [int] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[MailList] (
	[MailId] [int] IDENTITY (1, 1) NOT NULL ,
	[KPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EmailToKPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DateofEmail] [datetime] NULL ,
	[Subject] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[MemberInfo] (
	[PINId] [int] IDENTITY (1, 1) NOT NULL ,
	[KPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Password] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FirstName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LastName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MiddleName] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Country] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AgeDiff] [int] NULL ,
	[City] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LastUpdated] [datetime] NULL ,
	[Photo] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RequestforPublicMessage] (
	[RequestId] [int] IDENTITY (1, 1) NOT NULL ,
	[RequestedByKPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[RequestedDate] [datetime] NOT NULL ,
	[Subject] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Body] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[isPending] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[isApproved] [int] NOT NULL ,
	[ApprovedByKPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ApprovedDate] [smalldatetime] NULL ,
	[Filter] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Birthsafter1989] (
	[PinId] [int] NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Sex] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AgeDiff] [int] NULL ,
	[isSibling] [int] NULL ,
	[isMother] [int] NULL ,
	[ParentName] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ContactDetails] (
	[PinId] [int] NOT NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NativeAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PermanentAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CurrentAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MobileNo] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ResidenceNo] [varchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EmailId] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Deathsafter1989] (
	[PinId] [int] NOT NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Name] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Sex] [bit] NULL ,
	[AgeDiff] [int] NULL ,
	[Reasons] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Relation] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[FamilyDetails] (
	[PinId] [int] NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Sex] [int] NULL ,
	[MaritalStatus] [int] NULL ,
	[Nationality] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FathersName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MothersName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SpouseName] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[FathersPinId] [int] NULL ,
	[MothersPinId] [int] NULL ,
	[SpousePinId] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OffspringDetails] (
	[PinId] [int] NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Name] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Sex] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AgeDiff] [int] NULL ,
	[OffSpringPinId] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OtherDetails] (
	[PinId] [int] NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EmploymentStatus] [int] NULL ,
	[Profession] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[CurrentEmployer] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[YrsofExp] [int] NULL ,
	[AnnualIncome] [int] NULL ,
	[Education] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Board] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Year] [int] NULL ,
	[DateofMigrationDiff] [int] NULL ,
	[ReasonofMigration] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PropertyDetails] (
	[PinId] [int] NOT NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Type] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Specification] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Identification] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cost] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SiblingDetails] (
	[PinId] [int] NULL ,
	[VPIN] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Name] [varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Sex] [bit] NULL ,
	[AgeDiff] [int] NULL ,
	[SiblingPinId] [int] NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MemberInfo] WITH NOCHECK ADD 
	CONSTRAINT [PK_MemberInfo] PRIMARY KEY  CLUSTERED 
	(
		[PINId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[AdminAccess] ADD 
	CONSTRAINT [DF_AdminAccess_isAdmin] DEFAULT (1) FOR [isAdmin]
GO

 CREATE  UNIQUE  INDEX [IX_MemberInfo] ON [dbo].[MemberInfo]([KPIN]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RequestforPublicMessage] ADD 
	CONSTRAINT [DF_RequestforPublicMessage_isApproved] DEFAULT (0) FOR [isApproved]
GO

 CREATE  UNIQUE  INDEX [IX_Birthsafter1989] ON [dbo].[Birthsafter1989]([VPIN], [PinId], [AgeDiff], [Name]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContactDetails] ADD 
	CONSTRAINT [DF_ContactDetails_VPIN] DEFAULT ('') FOR [VPIN],
	CONSTRAINT [DF_ContactDetails_NativeAddress] DEFAULT ('') FOR [NativeAddress],
	CONSTRAINT [DF_ContactDetails_PermanentAddress] DEFAULT ('') FOR [PermanentAddress],
	CONSTRAINT [DF_ContactDetails_CurrentAddress] DEFAULT ('') FOR [CurrentAddress],
	CONSTRAINT [DF_ContactDetails_MobileNo] DEFAULT ('') FOR [MobileNo],
	CONSTRAINT [DF_ContactDetails_ResidenceNo] DEFAULT ('') FOR [ResidenceNo],
	CONSTRAINT [DF_ContactDetails_EmailId] DEFAULT ('') FOR [EmailId]
GO

 CREATE  INDEX [IX_ContactDetails] ON [dbo].[ContactDetails]([PinId], [VPIN]) ON [PRIMARY]
GO

 CREATE  INDEX [IX_Deathsafter1989] ON [dbo].[Deathsafter1989]([PinId], [VPIN], [Name], [AgeDiff]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FamilyDetails] ADD 
	CONSTRAINT [DF_FamilyDetails_Sex] DEFAULT (0) FOR [Sex],
	CONSTRAINT [DF_FamilyDetails_MaritalStatus] DEFAULT (0) FOR [MaritalStatus],
	CONSTRAINT [DF_FamilyDetails_Nationality] DEFAULT ('') FOR [Nationality],
	CONSTRAINT [DF_FamilyDetails_FathersName] DEFAULT ('') FOR [FathersName],
	CONSTRAINT [DF_FamilyDetails_MothersName] DEFAULT ('') FOR [MothersName],
	CONSTRAINT [DF_FamilyDetails_SpouseName] DEFAULT ('') FOR [SpouseName]
GO

 CREATE  INDEX [IX_FamilyDetails] ON [dbo].[FamilyDetails]([PinId], [VPIN]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [IX_OffspringDetails] ON [dbo].[OffspringDetails]([PinId], [VPIN], [Name], [AgeDiff]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OtherDetails] ADD 
	CONSTRAINT [DF_OtherDetails_EmploymentStatus] DEFAULT (0) FOR [EmploymentStatus],
	CONSTRAINT [DF_OtherDetails_DateofMigrationDiff] DEFAULT (0) FOR [DateofMigrationDiff]
GO

 CREATE  UNIQUE  INDEX [IX_PropertyDetails] ON [dbo].[PropertyDetails]([PinId], [VPIN], [Identification]) ON [PRIMARY]
GO

 CREATE  UNIQUE  INDEX [IX_SiblingDetails] ON [dbo].[SiblingDetails]([PinId], [Name], [AgeDiff], [VPIN]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Birthsafter1989] ADD 
	CONSTRAINT [FK_Birthsafter1989_MemberInfo] FOREIGN KEY 
	(
		[PinId]
	) REFERENCES [dbo].[MemberInfo] (
		[PINId]
	)
GO

ALTER TABLE [dbo].[ContactDetails] ADD 
	CONSTRAINT [FK_ContactDetails_MemberInfo] FOREIGN KEY 
	(
		[PinId]
	) REFERENCES [dbo].[MemberInfo] (
		[PINId]
	)
GO

ALTER TABLE [dbo].[Deathsafter1989] ADD 
	CONSTRAINT [FK_Deathsafter1989_MemberInfo] FOREIGN KEY 
	(
		[PinId]
	) REFERENCES [dbo].[MemberInfo] (
		[PINId]
	)
GO

ALTER TABLE [dbo].[FamilyDetails] ADD 
	CONSTRAINT [FK_FamilyDetails_MemberInfo] FOREIGN KEY 
	(
		[PinId]
	) REFERENCES [dbo].[MemberInfo] (
		[PINId]
	)
GO

ALTER TABLE [dbo].[OffspringDetails] ADD 
	CONSTRAINT [FK_OffspringDetails_MemberInfo] FOREIGN KEY 
	(
		[PinId]
	) REFERENCES [dbo].[MemberInfo] (
		[PINId]
	)
GO

ALTER TABLE [dbo].[OtherDetails] ADD 
	CONSTRAINT [FK_OtherDetails_MemberInfo] FOREIGN KEY 
	(
		[PinId]
	) REFERENCES [dbo].[MemberInfo] (
		[PINId]
	)
GO

ALTER TABLE [dbo].[PropertyDetails] ADD 
	CONSTRAINT [FK_PropertyDetails_MemberInfo] FOREIGN KEY 
	(
		[PinId]
	) REFERENCES [dbo].[MemberInfo] (
		[PINId]
	)
GO

ALTER TABLE [dbo].[SiblingDetails] ADD 
	CONSTRAINT [FK_SiblingDetails_MemberInfo] FOREIGN KEY 
	(
		[PinId]
	) REFERENCES [dbo].[MemberInfo] (
		[PINId]
	)
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

-- FamilyKPIN '3'
CREATE PROCEDURE [dbo].[FamilyKPIN](@KPIN Varchar(50)) 
AS 
	SET NOCOUNT ON 
	
	Declare @FamilyStructure Table
	(
		MemberName Varchar(30),
		DateofBirth varchar(12),
		Relation Varchar(30),
		KPIN Varchar(50),
		ID Int
	)
	
	Declare @PinId int
	
	Select @PinId = PinId From MemberInfo Where KPIN=@KPIN
	
	Insert Into @FamilyStructure (MemberName, ID, Relation)
	SELECT	FathersName, FathersPinId, 'Father'
	FROM FamilyDetails WHERE PinId = @PinId
	And IsNull(FathersName,'') <> ''
			
	Insert Into @FamilyStructure (MemberName, ID, Relation)
	SELECT	MothersName, MothersPinId, 'Mother'
	FROM FamilyDetails WHERE PinId = @PinId
	And IsNull(MothersName,'') <> ''

	Insert Into @FamilyStructure (MemberName, ID, Relation)
	SELECT	SpouseName, SpousePinId, 'Spouse'
	FROM FamilyDetails WHERE PinId = @PinId
	And IsNull(Replace(SpouseName,'-',''),'') <> ''

	Insert Into @FamilyStructure (MemberName, ID, Relation, DateofBirth)
	SELECT	Name, OffspringPinId, 'Offspring', Convert(Varchar(12),DATEADD(day, Agediff, '1-1-1900'),103)
	FROM OffspringDetails WHERE PinId = @PinId

	Insert Into @FamilyStructure (MemberName, ID, Relation, DateofBirth)
	SELECT	Name, SiblingPinId, 'Sibling', Convert(Varchar,DATEADD(day, Agediff, '1-1-1900'),103)
	FROM SiblingDetails WHERE PinId = @PinId
	
	Update FS
	Set KPIN = MI.KPIN,
		DateofBirth = Case When IsNull(DateofBirth,'') = '' Then Convert(Varchar,DATEADD(day, Agediff, '1-1-1900'),103)
				Else DateofBirth
				End
	From @FamilyStructure FS, MemberInfo MI
	Where MI.PinId = ID
	
	Select 	Replace(Replace(MemberName,'-',' '),'  ',' ') As Name,
		DateofBirth,
		Relation,
		KPIN
	From @FamilyStructure
	
RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[OrgChart](@KPIN Varchar(50)) 
AS 
	SET NOCOUNT ON 
	
	Declare @FamilyStructure Table
	(
		PinId Int,
		KPIN Varchar(50),
		MemberName Varchar(30),
		Photo Varchar(50),
		SpouseName Varchar(50),
		SpousePinID int,
		MotherName Varchar(50),
		MotherPinID Varchar(50),
		Sex Varchar(6),
		DateofBirth int,
		Levels int,
		MemberSearched int
	)
	
	Declare @PinId int
	
	Select @PinId = PinId From MemberInfo Where KPIN=@KPIN
	
	Insert Into @FamilyStructure (PinId, MemberName, Levels)
	SELECT	FathersPinId, FathersName, 1
	FROM FamilyDetails WHERE PinId = @PinId
			
	--Insert Into @FamilyStructure (PinId, MemberName, Levels)
	SELECT	Identity(Int, 1,1) Row, SiblingPinId As PinId, Name
	Into #Temp
	FROM SiblingDetails WHERE PinId = @PinId
	
	Declare @Count As Integer
	Select @Count = Count(*) From #Temp
	
	Insert Into @FamilyStructure (PinId, MemberName, Levels, MemberSearched)
	SELECT	PinId, Name, 2, 0
	FROM #Temp WHERE Row <= (@Count + 1/2)

	Insert Into @FamilyStructure (PinId, Levels, MemberSearched)
	SELECT	PinId, 2, 1
	FROM MemberInfo WHERE PinId = @PinId
	
	Insert Into @FamilyStructure (PinId, Levels, MemberSearched)
	SELECT	PinId, 2, 0
	FROM #Temp WHERE Row > (@Count + 1/2)

	Insert Into @FamilyStructure (PinId, MemberName, Levels)
	SELECT	OffspringPinId, Name, 3
	FROM OffspringDetails WHERE PinId = @PinId
	
	Update @FamilyStructure
	Set MemberSearched = 0
	Where IsNull(MemberSearched,0) <> 1
	
	Update FS
	Set KPIN = MI.KPIN,
		Photo = MI.Photo,
		SpouseName = FD.SpouseName,
		SpousePinID = FD.SpousePinID,
		MotherName = FD.MothersName,
		MotherPinID = FD.MothersPinID,
		Sex = FD.Sex,
		MemberName = FirstName + ' ' + MiddleName + ' ' + LastName,
		DateofBirth = AgeDiff
	From @FamilyStructure FS, MemberInfo MI, FamilyDetails FD
	Where FS.PinId = MI.PinId
	And MI.PinId = FD.PinId
	
	Select isNull(PinId,'') As PinId,
		isNull(KPIN,'') As KPIN,
		isNull(MemberName,'') As MemberName,
		isNull(Photo,'') As Photo,
		isNull(SpouseName,'') As SpouseName,
		isNull(SpousePinID,'') As SpousePinID,
		isNull(MotherName,'') As MotherName,
		isNull(MotherPinID,'') As MotherPinID,
		isNull(Sex,0) As Sex,
		isNull(DateofBirth,0) As DateofBirth,
		Levels,
		MemberSearched
	From @FamilyStructure
	
RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

