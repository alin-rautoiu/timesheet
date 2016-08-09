USE [Pontaj]
GO
/****** Object:  Table [dbo].[DaySheet]    Script Date: 8/9/2016 5:51:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DaySheet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NULL,
	[WorkedHour] [int] NULL,
	[TimeSheetId] [int] NULL,
 CONSTRAINT [PK_DaySheet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PontajTable]    Script Date: 8/9/2016 5:51:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PontajTable](
	[Guid] [uniqueidentifier] NOT NULL,
	[Project] [nvarchar](255) NULL,
	[Task] [nvarchar](255) NULL,
	[Comment] [nvarchar](255) NULL,
	[Sun] [int] NULL,
	[Mon] [int] NULL,
	[Tue] [int] NULL,
	[Wed] [int] NULL,
	[Thu] [int] NULL,
	[Fri] [int] NULL,
	[Sat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 8/9/2016 5:51:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProjectName] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Task]    Script Date: 8/9/2016 5:51:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_TaskName] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TimeSheet]    Script Date: 8/9/2016 5:51:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSheet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Comment] [nvarchar](50) NULL,
	[TaskId] [int] NULL,
 CONSTRAINT [PK_TimeSheet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DaySheet]  WITH CHECK ADD  CONSTRAINT [FK_DaySheet_TimeSheet] FOREIGN KEY([TimeSheetId])
REFERENCES [dbo].[TimeSheet] ([Id])
GO
ALTER TABLE [dbo].[DaySheet] CHECK CONSTRAINT [FK_DaySheet_TimeSheet]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
ALTER TABLE [dbo].[TimeSheet]  WITH CHECK ADD  CONSTRAINT [FK_TimeSheet_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([Id])
GO
ALTER TABLE [dbo].[TimeSheet] CHECK CONSTRAINT [FK_TimeSheet_Task]
GO
/****** Object:  StoredProcedure [dbo].[Pontaj]    Script Date: 8/9/2016 5:51:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--DROP PROCEDURE Pontaj
CREATE PROCEDURE [dbo].[Pontaj] (@nrOfWeek INT)
AS
BEGIN 
--IF OBJECT_ID('tempdb..#tabel1') IS NOT NULL
--	BEGIN
--		DROP TABLE #tabel1
--	END

--IF OBJECT_ID('tempdb..#tabelPivot') IS NOT NULL
--	BEGIN
--		DROP TABLE #tabelPivot
--	END

SELECT  Substring('Sun,Mon,Tue,Wed,Thu,Fri,Sat,Sun,Mon,Tue,Wed,Thu,Fri,Sat',
        (DATEPART(WEEKDAY,DS.Data)+@@datefirst-1)*4+1,3)AS Dayss , DS.WorkedHour, Ds.TimeSheetId,DS.Data
        INTO #tabel1
		from dbo.DaySheet DS
	--	SELECT * FROM #tabel1

		SELECT * INTO #tabelPivot FROM #tabel1
		PIVOT (SUM(WorkedHour)
		
		FOR Dayss in ([Sun],[Mon],[Tue],[Wed],[Thu],[Fri],[Sat])) AS DAd
		
	--	SELECT * FROM  #tabelPivot;

SELECT NEWID() AS [Guid], p.Name As Project, T.Name AS Task ,TS.Comment,
#tabelPivot.Mon,#tabelPivot.Tue,#tabelPivot.Wed ,#tabelPivot.Thu,#tabelPivot.Fri,#tabelPivot.Sat,#tabelPivot.Sun 
FROM dbo.Project p
INNER JOIN dbo.Task T ON p.Id=T.ProjectId 
INNER JOIN dbo.TimeSheet TS ON T.Id=TS.TaskId  
INNER JOIN #tabelPivot ON #tabelPivot.TimeSheetId=TS.Id
WHERE (select datepart(ww, #tabelPivot.Data))=(@nrOfWeek)
ORDER BY Project ASC, TASK ASC

END
GO
