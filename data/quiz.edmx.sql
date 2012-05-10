
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/29/2012 11:14:53
-- Generated from EDMX file: C:\workspace\quiz\quiz.models\DAL\quiz.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Quiz];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_QuizQuestion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_QuizQuestion];
GO
IF OBJECT_ID(N'[dbo].[FK_QuestionAnswer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_QuestionAnswer];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAnswer_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAnswer] DROP CONSTRAINT [FK_UserAnswer_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAnswer_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserAnswer] DROP CONSTRAINT [FK_UserAnswer_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_Stats_Quizs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stats] DROP CONSTRAINT [FK_Stats_Quizs];
GO
IF OBJECT_ID(N'[dbo].[FK_Stats_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stats] DROP CONSTRAINT [FK_Stats_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Quizs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Quizs];
GO
IF OBJECT_ID(N'[dbo].[Questions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questions];
GO
IF OBJECT_ID(N'[dbo].[Answers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answers];
GO
IF OBJECT_ID(N'[dbo].[Stats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stats];
GO
IF OBJECT_ID(N'[dbo].[UserAnswer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserAnswer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Quizs'
CREATE TABLE [dbo].[Quizs] (
    [QuizId] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [QuestionId] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [QuizId] int  NOT NULL
);
GO

-- Creating table 'Answers'
CREATE TABLE [dbo].[Answers] (
    [AnswerId] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsCorrect] bit  NOT NULL,
    [QuestionId] int  NOT NULL,
    [UserId] int  NULL
);
GO

-- Creating table 'Stats'
CREATE TABLE [dbo].[Stats] (
    [StatId] int IDENTITY(1,1) NOT NULL,
    [Users_UserId] int  NOT NULL,
    [Quizs_QuizId] int  NOT NULL,
    [CorrectAnswers] int  NOT NULL
);
GO

-- Creating table 'UserAnswer'
CREATE TABLE [dbo].[UserAnswer] (
    [Users_UserId] int  NOT NULL,
    [Answers_AnswerId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [QuizId] in table 'Quizs'
ALTER TABLE [dbo].[Quizs]
ADD CONSTRAINT [PK_Quizs]
    PRIMARY KEY CLUSTERED ([QuizId] ASC);
GO

-- Creating primary key on [QuestionId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([QuestionId] ASC);
GO

-- Creating primary key on [AnswerId] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [PK_Answers]
    PRIMARY KEY CLUSTERED ([AnswerId] ASC);
GO

-- Creating primary key on [StatId] in table 'Stats'
ALTER TABLE [dbo].[Stats]
ADD CONSTRAINT [PK_Stats]
    PRIMARY KEY CLUSTERED ([StatId] ASC);
GO

-- Creating primary key on [Users_UserId], [Answers_AnswerId] in table 'UserAnswer'
ALTER TABLE [dbo].[UserAnswer]
ADD CONSTRAINT [PK_UserAnswer]
    PRIMARY KEY NONCLUSTERED ([Users_UserId], [Answers_AnswerId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [QuizId] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_QuizQuestion]
    FOREIGN KEY ([QuizId])
    REFERENCES [dbo].[Quizs]
        ([QuizId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuizQuestion'
CREATE INDEX [IX_FK_QuizQuestion]
ON [dbo].[Questions]
    ([QuizId]);
GO

-- Creating foreign key on [QuestionId] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [FK_QuestionAnswer]
    FOREIGN KEY ([QuestionId])
    REFERENCES [dbo].[Questions]
        ([QuestionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_QuestionAnswer'
CREATE INDEX [IX_FK_QuestionAnswer]
ON [dbo].[Answers]
    ([QuestionId]);
GO

-- Creating foreign key on [Users_UserId] in table 'UserAnswer'
ALTER TABLE [dbo].[UserAnswer]
ADD CONSTRAINT [FK_UserAnswer_User]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Answers_AnswerId] in table 'UserAnswer'
ALTER TABLE [dbo].[UserAnswer]
ADD CONSTRAINT [FK_UserAnswer_Answer]
    FOREIGN KEY ([Answers_AnswerId])
    REFERENCES [dbo].[Answers]
        ([AnswerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAnswer_Answer'
CREATE INDEX [IX_FK_UserAnswer_Answer]
ON [dbo].[UserAnswer]
    ([Answers_AnswerId]);
GO

-- Creating foreign key on [Quizs_QuizId] in table 'Stats'
ALTER TABLE [dbo].[Stats]
ADD CONSTRAINT [FK_Stats_Quizs]
    FOREIGN KEY ([Quizs_QuizId])
    REFERENCES [dbo].[Quizs]
        ([QuizId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Stats_Quizs'
CREATE INDEX [IX_FK_Stats_Quizs]
ON [dbo].[Stats]
    ([Quizs_QuizId]);
GO

-- Creating foreign key on [Users_UserId] in table 'Stats'
ALTER TABLE [dbo].[Stats]
ADD CONSTRAINT [FK_Stats_User]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Stats_User'
CREATE INDEX [IX_FK_Stats_User]
ON [dbo].[Stats]
    ([Users_UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------