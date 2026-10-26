USE [master]
GO
/****** Object:  Database [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF]    Script Date: 10/26/2026 9:54:18 AM ******/
CREATE DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLCuaHangBanDienThoai', FILENAME = N'C:\Users\Admin\source\repos\QuanLyCuaHangDienThoai\QLCuaHangBanDienThoai.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLCuaHangBanDienThoai_log', FILENAME = N'C:\Users\Admin\source\repos\QuanLyCuaHangDienThoai\QLCuaHangBanDienThoai_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET ARITHABORT OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET  ENABLE_BROKER 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET  MULTI_USER 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET QUERY_STORE = ON
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF]
GO
/****** Object:  Table [dbo].[tblChiTietHDB]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHDB](
	[MaHDB] [nvarchar](30) NOT NULL,
	[MaHang] [nvarchar](20) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](18, 2) NOT NULL,
	[GiamGia] [decimal](5, 2) NOT NULL,
	[ThanhTien] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC,
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblChiTietHDN]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHDN](
	[MaHDN] [nvarchar](30) NOT NULL,
	[MaHang] [nvarchar](20) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGiaNhap] [decimal](18, 2) NOT NULL,
	[ThanhTien] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC,
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDungLuong]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDungLuong](
	[MaDungLuong] [nvarchar](20) NOT NULL,
	[TenDungLuong] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDungLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHang]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHang](
	[MaHang] [nvarchar](20) NOT NULL,
	[TenHang] [nvarchar](100) NOT NULL,
	[MaHangSX] [nvarchar](20) NULL,
	[MaLoai] [nvarchar](20) NULL,
	[MaMau] [nvarchar](20) NULL,
	[MaDungLuong] [nvarchar](20) NULL,
	[DonGiaBan] [decimal](18, 2) NOT NULL,
	[DonGiaNhap] [decimal](18, 2) NOT NULL,
	[SoLuongTon] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHangSX]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHangSX](
	[MaHangSX] [nvarchar](20) NOT NULL,
	[TenHangSX] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHangSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHoaDonBan]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoaDonBan](
	[MaHDB] [nvarchar](30) NOT NULL,
	[MaNV] [nvarchar](20) NOT NULL,
	[MaKH] [nvarchar](20) NULL,
	[NgayLap] [datetime] NOT NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHoaDonNhap]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoaDonNhap](
	[MaHDN] [nvarchar](30) NOT NULL,
	[MaNV] [nvarchar](20) NOT NULL,
	[MaNCC] [nvarchar](20) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKhachHang]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhachHang](
	[MaKH] [nvarchar](20) NOT NULL,
	[TenKH] [nvarchar](100) NOT NULL,
	[SDT] [nvarchar](15) NULL,
	[DiaChi] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLoai]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLoai](
	[MaLoai] [nvarchar](20) NOT NULL,
	[TenLoai] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblMau]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMau](
	[MaMau] [nvarchar](20) NOT NULL,
	[TenMau] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMau] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNhaCungCap]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhaCungCap](
	[MaNCC] [nvarchar](20) NOT NULL,
	[TenNCC] [nvarchar](100) NOT NULL,
	[SDT] [nvarchar](15) NULL,
	[DiaChi] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 10/26/2026 9:54:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[MaNV] [nvarchar](20) NOT NULL,
	[TenNV] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [date] NULL,
	[SDT] [nvarchar](15) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](255) NULL,
	[VaiTro] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB_20261025112424540', N'DT001', 2, CAST(30990000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(61980000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB001', N'DT001', 1, CAST(30990000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(30990000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB005', N'DT002', 1, CAST(19990000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(19990000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB002', N'DT006', 1, CAST(24500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(24500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB003', N'DT011', 2, CAST(5290000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(10580000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB004', N'DT016', 1, CAST(10990000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(10990000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB006', N'DT019', 1, CAST(11990000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(11990000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB004', N'PK001', 1, CAST(550000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(550000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB006', N'PK003', 1, CAST(990000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(990000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB002', N'PK005', 2, CAST(450000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(900000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB003', N'PK006', 1, CAST(180000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(180000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDB] ([MaHDB], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB001', N'PK007', 1, CAST(150000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(5, 2)), CAST(150000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN001', N'DT001', 5, CAST(27000000.00 AS Decimal(18, 2)), CAST(135000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN001', N'PK004', 20, CAST(220000.00 AS Decimal(18, 2)), CAST(4400000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN001', N'PK007', 30, CAST(70000.00 AS Decimal(18, 2)), CAST(2100000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN002', N'DT006', 4, CAST(21000000.00 AS Decimal(18, 2)), CAST(84000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN002', N'DT011', 10, CAST(4200000.00 AS Decimal(18, 2)), CAST(42000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN002', N'PK005', 15, CAST(300000.00 AS Decimal(18, 2)), CAST(4500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN003', N'PK006', 20, CAST(90000.00 AS Decimal(18, 2)), CAST(1800000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN003', N'PK009', 10, CAST(450000.00 AS Decimal(18, 2)), CAST(4500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblChiTietHDN] ([MaHDN], [MaHang], [SoLuong], [DonGiaNhap], [ThanhTien]) VALUES (N'HDN003', N'TB001', 3, CAST(10000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblDungLuong] ([MaDungLuong], [TenDungLuong]) VALUES (N'DL001', N'32GB')
GO
INSERT [dbo].[tblDungLuong] ([MaDungLuong], [TenDungLuong]) VALUES (N'DL002', N'64GB')
GO
INSERT [dbo].[tblDungLuong] ([MaDungLuong], [TenDungLuong]) VALUES (N'DL003', N'128GB')
GO
INSERT [dbo].[tblDungLuong] ([MaDungLuong], [TenDungLuong]) VALUES (N'DL004', N'256GB')
GO
INSERT [dbo].[tblDungLuong] ([MaDungLuong], [TenDungLuong]) VALUES (N'DL005', N'512GB')
GO
INSERT [dbo].[tblDungLuong] ([MaDungLuong], [TenDungLuong]) VALUES (N'DL006', N'1TB')
GO
INSERT [dbo].[tblDungLuong] ([MaDungLuong], [TenDungLuong]) VALUES (N'DL007', N'Không áp dụng')
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT001', N'iPhone 15 Pro Max', N'HSX001', N'L001', N'M001', N'DL005', CAST(30990000.00 AS Decimal(18, 2)), CAST(27000000.00 AS Decimal(18, 2)), 13)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT002', N'iPhone 15', N'HSX001', N'L001', N'M002', N'DL003', CAST(19990000.00 AS Decimal(18, 2)), CAST(17000000.00 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT003', N'iPhone 14', N'HSX001', N'L001', N'M003', N'DL003', CAST(15990000.00 AS Decimal(18, 2)), CAST(13500000.00 AS Decimal(18, 2)), 18)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT004', N'iPhone 13', N'HSX001', N'L001', N'M001', N'DL003', CAST(12990000.00 AS Decimal(18, 2)), CAST(11000000.00 AS Decimal(18, 2)), 12)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT005', N'iPhone 15 Pro', N'HSX001', N'L001', N'M004', N'DL004', CAST(25990000.00 AS Decimal(18, 2)), CAST(22500000.00 AS Decimal(18, 2)), 10)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT006', N'Samsung Galaxy S24 Ultra', N'HSX002', N'L001', N'M001', N'DL005', CAST(24500000.00 AS Decimal(18, 2)), CAST(21000000.00 AS Decimal(18, 2)), 12)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT007', N'Samsung Galaxy S24+', N'HSX002', N'L001', N'M003', N'DL004', CAST(19990000.00 AS Decimal(18, 2)), CAST(17200000.00 AS Decimal(18, 2)), 14)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT008', N'Samsung Galaxy A55', N'HSX002', N'L001', N'M003', N'DL003', CAST(9990000.00 AS Decimal(18, 2)), CAST(8200000.00 AS Decimal(18, 2)), 22)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT009', N'Samsung Galaxy A35', N'HSX002', N'L001', N'M001', N'DL003', CAST(7490000.00 AS Decimal(18, 2)), CAST(6200000.00 AS Decimal(18, 2)), 25)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT010', N'Samsung Galaxy Z Flip5', N'HSX002', N'L001', N'M005', N'DL004', CAST(18990000.00 AS Decimal(18, 2)), CAST(16000000.00 AS Decimal(18, 2)), 8)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT011', N'Xiaomi Redmi Note 13', N'HSX003', N'L001', N'M001', N'DL003', CAST(5290000.00 AS Decimal(18, 2)), CAST(4200000.00 AS Decimal(18, 2)), 25)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT012', N'Xiaomi Redmi Note 13 Pro', N'HSX003', N'L001', N'M003', N'DL004', CAST(7990000.00 AS Decimal(18, 2)), CAST(6500000.00 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT013', N'Xiaomi 14', N'HSX003', N'L001', N'M004', N'DL004', CAST(19990000.00 AS Decimal(18, 2)), CAST(17000000.00 AS Decimal(18, 2)), 10)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT014', N'Xiaomi Redmi 13C', N'HSX003', N'L001', N'M002', N'DL003', CAST(3290000.00 AS Decimal(18, 2)), CAST(2600000.00 AS Decimal(18, 2)), 30)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT015', N'Xiaomi POCO X6 Pro', N'HSX003', N'L001', N'M003', N'DL004', CAST(8990000.00 AS Decimal(18, 2)), CAST(7300000.00 AS Decimal(18, 2)), 16)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT016', N'OPPO Reno12', N'HSX004', N'L001', N'M003', N'DL004', CAST(10990000.00 AS Decimal(18, 2)), CAST(9000000.00 AS Decimal(18, 2)), 18)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT017', N'OPPO A79', N'HSX004', N'L001', N'M001', N'DL003', CAST(5990000.00 AS Decimal(18, 2)), CAST(4800000.00 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT018', N'OPPO Find N3 Flip', N'HSX004', N'L001', N'M005', N'DL004', CAST(19990000.00 AS Decimal(18, 2)), CAST(17000000.00 AS Decimal(18, 2)), 7)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT019', N'Vivo V40', N'HSX005', N'L001', N'M004', N'DL004', CAST(11990000.00 AS Decimal(18, 2)), CAST(9800000.00 AS Decimal(18, 2)), 10)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT020', N'Vivo Y28', N'HSX005', N'L001', N'M003', N'DL003', CAST(5990000.00 AS Decimal(18, 2)), CAST(4800000.00 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT021', N'Realme 12+', N'HSX006', N'L001', N'M003', N'DL004', CAST(7990000.00 AS Decimal(18, 2)), CAST(6500000.00 AS Decimal(18, 2)), 15)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'DT022', N'Realme C67', N'HSX006', N'L001', N'M001', N'DL003', CAST(4990000.00 AS Decimal(18, 2)), CAST(4000000.00 AS Decimal(18, 2)), 24)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK001', N'Apple EarPods USB-C', N'HSX001', N'L003', N'M002', N'DL007', CAST(550000.00 AS Decimal(18, 2)), CAST(350000.00 AS Decimal(18, 2)), 40)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK002', N'Tai nghe Samsung Buds FE', N'HSX002', N'L003', N'M001', N'DL007', CAST(1990000.00 AS Decimal(18, 2)), CAST(1500000.00 AS Decimal(18, 2)), 25)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK003', N'Tai nghe Xiaomi Redmi Buds 5', N'HSX003', N'L003', N'M002', N'DL007', CAST(990000.00 AS Decimal(18, 2)), CAST(700000.00 AS Decimal(18, 2)), 30)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK004', N'Sac Anker 20W', N'HSX010', N'L004', N'M002', N'DL007', CAST(350000.00 AS Decimal(18, 2)), CAST(220000.00 AS Decimal(18, 2)), 35)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK005', N'Sac Samsung 25W', N'HSX002', N'L004', N'M001', N'DL007', CAST(450000.00 AS Decimal(18, 2)), CAST(300000.00 AS Decimal(18, 2)), 30)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK006', N'Cap USB-C Anker', N'HSX010', N'L005', N'M001', N'DL007', CAST(180000.00 AS Decimal(18, 2)), CAST(90000.00 AS Decimal(18, 2)), 40)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK007', N'Op lung iPhone 15', N'HSX001', N'L006', N'M002', N'DL007', CAST(150000.00 AS Decimal(18, 2)), CAST(70000.00 AS Decimal(18, 2)), 50)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK008', N'Kinh cuong luc iPhone 15', N'HSX001', N'L007', N'M002', N'DL007', CAST(100000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)), 60)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'PK009', N'Pin du phong Anker 10000mAh', N'HSX010', N'L008', N'M001', N'DL007', CAST(650000.00 AS Decimal(18, 2)), CAST(450000.00 AS Decimal(18, 2)), 20)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'TB001', N'iPad Gen 10', N'HSX001', N'L002', N'M004', N'DL004', CAST(11990000.00 AS Decimal(18, 2)), CAST(10000000.00 AS Decimal(18, 2)), 10)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaHangSX], [MaLoai], [MaMau], [MaDungLuong], [DonGiaBan], [DonGiaNhap], [SoLuongTon]) VALUES (N'TB002', N'Samsung Galaxy Tab S9 FE', N'HSX002', N'L002', N'M003', N'DL004', CAST(9990000.00 AS Decimal(18, 2)), CAST(8200000.00 AS Decimal(18, 2)), 8)
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX001', N'Apple')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX002', N'Samsung')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX003', N'Xiaomi')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX004', N'OPPO')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX005', N'Vivo')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX006', N'Realme')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX007', N'ASUS')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX008', N'Huawei')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX009', N'Nokia')
GO
INSERT [dbo].[tblHangSX] ([MaHangSX], [TenHangSX]) VALUES (N'HSX010', N'Anker')
GO
INSERT [dbo].[tblHoaDonBan] ([MaHDB], [MaNV], [MaKH], [NgayLap], [TongTien]) VALUES (N'HDB_20261025112424540', N'NV001', NULL, CAST(N'2026-10-25T11:24:24.550' AS DateTime), CAST(61980000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonBan] ([MaHDB], [MaNV], [MaKH], [NgayLap], [TongTien]) VALUES (N'HDB001', N'NV001', N'KH001', CAST(N'2026-10-12T00:00:00.000' AS DateTime), CAST(31140000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonBan] ([MaHDB], [MaNV], [MaKH], [NgayLap], [TongTien]) VALUES (N'HDB002', N'NV002', N'KH002', CAST(N'2026-10-13T00:00:00.000' AS DateTime), CAST(25400000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonBan] ([MaHDB], [MaNV], [MaKH], [NgayLap], [TongTien]) VALUES (N'HDB003', N'NV003', N'KH003', CAST(N'2026-10-14T00:00:00.000' AS DateTime), CAST(10760000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonBan] ([MaHDB], [MaNV], [MaKH], [NgayLap], [TongTien]) VALUES (N'HDB004', N'NV004', N'KH004', CAST(N'2026-10-15T00:00:00.000' AS DateTime), CAST(11540000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonBan] ([MaHDB], [MaNV], [MaKH], [NgayLap], [TongTien]) VALUES (N'HDB005', N'NV005', N'KH005', CAST(N'2026-10-16T00:00:00.000' AS DateTime), CAST(19990000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonBan] ([MaHDB], [MaNV], [MaKH], [NgayLap], [TongTien]) VALUES (N'HDB006', N'NV001', N'KH006', CAST(N'2026-10-17T00:00:00.000' AS DateTime), CAST(12980000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonNhap] ([MaHDN], [MaNV], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'HDN001', N'NV001', N'NCC001', CAST(N'2026-10-01T00:00:00.000' AS DateTime), CAST(141500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonNhap] ([MaHDN], [MaNV], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'HDN002', N'NV002', N'NCC002', CAST(N'2026-10-05T00:00:00.000' AS DateTime), CAST(130500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblHoaDonNhap] ([MaHDN], [MaNV], [MaNCC], [NgayNhap], [TongTien]) VALUES (N'HDN003', N'NV003', N'NCC004', CAST(N'2026-10-10T00:00:00.000' AS DateTime), CAST(36300000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH001', N'Phạm Quốc Huy', N'0911000001', N'Hà Nội')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH002', N'Nguyễn Thị Mai', N'0911000002', N'Hải Phòng')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH003', N'Trần Minh Tuấn', N'0911000003', N'Đà Nẵng')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH004', N'Lê Thu Trang', N'0911000004', N'TP. Hồ Chí Minh')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH005', N'Hoàng Anh Dũng', N'0911000005', N'Bắc Ninh')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH006', N'Vũ Ngọc Linh', N'0911000006', N'Cần Thơ')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH007', N'Đặng Quốc Bảo', N'0911000007', N'Hà Nội')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH008', N'Bùi Thanh Tâm', N'0911000008', N'Nam Định')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH009', N'Đỗ Minh Quân', N'0911000009', N'Hải Dương')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH010', N'Phan Thị Hương', N'0911000010', N'Hà Nội')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH011', N'Nguyễn Đức Long', N'0911000011', N'Thanh Hóa')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH012', N'Trần Ngọc Anh', N'0911000012', N'Nghệ An')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH013', N'Lê Hoàng Nam', N'0911000013', N'Đà Nẵng')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH014', N'Phạm Mỹ Linh', N'0911000014', N'TP. Hồ Chí Minh')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH015', N'Đặng Văn Phúc', N'0911000015', N'Bình Dương')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH016', N'Võ Thị Ngân', N'0911000016', N'Hà Nội')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH017', N'Nguyễn Thành Đạt', N'0911000017', N'Hưng Yên')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH018', N'Phạm Khánh Vy', N'0911000018', N'Quảng Ninh')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH019', N'Đỗ Anh Khoa', N'0911000019', N'Hải Phòng')
GO
INSERT [dbo].[tblKhachHang] ([MaKH], [TenKH], [SDT], [DiaChi]) VALUES (N'KH020', N'Hoàng Thu Hà', N'0911000020', N'Đồng Nai')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L001', N'Điện thoại')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L002', N'Máy tính bảng')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L003', N'Tai nghe')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L004', N'Sạc điện thoại')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L005', N'Cáp sạc')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L006', N'Ốp lưng')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L007', N'Kính cường lực')
GO
INSERT [dbo].[tblLoai] ([MaLoai], [TenLoai]) VALUES (N'L008', N'Pin dự phòng')
GO
INSERT [dbo].[tblMau] ([MaMau], [TenMau]) VALUES (N'M001', N'Đen')
GO
INSERT [dbo].[tblMau] ([MaMau], [TenMau]) VALUES (N'M002', N'Trắng')
GO
INSERT [dbo].[tblMau] ([MaMau], [TenMau]) VALUES (N'M003', N'Xanh')
GO
INSERT [dbo].[tblMau] ([MaMau], [TenMau]) VALUES (N'M004', N'Bạc')
GO
INSERT [dbo].[tblMau] ([MaMau], [TenMau]) VALUES (N'M005', N'Tím')
GO
INSERT [dbo].[tblMau] ([MaMau], [TenMau]) VALUES (N'M006', N'Vàng')
GO
INSERT [dbo].[tblMau] ([MaMau], [TenMau]) VALUES (N'M007', N'Hồng')
GO
INSERT [dbo].[tblMau] ([MaMau], [TenMau]) VALUES (N'M008', N'Xám')
GO
INSERT [dbo].[tblNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi]) VALUES (N'NCC001', N'Công ty TNHH Phân phối Apple', N'0921000001', N'Hà Nội')
GO
INSERT [dbo].[tblNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi]) VALUES (N'NCC002', N'Công ty Điện tử Samsung', N'0921000002', N'TP. Hồ Chí Minh')
GO
INSERT [dbo].[tblNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi]) VALUES (N'NCC003', N'Công ty Xiaomi Việt Nam', N'0921000003', N'Đà Nẵng')
GO
INSERT [dbo].[tblNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi]) VALUES (N'NCC004', N'Công ty Phụ kiện Anker', N'0921000004', N'Hà Nội')
GO
INSERT [dbo].[tblNhaCungCap] ([MaNCC], [TenNCC], [SDT], [DiaChi]) VALUES (N'NCC005', N'Công ty Thiết bị di động Việt', N'0921000005', N'Bắc Ninh')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'NV001', N'Nguyễn Văn An', N'Nam', CAST(N'2000-03-15' AS Date), N'0901234567', N'Hà Nội', N'an', N'123456', N'Quản lý')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'NV002', N'Trần Thị Bình', N'Nữ', CAST(N'2001-07-20' AS Date), N'0902345678', N'Hà Nội', N'binh', N'123456', N'Nhân viên')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'NV003', N'Lê Văn Cường', N'Nam', CAST(N'2000-11-08' AS Date), N'0903456789', N'Hải Phòng', N'cuong', N'123456', N'Nhân viên')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'NV004', N'Phạm Thị Dung', N'Nữ', CAST(N'2002-01-12' AS Date), N'0904567890', N'Đà Nẵng', N'dung', N'123456', N'Nhân viên')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'NV005', N'Hoàng Văn Đức', N'Nam', CAST(N'1999-09-25' AS Date), N'0905678901', N'TP. Hồ Chí Minh', N'duc', N'123456', N'Nhân viên')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'NV006', N'Vũ Thị Hà', N'Nữ', CAST(N'2001-05-30' AS Date), N'0906789012', N'Cần Thơ', N'ha', N'123456', N'Nhân viên')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'NV007', N'Đặng Minh Khoa', N'Nam', CAST(N'2000-12-05' AS Date), N'0907890123', N'Hà Nội', N'khoa', N'123456', N'Nhân viên')
GO
INSERT [dbo].[tblNhanVien] ([MaNV], [TenNV], [GioiTinh], [NgaySinh], [SDT], [DiaChi], [TenDangNhap], [MatKhau], [VaiTro]) VALUES (N'NV008', N'Bùi Thị Lan', N'Nữ', CAST(N'2002-08-18' AS Date), N'0908901234', N'Bắc Ninh', N'lan', N'123456', N'Nhân viên')
GO
ALTER TABLE [dbo].[tblChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDB_tblHang] FOREIGN KEY([MaHang])
REFERENCES [dbo].[tblHang] ([MaHang])
GO
ALTER TABLE [dbo].[tblChiTietHDB] CHECK CONSTRAINT [FK_tblChiTietHDB_tblHang]
GO
ALTER TABLE [dbo].[tblChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDB_tblHoaDonBan] FOREIGN KEY([MaHDB])
REFERENCES [dbo].[tblHoaDonBan] ([MaHDB])
GO
ALTER TABLE [dbo].[tblChiTietHDB] CHECK CONSTRAINT [FK_tblChiTietHDB_tblHoaDonBan]
GO
ALTER TABLE [dbo].[tblChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDN_tblHang] FOREIGN KEY([MaHang])
REFERENCES [dbo].[tblHang] ([MaHang])
GO
ALTER TABLE [dbo].[tblChiTietHDN] CHECK CONSTRAINT [FK_tblChiTietHDN_tblHang]
GO
ALTER TABLE [dbo].[tblChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDN_tblHoaDonNhap] FOREIGN KEY([MaHDN])
REFERENCES [dbo].[tblHoaDonNhap] ([MaHDN])
GO
ALTER TABLE [dbo].[tblChiTietHDN] CHECK CONSTRAINT [FK_tblChiTietHDN_tblHoaDonNhap]
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD  CONSTRAINT [FK_tblHang_tblDungLuong] FOREIGN KEY([MaDungLuong])
REFERENCES [dbo].[tblDungLuong] ([MaDungLuong])
GO
ALTER TABLE [dbo].[tblHang] CHECK CONSTRAINT [FK_tblHang_tblDungLuong]
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD  CONSTRAINT [FK_tblHang_tblHangSX] FOREIGN KEY([MaHangSX])
REFERENCES [dbo].[tblHangSX] ([MaHangSX])
GO
ALTER TABLE [dbo].[tblHang] CHECK CONSTRAINT [FK_tblHang_tblHangSX]
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD  CONSTRAINT [FK_tblHang_tblLoai] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[tblLoai] ([MaLoai])
GO
ALTER TABLE [dbo].[tblHang] CHECK CONSTRAINT [FK_tblHang_tblLoai]
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD  CONSTRAINT [FK_tblHang_tblMau] FOREIGN KEY([MaMau])
REFERENCES [dbo].[tblMau] ([MaMau])
GO
ALTER TABLE [dbo].[tblHang] CHECK CONSTRAINT [FK_tblHang_tblMau]
GO
ALTER TABLE [dbo].[tblHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonBan_tblKhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[tblKhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[tblHoaDonBan] CHECK CONSTRAINT [FK_tblHoaDonBan_tblKhachHang]
GO
ALTER TABLE [dbo].[tblHoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonBan_tblNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tblHoaDonBan] CHECK CONSTRAINT [FK_tblHoaDonBan_tblNhanVien]
GO
ALTER TABLE [dbo].[tblHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonNhap_tblNhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[tblNhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[tblHoaDonNhap] CHECK CONSTRAINT [FK_tblHoaDonNhap_tblNhaCungCap]
GO
ALTER TABLE [dbo].[tblHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_tblHoaDonNhap_tblNhanVien] FOREIGN KEY([MaNV])
REFERENCES [dbo].[tblNhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[tblHoaDonNhap] CHECK CONSTRAINT [FK_tblHoaDonNhap_tblNhanVien]
GO
USE [master]
GO
ALTER DATABASE [C:\USERS\ADMIN\SOURCE\REPOS\QUANLYCUAHANGDIENTHOAI\QLCUAHANGBANDIENTHOAI.MDF] SET  READ_WRITE 
GO
