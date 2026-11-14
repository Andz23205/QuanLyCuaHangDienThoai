-- ============================================================
-- DATABASE: QLCuaHangBanDienThoai
-- Nhom 4 - Lap Trinh Truc Quan
-- Chay tren SQL Server (.\SQLEXPRESS hoac .\SQLEXPRESS01)
-- ============================================================

USE master;
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QLCuaHangBanDienThoai')
    DROP DATABASE QLCuaHangBanDienThoai;
GO

CREATE DATABASE QLCuaHangBanDienThoai;
GO

USE QLCuaHangBanDienThoai;
GO

-- ============================================================
-- TAO BANG
-- ============================================================

CREATE TABLE tblHangSX (
    MaHangSX    NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenHangSX   NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE tblLoai (
    MaLoai   NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenLoai  NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE tblMau (
    MaMau   NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenMau  NVARCHAR(50)  NOT NULL
);
GO

CREATE TABLE tblDungLuong (
    MaDungLuong   NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenDungLuong  NVARCHAR(50)  NOT NULL
);
GO

CREATE TABLE tblNhaCungCap (
    MaNCC   NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenNCC  NVARCHAR(100) NOT NULL,
    SDT     NVARCHAR(20)  NULL,
    DiaChi  NVARCHAR(200) NULL
);
GO

CREATE TABLE tblNhanVien (
    MaNV        NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenNV       NVARCHAR(100) NOT NULL,
    SDT         NVARCHAR(20)  NULL,
    DiaChi      NVARCHAR(200) NULL,
    ChucVu      NVARCHAR(50)  NULL,     -- 'Quan ly' hoac 'Nhan vien'
    TaiKhoan    NVARCHAR(50)  NULL,
    MatKhau     NVARCHAR(100) NULL
);
GO

CREATE TABLE tblKhachHang (
    MaKH    NVARCHAR(20)  NOT NULL PRIMARY KEY,
    TenKH   NVARCHAR(100) NOT NULL,
    SDT     NVARCHAR(20)  NULL,
    DiaChi  NVARCHAR(200) NULL
);
GO

CREATE TABLE tblHang (
    MaHang       NVARCHAR(20)   NOT NULL PRIMARY KEY,
    TenHang      NVARCHAR(200)  NOT NULL,
    MaHangSX     NVARCHAR(20)   NULL REFERENCES tblHangSX(MaHangSX),
    MaLoai       NVARCHAR(20)   NULL REFERENCES tblLoai(MaLoai),
    MaMau        NVARCHAR(20)   NULL REFERENCES tblMau(MaMau),
    MaDungLuong  NVARCHAR(20)   NULL REFERENCES tblDungLuong(MaDungLuong),
    DonGiaNhap   DECIMAL(18,2)  NOT NULL DEFAULT 0,
    DonGiaBan    DECIMAL(18,2)  NOT NULL DEFAULT 0,
    SoLuongTon   INT            NOT NULL DEFAULT 0,
    MoTa         NVARCHAR(500)  NULL
);
GO

CREATE TABLE tblHoaDonBan (
    MaHDB     NVARCHAR(30)  NOT NULL PRIMARY KEY,
    MaNV      NVARCHAR(20)  NOT NULL REFERENCES tblNhanVien(MaNV),
    MaKH      NVARCHAR(20)  NULL REFERENCES tblKhachHang(MaKH),
    NgayLap   DATETIME      NOT NULL DEFAULT GETDATE(),
    TongTien  DECIMAL(18,2) NOT NULL DEFAULT 0
);
GO

CREATE TABLE tblChiTietHDB (
    MaHDB     NVARCHAR(30)  NOT NULL REFERENCES tblHoaDonBan(MaHDB),
    MaHang    NVARCHAR(20)  NOT NULL REFERENCES tblHang(MaHang),
    SoLuong   INT           NOT NULL,
    DonGia    DECIMAL(18,2) NOT NULL,
    GiamGia   DECIMAL(5,2)  NOT NULL DEFAULT 0,
    ThanhTien DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHDB, MaHang)
);
GO

CREATE TABLE tblHoaDonNhap (
    MaHDN     NVARCHAR(30)  NOT NULL PRIMARY KEY,
    MaNV      NVARCHAR(20)  NOT NULL REFERENCES tblNhanVien(MaNV),
    MaNCC     NVARCHAR(20)  NOT NULL REFERENCES tblNhaCungCap(MaNCC),
    NgayNhap  DATETIME      NOT NULL DEFAULT GETDATE(),
    TongTien  DECIMAL(18,2) NOT NULL DEFAULT 0
);
GO

CREATE TABLE tblChiTietHDN (
    MaHDN       NVARCHAR(30)  NOT NULL REFERENCES tblHoaDonNhap(MaHDN),
    MaHang      NVARCHAR(20)  NOT NULL REFERENCES tblHang(MaHang),
    SoLuong     INT           NOT NULL,
    DonGiaNhap  DECIMAL(18,2) NOT NULL,
    ThanhTien   DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHDN, MaHang)
);
GO

