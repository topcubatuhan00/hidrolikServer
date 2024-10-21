DROP DATABASE TaskAssignment
CREATE DATABASE TaskAssignment
USE TaskAssignment


create table [User](
	[Id] int identity(1,1),
	[Name] nvarchar(50) not null,
	[LastName] nvarchar(50) not null,
	[UserName] nvarchar(50) not null,
	[Email] nvarchar(50) not null,
	[Password] nvarchar(MAX) not null,
	[Role] nvarchar(50) not null,
	[CreatedDate] datetime,
	[CreatorName] nvarchar(100),
	[UpdatedDate] datetime,
	[UpdaterName] nvarchar(100),
	[DeletedDate] datetime,
	[DeleterName] nvarchar(100),
	[IsActive] bit not null,
	primary key(Id),
)

create table [Mission](
	[Id] int identity(1,1),
	[Name] nvarchar(50) not null,
	[Descripton] nvarchar(100) not null,
	[Status] nvarchar(50) not null,
	[Priority] nvarchar(50) not null,
	[EstimatedEndDate] Date not null,
	[UserId] int not null,
	[Ticket] nvarchar(50) not null,
	[CreatedDate] datetime,
	[CreatorName] nvarchar(100),
	[UpdatedDate] datetime,
	[UpdaterName] nvarchar(100),
	[DeletedDate] datetime,
	[DeleterName] nvarchar(100),
	[IsActive] bit not null,
	primary key(Id),
)

create table [Comment](
	[Id] int identity(1,1),
	[Title] nvarchar(50) not null,
	[Content] nvarchar(100) not null,
	[UserId] int not null,
	[MissionId] int not null,
	[FilePathName] nvarchar(50) not null,
	[CreatedDate] datetime,
	[CreatorName] nvarchar(100),
	[UpdatedDate] datetime,
	[UpdaterName] nvarchar(100),
	[DeletedDate] datetime,
	[DeleterName] nvarchar(100),
	[IsActive] bit not null,
	primary key(Id),
)

create table [AutoReminder](
	[Id] int identity(1,1),
	[CycleTime] Date not null,
	[MissionId] int not null,
	[CreatedDate] datetime,
	[CreatorName] nvarchar(100),
	[UpdatedDate] datetime,
	[UpdaterName] nvarchar(100),
	[DeletedDate] datetime,
	[DeleterName] nvarchar(100),
	[IsActive] bit not null,
	primary key(Id),
)

create table [Tickets](
	[Id] int identity(1,1),
	[Name] nvarchar(50) not null,
	primary key(Id),
)

create table [Notification](
	[Id] int identity(1,1),
	[Content] nvarchar(50) not null,
	[UserId] int not null,
	primary key(Id),
)