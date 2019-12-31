CREATE TABLE [dbo].[ToDoList] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Status]      INT            NOT NULL,
    [Priority]    INT            NOT NULL,
    [DueDate]     DATETIME       NULL,
    [CreatedOn]   DATETIME       NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [ModifiedOn]  DATETIME       NULL,
    [ModifiedBy]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ToDoList] PRIMARY KEY CLUSTERED ([Id] ASC)
);

