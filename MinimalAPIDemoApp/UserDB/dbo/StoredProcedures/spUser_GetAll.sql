CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select Id, FirstName, LastName, EmailAddress, Password
	from dbo.[User];
end
