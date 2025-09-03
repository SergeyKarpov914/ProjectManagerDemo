IF OBJECT_ID(N'[dbo].[Task]', 'U') IS NOT NULL AND EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Task_Project]') AND parent_object_id = OBJECT_ID(N'[dbo].[Task]'))
    ALTER TABLE [dbo].[Task] DROP CONSTRAINT [FK_Task_Project]
GO

IF OBJECT_ID(N'[dbo].[Task]', 'U') IS NOT NULL AND EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Task]') AND name = N'AK_Task_Code')
    DROP INDEX [AK_Task_Code] ON [dbo].[Task]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectType]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectType]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deliverable]') AND type in (N'U'))
DROP TABLE [dbo].[Deliverable]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
DROP TABLE [dbo].[Client]
GO


IF OBJECT_ID(N'[dbo].[Task]', 'U') IS NOT NULL AND EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Task_Project]') AND parent_object_id = OBJECT_ID(N'[dbo].[Task]'))
    ALTER TABLE [dbo].[Task] DROP CONSTRAINT [FK_Task_Project]
GO


IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL AND EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Project_ProjectRateSchedule]') AND parent_object_id = OBJECT_ID(N'[dbo].[Project]'))
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_Project_ProjectRateSchedule]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Task]') AND type in (N'U'))
DROP TABLE [dbo].[Task]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectType]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project]') AND type in (N'U'))
DROP TABLE [dbo].[Project]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deliverable]') AND type in (N'U'))
DROP TABLE [dbo].[Deliverable]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Client]') AND type in (N'U'))
DROP TABLE [dbo].[Client]
GO
