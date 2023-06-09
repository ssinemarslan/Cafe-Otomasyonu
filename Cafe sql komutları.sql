USE [master]
GO
/****** Object:  Database [Cafe]    Script Date: 20.03.2023 16:46:21 ******/
CREATE DATABASE [Cafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Cafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Cafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Cafe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cafe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cafe] SET  MULTI_USER 
GO
ALTER DATABASE [Cafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Cafe] SET QUERY_STORE = OFF
GO
USE [Cafe]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 20.03.2023 16:46:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciNo] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NULL,
	[Sifre] [int] NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 20.03.2023 16:46:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[MusteriNo] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAdSoyad] [varchar](50) NULL,
	[MusteriTelefon] [nvarchar](max) NULL,
	[MusteriAdres] [varchar](50) NULL,
 CONSTRAINT [PK_Müsteriler] PRIMARY KEY CLUSTERED 
(
	[MusteriNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Saticilar]    Script Date: 20.03.2023 16:46:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Saticilar](
	[SaticiNo] [int] IDENTITY(1,1) NOT NULL,
	[SaticiAdSoyad] [varchar](50) NULL,
	[SaticiAdres] [varchar](50) NULL,
	[Saticiil] [varchar](50) NULL,
	[Saticiilce] [varchar](50) NULL,
 CONSTRAINT [PK_Saticilar] PRIMARY KEY CLUSTERED 
(
	[SaticiNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparisler]    Script Date: 20.03.2023 16:46:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparisler](
	[SiparisNo] [int] IDENTITY(1,1) NOT NULL,
	[SiparisAdi] [varchar](50) NULL,
	[SiparisAdres] [varchar](50) NULL,
	[SiparisAdet] [int] NULL,
	[MusteriNo] [int] NOT NULL,
 CONSTRAINT [PK_Siparisler_1] PRIMARY KEY CLUSTERED 
(
	[SiparisNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 20.03.2023 16:46:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunNo] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [varchar](50) NULL,
	[UrunFiyati] [money] NULL,
	[KullanimTarihi] [varchar](max) NULL,
	[UretimTarihi] [varchar](max) NULL,
	[SaticiNo] [int] NOT NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[UrunNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (1, N'Sinem', 777)
INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (2, N'Büsra', 111)
INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAdi], [Sifre]) VALUES (3, N'Aysenur', 520)
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteriler] ON 

INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon], [MusteriAdres]) VALUES (1, N'Gizem Çalışkan', N'(054) 689-2123', N'Bursa')
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon], [MusteriAdres]) VALUES (2, N'Beyza Yıldırım', N'05312654789', NULL)
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon], [MusteriAdres]) VALUES (3, N'Çağla Özertt', N'(054) 762-3145', NULL)
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon], [MusteriAdres]) VALUES (4, N'Merve Yönden', N'(056) 987-4120', NULL)
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon], [MusteriAdres]) VALUES (8, N'jhjjgh', N'(688) 979-8799', NULL)
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon], [MusteriAdres]) VALUES (10, N'Yaseminn', N'(545) 799-7823', NULL)
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon], [MusteriAdres]) VALUES (14, N'Buse Üstün', N'(544) 489-4894', N'Yozgat')
INSERT [dbo].[Musteriler] ([MusteriNo], [MusteriAdSoyad], [MusteriTelefon], [MusteriAdres]) VALUES (15, N'Ahmet Çelik', N'(546) 895-7421', N'Kocaeli')
SET IDENTITY_INSERT [dbo].[Musteriler] OFF
GO
SET IDENTITY_INSERT [dbo].[Saticilar] ON 

