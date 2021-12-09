USE [master]
GO

CREATE DATABASE [KanbanMVC]
 CONTAINMENT = NONE
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KanbanMVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [KanbanMVC] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [KanbanMVC] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [KanbanMVC] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [KanbanMVC] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [KanbanMVC] SET ARITHABORT OFF 
GO

ALTER DATABASE [KanbanMVC] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [KanbanMVC] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [KanbanMVC] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [KanbanMVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [KanbanMVC] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [KanbanMVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [KanbanMVC] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [KanbanMVC] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [KanbanMVC] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [KanbanMVC] SET  DISABLE_BROKER 
GO

ALTER DATABASE [KanbanMVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [KanbanMVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [KanbanMVC] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [KanbanMVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [KanbanMVC] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [KanbanMVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [KanbanMVC] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [KanbanMVC] SET RECOVERY FULL 
GO

ALTER DATABASE [KanbanMVC] SET  MULTI_USER 
GO

ALTER DATABASE [KanbanMVC] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [KanbanMVC] SET DB_CHAINING OFF 
GO

ALTER DATABASE [KanbanMVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [KanbanMVC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [KanbanMVC] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [KanbanMVC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [KanbanMVC] SET QUERY_STORE = OFF
GO

ALTER DATABASE [KanbanMVC] SET  READ_WRITE 
GO

USE [KanbanMVC]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Board](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Column](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[BoardId] [int] NOT NULL,
 CONSTRAINT [PK_Column] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Column]  WITH CHECK ADD  CONSTRAINT [FK_Column_Board_Cascade] FOREIGN KEY([BoardId])
REFERENCES [dbo].[Board] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Column] CHECK CONSTRAINT [FK_Column_Board_Cascade]
GO

CREATE TABLE [dbo].[Note](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Text] [varchar](500) NOT NULL,
	[ColumnId] [int] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Column_Cascade] FOREIGN KEY([ColumnId])
REFERENCES [dbo].[Column] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Column_Cascade]
GO