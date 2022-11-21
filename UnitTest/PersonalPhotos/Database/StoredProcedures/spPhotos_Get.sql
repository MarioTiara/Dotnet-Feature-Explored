CREATE PROCEDURE [dbo].[spPhotos_Get]
	@Email varchar(50)
AS
	Declare @UserId int
	Select @UserId = Id
	From Users
	Where Email=@Email

	if (@UserId is not null)
	Begin
		Select Id, UserId,[Description], [FileName]
		From Photos	
		Where UserId = @UserId;
	End;
Go
