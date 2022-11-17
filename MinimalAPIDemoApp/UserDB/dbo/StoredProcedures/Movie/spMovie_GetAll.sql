CREATE PROCEDURE [dbo].[spMovie_GetAll]
AS
begin
	select Id, Title,Description,Rating
	from dbo.Movie
end

