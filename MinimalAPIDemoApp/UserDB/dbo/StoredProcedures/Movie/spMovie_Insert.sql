CREATE PROCEDURE [dbo].[spMovie_Insert]
	@Title nvarchar(50),
	@Description nvarchar(100),
	@Rating float
AS
begin
	insert into dbo.Movie (Title, Description, Rating)
	values (@Title, @Description, @Rating);
end