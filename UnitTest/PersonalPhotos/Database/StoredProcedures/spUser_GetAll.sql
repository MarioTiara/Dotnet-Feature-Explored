CREATE PROCEDURE [dbo].[spUser_GetAll]

AS
begin
	select Id, Email, [Password]
	from dbo.Users;
end