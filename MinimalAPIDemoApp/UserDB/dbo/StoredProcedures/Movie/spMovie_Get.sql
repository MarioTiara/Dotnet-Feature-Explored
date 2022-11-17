CREATE PROCEDURE [dbo].[spMovie_Get]
	@Id int
AS
begin
	select Id, Title, Description, Rating
	from dbo.Movie
	where Id=@Id;
end
