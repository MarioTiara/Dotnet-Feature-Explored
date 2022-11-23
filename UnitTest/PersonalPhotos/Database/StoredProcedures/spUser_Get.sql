CREATE PROCEDURE [dbo].[spUser_Get]
	@Email int
	
AS
begin
	select Id, Email, [Password]
	from dbo.Users
	where Email=@Email;
end