-- ============================================================
-- DU LIEU MAU
-- ============================================================

INSERT INTO tblHangSX VALUES
('HSX001','Apple'),('HSX002','Samsung'),('HSX003','Xiaomi'),
('HSX004','OPPO'),('HSX005','Vivo'),('HSX006','Realme');
GO

INSERT INTO tblLoai VALUES
('L001','Điện thoại cao cấp'),('L002','Điện thoại tầm trung'),
('L003','Điện thoại phổ thông'),('L004','Máy tính bảng');
GO

INSERT INTO tblMau VALUES
('M001','Đen'),('M002','Trắng'),('M003','Xanh dương'),
('M004','Đỏ'),('M005','Vàng'),('M006','Hồng'),('M007','Xám');
GO

INSERT INTO tblDungLuong VALUES
('DL001','64GB'),('DL002','128GB'),('DL003','256GB'),
('DL004','512GB'),('DL005','1TB');
GO

INSERT INTO tblNhaCungCap VALUES
('NCC001','Công ty TNHH Phân phối Apple VN','0901234567','12 Nguyễn Huệ, Q1, TP.HCM'),
('NCC002','Samsung Electronics VN','0912345678','15 Lê Lợi, Q1, TP.HCM'),
('NCC003','Xiaomi Việt Nam','0923456789','20 Trần Hưng Đạo, Q5, TP.HCM'),
('NCC004','OPPO VN Co., Ltd','0934567890','8 Đinh Tiên Hoàng, Q1, TP.HCM'),
('NCC005','Vivo VN Technology','0945678901','25 Hai Bà Trưng, Q3, TP.HCM');
GO

INSERT INTO tblNhanVien VALUES
('NV001','Nguyễn Văn An','0901111111','10 Lê Duẩn, Q1, TP.HCM','Quan ly','an','123456'),
('NV002','Trần Thị Bình','0902222222','20 Điện Biên Phủ, Q3, TP.HCM','Nhan vien','binh','123456'),
('NV003','Lê Văn Cường','0903333333','30 Võ Văn Tần, Q3, TP.HCM','Nhan vien','cuong','123456'),
('NV004','Phạm Thị Dung','0904444444','40 Nam Kỳ Khởi Nghĩa, Q1, TP.HCM','Nhan vien','dung','123456'),
('NV005','Hoàng Văn Em','0905555555','50 Pasteur, Q1, TP.HCM','Nhan vien','em','123456'),
('NV006','Đặng Thị Phương','0906666666','60 Nguyễn Đình Chiểu, Q3, TP.HCM','Nhan vien','phuong','123456'),
('NV007','Bùi Văn Giang','0907777777','70 Lý Tự Trọng, Q1, TP.HCM','Nhan vien','giang','123456'),
('NV008','Ngô Thị Hoa','0908888888','80 Trần Phú, Q5, TP.HCM','Quan ly','hoa','123456');
GO

INSERT INTO tblKhachHang VALUES
('KH001','Nguyễn Thị Mai','0911111111','5 Hoàng Diệu, Q4, TP.HCM'),
('KH002','Trần Văn Nam','0922222222','15 Bến Vân Đồn, Q4, TP.HCM'),
('KH003','Lê Thị Oanh','0933333333','25 Khánh Hội, Q4, TP.HCM'),
('KH004','Phạm Văn Phúc','0944444444','35 Tôn Đức Thắng, Q1, TP.HCM'),
('KH005','Hoàng Thị Quỳnh','0955555555','45 Hai Bà Trưng, Q1, TP.HCM'),
('KH006','Đặng Văn Rồng','0966666666','55 Đinh Tiên Hoàng, Q1, TP.HCM'),
('KH007','Bùi Thị Sen','0977777777','65 Trần Quang Khải, Q1, TP.HCM'),
('KH008','Ngô Văn Tùng','0988888888','75 Lê Thánh Tôn, Q1, TP.HCM'),
('KH009','Vũ Thị Uyên','0999999999','85 Ngô Đức Kế, Q1, TP.HCM'),
('KH010','Dương Văn Việt','0910000000','95 Mạc Thị Bưởi, Q1, TP.HCM');
GO

