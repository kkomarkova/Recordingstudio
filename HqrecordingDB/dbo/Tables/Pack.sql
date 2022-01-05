CREATE TABLE [dbo].[Pack] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [PackName]      VARCHAR (100)  NOT NULL,
    [Description]   VARCHAR (MAX)  NULL,
    [PackImage]     NVARCHAR (MAX) NULL,
    [DateCreated]   SMALLDATETIME  DEFAULT (getdate()) NOT NULL,
    [DatePublished] SMALLDATETIME  DEFAULT (getdate()) NULL,
    [Price]         SMALLMONEY     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

