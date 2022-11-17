CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select Id, FirstName, LastName, EmailAddress, Password, Role
	from dbo.[User];
end
