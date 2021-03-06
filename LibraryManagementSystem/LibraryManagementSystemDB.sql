USE [master]
GO
/****** Object:  Database [LibraryDB]    Script Date: 1/20/2020 8:33:07 AM ******/
CREATE DATABASE [LibraryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LibraryDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LibraryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\LibraryDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LibraryDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LibraryDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 1/20/2020 8:33:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminId] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Assign]    Script Date: 1/20/2020 8:33:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assign](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[IssueDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Assign] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 1/20/2020 8:33:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](50) NULL,
	[BookId] [varchar](50) NULL,
	[AuthorName] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 1/20/2020 8:33:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] NOT NULL,
	[DepartmentName] [varchar](50) NULL,
	[ShortName] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RecieveBook]    Script Date: 1/20/2020 8:33:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecieveBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[BookId] [int] NULL,
	[DepartmentId] [int] NULL,
	[RecieveDate] [datetime] NULL,
	[LateFee] [int] NULL,
 CONSTRAINT [PK_RecieveBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/20/2020 8:33:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[StudentId] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [AdminId], [Password]) VALUES (1, N'D-02', N'2345')
INSERT [dbo].[Admin] ([Id], [AdminId], [Password]) VALUES (2, N'D-03', N'3456')
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [BookName], [BookId], [AuthorName], [DepartmentId], [Quantity], [Price]) VALUES (1002, N'Computer programming', N'CSE-202', N'Diganta', 1, 14, 400)
SET IDENTITY_INSERT [dbo].[Books] OFF
INSERT [dbo].[Department] ([Id], [DepartmentName], [ShortName]) VALUES (1, N'Computer Science and Engineering ', N'CSE')
INSERT [dbo].[Department] ([Id], [DepartmentName], [ShortName]) VALUES (2, N'Electrical and Elecronics Engineering', N'EEE')
SET IDENTITY_INSERT [dbo].[RecieveBook] ON 

INSERT [dbo].[RecieveBook] ([Id], [StudentId], [BookId], [DepartmentId], [RecieveDate], [LateFee]) VALUES (1, 0, 1002, 1, CAST(0x0000AB3C00000000 AS DateTime), 1474834)
INSERT [dbo].[RecieveBook] ([Id], [StudentId], [BookId], [DepartmentId], [RecieveDate], [LateFee]) VALUES (2, 0, 1002, 1, CAST(0x0000AB3B00000000 AS DateTime), 1474832)
SET IDENTITY_INSERT [dbo].[RecieveBook] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [StudentId], [DepartmentId]) VALUES (1, N'Diganta', N'c345', 1)
SET IDENTITY_INSERT [dbo].[Student] OFF
ALTER TABLE [dbo].[Assign]  WITH CHECK ADD  CONSTRAINT [FK_Assign_Assign] FOREIGN KEY([Id])
REFERENCES [dbo].[Assign] ([Id])
GO
ALTER TABLE [dbo].[Assign] CHECK CONSTRAINT [FK_Assign_Assign]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
USE [master]
GO
ALTER DATABASE [LibraryDB] SET  READ_WRITE 
GO