INSERT [dbo].[Saticilar] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiil], [Saticiilce]) VALUES (1, N'Ahmet Yılmaz', N'Atatürk Mahallesi', N'İstanbul', N'Ataşehir')
INSERT [dbo].[Saticilar] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiil], [Saticiilce]) VALUES (2, N'Yasemin Kara', N'Mimar Sinan Mahallesi', N'İstanbul', N'Ataşehir')
INSERT [dbo].[Saticilar] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiil], [Saticiilce]) VALUES (3, N'Zeynep Çelik', N'Gül Mahallesi', N'İstanbul', N'Üsküdar')
INSERT [dbo].[Saticilar] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiil], [Saticiilce]) VALUES (4, N'fgf', N'fdgfdg', N'fdgd', N'dfg')
INSERT [dbo].[Saticilar] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiil], [Saticiilce]) VALUES (5, N'Büşra Kuş', N'Esatpaşa mahallesi', N'İstanbul', N'Ataşehir')
INSERT [dbo].[Saticilar] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiil], [Saticiilce]) VALUES (6, N'Ayşenur Fırat', N'örnek mahallesi', N'istanbul', N'ataşehir')
INSERT [dbo].[Saticilar] ([SaticiNo], [SaticiAdSoyad], [SaticiAdres], [Saticiil], [Saticiilce]) VALUES (8, N'kkk', N'fff', N'fff', N'fff')
SET IDENTITY_INSERT [dbo].[Saticilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Siparisler] ON 

INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [MusteriNo]) VALUES (1, N'Soda', N'Bakırköy', 3, 4)
INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [MusteriNo]) VALUES (2, N'Cheesecake', N'Üsküdar', 2, 1)
INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [MusteriNo]) VALUES (3, N'Mozaik Pasta', N'EyüpSultan', 1, 3)
INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [MusteriNo]) VALUES (4, N'Soda', N'Üsküdar', 2, 1)
INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [MusteriNo]) VALUES (5, N'Browni', N'Bakırköy', 4, 4)
INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [MusteriNo]) VALUES (10, N'cfhdh', N'hfdhdjh', 2, 1)
INSERT [dbo].[Siparisler] ([SiparisNo], [SiparisAdi], [SiparisAdres], [SiparisAdet], [MusteriNo]) VALUES (13, N'gggs', N'ggg', 10, 2)
SET IDENTITY_INSERT [dbo].[Siparisler] OFF
GO
SET IDENTITY_INSERT [dbo].[Urunler] ON 

INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (1, N'Brownii', 200000.0000, N' 2.0 .2023', N' 2.8 .2023', 1)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (2, N'Mozaik Pasta', 30.0000, N'Jan 10 2023 12:00AM', N'Jan  8 2023 12:00AM', 1)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (3, N'Meyve Suyu', 10.0000, N'Mar  1 2023 12:00AM', N'Feb 28 2023 12:00AM', 2)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (4, N'Magnolia', 25.0000, N'Apr 15 2023 12:00AM', N'Apr  1 2023 12:00AM', 3)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (5, N'Cheesecake', 30.0000, N'Aug 29 2023 12:00AM', N'Aug 15 2023 12:00AM', 3)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (6, N'Soda', 150000.0000, N'  .6 .2023', N'  .6 .2023', 2)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (7, N'çay', 25.0000, N'20.06.1999', N'01.03.2023', 1)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (10, N'su', 5.0000, N'02.03.2023', N'04.03.2023', 3)
INSERT [dbo].[Urunler] ([UrunNo], [UrunAdi], [UrunFiyati], [KullanimTarihi], [UretimTarihi], [SaticiNo]) VALUES (11, N'Gazoz', 5.0000, N'10.02.2003', N'11.03.2023', 6)
SET IDENTITY_INSERT [dbo].[Urunler] OFF
GO
ALTER TABLE [dbo].[Siparisler]  WITH CHECK ADD  CONSTRAINT [FK_Siparisler_Müsteriler] FOREIGN KEY([MusteriNo])
REFERENCES [dbo].[Musteriler] ([MusteriNo])
GO
ALTER TABLE [dbo].[Siparisler] CHECK CONSTRAINT [FK_Siparisler_Müsteriler]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [FK_Urunler_Saticilar] FOREIGN KEY([SaticiNo])
REFERENCES [dbo].[Saticilar] ([SaticiNo])
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [FK_Urunler_Saticilar]
GO
USE [master]
GO
ALTER DATABASE [Cafe] SET  READ_WRITE 
GO