INSERT INTO tblHang VALUES
('SP001','iPhone 15 Pro Max 256GB','HSX001','L001','M001','DL003',25000000,32000000,15,N'Chip A17 Pro, camera 48MP'),
('SP002','iPhone 15 128GB','HSX001','L001','M002','DL002',18000000,24000000,20,N'Chip A16, Dynamic Island'),
('SP003','Samsung Galaxy S24 Ultra','HSX002','L001','M001','DL003',22000000,28000000,12,N'Snapdragon 8 Gen 3, bút S Pen'),
('SP004','Samsung Galaxy A55','HSX002','L002','M003','DL002',7000000,9500000,30,N'Exynos 1480, chống nước IP67'),
('SP005','Xiaomi 14 Pro','HSX003','L001','M007','DL003',16000000,21000000,10,N'Snapdragon 8 Gen 3, Leica camera'),
('SP006','Xiaomi Redmi Note 13','HSX003','L002','M003','DL002',3500000,5000000,45,N'Helio G99, 108MP camera'),
('SP007','OPPO Find X7','HSX004','L001','M001','DL003',17000000,22000000,8,N'Hasselblad camera, Dimensity 9300'),
('SP008','OPPO A98','HSX004','L002','M002','DL002',5000000,7000000,35,N'Snapdragon 695, 67W charging'),
('SP009','Vivo X100 Pro','HSX005','L001','M001','DL003',18000000,23000000,7,N'Dimensity 9300, ZEISS camera'),
('SP010','Vivo Y36','HSX005','L003','M004','DL001',3000000,4200000,50,N'Snapdragon 680, 50MP camera'),
('SP011','Realme GT 5','HSX006','L001','M006','DL003',12000000,16000000,15,N'Snapdragon 8 Gen 2, 240W charging'),
('SP012','Realme C55','HSX006','L003','M002','DL002',2500000,3800000,60,N'Helio G88, 64MP camera'),
('SP013','iPhone 14 Pro 128GB','HSX001','L001','M005','DL002',20000000,26000000,8,N'Chip A16, Always-On display'),
('SP014','Samsung Galaxy Z Fold 5','HSX002','L001','M001','DL004',30000000,40000000,5,N'Màn hình gập, Snapdragon 8 Gen 2'),
('SP015','Xiaomi Poco X6 Pro','HSX003','L002','M007','DL002',6000000,8500000,25,N'Dimensity 8300, 144Hz display'),
('SP016','OPPO Reno 11','HSX004','L002','M006','DL002',7500000,10000000,20,N'Dimensity 7050, 80W charging'),
('SP017','Vivo V29e','HSX005','L002','M003','DL002',5500000,7500000,30,N'Snapdragon 695, 50MP selfie'),
('SP018','Realme 12 Pro+','HSX006','L002','M002','DL002',7000000,9500000,20,N'Snapdragon 7s Gen 2, periscope cam'),
('SP019','iPhone SE 2022','HSX001','L002','M002','DL002',10000000,14000000,12,N'Chip A15, thiết kế cổ điển'),
('SP020','Samsung Galaxy M34','HSX002','L003','M004','DL002',4000000,5800000,40,N'Exynos 1280, pin 6000mAh'),
('SP021','Xiaomi Redmi 12C','HSX003','L003','M003','DL001',1800000,2800000,70,N'Helio G85, pin 5000mAh'),
('SP022','OPPO A58','HSX004','L003','M002','DL001',2800000,4000000,55,N'Helio G85, 50MP camera'),
('SP023','Vivo Y17s','HSX005','L003','M005','DL001',2200000,3200000,65,N'Helio G85, pin 5000mAh'),
('SP024','Realme C30','HSX006','L003','M001','DL001',1500000,2400000,80,N'UNISOC T612, thiết kế mỏng'),
('SP025','iPhone 15 Pro 256GB','HSX001','L001','M007','DL003',23000000,30000000,10,N'Titanium, USB-C, A17 Pro'),
('SP026','Samsung Galaxy S23 FE','HSX002','L001','M006','DL002',9000000,12500000,18,N'Exynos 2200, 50MP camera'),
('SP027','Xiaomi 13T Pro','HSX003','L001','M001','DL003',14000000,19000000,12,N'Dimensity 9200+, Leica tuned'),
('SP028','OPPO Find N3 Flip','HSX004','L001','M001','DL003',18000000,24000000,6,N'Dimensity 9200, màn gập vỏ sò'),
('SP029','Vivo X90 Pro','HSX005','L001','M001','DL003',16000000,21000000,9,N'Dimensity 9200, ZEISS cinema cam'),
('SP030','Realme GT Neo 5','HSX006','L001','M007','DL003',10000000,14000000,14,N'Snapdragon 8+ Gen 1, 150W charging'),
('SP031','iPhone 12 64GB','HSX001','L002','M002','DL001',9000000,12000000,5,N'Chip A14, 5G, OLED'),
('SP032','Samsung Galaxy A14','HSX002','L003','M003','DL001',2500000,3600000,50,N'Exynos 850, 50MP camera'),
('SP033','Xiaomi Poco M6 Pro','HSX003','L002','M004','DL002',4500000,6500000,30,N'Helio G99 Ultra, 64MP');
GO

