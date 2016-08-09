DROP TABLE #tabel1, #tabelPivot
SELECT  Substring('Sun,Mon,Tue,Wed,Thu,Fri,Sat,Sun,Mon,Tue,Wed,Thu,Fri,Sat',
        (DATEPART(WEEKDAY,DS.Data)+@@datefirst-1)*4+1,3)AS Dayss , DS.WorkedHour, Ds.TimeSheetId,DS.Data
        INTO #tabel1
		from dbo.DaySheet DS
		SELECT * FROM #tabel1

		SELECT * INTO #tabelPivot FROM #tabel1
		PIVOT (SUM(WorkedHour)
		
		FOR Dayss in ([Sun],[Mon],[Tue],[Wed],[Thu],[Fri],[Sat])) AS DAd
		
		SELECT * FROM  #tabelPivot;
			
SELECT  p.Name As Project, T.Name AS Task ,TS.Comment,
#tabelPivot.Mon,#tabelPivot.Tue,#tabelPivot.Wed ,#tabelPivot.Thu,#tabelPivot.Fri,#tabelPivot.Sat,#tabelPivot.Sun
FROM dbo.Project p
INNER JOIN dbo.Task T ON p.Id=T.ProjectId 
INNER JOIN dbo.TimeSheet TS ON T.Id=TS.TaskId  
INNER JOIN #tabelPivot ON #tabelPivot.TimeSheetId=TS.Id
