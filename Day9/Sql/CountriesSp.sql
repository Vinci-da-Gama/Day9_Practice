-- Create a new stored procedure called 'GrabAllCountries' in schema 'dbo'
-- Drop the stored procedure if it already exists
IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'GrabAllCountries'
)
DROP PROCEDURE GrabAllCountries
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE GrabAllCountries
AS
BEGIN
    -- Select rows from a Table or View 'Countries' in schema 'dbo'
    SELECT Distinct CountryName as Countries FROM Countries
END
GO

-- Fetch All Countries
Exec GrabAllCountries