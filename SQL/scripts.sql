USE [master]
GO
/****** Object:  Database [PPI]    Script Date: 5/2/2024 00:34:33 ******/
CREATE DATABASE [PPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PPI', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PPI_log', FILENAME = N'D:\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PPI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [PPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PPI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PPI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PPI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PPI] SET  MULTI_USER 
GO
ALTER DATABASE [PPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PPI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PPI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PPI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PPI] SET QUERY_STORE = OFF
GO
USE [PPI]
GO
/****** Object:  Table [dbo].[Assets]    Script Date: 5/2/2024 00:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ticker] [varchar](20) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[AssetTypeId] [int] NOT NULL,
	[UnitPrice] [decimal](20, 4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetTypes]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorMessages]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](100) NOT NULL,
	[ErrorCode] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[AssetId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](20, 4) NOT NULL,
	[Commission] [decimal](10, 6) NULL,
	[Taxes] [decimal](10, 6) NULL,
	[Operation] [char](1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[TotalAmount] [decimal](20, 4) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] NOT NULL,
	[Description] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[AccountId] [int] NOT NULL,
	[Password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assets] ON 

INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (1, N'AAPL', N'Apple', 1, CAST(177.9700 AS Decimal(20, 4)))
INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (2, N'GOOGL', N'Alphabet Inc', 1, CAST(138.2100 AS Decimal(20, 4)))
INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (3, N'MSFT', N'Microsoft', 1, CAST(329.0400 AS Decimal(20, 4)))
INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (4, N'KO', N'Coca Cola', 1, CAST(58.3000 AS Decimal(20, 4)))
INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (5, N'WMT', N'Walmart', 1, CAST(163.4200 AS Decimal(20, 4)))
INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (6, N'AL30', N'BONOS ARGENTINA USD 2030 L.A', 2, CAST(307.4000 AS Decimal(20, 4)))
INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (7, N'GD30', N'Bonos Globales Argentina USD Step Up 2030', 2, CAST(336.1000 AS Decimal(20, 4)))
INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (8, N'Delta.Pesos', N'Delta Pesos Clase A', 3, CAST(0.0181 AS Decimal(20, 4)))
INSERT [dbo].[Assets] ([Id], [Ticker], [Name], [AssetTypeId], [UnitPrice]) VALUES (9, N'Fima.Premium', N'Fima Premium Clase A', 3, CAST(0.0317 AS Decimal(20, 4)))
SET IDENTITY_INSERT [dbo].[Assets] OFF
GO
SET IDENTITY_INSERT [dbo].[AssetTypes] ON 

INSERT [dbo].[AssetTypes] ([Id], [Description]) VALUES (1, N'Acción')
INSERT [dbo].[AssetTypes] ([Id], [Description]) VALUES (2, N'Bono')
INSERT [dbo].[AssetTypes] ([Id], [Description]) VALUES (3, N'FCI')
SET IDENTITY_INSERT [dbo].[AssetTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[ErrorMessages] ON 

INSERT [dbo].[ErrorMessages] ([Id], [Message], [ErrorCode]) VALUES (1, N'El AssetId ingresado no existe', N'010001')
INSERT [dbo].[ErrorMessages] ([Id], [Message], [ErrorCode]) VALUES (2, N'La orden ingresada no existe', N'010002')
SET IDENTITY_INSERT [dbo].[ErrorMessages] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (8, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (9, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (10, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (11, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (12, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (15, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (16, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (17, 25, 9, 1, CAST(11.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'V', 0, CAST(11.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (18, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 1, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (19, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (20, 25, 9, 1, CAST(11.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'V', 0, CAST(11.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (21, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (22, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (23, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (24, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (25, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (26, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (27, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (28, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (29, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (30, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (31, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (32, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (33, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (34, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (35, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (36, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (37, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (38, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (39, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (40, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (41, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (42, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (43, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (44, 25, 7, 12, CAST(21.7500 AS Decimal(20, 4)), CAST(0.522000 AS Decimal(10, 6)), CAST(0.109620 AS Decimal(10, 6)), N'C', 0, CAST(261.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (45, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (46, 25, 2, 5, CAST(138.2100 AS Decimal(20, 4)), CAST(4.146300 AS Decimal(10, 6)), CAST(0.870723 AS Decimal(10, 6)), N'V', 0, CAST(691.0500 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (48, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (49, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (50, 25, 9, 1, CAST(11.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'V', 0, CAST(11.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (51, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 1, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (53, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (54, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 0, CAST(20.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (55, 25, 9, 1, CAST(11.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'V', 0, CAST(11.0000 AS Decimal(20, 4)))
INSERT [dbo].[Orders] ([Id], [AccountId], [AssetId], [Quantity], [Price], [Commission], [Taxes], [Operation], [StatusId], [TotalAmount]) VALUES (56, 25, 9, 2, CAST(10.0000 AS Decimal(20, 4)), CAST(0.000000 AS Decimal(10, 6)), CAST(0.000000 AS Decimal(10, 6)), N'C', 1, CAST(20.0000 AS Decimal(20, 4)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
INSERT [dbo].[OrderStatus] ([Id], [Description]) VALUES (0, N'En proceso')
INSERT [dbo].[OrderStatus] ([Id], [Description]) VALUES (1, N'Ejecutada')
INSERT [dbo].[OrderStatus] ([Id], [Description]) VALUES (3, N'Cancelada')
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [AccountId], [Password]) VALUES (1, N'jroberts', 25, N'123456')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Assets]  WITH CHECK ADD FOREIGN KEY([AssetTypeId])
REFERENCES [dbo].[AssetTypes] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([AssetId])
REFERENCES [dbo].[Assets] ([Id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([StatusId])
REFERENCES [dbo].[OrderStatus] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[GetAssets]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAssets]
AS
BEGIN
	SELECT
		Id,
		Ticker,
		Name,
		AssetTypeId AssetType,
		UnitPrice
	FROM dbo.Assets (NOLOCK);
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAssetTypes]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAssetTypes]
AS
BEGIN
	SELECT
		Id,
		Description
	FROM dbo.AssetTypes (NOLOCK);
END;
GO
/****** Object:  StoredProcedure [dbo].[GetErrorMessages]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetErrorMessages]
AS
BEGIN
	SELECT
		ErrorCode,
		Message
	FROM dbo.ErrorMessages (NOLOCK);
END;
GO
/****** Object:  StoredProcedure [dbo].[GetExistsUser]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetExistsUser]
	@userName VARCHAR(50),
	@password VARCHAR(50)
AS
BEGIN
	DECLARE @accountId INT;

	SELECT 
		@accountId = AccountId
	FROM dbo.Users (NOLOCK)
	WHERE UserName = @userName
	AND Password = @password;

	IF @accountId IS NOT NULL
	BEGIN
		SELECT 1 AS 'Exists', @accountId AS AccountId;
	END
	ELSE
	BEGIN
		SELECT 0 AS 'Exists', 0 AS AccountId;
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetOrderById]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderById] @orderId INT
AS
BEGIN
	SELECT
		ord.Id,
		usr.UserName,
		asst.Name AssetName,
		asstTyp.Description AssetTypeName,
		ord.Quantity,
		ord.Price,
		ord.Operation,
		stt.Description Status,
		ord.Commission,
		ord.Taxes,
		ord.TotalAmount
	FROM dbo.Orders (NOLOCK) ord
	INNER JOIN dbo.Users (NOLOCK) usr
	ON ord.AccountId = usr.AccountId
	INNER JOIN dbo.Assets (NOLOCK) asst
	ON ord.AssetId = asst.Id
	INNER JOIN dbo.OrderStatus (NOLOCK) stt
	ON ord.StatusId = stt.Id
	INNER JOIN dbo.AssetTypes (NOLOCK) asstTyp
	ON asst.AssetTypeId = asstTyp.Id
	WHERE ord.Id = @orderId;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetOrdersByAccountId]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetOrdersByAccountId] @accountId INT
AS
BEGIN
	SELECT
		ord.Id,
		asst.Name AssetName,
		asst.Ticker,
		asstTyp.Description AssetType,
		ord.TotalAmount
	FROM dbo.Orders (NOLOCK) ord
	INNER JOIN dbo.Users (NOLOCK) usr
	ON ord.AccountId = usr.AccountId
	INNER JOIN dbo.Assets (NOLOCK) asst
	ON ord.AssetId = asst.Id
	INNER JOIN dbo.AssetTypes (NOLOCK) asstTyp
	ON asst.AssetTypeId = asstTyp.Id
	WHERE usr.AccountId = @accountId;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetOrderStatus]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetOrderStatus]
AS
BEGIN
	SELECT
		Id,
		Description
	FROM dbo.OrderStatus (NOLOCK);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 5/2/2024 00:34:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertOrder] 
	@accountId INT,
	@assetId INT,
	@quantity INT,
	@price DECIMAL(20, 4),
	@commission DECIMAL(10, 6) = NULL,
	@taxes DECIMAL(10, 6) = NULL,
	@operation CHAR(1),
	@totalAmount DECIMAL(20, 4)
AS
BEGIN
	INSERT INTO dbo.Orders (AccountId, AssetId, Quantity, Price, Commission, Taxes, Operation, StatusId, TotalAmount)
	VALUES (@accountId, @assetId, @quantity, @price, @commission, @taxes, @operation, 0, @totalAmount);

	SELECT SCOPE_IDENTITY()
END;
GO
USE [master]
GO
ALTER DATABASE [PPI] SET  READ_WRITE 
GO
