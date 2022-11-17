CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(50),
	@Password nvarchar (10)
AS
begin
	insert into dbo.[User] (FirstName, LastName,EmailAddress, [Password])
	values (@FirstName, @LastName, @EmailAddress,@Password);
end
