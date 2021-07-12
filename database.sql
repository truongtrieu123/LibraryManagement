USE [master]
GO
/****** Object:  Database [LibraryManagement]    Script Date: 7/12/2021 4:05:30 PM ******/
CREATE DATABASE [LibraryManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LibraryManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LibraryManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LibraryManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibraryManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibraryManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryManagement] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LibraryManagement] SET QUERY_STORE = OFF
GO
USE [LibraryManagement]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 7/12/2021 4:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CatID] [bigint] NOT NULL,
	[Author] [nvarchar](max) NOT NULL,
	[PublicationDate] [datetime] NULL,
	[ImportDate] [datetime] NULL,
	[StorageState] [bit] NULL,
	[Location] [nvarchar](max) NULL,
	[PublishingCompany] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookRentalHitory]    Script Date: 7/12/2021 4:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRentalHitory](
	[ID] [bigint] NOT NULL,
	[ReaderID] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[State] [bit] NULL,
	[ReturnDate] [datetime] NULL,
 CONSTRAINT [PK_BookRentalHitory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookRentalList]    Script Date: 7/12/2021 4:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRentalList](
	[BookID] [bigint] NOT NULL,
	[BookRentalID] [bigint] NOT NULL,
	[No] [bigint] NULL,
 CONSTRAINT [PK_BookRentalList] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC,
	[BookRentalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/12/2021 4:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Config]    Script Date: 7/12/2021 4:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Config](
	[ID] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DateType] [nvarchar](max) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[State] [bit] NULL,
 CONSTRAINT [PK_Config] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reader]    Script Date: 7/12/2021 4:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reader](
	[ID] [bigint] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[CatID] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ExpiryDate] [datetime] NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reader] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredBook]    Script Date: 7/12/2021 4:05:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoredBook](
	[ID] [bigint] NOT NULL,
	[StorageDate] [datetime] NOT NULL,
	[State] [bit] NULL,
	[Location] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_StoredBook] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (0, N'Đắc nhân tâm', 2, N'Dale Canegie', CAST(N'2021-06-25T16:29:58.740' AS DateTime), CAST(N'2021-06-25T16:29:58.740' AS DateTime), 0, N'A22', N'Kim Đồng', N'Database\Images\BookImages\0.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (1, N'21 Bài Học Cho Thế Kỷ 21', 4, N'Yuval Noah Harari ', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 0, N'A11', N'Nhà Xuất Bản Tổng Hợp', N'Database\Images\BookImages\1.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (2, N'Sapiens: Lược Sử Loài Người Bằng Tranh - Tập 1: Khởi Đầu Của Loài Người', 4, N'Yuval Noah Harari', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A12', N'Nhà Xuất Bản Tổng Hợp', N'Database\Images\BookImages\2.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (3, N'Sapiens: Lược Sử Loài Người ', 4, N'Yuval Noah Harai', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 0, N'A13', N'Nhà Xuất Bản Tổng Hợp', N'Database\Images\BookImages\3.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (4, N'Homo Deus: Lược Sử Tương Lai', 4, N'Yuval Noah Harari', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 0, N'A14', N'Nhà Xuất Bản Tổng Hợp', N'Database\Images\BookImages\4.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (5, N'Chủ Nghĩa Khắc Kỷ', 7, N'William B. Irvine', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A15', N'Nhà Xuất Bản Thái Hà', N'Database\Images\BookImages\5.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (6, N'Đàn Ông Sao Hỏa Đàn Bà Sao Kim', 7, N'John Gray', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A16', N'Nhà Xuất Bản Hồng Đức', N'Database\Images\BookImages\6.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (7, N'Nhà Giả Kim', 6, N'Paulo Coelho', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 0, N'A17', N'Nhà Xuất Bản Hội Nhà Văn', N'Database\Images\BookImages\7.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (8, N'Hoàng tử bé', 6, N'Antone De Saint Exupery', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A18', N'Nhà Xuất Bản Hội Nhà Văn', N'Database\Images\BookImages\8.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (9, N'The Story Of Art - Câu Chuyện Nghệ Thuật', 3, N'E.H Gombrich', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A19', N'Nhà Xuất Bản Dân Trí', N'Database\Images\BookImages\9.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (10, N'Siêu Nhí Hỏi Nhà Khoa Học Trả Lời - 100 Bí Ẩn Mọi Đứa Trẻ Đều Muốn Hỏi Một Nhà', 2, N'Robert Winston', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A20', N'Nhà Xuất Bản Dân Trí
', N'Database\Images\BookImages\10.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (11, N'Bách Khoa Tri Thức Về Khám Phá Thế Giới Cho Trẻ Em - Thiên Văn Học', 2, N'Rachel Firth', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A21', N'Nhà Xuất Bản Thế Giới', N'Database\Images\BookImages\11.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (12, N'Sách Pháp Luật Về Giao Dịch Điện Tử Trên Thị Trường Chứng Khoán Ở Việt Nam Năm 2020 - NXB Chính Trị Quốc Gia Sự Thật', 1, N'PGS.TS. Phạm Thị Giang Thu (Chủ biên) - ThS. Nguyễn Thu Trang - TS. Nguyễn Ngọc Lương', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A22', N'Nhà Xuất Bản Chính Trị Quốc Gia Sự Thật', N'Database\Images\BookImages\12.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (13, N'Giáo Trình C++ Và Lập Trình', 5, N'GS. Phạm Văn Ất ( chủ biên), Lê Trường Thông', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A23', N'Nhà Xuất Bản Bách Khoa Hà Nội', N'Database\Images\BookImages\13.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (14, N'Doraemon', 8, N'Fujiko F. Fujio', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2019-09-01T00:00:00.000' AS DateTime), 1, N'A24', N'Nhà Xuất Bản Kim Đồng', N'Database\Images\BookImages\14.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (15, N'Trong Gia Đình', 3, N'Dale Carnegie', CAST(N'2011-02-01T00:00:00.000' AS DateTime), CAST(N'2011-02-01T00:00:00.000' AS DateTime), 1, N'A43', N'First News', N'Database\Images\BookImages\15.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (16, N'Cô gái đến từ hôm qua', 3, N'Nguyễn Nhật Ánh', CAST(N'2021-06-27T16:58:24.793' AS DateTime), CAST(N'2021-06-27T16:58:24.793' AS DateTime), 1, N'A33', N'First News', N'Database\Images\BookImages\16.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (17, N'Không gia đình', 4, N'Hector Malot', CAST(N'2021-06-01T00:00:00.000' AS DateTime), CAST(N'2021-06-01T00:00:00.000' AS DateTime), 1, N'A33', N'First News', N'Database\Images\BookImages\17.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (18, N'Conan - Tập 98', 9, N'Gosho AOYAMA', CAST(N'2014-06-04T00:00:00.000' AS DateTime), CAST(N'2014-06-04T00:00:00.000' AS DateTime), 1, N'A55', N'Kim Đồng', N'Database\Images\BookImages\18.png')
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (19, N'Giết Con Chim Nhại', 3, N'Happer Lee', CAST(N'2021-07-11T00:00:00.000' AS DateTime), CAST(N'2021-07-11T00:00:00.000' AS DateTime), 0, N'A21', N'NXB Sự Thật', N'Database\Images\BookImages\19.png')
GO
INSERT [dbo].[BookRentalHitory] ([ID], [ReaderID], [CreatedDate], [State], [ReturnDate]) VALUES (0, 1, CAST(N'2021-05-01T15:15:41.000' AS DateTime), 0, NULL)
INSERT [dbo].[BookRentalHitory] ([ID], [ReaderID], [CreatedDate], [State], [ReturnDate]) VALUES (1, 3, CAST(N'2021-07-12T15:36:53.000' AS DateTime), 0, NULL)
INSERT [dbo].[BookRentalHitory] ([ID], [ReaderID], [CreatedDate], [State], [ReturnDate]) VALUES (2, 4, CAST(N'2021-05-01T15:37:37.000' AS DateTime), 0, NULL)
INSERT [dbo].[BookRentalHitory] ([ID], [ReaderID], [CreatedDate], [State], [ReturnDate]) VALUES (3, 9, CAST(N'2021-07-12T15:49:03.000' AS DateTime), 1, CAST(N'2021-07-12T15:50:02.863' AS DateTime))
GO
INSERT [dbo].[BookRentalList] ([BookID], [BookRentalID], [No]) VALUES (0, 0, NULL)
INSERT [dbo].[BookRentalList] ([BookID], [BookRentalID], [No]) VALUES (1, 1, NULL)
INSERT [dbo].[BookRentalList] ([BookID], [BookRentalID], [No]) VALUES (3, 1, NULL)
INSERT [dbo].[BookRentalList] ([BookID], [BookRentalID], [No]) VALUES (4, 1, NULL)
INSERT [dbo].[BookRentalList] ([BookID], [BookRentalID], [No]) VALUES (7, 2, NULL)
INSERT [dbo].[BookRentalList] ([BookID], [BookRentalID], [No]) VALUES (15, 3, NULL)
INSERT [dbo].[BookRentalList] ([BookID], [BookRentalID], [No]) VALUES (17, 3, NULL)
GO
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1, N'Chính trị - pháp luật')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (2, N'Khoa học công nghệ')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (3, N'Văn học')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (4, N'Văn hóa xã hội - Lịch sử')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (5, N'Giáo trình')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (6, N'Truyện, tiểu thuyết')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (7, N'Tâm lý, tâm linh, tôn giáo')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (8, N'Sách thiếu nhi')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (9, N'Ca dao dân gian')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (10, N'Kỹ năng sống')
GO
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (1, N'ThoiHanThe', N'string', N'6', 1)
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (2, N'TuoiToiThieu', N'string', N'18', 1)
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (3, N'SoLuongSachDuocMuonToiDa', N'long', N'1', 1)
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (4, N'SoNgayMuonToiDa', N'long', N'15', 1)
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (5, N'KhoangCachNamXuatBan', N'long', N'10', 1)
GO
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (1, N'Trần Văn An', N'an@gmail.com', 1, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), N'Database\Images\ReaderImages\1.png')
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (2, N'Nguyễn Thị Bình', N'binh@gmail.com', 1, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), N'Database\Images\ReaderImages\2.png')
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (3, N'Lê Văn Cường', N'cuong@gmail.com', 0, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), N'Database\Images\ReaderImages\3.png')
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (4, N'Dương Văn Dương', N'duong@gmail.com', 0, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), N'Database\Images\ReaderImages\4.png')
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (5, N'Nguyễn Văn Tài Em', N'taiem@gmail.com', 0, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), N'Database\Images\ReaderImages\5.png')
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (6, N'Lê Văn Hoàng', N'letrung020820001@gmail.com', 0, CAST(N'2021-07-11T00:00:00.000' AS DateTime), CAST(N'2022-07-11T00:00:00.000' AS DateTime), N'Database\Images\ReaderImages\6.png')
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (7, N'Lê Văn Đức', N'letrung020820001@gmail.com', 0, CAST(N'2021-07-11T00:00:00.000' AS DateTime), CAST(N'2022-07-11T00:00:00.000' AS DateTime), N'Database\Images\ReaderImages\7.png')
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (8, N'Lê Văn Thành', N'letrung02082000@gmail.com', 1, CAST(N'2021-07-12T15:23:06.593' AS DateTime), CAST(N'2022-07-12T15:23:06.593' AS DateTime), N'Database\Images\ReaderImages\8.png')
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (9, N'Lê Văn Trung', N'letrung020820001@gmail.com', 0, CAST(N'2021-07-12T15:44:19.417' AS DateTime), CAST(N'2022-07-12T15:44:19.417' AS DateTime), N'Database\Images\ReaderImages\9.png')
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Category] FOREIGN KEY([CatID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Category]
GO
ALTER TABLE [dbo].[BookRentalHitory]  WITH CHECK ADD  CONSTRAINT [FK_BookRentalHitory_Reader] FOREIGN KEY([ReaderID])
REFERENCES [dbo].[Reader] ([ID])
GO
ALTER TABLE [dbo].[BookRentalHitory] CHECK CONSTRAINT [FK_BookRentalHitory_Reader]
GO
ALTER TABLE [dbo].[BookRentalList]  WITH CHECK ADD  CONSTRAINT [FK_BookRentalList_Book] FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[BookRentalList] CHECK CONSTRAINT [FK_BookRentalList_Book]
GO
ALTER TABLE [dbo].[BookRentalList]  WITH CHECK ADD  CONSTRAINT [FK_BookRentalList_BookRentalHitory] FOREIGN KEY([BookRentalID])
REFERENCES [dbo].[BookRentalHitory] ([ID])
GO
ALTER TABLE [dbo].[BookRentalList] CHECK CONSTRAINT [FK_BookRentalList_BookRentalHitory]
GO
ALTER TABLE [dbo].[StoredBook]  WITH CHECK ADD  CONSTRAINT [FK_StoredBook_Book] FOREIGN KEY([ID])
REFERENCES [dbo].[Book] ([ID])
GO
ALTER TABLE [dbo].[StoredBook] CHECK CONSTRAINT [FK_StoredBook_Book]
GO
USE [master]
GO
ALTER DATABASE [LibraryManagement] SET  READ_WRITE 
GO
