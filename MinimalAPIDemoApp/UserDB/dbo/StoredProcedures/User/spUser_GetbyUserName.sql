CREATE PROCEDURE [dbo].[spUser_GetbyUserName]
	@Username varchar(50)
AS
begin
	select Id, [UserName],FirstName, LastName,EmailAddress, Password, Role
	from dbo.[User]
	where [UserName]=@Username
end
