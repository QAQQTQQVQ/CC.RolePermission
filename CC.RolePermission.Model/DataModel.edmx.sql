
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/05/2020 00:38:34
-- Generated from EDMX file: D:\CC.RolePermission\CC.RolePermission.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RolePermission];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfoOrderInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderInfo] DROP CONSTRAINT [FK_UserInfoOrderInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfo];
GO
IF OBJECT_ID(N'[dbo].[OrderInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfoSet];
GO
IF OBJECT_ID(N'[dbo].[ActionInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfo'
CREATE TABLE [dbo].[UserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(max)  NULL,
    [Pwd] nvarchar(max)  NULL,
    [ShowName] nvarchar(max)  NULL,
    [DelFlag] int  NOT NULL,
    [Remark] nvarchar(64)  NULL,
    [ModifyOn] datetime  NULL,
    [SubTime] datetime  NULL
);
GO

-- Creating table 'OrderInfo'
CREATE TABLE [dbo].[OrderInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NULL,
    [UserInfoId] int  NOT NULL,
    [DelFlag] int  NOT NULL
);
GO

-- Creating table 'RoleInfoSet'
CREATE TABLE [dbo].[RoleInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleNale] nvarchar(32)  NULL,
    [DelFlag] int  NOT NULL,
    [Remark] nvarchar(64)  NULL,
    [ModifyOn] datetime  NULL,
    [SubTime] datetime  NULL
);
GO

-- Creating table 'ActionInfoSet'
CREATE TABLE [dbo].[ActionInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DelFlag] int  NOT NULL,
    [Remark] nvarchar(64)  NULL,
    [ModifyOn] datetime  NULL,
    [SubTime] datetime  NULL,
    [ActionName] nvarchar(64)  NULL,
    [Url] nvarchar(512)  NULL,
    [HttpMethod] nvarchar(32)  NULL,
    [IsMenu] bit  NULL,
    [MenuIcon] nvarchar(max)  NULL,
    [Sort] int  NULL
);
GO

-- Creating table 'UserInfoExtSet'
CREATE TABLE [dbo].[UserInfoExtSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Age] int  NULL,
    [Sex] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [UserInfoId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'R_UserInfo_ActionInfoSet'
CREATE TABLE [dbo].[R_UserInfo_ActionInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HasPermission] bit  NULL,
    [ActionInfoId] int  NOT NULL,
    [DelFlag] int  NOT NULL,
    [UserInfo_Id] int  NOT NULL
);
GO

-- Creating table 'UserInfoRoleInfo'
CREATE TABLE [dbo].[UserInfoRoleInfo] (
    [UserInfo_Id] int  NOT NULL,
    [RoleInfo_Id] int  NOT NULL
);
GO

-- Creating table 'RoleInfoActionInfo'
CREATE TABLE [dbo].[RoleInfoActionInfo] (
    [RoleInfo_Id] int  NOT NULL,
    [ActionInfo_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserInfo'
ALTER TABLE [dbo].[UserInfo]
ADD CONSTRAINT [PK_UserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [PK_OrderInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoleInfoSet'
ALTER TABLE [dbo].[RoleInfoSet]
ADD CONSTRAINT [PK_RoleInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActionInfoSet'
ALTER TABLE [dbo].[ActionInfoSet]
ADD CONSTRAINT [PK_ActionInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserInfoExtSet'
ALTER TABLE [dbo].[UserInfoExtSet]
ADD CONSTRAINT [PK_UserInfoExtSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'R_UserInfo_ActionInfoSet'
ALTER TABLE [dbo].[R_UserInfo_ActionInfoSet]
ADD CONSTRAINT [PK_R_UserInfo_ActionInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserInfo_Id], [RoleInfo_Id] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [PK_UserInfoRoleInfo]
    PRIMARY KEY CLUSTERED ([UserInfo_Id], [RoleInfo_Id] ASC);
GO

-- Creating primary key on [RoleInfo_Id], [ActionInfo_Id] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [PK_RoleInfoActionInfo]
    PRIMARY KEY CLUSTERED ([RoleInfo_Id], [ActionInfo_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfoId] in table 'OrderInfo'
ALTER TABLE [dbo].[OrderInfo]
ADD CONSTRAINT [FK_UserInfoOrderInfo]
    FOREIGN KEY ([UserInfoId])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoOrderInfo'
CREATE INDEX [IX_FK_UserInfoOrderInfo]
ON [dbo].[OrderInfo]
    ([UserInfoId]);
GO

-- Creating foreign key on [UserInfo_Id] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_UserInfo]
    FOREIGN KEY ([UserInfo_Id])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleInfo_Id] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_Id])
    REFERENCES [dbo].[RoleInfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRoleInfo_RoleInfo'
CREATE INDEX [IX_FK_UserInfoRoleInfo_RoleInfo]
ON [dbo].[UserInfoRoleInfo]
    ([RoleInfo_Id]);
GO

-- Creating foreign key on [UserInfo_Id] in table 'R_UserInfo_ActionInfoSet'
ALTER TABLE [dbo].[R_UserInfo_ActionInfoSet]
ADD CONSTRAINT [FK_R_UserInfo_ActionInfoUserInfo]
    FOREIGN KEY ([UserInfo_Id])
    REFERENCES [dbo].[UserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_R_UserInfo_ActionInfoUserInfo'
CREATE INDEX [IX_FK_R_UserInfo_ActionInfoUserInfo]
ON [dbo].[R_UserInfo_ActionInfoSet]
    ([UserInfo_Id]);
GO

-- Creating foreign key on [ActionInfoId] in table 'R_UserInfo_ActionInfoSet'
ALTER TABLE [dbo].[R_UserInfo_ActionInfoSet]
ADD CONSTRAINT [FK_ActionInfoR_UserInfo_ActionInfo]
    FOREIGN KEY ([ActionInfoId])
    REFERENCES [dbo].[ActionInfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActionInfoR_UserInfo_ActionInfo'
CREATE INDEX [IX_FK_ActionInfoR_UserInfo_ActionInfo]
ON [dbo].[R_UserInfo_ActionInfoSet]
    ([ActionInfoId]);
GO

-- Creating foreign key on [RoleInfo_Id] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_Id])
    REFERENCES [dbo].[RoleInfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionInfo_Id] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_Id])
    REFERENCES [dbo].[ActionInfoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoActionInfo_ActionInfo'
CREATE INDEX [IX_FK_RoleInfoActionInfo_ActionInfo]
ON [dbo].[RoleInfoActionInfo]
    ([ActionInfo_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------