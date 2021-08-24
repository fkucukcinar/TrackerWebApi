# TrackerWebApi
employee tracking web app
This project has three sub projects
 1. Tracker Web Api - is responsible for the back end rest services
 2. Web App - is responsible for the front end side of the project.
 3. Tracker Web Api Test - is the test side of the backend codes.

This project has been used mssql db. so you can find the create script of the tables below.

***** Track Table **************
CREATE TABLE [dbo].[Track](
	[TrackId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[EntranceTime] [datetime] NULL,
	[LeaveTime] [datetime] NULL,
	[TrackDay] [datetime] NULL,
 CONSTRAINT [PK_Track2] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

***** User Table ***************
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[UserName] [nvarchar](250) NULL,
	[Password] [nvarchar](250) NULL,
	[IsAdmin] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
