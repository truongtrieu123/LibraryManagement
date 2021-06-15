USE [master]
GO
/****** Object:  Database [LibraryMangement]    Script Date: 6/15/2021 3:26:36 PM ******/
CREATE DATABASE [LibraryMangement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryMangement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LibraryMangement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryMangement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LibraryMangement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LibraryMangement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryMangement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryMangement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryMangement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryMangement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryMangement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryMangement] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryMangement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibraryMangement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryMangement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryMangement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryMangement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryMangement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryMangement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryMangement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryMangement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryMangement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibraryMangement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryMangement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryMangement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryMangement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryMangement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryMangement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryMangement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryMangement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryMangement] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryMangement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryMangement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryMangement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryMangement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryMangement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryMangement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LibraryMangement] SET QUERY_STORE = OFF
GO
USE [LibraryMangement]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 6/15/2021 3:26:37 PM ******/
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
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookRentalHitory]    Script Date: 6/15/2021 3:26:37 PM ******/
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
/****** Object:  Table [dbo].[BookRentalList]    Script Date: 6/15/2021 3:26:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookRentalList](
	[BookID] [bigint] NOT NULL,
	[BookRentalID] [bigint] NOT NULL,
 CONSTRAINT [PK_BookRentalList] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC,
	[BookRentalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/15/2021 3:26:37 PM ******/
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
/****** Object:  Table [dbo].[Config]    Script Date: 6/15/2021 3:26:37 PM ******/
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
/****** Object:  Table [dbo].[Reader]    Script Date: 6/15/2021 3:26:37 PM ******/
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
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Reader] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoredBook]    Script Date: 6/15/2021 3:26:37 PM ******/
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
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (1, N'21 Bài Học Cho Thế Kỷ 21', 4, N'Yuval Noah Harari ', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A11', N'Nhà Xuất Bản Tổng Hợp', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (2, N'Sapiens: Lược Sử Loài Người Bằng Tranh - Tập 1: Khởi Đầu Của Loài Người', 4, N'Yuval Noah Harari', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A12', N'Nhà Xuất Bản Tổng Hợp', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (3, N'Sapiens: Lược Sử Loài Người ', 4, N'Yuval Noah Harai', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A13', N'Nhà Xuất Bản Tổng Hợp', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (4, N'Homo Deus: Lược Sử Tươ', 4, N'Yuval Noah Harari', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A14', N'Nhà Xuất Bản Tổng Hợp', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (5, N'Chủ Nghĩa Khắc Kỷ', 7, N'William B. Irvine', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A15', N'Nhà Xuất Bản Thái Hà', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (6, N'Đàn Ông Sao Hỏa Đàn Bà Sao Kim', 7, N'John Gray', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A16', N'Nhà Xuất Bản Hồng Đức', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (7, N'Nhà giả kim', 6, N'Paulo Coelho', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A17', N'Nhà Xuất Bản Hội Nhà Văn', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (8, N'Hoàng tử bé', 6, N'Antone De Saint Exupery', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A18', N'Nhà Xuất Bản Hội Nhà Văn', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (9, N'The Story Of Art - Câu Chuyện Nghệ', 3, N'E.H Gombrich', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A19', N'Nhà Xuất Bản Dân Trí', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (10, N'Siêu Nhí Hỏi Nhà Khoa Học Trả Lời - 100 Bí Ẩn Mọi Đứa Trẻ Đều Muốn Hỏi Một Nhà', 2, N'Robert Winston', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A20', N'Nhà Xuất Bản Dân Trí
', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (11, N'Bách Khoa Tri Thức Về Khám Phá Thế Giới Cho Trẻ Em - Thiên Văn Học ', 2, N'Rachel Firth', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A21', N'Nhà Xuất Bản Thế Giới', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (12, N'Sách Pháp Luật Về Giao Dịch Điện Tử Trên Thị Trường Chứng Khoán Ở Việt Nam Năm 2020 - NXB Chính Trị Quốc Gia Sự Thật', 1, N'PGS.TS. Phạm Thị Giang Thu (Chủ biên) - ThS. Nguyễn Thu Trang - TS. Nguyễn Ngọc Lương', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A22', N'Nhà Xuất Bản Chính Trị Quốc Gia Sự Thật', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (13, N'Giáo Trình C++ Và Lập Trì', 5, N'GS. Phạm Văn Ất ( chủ biên), Lê Trường Thông', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A23', N'Nhà Xuất Bản Bách Khoa Hà Nội', NULL)
INSERT [dbo].[Book] ([ID], [Name], [CatID], [Author], [PublicationDate], [ImportDate], [StorageState], [Location], [PublishingCompany], [Image]) VALUES (14, N'Doraemon', 8, N'Fujiko F. Fujio', CAST(N'2019-09-01T00:00:00.000' AS DateTime), CAST(N'2020-09-01T00:00:00.000' AS DateTime), 0, N'A24', N'Nhà Xuất Bản Kim Đồng', NULL)
GO
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1, N'Chính trị - pháp luật')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (2, N'Khoa học công nghệ - Kinh tế')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (3, N'Văn học nghệ thuật')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (4, N'Văn hóa xã hội - Lịch sử')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (5, N'Giáo trình')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (6, N'Truyện, tiểu thuyết')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (7, N'Tâm lý, tâm linh, tôn giáo')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (8, N'Sách thiếu nhi')
GO
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (1, N'ThoiHanThe', N'string', N'1', 1)
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (2, N'TuoiToiThieu', N'string', N'18', 1)
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (3, N'SoLuongSachDuocMuonToiDa', N'long', N'3', 1)
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (4, N'SoNgayMuonToiDa', N'long', N'7', 1)
INSERT [dbo].[Config] ([ID], [Name], [DateType], [Value], [State]) VALUES (5, N'KhoangCachNamXuatBan', N'long', N'6', 1)
GO
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (1, N'Trần Văn An', N'an@gmail.com', NULL, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (2, N'Nguyễn Thị Bình', N'binh@gmail.com', NULL, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (3, N'Lê Văn Cường', N'cuong@gmail.com', NULL, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (4, N'Dương Văn Dương', N'duong@gmail.com', NULL, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Reader] ([ID], [Name], [Email], [CatID], [CreatedDate], [ExpiryDate], [Image]) VALUES (5, N'Nguyễn Văn Tài Em', N'taiem@gmail.com', NULL, CAST(N'2021-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
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
ALTER DATABASE [LibraryMangement] SET  READ_WRITE 
GO
