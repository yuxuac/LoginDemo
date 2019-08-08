CREATE TABLE [dbo].[Users]
(
	[Id]            INT NOT NULL PRIMARY KEY,
	[UserName]      NVARCHAR(200) UNIQUE NOT NULL,
	[Password]      NVARCHAR(200) NOT NULL,
	[DisplayName]   NVARCHAR(200) NULL,
	[LoginTime]     DATETIME NULL,
	[LogoffTime]    DATETIME NULL,
	[UpdateTime]    DATETIME NULL, 
    [ImgUrl]        NVARCHAR(200) NULL,
	[IsDeleted]     BIT NULL,
)
GO

CREATE NONCLUSTERED INDEX [IX_Users_UserName] ON [dbo].[Users] (UserName ASC)
GO

CREATE NONCLUSTERED INDEX [IX_Users_DisplayName] ON [dbo].[Users] (DisplayName ASC)
GO

CREATE NONCLUSTERED INDEX [IX_Users_LoginTime] ON [dbo].[Users] (LoginTime ASC)
GO

CREATE NONCLUSTERED INDEX [IX_Users_LogoffTime] ON [dbo].[Users] (LogoffTime ASC)
GO

CREATE NONCLUSTERED INDEX [IX_Users_UpdateTime] ON [dbo].[Users] (UpdateTime ASC)
GO

CREATE NONCLUSTERED INDEX [IX_Users_ImgUrl] ON [dbo].[Users] (ImgUrl ASC)
GO

CREATE NONCLUSTERED INDEX [IX_Users_IsDeleted] ON [dbo].[Users] (IsDeleted ASC)
GO