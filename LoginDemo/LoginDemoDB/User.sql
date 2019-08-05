CREATE TABLE [dbo].[User]
(
	[Id]            INT NOT NULL PRIMARY KEY,
	[UserName]      NVARCHAR(200) NOT NULL,
	[Password]      NVARCHAR(200) NOT NULL,
	[DisplayName]   NVARCHAR(200) NULL,
	[LoginTime]     DATETIME NULL,
	[LogoffTime]    DATETIME NULL,
	[UpdateTime]    DATETIME NULL,
)
GO

CREATE NONCLUSTERED INDEX [IX_User_UserName] ON [dbo].[User] (UserName ASC)
GO

CREATE NONCLUSTERED INDEX [IX_User_DisplayName] ON [dbo].[User] (DisplayName ASC)
GO

CREATE NONCLUSTERED INDEX [IX_User_LoginTime] ON [dbo].[User] (LoginTime ASC)
GO

CREATE NONCLUSTERED INDEX [IX_User_LogoffTime] ON [dbo].[User] (LogoffTime ASC)
GO

CREATE NONCLUSTERED INDEX [IX_User_UpdateTime] ON [dbo].[User] (UpdateTime ASC)
GO