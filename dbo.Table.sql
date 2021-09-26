CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	Name int not null,
	Password nvarchar(max)
)
go
CREATE TABLE [dbo].[SMS]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	smscontext nvarchar(max),

	foreign key (Id) references dbo.Account(Id)
)
