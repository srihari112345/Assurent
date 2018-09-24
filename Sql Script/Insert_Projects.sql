DECLARE @Count INT
SET @Count = 1
WHILE @Count <= 250
BEGIN
	INSERT INTO Project VALUES ( 'Project -' + CAST(@Count as nchar(10)))
	SET @Count = @Count + 1
END 