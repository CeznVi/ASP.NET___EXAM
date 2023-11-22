USE [usersdb]
GO

/****** Объект: Table [dbo].[data] Дата скрипта: 20.11.2023 22:39:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[data] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX)  NOT NULL,
    [Description] NVARCHAR (MAX)  NOT NULL,
    [Img]         NVARCHAR (MAX)  NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL
);


