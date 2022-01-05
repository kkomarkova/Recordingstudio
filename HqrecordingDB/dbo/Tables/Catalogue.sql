CREATE TABLE [dbo].[Catalogue] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Title]         VARCHAR (255)  NOT NULL,
    [Description]   VARCHAR (MAX)  NULL,
    [Image]         NVARCHAR (MAX) NULL,
    [ArtistId]      INT            NULL,
    [Price]         SMALLMONEY     NULL,
    [Tracklength]   VARCHAR (8)    NULL,
    [DateCreated]   SMALLDATETIME  DEFAULT (getdate()) NOT NULL,
    [DatePublished] NCHAR (10)     DEFAULT (getdate()) NULL,
    [ParentId]      INT            NULL,
    [SoundCatId]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Catalogue_Artist] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([Id]),
    CONSTRAINT [FK_Catalogue_Catalogue] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Catalogue] ([Id]),
    CONSTRAINT [FK_Catalogue_ToTable] FOREIGN KEY ([SoundCatId]) REFERENCES [dbo].[SoundCategory] ([Id])
);

