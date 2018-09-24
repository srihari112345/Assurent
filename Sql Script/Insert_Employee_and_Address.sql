Declare @Id int
Set @Id = 1
DECLARE @Location TABLE (Name varchar(20))
INSERT INTO @Location VALUES ('Hydrebad')
INSERT INTO @Location VALUES ('Banglore')
INSERT INTO @Location VALUES ('Kochi')

DECLARE @BaseLocation NVARCHAR(30)
DECLARE @EmployeeTableOutput AS TABLE ( EmployeeId INT)
DECLARE @EmployeeId INT

WHILE @Id <= 2000
BEGIN 
	SET @BaseLocation = (SELECT TOP 1 Name FROM @Location ORDER BY NEWID())
	INSERT INTO Employee OUTPUT inserted.EmployeeId 
						 INTO @EmployeeTableOutput(EmployeeId) 
						 VALUES ('Name - ' + CAST(@Id as nvarchar(10)),
						          @BaseLocation)
	SELECT @EmployeeId = EmployeeId FROM @EmployeeTableOutput
	INSERT INTO Address VALUES( 'Line - 1', 'Line - 2 ','Line - 3', 'City', 'State', 'India', @EmployeeId)
	SET @Id = @Id + 1
END



