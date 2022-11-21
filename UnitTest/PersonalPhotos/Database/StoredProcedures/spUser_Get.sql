CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
	
AS
begin
	select Id, Email, [Password]
	from dbo.Users
	where Id=@Id;
end