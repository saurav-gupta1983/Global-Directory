SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MemberInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MemberInfo](
	[PINId] [int] IDENTITY(1,1) NOT NULL,
	[KPIN] [varchar](50) NULL,
	[VPIN] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[FirstName] [varchar](20) NULL,
	[LastName] [varchar](20) NULL,
	[MiddleName] [varchar](20) NULL,
	[Country] [varchar](20) NULL,
	[AgeDiff] [int] NULL,
	[City] [varchar](20) NULL,
	[LastUpdated] [datetime] NULL,
	[Photo] [varchar](50) NULL,
 CONSTRAINT [PK_MemberInfo] PRIMARY KEY CLUSTERED 
(
	[PINId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MemberInfo]') AND name = N'IX_MemberInfo')
CREATE UNIQUE NONCLUSTERED INDEX [IX_MemberInfo] ON [dbo].[MemberInfo] 
(
	[KPIN] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdminAccess]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AdminAccess](
	[KPIN] [varchar](50) NOT NULL,
	[isAdmin] [int] NOT NULL CONSTRAINT [DF_AdminAccess_isAdmin]  DEFAULT ((1))
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RequestforPublicMessage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RequestforPublicMessage](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[RequestedByKPIN] [varchar](50) NOT NULL,
	[RequestedDate] [datetime] NOT NULL,
	[Subject] [varchar](50) NOT NULL,
	[Body] [varchar](50) NOT NULL,
	[isPending] [varchar](50) NOT NULL,
	[isApproved] [int] NOT NULL CONSTRAINT [DF_RequestforPublicMessage_isApproved]  DEFAULT ((0)),
	[ApprovedByKPIN] [varchar](50) NULL,
	[ApprovedDate] [smalldatetime] NULL,
	[Filter] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ArchivedRequests]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ArchivedRequests](
	[RequestId] [int] NULL,
	[RequestedByKPIN] [varchar](50) NULL,
	[RequestedDate] [datetime] NULL,
	[Subject] [varchar](50) NULL,
	[Body] [varchar](50) NULL,
	[isApproved] [int] NULL,
	[ApprovedByKPIN] [varchar](50) NULL,
	[ApprovedDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MailList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MailList](
	[MailId] [int] IDENTITY(1,1) NOT NULL,
	[KPIN] [varchar](50) NULL,
	[EmailToKPIN] [varchar](50) NULL,
	[DateofEmail] [datetime] NULL,
	[Subject] [varchar](100) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FamilyDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FamilyDetails](
	[PinId] [int] NULL,
	[VPIN] [varchar](50) NULL,
	[Sex] [int] NULL CONSTRAINT [DF_FamilyDetails_Sex]  DEFAULT ((0)),
	[MaritalStatus] [int] NULL CONSTRAINT [DF_FamilyDetails_MaritalStatus]  DEFAULT ((0)),
	[Nationality] [varchar](20) NULL CONSTRAINT [DF_FamilyDetails_Nationality]  DEFAULT (''),
	[FathersName] [varchar](30) NULL CONSTRAINT [DF_FamilyDetails_FathersName]  DEFAULT (''),
	[MothersName] [varchar](30) NULL CONSTRAINT [DF_FamilyDetails_MothersName]  DEFAULT (''),
	[SpouseName] [varchar](30) NULL CONSTRAINT [DF_FamilyDetails_SpouseName]  DEFAULT (''),
	[FathersPinId] [int] NULL,
	[MothersPinId] [int] NULL,
	[SpousePinId] [int] NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[FamilyDetails]') AND name = N'IX_FamilyDetails')
CREATE NONCLUSTERED INDEX [IX_FamilyDetails] ON [dbo].[FamilyDetails] 
(
	[PinId] ASC,
	[VPIN] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PropertyDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PropertyDetails](
	[PinId] [int] NOT NULL,
	[VPIN] [varchar](50) NULL,
	[Type] [varchar](20) NULL,
	[Specification] [varchar](50) NULL,
	[Identification] [varchar](50) NULL,
	[Cost] [int] NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[PropertyDetails]') AND name = N'IX_PropertyDetails')
CREATE UNIQUE NONCLUSTERED INDEX [IX_PropertyDetails] ON [dbo].[PropertyDetails] 
(
	[PinId] ASC,
	[VPIN] ASC,
	[Identification] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SiblingDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SiblingDetails](
	[PinId] [int] NULL,
	[VPIN] [varchar](50) NULL,
	[Name] [varchar](30) NULL,
	[Sex] [bit] NULL,
	[AgeDiff] [int] NULL,
	[SiblingPinId] [int] NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SiblingDetails]') AND name = N'IX_SiblingDetails')
CREATE UNIQUE NONCLUSTERED INDEX [IX_SiblingDetails] ON [dbo].[SiblingDetails] 
(
	[PinId] ASC,
	[Name] ASC,
	[AgeDiff] ASC,
	[VPIN] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OtherDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OtherDetails](
	[PinId] [int] NULL,
	[VPIN] [varchar](50) NULL,
	[EmploymentStatus] [int] NULL CONSTRAINT [DF_OtherDetails_EmploymentStatus]  DEFAULT ((0)),
	[Profession] [varchar](30) NULL,
	[CurrentEmployer] [varchar](30) NULL,
	[YrsofExp] [int] NULL,
	[AnnualIncome] [int] NULL,
	[Education] [varchar](30) NULL,
	[Board] [varchar](20) NULL,
	[Year] [int] NULL,
	[DateofMigrationDiff] [int] NULL CONSTRAINT [DF_OtherDetails_DateofMigrationDiff]  DEFAULT ((0)),
	[ReasonofMigration] [varchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ContactDetails](
	[PinId] [int] NOT NULL,
	[VPIN] [varchar](50) NULL CONSTRAINT [DF_ContactDetails_VPIN]  DEFAULT (''),
	[NativeAddress] [varchar](50) NULL CONSTRAINT [DF_ContactDetails_NativeAddress]  DEFAULT (''),
	[PermanentAddress] [varchar](50) NULL CONSTRAINT [DF_ContactDetails_PermanentAddress]  DEFAULT (''),
	[CurrentAddress] [varchar](50) NULL CONSTRAINT [DF_ContactDetails_CurrentAddress]  DEFAULT (''),
	[MobileNo] [varchar](15) NULL CONSTRAINT [DF_ContactDetails_MobileNo]  DEFAULT (''),
	[ResidenceNo] [varchar](15) NULL CONSTRAINT [DF_ContactDetails_ResidenceNo]  DEFAULT (''),
	[EmailId] [varchar](20) NULL CONSTRAINT [DF_ContactDetails_EmailId]  DEFAULT ('')
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ContactDetails]') AND name = N'IX_ContactDetails')
CREATE NONCLUSTERED INDEX [IX_ContactDetails] ON [dbo].[ContactDetails] 
(
	[PinId] ASC,
	[VPIN] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OffspringDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OffspringDetails](
	[PinId] [int] NULL,
	[VPIN] [varchar](50) NULL,
	[Name] [varchar](30) NULL,
	[Sex] [varchar](30) NULL,
	[AgeDiff] [int] NULL,
	[OffSpringPinId] [int] NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[OffspringDetails]') AND name = N'IX_OffspringDetails')
CREATE UNIQUE NONCLUSTERED INDEX [IX_OffspringDetails] ON [dbo].[OffspringDetails] 
(
	[PinId] ASC,
	[VPIN] ASC,
	[Name] ASC,
	[AgeDiff] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deathsafter1989]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Deathsafter1989](
	[PinId] [int] NOT NULL,
	[VPIN] [varchar](50) NULL,
	[Name] [varchar](30) NULL,
	[Sex] [bit] NULL,
	[AgeDiff] [int] NULL,
	[Reasons] [varchar](50) NULL,
	[Relation] [varchar](50) NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Deathsafter1989]') AND name = N'IX_Deathsafter1989')
CREATE NONCLUSTERED INDEX [IX_Deathsafter1989] ON [dbo].[Deathsafter1989] 
(
	[PinId] ASC,
	[VPIN] ASC,
	[Name] ASC,
	[AgeDiff] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Birthsafter1989]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Birthsafter1989](
	[PinId] [int] NULL,
	[VPIN] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Sex] [varchar](50) NULL,
	[AgeDiff] [int] NULL,
	[isSibling] [int] NULL,
	[isMother] [int] NULL,
	[ParentName] [varchar](50) NULL
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Birthsafter1989]') AND name = N'IX_Birthsafter1989')
CREATE UNIQUE NONCLUSTERED INDEX [IX_Birthsafter1989] ON [dbo].[Birthsafter1989] 
(
	[VPIN] ASC,
	[PinId] ASC,
	[AgeDiff] ASC,
	[Name] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrgChart]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[OrgChart](@KPIN Varchar(50)) 
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
		DateofBirth Varchar(50),
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
		MemberName = FirstName + '' '' + MiddleName + '' '' + LastName
	From @FamilyStructure FS, MemberInfo MI, FamilyDetails FD
	Where FS.PinId = MI.PinId
	And MI.PinId = FD.PinId
	
	Select isNull(PinId,'''') As PinId,
		isNull(KPIN,'''') As KPIN,
		isNull(MemberName,'''') As MemberName,
		isNull(Photo,'''') As Photo,
		isNull(SpouseName,'''') As SpouseName,
		isNull(SpousePinID,'''') As SpousePinID,
		isNull(MotherName,'''') As MotherName,
		isNull(MotherPinID,'''') As MotherPinID,
		isNull(Sex,0) As Sex,
		isNull(DateofBirth,'''') As DateofBirth,
		Levels,
		MemberSearched
	From @FamilyStructure
	
RETURN' 
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FamilyDetails_MemberInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[FamilyDetails]'))
ALTER TABLE [dbo].[FamilyDetails]  WITH CHECK ADD  CONSTRAINT [FK_FamilyDetails_MemberInfo] FOREIGN KEY([PinId])
REFERENCES [dbo].[MemberInfo] ([PINId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PropertyDetails_MemberInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[PropertyDetails]'))
ALTER TABLE [dbo].[PropertyDetails]  WITH CHECK ADD  CONSTRAINT [FK_PropertyDetails_MemberInfo] FOREIGN KEY([PinId])
REFERENCES [dbo].[MemberInfo] ([PINId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SiblingDetails_MemberInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[SiblingDetails]'))
ALTER TABLE [dbo].[SiblingDetails]  WITH CHECK ADD  CONSTRAINT [FK_SiblingDetails_MemberInfo] FOREIGN KEY([PinId])
REFERENCES [dbo].[MemberInfo] ([PINId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OtherDetails_MemberInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[OtherDetails]'))
ALTER TABLE [dbo].[OtherDetails]  WITH CHECK ADD  CONSTRAINT [FK_OtherDetails_MemberInfo] FOREIGN KEY([PinId])
REFERENCES [dbo].[MemberInfo] ([PINId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContactDetails_MemberInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContactDetails]'))
ALTER TABLE [dbo].[ContactDetails]  WITH CHECK ADD  CONSTRAINT [FK_ContactDetails_MemberInfo] FOREIGN KEY([PinId])
REFERENCES [dbo].[MemberInfo] ([PINId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OffspringDetails_MemberInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[OffspringDetails]'))
ALTER TABLE [dbo].[OffspringDetails]  WITH CHECK ADD  CONSTRAINT [FK_OffspringDetails_MemberInfo] FOREIGN KEY([PinId])
REFERENCES [dbo].[MemberInfo] ([PINId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Deathsafter1989_MemberInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Deathsafter1989]'))
ALTER TABLE [dbo].[Deathsafter1989]  WITH CHECK ADD  CONSTRAINT [FK_Deathsafter1989_MemberInfo] FOREIGN KEY([PinId])
REFERENCES [dbo].[MemberInfo] ([PINId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Birthsafter1989_MemberInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[Birthsafter1989]'))
ALTER TABLE [dbo].[Birthsafter1989]  WITH CHECK ADD  CONSTRAINT [FK_Birthsafter1989_MemberInfo] FOREIGN KEY([PinId])
REFERENCES [dbo].[MemberInfo] ([PINId])
