CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@Email varchar(50),
	@Password varchar(10)
AS
begin
	update dbo.Users 
	set Email=@Email, [Password]=@Password
	where Id=@Id;
end
