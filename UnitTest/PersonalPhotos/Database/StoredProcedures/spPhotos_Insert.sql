CREATE PROCEDURE [dbo].[spPhotos_Insert]
	@Email varchar(50),
	@Description varchar(MAX),
	@FileName varchar(100)
AS
	declare @UserId int
	select @UserId=Id
	from dbo.Users
	where Email=@Email
	if @UserId is not null
	begin
		insert into dbo.Photos
		(UserId, [Description], [FileName])
		values (@UserId, @Description, @FileName)
	end
go