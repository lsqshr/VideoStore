
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/15/2013 23:42:09
-- Generated from EDMX file: C:\Users\siqi\Dropbox\VideoStoreWithRolesS12012(3)\VideoStore.Entities\VideoStore.Business.Entities\VideoStoreEntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Videos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DeliveryOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_DeliveryOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOrderItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItems] DROP CONSTRAINT [FK_OrderOrderItem];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_CustomerOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerLoginCredential]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_CustomerLoginCredential];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderItemMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderItems] DROP CONSTRAINT [FK_OrderItemMedia];
GO
IF OBJECT_ID(N'[dbo].[FK_MediaStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stocks] DROP CONSTRAINT [FK_MediaStock];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMedia_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserMedia] DROP CONSTRAINT [FK_UserMedia_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMedia_Media]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserMedia] DROP CONSTRAINT [FK_UserMedia_Media];
GO
IF OBJECT_ID(N'[dbo].[FK_RecommendationLikeMatching]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LikeMatchings] DROP CONSTRAINT [FK_RecommendationLikeMatching];
GO
IF OBJECT_ID(N'[dbo].[FK_LikeMatchingMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LikeMatchings] DROP CONSTRAINT [FK_LikeMatchingMedia];
GO
IF OBJECT_ID(N'[dbo].[FK_RecommendationLikeMatching1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LikeMatchings] DROP CONSTRAINT [FK_RecommendationLikeMatching1];
GO
IF OBJECT_ID(N'[dbo].[FK_RecommendationMedia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Recommendations] DROP CONSTRAINT [FK_RecommendationMedia];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Deliveries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Deliveries];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[OrderItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderItems];
GO
IF OBJECT_ID(N'[dbo].[Stocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stocks];
GO
IF OBJECT_ID(N'[dbo].[LoginCredentials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginCredentials];
GO
IF OBJECT_ID(N'[dbo].[Media]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Media];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Recommendations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recommendations];
GO
IF OBJECT_ID(N'[dbo].[LikeMatchings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LikeMatchings];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO
IF OBJECT_ID(N'[dbo].[UserMedia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserMedia];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Revision] timestamp NOT NULL,
    [LoginCredential_Id] int  NOT NULL
);
GO

-- Creating table 'Deliveries'
CREATE TABLE [dbo].[Deliveries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DeliveryDate] datetime  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Warehouse] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Total] float  NULL,
    [OrderDate] datetime  NOT NULL,
    [Warehouse] nvarchar(max)  NULL,
    [Store] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [DeliveryOrder_Order_Id] int  NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'OrderItems'
CREATE TABLE [dbo].[OrderItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [OrderOrderItem_OrderItem_Id] int  NOT NULL,
    [Media_Id] int  NOT NULL
);
GO

-- Creating table 'Stocks'
CREATE TABLE [dbo].[Stocks] (
    [Id] uniqueidentifier  NOT NULL,
    [Warehouse] nvarchar(max)  NOT NULL,
    [Holding] int  NULL,
    [Media_Id] int  NOT NULL
);
GO

-- Creating table 'LoginCredentials'
CREATE TABLE [dbo].[LoginCredentials] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(30)  NOT NULL,
    [EncryptedPassword] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Media'
CREATE TABLE [dbo].[Media] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Director] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Price] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Recommendations'
CREATE TABLE [dbo].[Recommendations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Revision] timestamp  NOT NULL,
    [Medium_Id] int  NOT NULL
);
GO

-- Creating table 'LikeMatchings'
CREATE TABLE [dbo].[LikeMatchings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [count] int  NOT NULL,
    [RecommendationId] int  NOT NULL,
    [Revision] timestamp  NOT NULL,
    [Medium_Id] int  NOT NULL,
    [RecommendationLikeMatching1_LikeMatching_Id] int  NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [User_Id] int  NOT NULL,
    [Roles_Id] int  NOT NULL
);
GO

-- Creating table 'UserMedia'
CREATE TABLE [dbo].[UserMedia] (
    [Users_Id] int  NOT NULL,
    [Medium_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Deliveries'
ALTER TABLE [dbo].[Deliveries]
ADD CONSTRAINT [PK_Deliveries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [PK_OrderItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [PK_Stocks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LoginCredentials'
ALTER TABLE [dbo].[LoginCredentials]
ADD CONSTRAINT [PK_LoginCredentials]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Media'
ALTER TABLE [dbo].[Media]
ADD CONSTRAINT [PK_Media]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Recommendations'
ALTER TABLE [dbo].[Recommendations]
ADD CONSTRAINT [PK_Recommendations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LikeMatchings'
ALTER TABLE [dbo].[LikeMatchings]
ADD CONSTRAINT [PK_LikeMatchings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [User_Id], [Roles_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY NONCLUSTERED ([User_Id], [Roles_Id] ASC);
GO

-- Creating primary key on [Users_Id], [Medium_Id] in table 'UserMedia'
ALTER TABLE [dbo].[UserMedia]
ADD CONSTRAINT [PK_UserMedia]
    PRIMARY KEY NONCLUSTERED ([Users_Id], [Medium_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DeliveryOrder_Order_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_DeliveryOrder]
    FOREIGN KEY ([DeliveryOrder_Order_Id])
    REFERENCES [dbo].[Deliveries]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DeliveryOrder'
CREATE INDEX [IX_FK_DeliveryOrder]
ON [dbo].[Orders]
    ([DeliveryOrder_Order_Id]);
GO

-- Creating foreign key on [OrderOrderItem_OrderItem_Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderOrderItem]
    FOREIGN KEY ([OrderOrderItem_OrderItem_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderItem'
CREATE INDEX [IX_FK_OrderOrderItem]
ON [dbo].[OrderItems]
    ([OrderOrderItem_OrderItem_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Orders]
    ([Customer_Id]);
GO

-- Creating foreign key on [LoginCredential_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_CustomerLoginCredential]
    FOREIGN KEY ([LoginCredential_Id])
    REFERENCES [dbo].[LoginCredentials]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerLoginCredential'
CREATE INDEX [IX_FK_CustomerLoginCredential]
ON [dbo].[Users]
    ([LoginCredential_Id]);
GO

-- Creating foreign key on [Media_Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderItemMedia]
    FOREIGN KEY ([Media_Id])
    REFERENCES [dbo].[Media]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItemMedia'
CREATE INDEX [IX_FK_OrderItemMedia]
ON [dbo].[OrderItems]
    ([Media_Id]);
GO

-- Creating foreign key on [Media_Id] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [FK_MediaStock]
    FOREIGN KEY ([Media_Id])
    REFERENCES [dbo].[Media]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MediaStock'
CREATE INDEX [IX_FK_MediaStock]
ON [dbo].[Stocks]
    ([Media_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_User]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Role]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Role'
CREATE INDEX [IX_FK_UserRole_Role]
ON [dbo].[UserRole]
    ([Roles_Id]);
GO

-- Creating foreign key on [Users_Id] in table 'UserMedia'
ALTER TABLE [dbo].[UserMedia]
ADD CONSTRAINT [FK_UserMedia_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Medium_Id] in table 'UserMedia'
ALTER TABLE [dbo].[UserMedia]
ADD CONSTRAINT [FK_UserMedia_Media]
    FOREIGN KEY ([Medium_Id])
    REFERENCES [dbo].[Media]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMedia_Media'
CREATE INDEX [IX_FK_UserMedia_Media]
ON [dbo].[UserMedia]
    ([Medium_Id]);
GO

-- Creating foreign key on [RecommendationId] in table 'LikeMatchings'
ALTER TABLE [dbo].[LikeMatchings]
ADD CONSTRAINT [FK_RecommendationLikeMatching]
    FOREIGN KEY ([RecommendationId])
    REFERENCES [dbo].[Recommendations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecommendationLikeMatching'
CREATE INDEX [IX_FK_RecommendationLikeMatching]
ON [dbo].[LikeMatchings]
    ([RecommendationId]);
GO

-- Creating foreign key on [Medium_Id] in table 'LikeMatchings'
ALTER TABLE [dbo].[LikeMatchings]
ADD CONSTRAINT [FK_LikeMatchingMedia]
    FOREIGN KEY ([Medium_Id])
    REFERENCES [dbo].[Media]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LikeMatchingMedia'
CREATE INDEX [IX_FK_LikeMatchingMedia]
ON [dbo].[LikeMatchings]
    ([Medium_Id]);
GO

-- Creating foreign key on [RecommendationLikeMatching1_LikeMatching_Id] in table 'LikeMatchings'
ALTER TABLE [dbo].[LikeMatchings]
ADD CONSTRAINT [FK_RecommendationLikeMatching1]
    FOREIGN KEY ([RecommendationLikeMatching1_LikeMatching_Id])
    REFERENCES [dbo].[Recommendations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecommendationLikeMatching1'
CREATE INDEX [IX_FK_RecommendationLikeMatching1]
ON [dbo].[LikeMatchings]
    ([RecommendationLikeMatching1_LikeMatching_Id]);
GO

-- Creating foreign key on [Medium_Id] in table 'Recommendations'
ALTER TABLE [dbo].[Recommendations]
ADD CONSTRAINT [FK_RecommendationMedia]
    FOREIGN KEY ([Medium_Id])
    REFERENCES [dbo].[Media]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecommendationMedia'
CREATE INDEX [IX_FK_RecommendationMedia]
ON [dbo].[Recommendations]
    ([Medium_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------