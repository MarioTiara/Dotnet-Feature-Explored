CREATE PROCEDURE [dbo].[spUSer_Get]
	@Id int
AS
begin
	select Id,FirstName, LastName
	from dbo.[User]
	where Id=@Id
end
