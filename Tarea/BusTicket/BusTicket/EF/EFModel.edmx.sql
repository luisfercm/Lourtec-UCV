
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/08/2017 18:17:01
-- Generated from EDMX file: C:\BusTicket\BusTicket\EF\EFModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BDBusTicket];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ReservaLocalizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT [FK_ReservaLocalizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ReservaLocalizacion1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT [FK_ReservaLocalizacion1];
GO
IF OBJECT_ID(N'[dbo].[FK_LocalizacionRutas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rutas] DROP CONSTRAINT [FK_LocalizacionRutas];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Rutas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rutas];
GO
IF OBJECT_ID(N'[dbo].[Localizacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Localizacion];
GO
IF OBJECT_ID(N'[dbo].[Reserva]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reserva];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Rutas'
CREATE TABLE [dbo].[Rutas] (
    [IdRuta] uniqueidentifier  NOT NULL,
    [Chofer] nvarchar(60)  NOT NULL,
    [Compania] nvarchar(60)  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL,
    [Estaciones_IdLocalizacion] int  NOT NULL
);
GO

-- Creating table 'Localizacion'
CREATE TABLE [dbo].[Localizacion] (
    [IdLocalizacion] int IDENTITY(1,1) NOT NULL,
    [Estado] nvarchar(60)  NOT NULL,
    [Ciudad] nvarchar(60)  NOT NULL,
    [Pais] nvarchar(60)  NOT NULL,
    [Estacion] nvarchar(60)  NOT NULL
);
GO

-- Creating table 'Reserva'
CREATE TABLE [dbo].[Reserva] (
    [IdReserva] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Destino_IdLocalizacion] int  NOT NULL,
    [Salida_IdLocalizacion] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdRuta] in table 'Rutas'
ALTER TABLE [dbo].[Rutas]
ADD CONSTRAINT [PK_Rutas]
    PRIMARY KEY CLUSTERED ([IdRuta] ASC);
GO

-- Creating primary key on [IdLocalizacion] in table 'Localizacion'
ALTER TABLE [dbo].[Localizacion]
ADD CONSTRAINT [PK_Localizacion]
    PRIMARY KEY CLUSTERED ([IdLocalizacion] ASC);
GO

-- Creating primary key on [IdReserva] in table 'Reserva'
ALTER TABLE [dbo].[Reserva]
ADD CONSTRAINT [PK_Reserva]
    PRIMARY KEY CLUSTERED ([IdReserva] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Destino_IdLocalizacion] in table 'Reserva'
ALTER TABLE [dbo].[Reserva]
ADD CONSTRAINT [FK_ReservaLocalizacion]
    FOREIGN KEY ([Destino_IdLocalizacion])
    REFERENCES [dbo].[Localizacion]
        ([IdLocalizacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReservaLocalizacion'
CREATE INDEX [IX_FK_ReservaLocalizacion]
ON [dbo].[Reserva]
    ([Destino_IdLocalizacion]);
GO

-- Creating foreign key on [Salida_IdLocalizacion] in table 'Reserva'
ALTER TABLE [dbo].[Reserva]
ADD CONSTRAINT [FK_ReservaLocalizacion1]
    FOREIGN KEY ([Salida_IdLocalizacion])
    REFERENCES [dbo].[Localizacion]
        ([IdLocalizacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReservaLocalizacion1'
CREATE INDEX [IX_FK_ReservaLocalizacion1]
ON [dbo].[Reserva]
    ([Salida_IdLocalizacion]);
GO

-- Creating foreign key on [Estaciones_IdLocalizacion] in table 'Rutas'
ALTER TABLE [dbo].[Rutas]
ADD CONSTRAINT [FK_LocalizacionRutas]
    FOREIGN KEY ([Estaciones_IdLocalizacion])
    REFERENCES [dbo].[Localizacion]
        ([IdLocalizacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalizacionRutas'
CREATE INDEX [IX_FK_LocalizacionRutas]
ON [dbo].[Rutas]
    ([Estaciones_IdLocalizacion]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------