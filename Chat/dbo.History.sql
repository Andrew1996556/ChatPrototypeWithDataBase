CREATE TABLE [dbo].[History] (
    [Id]       INT           NOT NULL,
    [UserName] VARCHAR (15)  NOT NULL,
    [Message]  VARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

SELECT 

