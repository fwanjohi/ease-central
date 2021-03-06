USE [EaseCentral]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 3/25/2018 1:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](10) NOT NULL,
	[LastName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonAddress]    Script Date: 3/25/2018 1:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonAddress](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[StreetAddress] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](2) NOT NULL,
	[Zip] [nvarchar](5) NULL,
 CONSTRAINT [PK_PersonAddress] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonPhone]    Script Date: 3/25/2018 1:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonPhone](
	[PhoneId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_PersonPhone] PRIMARY KEY CLUSTERED 
(
	[PhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (1, N'Festus    ', N'Wanjohi   ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (2, N'Jane      ', N'Doe       ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (3, N'Anne      ', N'Smith     ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (4, N'Robert    ', N'Klein     ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (5, N'James     ', N'Joe       ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (6, N'Sue       ', N'Aikens    ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (7, N'Mary      ', N'Bee       ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (8, N'John      ', N'James     ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (9, N'Emma      ', N'Hill      ')
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName]) VALUES (10, N'Dilbert   ', N'Dill      ')
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[PersonAddress] ON 

INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (1, 1, N'1 California', N'SF', N'CA', N'99999')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (2, 1, N'55 california', N'SF', N'CA', N'99990')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (3, 2, N'3 Marland Street', N'Maryland', N'MD', N'09675')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (4, 2, N'3 Gill street', N'Bull Street', N'MA', N'09769')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (5, 3, N'2 marble Avenue', N'Bull Street', N'MA', N'09769')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (6, 4, N'marble Avenue', N'Bull Street', N'MA', N'09769')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (7, 5, N'marble Avenue', N'Bull Street', N'MA', N'09769')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (8, 5, N'77 Carl Street', N'ATL', N'GA', N'09769')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (9, 6, N'7 Oakland Ave', N'Oakland', N'CA', N'09769')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (10, 7, N'5 Jake Street', N'Las Vegas', N'NV', N'09769')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (11, 8, N'8', N'Bud City', N'IL', N'09769')
INSERT [dbo].[PersonAddress] ([AddressId], [PersonId], [StreetAddress], [City], [State], [Zip]) VALUES (12, 9, N'8', N'Cool Lane', N'TX', N'09769')
SET IDENTITY_INSERT [dbo].[PersonAddress] OFF
SET IDENTITY_INSERT [dbo].[PersonPhone] ON 

INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (1, 1, N'666-667-8769')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (2, 1, N'555-555-888')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (5, 3, N'333-889-9000')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (6, 4, N'4444444444')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (7, 5, N'7777777777')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (8, 6, N'9999999999')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (9, 7, N'1212121212')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (10, 2, N'343443444')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (11, 2, N'7877677666')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (12, 8, N'890996549')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (13, 9, N'890976521')
INSERT [dbo].[PersonPhone] ([PhoneId], [PersonId], [PhoneNumber]) VALUES (14, 10, N'11111111111')
SET IDENTITY_INSERT [dbo].[PersonPhone] OFF
ALTER TABLE [dbo].[PersonAddress]  WITH CHECK ADD  CONSTRAINT [FK_PersonAddress_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[PersonAddress] CHECK CONSTRAINT [FK_PersonAddress_Person]
GO
ALTER TABLE [dbo].[PersonPhone]  WITH CHECK ADD  CONSTRAINT [FK_PersonPhone_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[PersonPhone] CHECK CONSTRAINT [FK_PersonPhone_Person]
GO
