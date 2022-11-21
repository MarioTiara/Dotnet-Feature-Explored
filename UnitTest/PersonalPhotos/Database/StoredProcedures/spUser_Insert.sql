CREATE PROCEDURE [dbo].[spUser_Insert]
	@Email varchar(100),
	@Password varchar(100)
AS
begin
	Insert Into dbo.Users(Email, [Password])
	values (@Email, @Password);
end
