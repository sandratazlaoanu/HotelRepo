
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2019 21:58:21
-- Generated from EDMX file: D:\Uni\Second Year\Semestrul 2\MVP\Workspace\HotelRepo\Hotel\Hotel\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RoomSet'
CREATE TABLE [dbo].[RoomSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL,
    [isAvailable] nvarchar(max)  NOT NULL,
    [standardPrice] nvarchar(max)  NOT NULL,
    [Booking_id] int  NOT NULL
);
GO

-- Creating table 'ExtraServiceSet'
CREATE TABLE [dbo].[ExtraServiceSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(max)  NOT NULL,
    [price] nvarchar(max)  NOT NULL,
    [Booking_id] int  NOT NULL
);
GO

-- Creating table 'BookingSet'
CREATE TABLE [dbo].[BookingSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [start] nvarchar(max)  NOT NULL,
    [end] nvarchar(max)  NOT NULL,
    [isActive] nvarchar(max)  NOT NULL,
    [price] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'RoomSet'
ALTER TABLE [dbo].[RoomSet]
ADD CONSTRAINT [PK_RoomSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ExtraServiceSet'
ALTER TABLE [dbo].[ExtraServiceSet]
ADD CONSTRAINT [PK_ExtraServiceSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'BookingSet'
ALTER TABLE [dbo].[BookingSet]
ADD CONSTRAINT [PK_BookingSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Booking_id] in table 'ExtraServiceSet'
ALTER TABLE [dbo].[ExtraServiceSet]
ADD CONSTRAINT [FK_BookingExtraService]
    FOREIGN KEY ([Booking_id])
    REFERENCES [dbo].[BookingSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingExtraService'
CREATE INDEX [IX_FK_BookingExtraService]
ON [dbo].[ExtraServiceSet]
    ([Booking_id]);
GO

-- Creating foreign key on [Booking_id] in table 'RoomSet'
ALTER TABLE [dbo].[RoomSet]
ADD CONSTRAINT [FK_BookingRoom]
    FOREIGN KEY ([Booking_id])
    REFERENCES [dbo].[BookingSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingRoom'
CREATE INDEX [IX_FK_BookingRoom]
ON [dbo].[RoomSet]
    ([Booking_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------