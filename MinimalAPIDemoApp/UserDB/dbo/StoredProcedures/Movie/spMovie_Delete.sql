CREATE PROCEDURE [dbo].[spMovie_Delete]
@Id int
AS
begin
	delete
	from dbo.Movie
	where Id=@Id
end
