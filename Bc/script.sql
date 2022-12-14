Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.10 initialized 'DBProjeto' using provider 'Microsoft.EntityFrameworkCore.SqlServer:6.0.10' with options: None
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Pedidos] (
    [PedidoId] int NOT NULL IDENTITY,
    [Data] datetime2 NOT NULL,
    [Cliente] nvarchar(max) NOT NULL,
    [Produtos] nvarchar(max) NOT NULL,
    [Total] float NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([PedidoId])
);
GO

CREATE TABLE [Users] (
    [UserId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Sa] bit NOT NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [Rua] nvarchar(max) NULL,
    [Numero] int NULL,
    [CEP] int NULL,
    [Cidade] nvarchar(max) NULL,
    [Salario] float NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [Carrinhos] (
    [CarrinhoId] int NOT NULL IDENTITY,
    [ClienteUserId] int NOT NULL,
    CONSTRAINT [PK_Carrinhos] PRIMARY KEY ([CarrinhoId]),
    CONSTRAINT [FK_Carrinhos_Users_ClienteUserId] FOREIGN KEY ([ClienteUserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Produtos] (
    [ProdutoId] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Preco] float NOT NULL,
    [Tag] nvarchar(max) NOT NULL,
    [CarrinhoId] int NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([ProdutoId]),
    CONSTRAINT [FK_Produtos_Carrinhos_CarrinhoId] FOREIGN KEY ([CarrinhoId]) REFERENCES [Carrinhos] ([CarrinhoId])
);
GO

CREATE INDEX [IX_Carrinhos_ClienteUserId] ON [Carrinhos] ([ClienteUserId]);
GO

CREATE INDEX [IX_Produtos_CarrinhoId] ON [Produtos] ([CarrinhoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221122015029_V1', N'6.0.10');
GO

COMMIT;
GO


