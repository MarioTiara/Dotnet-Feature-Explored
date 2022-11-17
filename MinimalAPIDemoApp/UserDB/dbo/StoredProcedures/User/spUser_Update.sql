CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(50),
	@Password nvarchar (10)
AS
begin
	update dbo.[User]
	set FirstName = @FirstName, LastName = @LastName, EmailAddress=@EmailAddress, [Password]=@Password
	where Id = @Id;
end
