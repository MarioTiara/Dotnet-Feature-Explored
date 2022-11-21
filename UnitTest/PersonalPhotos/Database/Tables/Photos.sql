﻿CREATE TABLE [dbo].[Photos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL  FOREIGN KEY REFERENCES dbo.Users(Id), 
    [Description] VARCHAR(MAX) NULL, 
    [FileName] VARCHAR(100) NULL
)