INSERT INTO tblHoaDonBan VALUES
('HDB001','NV001','KH001','2026-10-01',32000000),
('HDB002','NV002','KH002','2026-10-05',9500000),
('HDB003','NV001','KH003','2026-10-10',24000000),
('HDB004','NV003','KH004','2026-10-15',5000000),
('HDB005','NV002','KH005','2026-10-20',28000000),
('HDB006','NV001','KH006','2026-10-25',14000000),
('HDB007','NV003','KH007','2026-10-30',9500000);
GO

INSERT INTO tblChiTietHDB VALUES
('HDB001','SP001',1,32000000,0,32000000),
('HDB002','SP004',1,9500000,0,9500000),
('HDB003','SP002',1,24000000,0,24000000),
('HDB004','SP006',1,5000000,0,5000000),
('HDB005','SP003',1,28000000,0,28000000),
('HDB006','SP011',1,16000000,0,16000000),('HDB006','SP012',1,3800000,10,3420000),
('HDB007','SP008',1,7000000,0,7000000),('HDB007','SP010',1,4200000,5,3990000);
GO

INSERT INTO tblHoaDonNhap VALUES
('HDN001','NV001','NCC001','2026-09-01',375000000),
('HDN002','NV001','NCC002','2026-09-05',297000000),
('HDN003','NV001','NCC003','2026-09-10',242500000);
GO

INSERT INTO tblChiTietHDN VALUES
('HDN001','SP001',15,25000000,375000000),
('HDN002','SP003',9,22000000,198000000),('HDN002','SP004',9,7000000,63000000),
('HDN003','SP005',5,16000000,80000000),('HDN003','SP006',15,3500000,52500000),('HDN003','SP007',5,17000000,85000000);
GO

-- ============================================================
-- STORED PROCEDURES
-- ============================================================

-- 1. Lay danh sach hang hoa
IF OBJECT_ID('sp_LayDanhSachHang','P') IS NOT NULL DROP PROCEDURE sp_LayDanhSachHang;
GO
CREATE PROCEDURE sp_LayDanhSachHang
AS
BEGIN
    SELECT h.MaHang, h.TenHang,
           hs.TenHangSX AS Hang, l.TenLoai AS Loai,
           m.TenMau AS Mau, dl.TenDungLuong AS DungLuong,
           h.DonGiaNhap, h.DonGiaBan, h.SoLuongTon, h.MoTa
    FROM tblHang h
    LEFT JOIN tblHangSX  hs ON h.MaHangSX    = hs.MaHangSX
    LEFT JOIN tblLoai     l  ON h.MaLoai      = l.MaLoai
    LEFT JOIN tblMau      m  ON h.MaMau       = m.MaMau
    LEFT JOIN tblDungLuong dl ON h.MaDungLuong = dl.MaDungLuong
    ORDER BY h.TenHang;
END
GO

-- 2. Tim kiem hang hoa
IF OBJECT_ID('sp_TimKiemHang','P') IS NOT NULL DROP PROCEDURE sp_TimKiemHang;
GO
CREATE PROCEDURE sp_TimKiemHang
    @TenHang    NVARCHAR(200) = NULL,
    @MaHangSX   NVARCHAR(20)  = NULL,
    @MaLoai     NVARCHAR(20)  = NULL,
    @MaMau      NVARCHAR(20)  = NULL,
    @GiaTu      DECIMAL(18,2) = NULL,
    @GiaDen     DECIMAL(18,2) = NULL
