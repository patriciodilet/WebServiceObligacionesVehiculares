/****** Objeto: Table [dbo].[Vehiculo] Fecha del script: 05-02-2021 1:44:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vehiculo] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Patente]  VARCHAR (50) NULL,
    [IdModelo] INT          NOT NULL
);

/****** Objeto: Table [dbo].[PermisoCirculacion] Fecha del script: 05-02-2021 1:44:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PermisoCirculacion] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [ValorPermiso] INT NULL,
    [IdModelo]     INT NOT NULL
);

/****** Objeto: Table [dbo].[Pago] Fecha del script: 05-02-2021 1:43:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pago] (
    [Id]         INT NOT NULL,
    [IdMulta]    INT NULL,
    [IdVehiculo] INT NULL,
    [ValorPago]  INT NULL
);

/****** Objeto: Table [dbo].[Multa] Fecha del script: 05-02-2021 1:43:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Multa] (
    [Id]         INT NOT NULL,
    [ValorMulta] INT NULL,
    [IdVehiculo] INT NULL
);

USE [DBObligacionesVehiculares]
GO

/****** Objeto: Table [dbo].[Modelo] Fecha del script: 05-02-2021 1:42:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Modelo] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Modelo] VARCHAR (50) NULL
);

