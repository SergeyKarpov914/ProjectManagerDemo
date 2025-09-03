INSERT INTO [dbo].[ProjectType] VALUES ('00 - Study','00')
INSERT INTO [dbo].[ProjectType] VALUES ('10 - Design','10')
INSERT INTO [dbo].[ProjectType] VALUES ('20 - Construction Srv. Periodic Inspection','20')
INSERT INTO [dbo].[ProjectType] VALUES ('30 - Construction Srv. Resident Engineer','30')
INSERT INTO [dbo].[ProjectType] VALUES ('40 - Design Services (Design Build)','40')
INSERT INTO [dbo].[ProjectType] VALUES ('50 - Construction Services (Design Build)','50')
INSERT INTO [dbo].[ProjectType] VALUES ('60 - Program Mgmt. & Owner Advisory','60')
INSERT INTO [dbo].[ProjectType] VALUES ('70 - O&M Manual','70')
INSERT INTO [dbo].[ProjectType] VALUES ('80 - Startup & Training','80')
INSERT INTO [dbo].[ProjectType] VALUES ('90 - Warranty','90')
INSERT INTO [dbo].[ProjectType] VALUES ('IN - In Kind Services','IN')

INSERT [dbo].[Employee] ([Id], [Name], [Code], [FirstName], [LastName], [DLRate], [MiddleName], [Username], [LocationCode], [Discipline], [JobGroupDescription], [StatusCategoryDescription], [RBTOrgLevel], [CorporateTitle], [Classification], [OHRate]) VALUES (1, N'M.Richard', N'4546', N'TestMonte', N'Richard', 120, NULL, NULL, NULL, N'Instrumentation and Control', N'Engineering', NULL, NULL, NULL, N'ES VIII', 1.8)
INSERT [dbo].[Employee] ([Id], [Name], [Code], [FirstName], [LastName], [DLRate], [MiddleName], [Username], [LocationCode], [Discipline], [JobGroupDescription], [StatusCategoryDescription], [RBTOrgLevel], [CorporateTitle], [Classification], [OHRate]) VALUES (2, N'N.Evenson', N'5236', N'TestNathan', N'Evenson', 45, NULL, NULL, NULL, N'Construction (Field)', N'Construction Services Group', NULL, NULL, NULL, N'ES VI', 1.55)
INSERT [dbo].[Employee] ([Id], [Name], [Code], [FirstName], [LastName], [DLRate], [MiddleName], [Username], [LocationCode], [Discipline], [JobGroupDescription], [StatusCategoryDescription], [RBTOrgLevel], [CorporateTitle], [Classification], [OHRate]) VALUES (3, N'M.Tevebaugh', N'5242', N'TestMatthew', N'Tevebaugh', 55, NULL, NULL, NULL, N'Electrical', N'Engineering', NULL, NULL, NULL, N'ES VIII', 1.8)
INSERT [dbo].[Employee] ([Id], [Name], [Code], [FirstName], [LastName], [DLRate], [MiddleName], [Username], [LocationCode], [Discipline], [JobGroupDescription], [StatusCategoryDescription], [RBTOrgLevel], [CorporateTitle], [Classification], [OHRate]) VALUES (4, N'A.Willyard', N'5418', N'TestAlexandria', N'Willyard', 45, NULL, NULL, NULL, N'Instrumentation and Control', N'Designer', NULL, NULL, NULL, N'EA VI', 1.8)
INSERT [dbo].[Employee] ([Id], [Name], [Code], [FirstName], [LastName], [DLRate], [MiddleName], [Username], [LocationCode], [Discipline], [JobGroupDescription], [StatusCategoryDescription], [RBTOrgLevel], [CorporateTitle], [Classification], [OHRate]) VALUES (5, N'V.Jolomi', N'5601', N'TestVaughn', N'Jolomi', 45, NULL, NULL, NULL, N'Electrical', N'CAD/BIM', NULL, NULL, NULL, N'ET VI', 1.8)
INSERT [dbo].[Employee] ([Id], [Name], [Code], [FirstName], [LastName], [DLRate], [MiddleName], [Username], [LocationCode], [Discipline], [JobGroupDescription], [StatusCategoryDescription], [RBTOrgLevel], [CorporateTitle], [Classification], [OHRate]) VALUES (6, N'R.DeFreitas', N'6611', N'TestRichard', N'DeFreitas', 65, NULL, NULL, NULL, N'Instrumentation and Control', N'Engineering', NULL, NULL, NULL, N'ES VI', 1.8)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployeeRate] ON 

SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (14, N'Project Management', N'100', 1, 0, CAST(0.00 AS Numeric(7, 2)), 15, CAST(N'2025-01-14' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (15, N'Project Management Coordination', N'100.01', 1, 14, CAST(0.00 AS Numeric(7, 2)), 3, CAST(N'2025-01-14' AS Date), CAST(N'2025-01-14' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (16, N'Project Kickoff Meeting', N'100.02', 1, 14, CAST(0.00 AS Numeric(7, 2)), 2, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (17, N'90 % Design Development', N'200', 1, 0, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (18, N'Field Investigation and Data Collection', N'200.01', 1, 17, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (19, N'Wireless Coverage Study', N'200.02', 1, 17, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (20, N'Workshops', N'200.03', 1, 17, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (21, N'90% Design Deliverable', N'200.04', 1, 17, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (22, N'100% Design Development', N'300', 1, 0, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (23, N'CONTRACTOR Pre-Qualification', N'300.01', 1, 22, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (24, N'Workshops', N'300.02', 1, 22, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (25, N'100% Design Deliverable', N'300.03', 1, 22, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
INSERT [dbo].[Task] ([Id], [Name], [Code], [ProjectId], [ParentTaskId], [Percent], [ODCFee], [StartDate], [EndDate]) VALUES (45, N'Add one more task', N'300.04', 1, 22, CAST(0.00 AS Numeric(7, 2)), 0, CAST(N'2025-01-17' AS Date), CAST(N'2025-01-17' AS Date))
SET IDENTITY_INSERT [dbo].[Task] OFF
GO

