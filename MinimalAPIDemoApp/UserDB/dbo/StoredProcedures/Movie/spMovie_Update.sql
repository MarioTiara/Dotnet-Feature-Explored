CREATE PROCEDURE [dbo].[spMovie_Update]
	@Id int,
	@Title nvarchar (50),
	@Description nvarchar(100),
	@Rating float
AS
begin
	update dbo.Movie
	set Title=@Title, Description=@Description, Rating=@Rating
	where Id=@Id;
end
