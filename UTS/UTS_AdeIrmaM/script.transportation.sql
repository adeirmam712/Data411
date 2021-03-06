USE [master]
GO
/****** Object:  Database [dbTransportation]    Script Date: 10/12/2018 22:05:41 ******/
CREATE DATABASE [dbTransportation] ON  PRIMARY 
( NAME = N'dbTransportation', FILENAME = N'D:\AdeIrmaM\UTS\dbTransportation.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbTransportation_log', FILENAME = N'D:\AdeIrmaM\UTS\dbTransportation_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbTransportation] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbTransportation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbTransportation] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [dbTransportation] SET ANSI_NULLS OFF
GO
ALTER DATABASE [dbTransportation] SET ANSI_PADDING OFF
GO
ALTER DATABASE [dbTransportation] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [dbTransportation] SET ARITHABORT OFF
GO
ALTER DATABASE [dbTransportation] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [dbTransportation] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [dbTransportation] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [dbTransportation] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [dbTransportation] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [dbTransportation] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [dbTransportation] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [dbTransportation] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [dbTransportation] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [dbTransportation] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [dbTransportation] SET  DISABLE_BROKER
GO
ALTER DATABASE [dbTransportation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [dbTransportation] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [dbTransportation] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [dbTransportation] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [dbTransportation] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [dbTransportation] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [dbTransportation] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [dbTransportation] SET  READ_WRITE
GO
ALTER DATABASE [dbTransportation] SET RECOVERY SIMPLE
GO
ALTER DATABASE [dbTransportation] SET  MULTI_USER
GO
ALTER DATABASE [dbTransportation] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [dbTransportation] SET DB_CHAINING OFF
GO
USE [dbTransportation]
GO
/****** Object:  Table [dbo].[Transportation]    Script Date: 10/12/2018 22:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transportation](
	[RequestId] [int] NULL,
	[NameRequestor] [char](30) NULL,
	[RequestorId] [char](15) NULL,
	[Unit] [char](15) NULL,
	[DateIssue] [datetime] NULL,
	[UnitDestination] [char](15) NULL,
	[acRegis] [char](15) NULL,
	[Transportation] [char](30) NULL,
	[Phone] [char](15) NULL,
	[Instruction] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transport]    Script Date: 10/12/2018 22:05:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transport](
	[IdTransport] [int] NOT NULL,
	[Transport] [char](20) NULL,
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[IdTransport] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