AS
BEGIN
    SELECT h.MaHang, h.TenHang,
           hs.TenHangSX AS Hang, l.TenLoai AS Loai,
           m.TenMau AS Mau, dl.TenDungLuong AS DungLuong,
           h.DonGiaNhap, h.DonGiaBan, h.SoLuongTon, h.MoTa
    FROM tblHang h
    LEFT JOIN tblHangSX   hs ON h.MaHangSX    = hs.MaHangSX
    LEFT JOIN tblLoai      l  ON h.MaLoai      = l.MaLoai
    LEFT JOIN tblMau       m  ON h.MaMau       = m.MaMau
    LEFT JOIN tblDungLuong dl ON h.MaDungLuong = dl.MaDungLuong
    WHERE (@TenHang  IS NULL OR h.TenHang  LIKE N'%' + @TenHang + '%')
      AND (@MaHangSX IS NULL OR h.MaHangSX = @MaHangSX)
      AND (@MaLoai   IS NULL OR h.MaLoai   = @MaLoai)
      AND (@MaMau    IS NULL OR h.MaMau    = @MaMau)
      AND (@GiaTu    IS NULL OR h.DonGiaBan >= @GiaTu)
      AND (@GiaDen   IS NULL OR h.DonGiaBan <= @GiaDen)
    ORDER BY h.TenHang;
END
GO

-- 3. Them hang hoa
IF OBJECT_ID('sp_ThemHang','P') IS NOT NULL DROP PROCEDURE sp_ThemHang;
GO
CREATE PROCEDURE sp_ThemHang
    @MaHang      NVARCHAR(20),
    @TenHang     NVARCHAR(200),
    @MaHangSX    NVARCHAR(20),
    @MaLoai      NVARCHAR(20),
    @MaMau       NVARCHAR(20),
    @MaDungLuong NVARCHAR(20),
    @DonGiaNhap  DECIMAL(18,2),
    @DonGiaBan   DECIMAL(18,2),
    @SoLuongTon  INT,
    @MoTa        NVARCHAR(500)
AS
BEGIN
    INSERT INTO tblHang(MaHang,TenHang,MaHangSX,MaLoai,MaMau,MaDungLuong,DonGiaNhap,DonGiaBan,SoLuongTon,MoTa)
    VALUES(@MaHang,@TenHang,@MaHangSX,@MaLoai,@MaMau,@MaDungLuong,@DonGiaNhap,@DonGiaBan,@SoLuongTon,@MoTa);
END
GO

-- 4. Cap nhat hang hoa
IF OBJECT_ID('sp_CapNhatHang','P') IS NOT NULL DROP PROCEDURE sp_CapNhatHang;
GO
CREATE PROCEDURE sp_CapNhatHang
    @MaHang      NVARCHAR(20),
    @TenHang     NVARCHAR(200),
    @MaHangSX    NVARCHAR(20),
    @MaLoai      NVARCHAR(20),
    @MaMau       NVARCHAR(20),
    @MaDungLuong NVARCHAR(20),
    @DonGiaNhap  DECIMAL(18,2),
    @DonGiaBan   DECIMAL(18,2),
    @SoLuongTon  INT,
    @MoTa        NVARCHAR(500)
AS
BEGIN
    UPDATE tblHang SET
        TenHang=@TenHang, MaHangSX=@MaHangSX, MaLoai=@MaLoai,
        MaMau=@MaMau, MaDungLuong=@MaDungLuong, DonGiaNhap=@DonGiaNhap,
        DonGiaBan=@DonGiaBan, SoLuongTon=@SoLuongTon, MoTa=@MoTa
    WHERE MaHang=@MaHang;
END
GO

-- 5. Xoa hang hoa
IF OBJECT_ID('sp_XoaHang','P') IS NOT NULL DROP PROCEDURE sp_XoaHang;
GO
CREATE PROCEDURE sp_XoaHang @MaHang NVARCHAR(20)
AS
BEGIN
    DELETE FROM tblHang WHERE MaHang=@MaHang;
END
GO

-- 6. Kiem tra dang nhap
IF OBJECT_ID('sp_KiemTraDangNhap','P') IS NOT NULL DROP PROCEDURE sp_KiemTraDangNhap;
GO
CREATE PROCEDURE sp_KiemTraDangNhap
    @TaiKhoan NVARCHAR(50),
    @MatKhau  NVARCHAR(100)
AS
BEGIN
    SELECT MaNV, TenNV, ChucVu, TaiKhoan
    FROM tblNhanVien
    WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau;
END
GO

PRINT N'Tao database QLCuaHangBanDienThoai thanh cong!';
GO
