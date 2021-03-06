USE [master]
GO
/****** Object:  Database [bdeli]    Script Date: 10/22/2018 5:42:09 PM ******/
CREATE DATABASE [bdeli]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bdeli', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\bdeli.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bdeli_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\bdeli_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bdeli] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdeli].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdeli] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bdeli] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bdeli] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bdeli] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bdeli] SET ARITHABORT OFF 
GO
ALTER DATABASE [bdeli] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bdeli] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [bdeli] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bdeli] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bdeli] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bdeli] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bdeli] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bdeli] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bdeli] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bdeli] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bdeli] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bdeli] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bdeli] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bdeli] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bdeli] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bdeli] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bdeli] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bdeli] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bdeli] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bdeli] SET  MULTI_USER 
GO
ALTER DATABASE [bdeli] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bdeli] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bdeli] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bdeli] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [bdeli]
GO
/****** Object:  Table [dbo].[bD.Booking]    Script Date: 10/22/2018 5:42:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bD.Booking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DateBooking] [date] NULL,
	[TimeBooking] [nvarchar](50) NULL,
	[Amount] [int] NULL,
	[Note] [nvarchar](50) NULL,
	[Tel] [nvarchar](50) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bD.Contacts]    Script Date: 10/22/2018 5:42:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bD.Contacts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Sdt] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bD.Images]    Script Date: 10/22/2018 5:42:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bD.Images](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image1] [nvarchar](50) NULL,
	[image2] [nvarchar](50) NULL,
	[image3] [nvarchar](50) NULL,
	[image4] [nvarchar](50) NULL,
	[image5] [nvarchar](50) NULL,
	[image6] [nvarchar](50) NULL,
	[image7] [nvarchar](50) NULL,
	[image8] [nvarchar](50) NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bD.Introduce]    Script Date: 10/22/2018 5:42:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bD.Introduce](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NULL,
	[Images] [nvarchar](200) NULL,
	[Subtitle] [nvarchar](30) NULL,
	[Description] [nvarchar](1000) NULL,
	[Images1] [nvarchar](200) NULL,
 CONSTRAINT [PK_b.Deli] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bD.Service]    Script Date: 10/22/2018 5:42:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bD.Service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Images1] [nvarchar](50) NULL,
	[Title1] [nvarchar](40) NULL,
	[Description1] [nvarchar](200) NULL,
	[Images2] [nvarchar](50) NULL,
	[Title2] [nvarchar](40) NULL,
	[Description2] [nvarchar](200) NULL,
	[Images3] [nvarchar](50) NULL,
	[Title3] [nvarchar](40) NULL,
	[Description3] [nvarchar](200) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bD.Slide]    Script Date: 10/22/2018 5:42:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bD.Slide](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](1000) NULL,
	[Images] [nvarchar](50) NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bD.Video]    Script Date: 10/22/2018 5:42:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bD.Video](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Video] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bD.Booking] ON 

INSERT [dbo].[bD.Booking] ([id], [Name], [Email], [DateBooking], [TimeBooking], [Amount], [Note], [Tel]) VALUES (1, N'Nguyễn Ngọc Phương Trang', N'phuongtrang1397@gmail.com', CAST(0xD83E0B00 AS Date), N'20:00', 3, NULL, N'01672690747')
SET IDENTITY_INSERT [dbo].[bD.Booking] OFF
SET IDENTITY_INSERT [dbo].[bD.Contacts] ON 

INSERT [dbo].[bD.Contacts] ([id], [Email], [Sdt], [Address]) VALUES (1, N'trangnguyen@gmail.com', N'0902285621', N'91 Nguyễn Thái Sơn, Quận Gò Vấp')
SET IDENTITY_INSERT [dbo].[bD.Contacts] OFF
SET IDENTITY_INSERT [dbo].[bD.Images] ON 

INSERT [dbo].[bD.Images] ([id], [image1], [image2], [image3], [image4], [image5], [image6], [image7], [image8]) VALUES (1, N'gallery-img-03.png,', N'gallery-img-05.png,', N'gallery-img-07.png,', N'gallery-img-01.png,', N'gallery-img-08.png,', N'gallery-img-06.png,', N'gallery-img-04.png,', N'gallery-img-02.png,')
SET IDENTITY_INSERT [dbo].[bD.Images] OFF
SET IDENTITY_INSERT [dbo].[bD.Introduce] ON 

INSERT [dbo].[bD.Introduce] ([id], [Title], [Images], [Subtitle], [Description], [Images1]) VALUES (1, N'Câu chuyện của chúng tôi', N'gallery-img-01.png', N'Chúng tôi là b.deli', N'b.deli được sinh ra từ những trái tim đam mê ẩm thực , muốn đem lại sản phẩm dịch vụ tốt nhất cho khách hàng .  Với b.deli việc khách hàng hài lòng dù là ly trà hay một miếng bánh thì cũng là động lực thúc đẩy cho chúng tôi càng ngày càng hoàn thiện .  Mô hình food court đem lại sự tiện lợi nhất cho quí khách trong việc chọn lựa món ăn và chủ động hơn trong việc thanh toán .', N'gallery-img-02.png,')
SET IDENTITY_INSERT [dbo].[bD.Introduce] OFF
SET IDENTITY_INSERT [dbo].[bD.Service] ON 

INSERT [dbo].[bD.Service] ([id], [Images1], [Title1], [Description1], [Images2], [Title2], [Description2], [Images3], [Title3], [Description3]) VALUES (1, N'testimonial-img-2.png,', N' b.deli Food Court', N'Là hệ thống cung cấp dịch vụ ẩm thực theo phương pháp tự do chọn lựa và thanh toán trước với rất nhiều những món ẩm thực Việt - Nhật giúp cho thực khách nhiều lựa chọn và hài lòng với chất lượng.', N'menu-img-17.png,', N'b.deli Tea & Coffee', N'Là hệ thống cung cấp dịch vụ giải khát với những loại sản phẩm được dùng nguồn nguyên liệu từ nhật bản , với những thức uống công thức đặc biệt về milk tea, trà nhật và macchiato…', N'gallery-img-07.png,', N'b.deli Gift', N'Là hệ thống cung cấp dịch vụ quà tặng truyền thống cho khách hàng , vừa có thể làm quà tặng cho người than vừa có thể đem về gia đình để sử dụng')
SET IDENTITY_INSERT [dbo].[bD.Service] OFF
SET IDENTITY_INSERT [dbo].[bD.Slide] ON 

INSERT [dbo].[bD.Slide] ([id], [Title], [Description], [Images]) VALUES (1, N'Welcome to b.deli', N'Nhà hàng Việt - Nhật cổ điển và sang trọng.', N'intro-bg.jpg')
SET IDENTITY_INSERT [dbo].[bD.Slide] OFF
SET IDENTITY_INSERT [dbo].[bD.Video] ON 

INSERT [dbo].[bD.Video] ([id], [Title], [Description]) VALUES (1, N'Những Loại Trà Ngon Nhất', N'Nhà hàng Việt - Nhật cổ điển và sang trọng.')
SET IDENTITY_INSERT [dbo].[bD.Video] OFF
USE [master]
GO
ALTER DATABASE [bdeli] SET  READ_WRITE 
GO
