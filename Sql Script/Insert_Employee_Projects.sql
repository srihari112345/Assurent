DECLARE @Count INT
DECLARE @CountProject INT
DECLARE @ProjectId INT
DECLARE @EmployeeCursor CURSOR 
DECLARE @ProjectCursor CURSOR
DECLARE @EmployeeId INT
DECLARE @NumberOfProjects INT

SET @Count = 1 
SET @CountProject = 1
SET @EmployeeCursor = CURSOR FOR
				select top 2000 EmployeeId from Employee

SET @ProjectCursor =  CURSOR SCROLL FOR SELECT ProjectId from Project


OPEN @ProjectCursor
FETCH NEXT FROM @ProjectCursor INTO @ProjectId
OPEN @EmployeeCursor
FETCH NEXT FROM @EmployeeCursor INTO @EmployeeId 

WHILE @@FETCH_STATUS = 0
BEGIN
	IF @Count <= 2000
	BEGIN
		SET @CountProject = 1	
		SELECT @NumberOfProjects = ROUND(((5 - 1 -1) * RAND() + 1), 0)
		IF @ProjectId = ( SELECT TOP 1 ProjectId FROM Project ORDER BY ProjectId DESC )
		BEGIN 
			FETCH FIRST FROM @ProjectCursor
		END	
		WHILE @CountProject <= @NumberOfProjects
		BEGIN
			INSERT INTO ProjectEngagement Values ( @EmployeeId , @ProjectId )
			FETCH NEXT FROM @ProjectCursor INTO @ProjectId		  
			SET @CountProject = @CountProject + 1
		END	   
		SET @Count = @Count + 1
	END
	FETCH NEXT FROM @EmployeeCursor 
	INTO @EmployeeId
	Print @EmployeeId
END

CLOSE @EmployeeCursor	
DEALLOCATE @EmployeeCursor
CLOSE @ProjectCursor
DEALLOCATE @ProjectCursor
