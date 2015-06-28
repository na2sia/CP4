
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/28/2015 20:24:20
-- Generated from EDMX file: D:\Natasha\!!Trening ASP.NET\Projects\CheckPoint4\CheckPoint4\DBModel\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBSales];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientSales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesSet] DROP CONSTRAINT [FK_ClientSales];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerSales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesSet] DROP CONSTRAINT [FK_ManagerSales];
GO
IF OBJECT_ID(N'[dbo].[FK_GoodsSales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SalesSet] DROP CONSTRAINT [FK_GoodsSales];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientSet];
GO
IF OBJECT_ID(N'[dbo].[ManagerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManagerSet];
GO
IF OBJECT_ID(N'[dbo].[GoodsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GoodsSet];
GO
IF OBJECT_ID(N'[dbo].[SalesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SalesSet];
GO
IF OBJECT_ID(N'[dbo].[FilesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilesSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NULL,
    [LastName] nvarchar(max)  NULL
);
GO

-- Creating table 'ManagerSet'
CREATE TABLE [dbo].[ManagerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NULL
);
GO

-- Creating table 'GoodsSet'
CREATE TABLE [dbo].[GoodsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] float  NULL
);
GO

-- Creating table 'SalesSet'
CREATE TABLE [dbo].[SalesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Cost] float  NOT NULL,
    [ClientId] int  NOT NULL,
    [ManagerId] int  NOT NULL,
    [GoodsId] int  NOT NULL
);
GO

-- Creating table 'FilesSet'
CREATE TABLE [dbo].[FilesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [PK_ManagerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GoodsSet'
ALTER TABLE [dbo].[GoodsSet]
ADD CONSTRAINT [PK_GoodsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SalesSet'
ALTER TABLE [dbo].[SalesSet]
ADD CONSTRAINT [PK_SalesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FilesSet'
ALTER TABLE [dbo].[FilesSet]
ADD CONSTRAINT [PK_FilesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ClientId] in table 'SalesSet'
ALTER TABLE [dbo].[SalesSet]
ADD CONSTRAINT [FK_ClientSales]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[ClientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientSales'
CREATE INDEX [IX_FK_ClientSales]
ON [dbo].[SalesSet]
    ([ClientId]);
GO

-- Creating foreign key on [ManagerId] in table 'SalesSet'
ALTER TABLE [dbo].[SalesSet]
ADD CONSTRAINT [FK_ManagerSales]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[ManagerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerSales'
CREATE INDEX [IX_FK_ManagerSales]
ON [dbo].[SalesSet]
    ([ManagerId]);
GO

-- Creating foreign key on [GoodsId] in table 'SalesSet'
ALTER TABLE [dbo].[SalesSet]
ADD CONSTRAINT [FK_GoodsSales]
    FOREIGN KEY ([GoodsId])
    REFERENCES [dbo].[GoodsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GoodsSales'
CREATE INDEX [IX_FK_GoodsSales]
ON [dbo].[SalesSet]
    ([GoodsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------