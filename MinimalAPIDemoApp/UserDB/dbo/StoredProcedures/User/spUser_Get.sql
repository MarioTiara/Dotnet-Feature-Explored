CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
begin
	select Id, FirstName, LastName,EmailAddress, Password
	from dbo.[User]
	where Id = @Id;
end
