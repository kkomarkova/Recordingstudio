CREATE TABLE [dbo].[Favourite] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      NVARCHAR (450) NOT NULL,
    [CatalogueId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Favourite_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Favourite_Catalogue] FOREIGN KEY ([CatalogueId]) REFERENCES [dbo].[Catalogue] ([Id])
);

