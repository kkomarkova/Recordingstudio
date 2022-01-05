CREATE TABLE [dbo].[Artist] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (50)   NOT NULL,
    [LastName]  VARCHAR (50)   NOT NULL,
    [UserId]    NVARCHAR (450) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Artist_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

