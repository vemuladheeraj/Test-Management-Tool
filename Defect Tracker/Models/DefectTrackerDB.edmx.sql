
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/28/2019 21:01:24
-- Generated from EDMX file: C:\Users\vemul\Downloads\MyDefectTracker\MyDefectTracker\MyDefectTracker\Defect Tracker\Defect Tracker\Models\DefectTrackerDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Defect_Tracker];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Defects__r_id__2B3F6F97]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Defects] DROP CONSTRAINT [FK__Defects__r_id__2B3F6F97];
GO
IF OBJECT_ID(N'[dbo].[FK__Testexecu__comme__24927208]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Testexecution] DROP CONSTRAINT [FK__Testexecu__comme__24927208];
GO
IF OBJECT_ID(N'[dbo].[FK__TicketInf__T_Tes__1DE57479]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketInfo] DROP CONSTRAINT [FK__TicketInf__T_Tes__1DE57479];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[release]', 'U') IS NOT NULL
    DROP TABLE [dbo].[release];
GO
IF OBJECT_ID(N'[dbo].[Testexecution]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Testexecution];
GO
IF OBJECT_ID(N'[dbo].[TicketInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketInfo];
GO
IF OBJECT_ID(N'[dbo].[Defects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Defects];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'releases'
CREATE TABLE [dbo].[releases] (
    [R_Id] int IDENTITY(1,1) NOT NULL,
    [Release_Name] varchar(100)  NULL
);
GO

-- Creating table 'Testexecutions'
CREATE TABLE [dbo].[Testexecutions] (
    [TE_Id] int IDENTITY(1,1) NOT NULL,
    [T_Id] int  NOT NULL,
    [Testcases] int  NULL,
    [passed] int  NULL,
    [fail] int  NULL,
    [onhold] int  NULL,
    [defects] int  NULL,
    [comments] varchar(1000)  NULL
);
GO

-- Creating table 'TicketInfoes'
CREATE TABLE [dbo].[TicketInfoes] (
    [T_Id] int IDENTITY(1,1) NOT NULL,
    [R_ID] int  NULL,
    [T_Number] varchar(100)  NULL,
    [T_Desc] varchar(1000)  NULL,
    [T_State] varchar(100)  NULL,
    [T_Developer] varchar(100)  NULL,
    [T_Tester] varchar(100)  NULL
);
GO

-- Creating table 'Defects'
CREATE TABLE [dbo].[Defects] (
    [D_id] int IDENTITY(1,1) NOT NULL,
    [T_id] int  NULL,
    [r_id] int  NULL,
    [d_number] varchar(100)  NULL,
    [d_title] varchar(100)  NULL,
    [D_Description] varchar(1000)  NULL,
    [attachment] varbinary(max)  NULL,
    [Stepstorepro] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [R_Id] in table 'releases'
ALTER TABLE [dbo].[releases]
ADD CONSTRAINT [PK_releases]
    PRIMARY KEY CLUSTERED ([R_Id] ASC);
GO

-- Creating primary key on [TE_Id] in table 'Testexecutions'
ALTER TABLE [dbo].[Testexecutions]
ADD CONSTRAINT [PK_Testexecutions]
    PRIMARY KEY CLUSTERED ([TE_Id] ASC);
GO

-- Creating primary key on [T_Id] in table 'TicketInfoes'
ALTER TABLE [dbo].[TicketInfoes]
ADD CONSTRAINT [PK_TicketInfoes]
    PRIMARY KEY CLUSTERED ([T_Id] ASC);
GO

-- Creating primary key on [D_id] in table 'Defects'
ALTER TABLE [dbo].[Defects]
ADD CONSTRAINT [PK_Defects]
    PRIMARY KEY CLUSTERED ([D_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [r_id] in table 'Defects'
ALTER TABLE [dbo].[Defects]
ADD CONSTRAINT [FK__Defects__r_id__2B3F6F97]
    FOREIGN KEY ([r_id])
    REFERENCES [dbo].[releases]
        ([R_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Defects__r_id__2B3F6F97'
CREATE INDEX [IX_FK__Defects__r_id__2B3F6F97]
ON [dbo].[Defects]
    ([r_id]);
GO

-- Creating foreign key on [R_ID] in table 'TicketInfoes'
ALTER TABLE [dbo].[TicketInfoes]
ADD CONSTRAINT [FK__TicketInf__T_Tes__1DE57479]
    FOREIGN KEY ([R_ID])
    REFERENCES [dbo].[releases]
        ([R_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TicketInf__T_Tes__1DE57479'
CREATE INDEX [IX_FK__TicketInf__T_Tes__1DE57479]
ON [dbo].[TicketInfoes]
    ([R_ID]);
GO

-- Creating foreign key on [T_Id] in table 'Testexecutions'
ALTER TABLE [dbo].[Testexecutions]
ADD CONSTRAINT [FK__Testexecu__comme__24927208]
    FOREIGN KEY ([T_Id])
    REFERENCES [dbo].[TicketInfoes]
        ([T_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Testexecu__comme__24927208'
CREATE INDEX [IX_FK__Testexecu__comme__24927208]
ON [dbo].[Testexecutions]
    ([T_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------