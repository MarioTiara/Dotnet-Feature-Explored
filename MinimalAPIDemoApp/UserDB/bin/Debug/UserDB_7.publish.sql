/*
Deployment script for MinimalAPIDemo

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MinimalAPIDemo"
:setvar DefaultFilePrefix "MinimalAPIDemo"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQL19\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQL19\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The type for column Description in table [dbo].[Movie] is currently  VARCHAR (1000) NULL but is being changed to  VARCHAR (200) NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  VARCHAR (200) NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[Movie])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering Table [dbo].[Movie]...';


GO
ALTER TABLE [dbo].[Movie] ALTER COLUMN [Description] VARCHAR (200) NULL;


GO
PRINT N'Creating Procedure [dbo].[spUser_GetbyUserName]...';


GO
CREATE PROCEDURE [dbo].[spUser_GetbyUserName]
	@Username varchar(50)
AS
begin
	select Id, FirstName, LastName,EmailAddress, Password, Role
	from dbo.[User]
	where [UserName]=@Username
end
GO
PRINT N'Refreshing Procedure [dbo].[spMovie_Delete]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[spMovie_Delete]';


GO
PRINT N'Refreshing Procedure [dbo].[spMovie_Get]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[spMovie_Get]';


GO
PRINT N'Refreshing Procedure [dbo].[spMovie_GetAll]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[spMovie_GetAll]';


GO
PRINT N'Refreshing Procedure [dbo].[spMovie_Insert]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[spMovie_Insert]';


GO
PRINT N'Refreshing Procedure [dbo].[spMovie_Update]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[spMovie_Update]';


GO
if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (UserName, FirstName, LastName,EmailAddress, [Password],[Role])
	values ('TimeCorey','Tim', 'Corey','Corey@gmail.com', '123deqa', 'Adminstrator'),
	('StormSue','Sue', 'Storm','Sue.Storm@gmail.com','122asd','Standard'),
	('JohnSMith','John', 'Smith','JohnSmith@gmail.com','234dft','Adminstrator'),
	('JonesMary','Mary', 'Jones','MaryJones@gmail.com','azsa21','Standard');

	insert into dbo.Movie (Title, Description, Rating)
	values('Eternals', 'The saga of the Eternals, a race of immortal beings who lived on Earth and shaped its history and civilizations.',6.8),
	('Dune', 'Feature adaptation of Frank Herberts science fiction novel, about the son of a noble family entrusted with the protection of the most valuable asset and most vital element in the galaxy.',8.8),
	('The Harder They Fall', 'When an outlaw discovers his enemy is being released from prison, he reunites his gang to seek revenge in this Western.',8.8),
	('Red Notic', 'An Interpol agent tracks the worlds most wanted art thief.',6.4),
	('No Time to Die', 'James Bond has left active service. His peace is short-lived when Felix Leiter, an old friend from the CIA, turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology',7.4);
end
GO

GO
PRINT N'Update complete.';


GO
