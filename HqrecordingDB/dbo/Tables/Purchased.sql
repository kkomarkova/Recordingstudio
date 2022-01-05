CREATE TABLE [dbo].[Purchased] (
    [Id]      INT NOT NULL,
    [TrackId] INT NOT NULL,
    [PackId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Purchased_Catalogue] FOREIGN KEY ([TrackId]) REFERENCES [dbo].[Catalogue] ([Id]),
    CONSTRAINT [FK_Purchased_Pack] FOREIGN KEY ([PackId]) REFERENCES [dbo].[Pack] ([Id])
);

