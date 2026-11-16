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
('L001',N'Điện thoại cao cấp'),('L002',N'Điện thoại tầm trung'),
('L003',N'Điện thoại phổ thông'),('L004',N'Máy tính bảng');
GO

INSERT INTO tblMau VALUES
('M001',N'Đen'),('M002',N'Trắng'),('M003',N'Xanh dương'),
('M004',N'Đỏ'),('M005',N'Vàng'),('M006',N'Hồng'),('M007',N'Xám');
GO

INSERT INTO tblDungLuong VALUES
('DL001',N'64GB'),('DL002',N'128GB'),('DL003',N'256GB'),
('DL004',N'512GB'),('DL005',N'1TB');
GO

INSERT INTO tblNhaCungCap VALUES
('NCC001',N'Công ty TNHH Phân phối Apple VN','0901234567',N'12 Nguyễn Huệ, Q1, TP.HCM'),
('NCC002',N'Samsung Electronics VN','0912345678',N'15 Lê Lợi, Q1, TP.HCM'),
('NCC003',N'Xiaomi Việt Nam','0923456789',N'20 Trần Hưng Đạo, Q5, TP.HCM'),
('NCC004',N'OPPO VN Co., Ltd','0934567890',N'8 Đinh Tiên Hoàng, Q1, TP.HCM'),
('NCC005',N'Vivo VN Technology','0945678901',N'25 Hai Bà Trưng, Q3, TP.HCM');
GO

INSERT INTO tblNhanVien VALUES
('NV001',N'Nguyễn Văn An','0901111111',N'10 Lê Duẩn, Q1, TP.HCM','Quan ly','an','123456'),
('NV002',N'Trần Thị Bình','0902222222',N'20 Điện Biên Phủ, Q3, TP.HCM','Nhan vien','binh','123456'),
('NV003',N'Lê Văn Cường','0903333333',N'30 Võ Văn Tần, Q3, TP.HCM','Nhan vien','cuong','123456'),
('NV004',N'Phạm Thị Dung','0904444444',N'40 Nam Kỳ Khởi Nghĩa, Q1, TP.HCM','Nhan vien','dung','123456'),
('NV005',N'Hoàng Văn Em','0905555555',N'50 Pasteur, Q1, TP.HCM','Nhan vien','em','123456'),
('NV006',N'Đặng Thị Phương','0906666666',N'60 Nguyễn Đình Chiểu, Q3, TP.HCM','Nhan vien','phuong','123456'),
('NV007',N'Bùi Văn Giang','0907777777',N'70 Lý Tự Trọng, Q1, TP.HCM','Nhan vien','giang','123456'),
('NV008',N'Ngô Thị Hoa','0908888888',N'80 Trần Phú, Q5, TP.HCM','Quan ly','hoa','123456');
GO

INSERT INTO tblKhachHang VALUES
('KH001',N'Nguyễn Thị Mai','0911111111',N'5 Hoàng Diệu, Q4, TP.HCM'),
('KH002',N'Trần Văn Nam','0922222222',N'15 Bến Vân Đồn, Q4, TP.HCM'),
('KH003',N'Lê Thị Oanh','0933333333',N'25 Khánh Hội, Q4, TP.HCM'),
('KH004',N'Phạm Văn Phúc','0944444444',N'35 Tôn Đức Thắng, Q1, TP.HCM'),
('KH005',N'Hoàng Thị Quỳnh','0955555555',N'45 Hai Bà Trưng, Q1, TP.HCM'),
('KH006',N'Đặng Văn Long','0966666666',N'55 Đinh Tiên Hoàng, Q1, TP.HCM'),
('KH007',N'Bùi Thị Sen','0977777777',N'65 Trần Quang Khải, Q1, TP.HCM'),
('KH008',N'Ngô Văn Tùng','0988888888',N'75 Lê Thánh Tôn, Q1, TP.HCM'),
('KH009',N'Vũ Thị Uyên','0999999999',N'85 Ngô Đức Kế, Q1, TP.HCM'),
('KH010',N'Dương Văn Việt','0910000000',N'95 Mạc Thị Bưởi, Q1, TP.HCM');
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
('SP023','Vivo Y17s','HSX005','L003','M005','DL001',2200000,3200000,65,N'Helio G85, pin 5000mAh'),
('SP024','Realme C30','HSX006','L003','M001','DL001',1500000,2400000,80,N'UNISOC T612, thiết kế mỏng'),
('SP025','iPhone 15 Pro 256GB','HSX001','L001','M007','DL003',23000000,30000000,10,N'Titanium, USB-C, A17 Pro'),
('SP026','Samsung Galaxy S23 FE','HSX002','L001','M006','DL002',9000000,12500000,18,N'Exynos 2200, 50MP camera'),
('SP027','Xiaomi 13T Pro','HSX003','L001','M001','DL003',14000000,19000000,12,N'Dimensity 9200+, Leica tuned');

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
    SET NOCOUNT ON;

    -- C# NhanVienBUS doc cot r["VaiTro"], trong bang hien tai cot that la ChucVu.
    -- Alias ChucVu thanh VaiTro de dong bo ten cot tra ve voi DTO/BUS.
    SELECT
        MaNV,
        TenNV,
        ChucVu AS VaiTro,
        TaiKhoan
    FROM dbo.tblNhanVien
    WHERE TaiKhoan = @TaiKhoan
      AND MatKhau = @MatKhau;
END
GO

PRINT N'Tao database QLCuaHangBanDienThoai thanh cong!';
GO



/* =====================================================
   1. BỔ SUNG CỘT CHO tblNhanVien
   ===================================================== */

IF COL_LENGTH('dbo.tblNhanVien', 'GioiTinh') IS NULL
    ALTER TABLE tblNhanVien ADD GioiTinh NVARCHAR(10) NULL;
GO

IF COL_LENGTH('dbo.tblNhanVien', 'NgaySinh') IS NULL
    ALTER TABLE tblNhanVien ADD NgaySinh DATE NULL;
GO

IF COL_LENGTH('dbo.tblNhanVien', 'TrangThai') IS NULL
    ALTER TABLE tblNhanVien
    ADD TrangThai NVARCHAR(50) NULL
        CONSTRAINT DF_tblNhanVien_TrangThai
        DEFAULT N'Đang làm việc' WITH VALUES;
GO

/* Dữ liệu cũ chưa có trạng thái thì mặc định là đang làm việc */
UPDATE tblNhanVien
SET TrangThai = N'Đang làm việc'
WHERE TrangThai IS NULL;
GO

/* =====================================================
   2. BỔ SUNG EMAIL CHO tblKhachHang
   ===================================================== */

IF COL_LENGTH('dbo.tblKhachHang', 'Email') IS NULL
    ALTER TABLE tblKhachHang ADD Email NVARCHAR(150) NULL;
GO

/* =====================================================
   3. BỔ SUNG EMAIL VÀ NGƯỜI LIÊN HỆ CHO tblNhaCungCap
   ===================================================== */

IF COL_LENGTH('dbo.tblNhaCungCap', 'Email') IS NULL
    ALTER TABLE tblNhaCungCap ADD Email NVARCHAR(255) NULL;
GO

IF COL_LENGTH('dbo.tblNhaCungCap', 'NguoiLH') IS NULL
    ALTER TABLE tblNhaCungCap ADD NguoiLH NVARCHAR(100) NULL;
GO

UPDATE tblNhaCungCap
SET Email = N'applevn@gmail.com',
    NguoiLH = N'Nguyễn Văn An'
WHERE MaNCC = 'NCC001';

UPDATE tblNhaCungCap
SET Email = N'samsungvn@gmail.com',
    NguoiLH = N'Trần Minh Tuấn'
WHERE MaNCC = 'NCC002';

UPDATE tblNhaCungCap
SET Email = N'xiaomivn@gmail.com',
    NguoiLH = N'Lê Hoàng Nam'
WHERE MaNCC = 'NCC003';

UPDATE tblNhaCungCap
SET Email = N'oppovn@gmail.com',
    NguoiLH = N'Phạm Quốc Bảo'
WHERE MaNCC = 'NCC004';

UPDATE tblNhaCungCap
SET Email = N'vivovn@gmail.com',
    NguoiLH = N'Vũ Thanh Hùng'
WHERE MaNCC = 'NCC005';
GO


UPDATE dbo.tblNhanVien
SET GioiTinh = N'Nam', NgaySinh = '2002-01-15'
WHERE MaNV = 'NV001';

UPDATE dbo.tblNhanVien
SET GioiTinh = N'Nữ', NgaySinh = '2002-04-20'
WHERE MaNV = 'NV002';

UPDATE dbo.tblNhanVien
SET GioiTinh = N'Nam', NgaySinh = '2001-08-12'
WHERE MaNV = 'NV003';

UPDATE dbo.tblNhanVien
SET GioiTinh = N'Nữ', NgaySinh = '2003-02-25'
WHERE MaNV = 'NV004';

UPDATE dbo.tblNhanVien
SET GioiTinh = N'Nam', NgaySinh = '2002-06-18'
WHERE MaNV = 'NV005';

UPDATE dbo.tblNhanVien
SET GioiTinh = N'Nữ', NgaySinh = '2001-11-09'
WHERE MaNV = 'NV006';

UPDATE dbo.tblNhanVien
SET GioiTinh = N'Nam', NgaySinh = '2003-07-22'
WHERE MaNV = 'NV007';

UPDATE dbo.tblNhanVien
SET GioiTinh = N'Nữ', NgaySinh = '2002-09-30'
WHERE MaNV = 'NV008';
GO

UPDATE dbo.tblKhachHang SET Email = 'mai.nguyen@example.com'
WHERE MaKH = 'KH001';

UPDATE dbo.tblKhachHang SET Email = 'nam.tran@example.com'
WHERE MaKH = 'KH002';

UPDATE dbo.tblKhachHang SET Email = 'oanh.le@example.com'
WHERE MaKH = 'KH003';

UPDATE dbo.tblKhachHang SET Email = 'phuc.pham@example.com'
WHERE MaKH = 'KH004';

UPDATE dbo.tblKhachHang SET Email = 'quynh.hoang@example.com'
WHERE MaKH = 'KH005';

UPDATE dbo.tblKhachHang SET Email = 'long.dang@example.com'
WHERE MaKH = 'KH006';

UPDATE dbo.tblKhachHang SET Email = 'sen.bui@example.com'
WHERE MaKH = 'KH007';

UPDATE dbo.tblKhachHang SET Email = 'tung.ngo@example.com'
WHERE MaKH = 'KH008';

UPDATE dbo.tblKhachHang SET Email = 'uyen.vu@example.com'
WHERE MaKH = 'KH009';

UPDATE dbo.tblKhachHang SET Email = 'viet.duong@example.com'
WHERE MaKH = 'KH010';
GO

USE QLCuaHangBanDienThoai;
GO

DECLARE @MaNV VARCHAR(10);
DECLARE @MaKH VARCHAR(10);
DECLARE @i INT = 0;

-- Lấy mã nhân viên và khách hàng đang tồn tại
SELECT TOP 1 @MaNV = MaNV FROM dbo.tblNhanVien ORDER BY MaNV;
SELECT TOP 1 @MaKH = MaKH FROM dbo.tblKhachHang ORDER BY MaKH;

-- Kiểm tra dữ liệu đầu vào
IF @MaNV IS NULL OR @MaKH IS NULL
BEGIN
    PRINT N'Không tìm thấy nhân viên hoặc khách hàng. Hãy kiểm tra dữ liệu hai bảng.';
    RETURN;
END;

DECLARE @DoanhThu TABLE
(
    Ngay INT,
    TongTien DECIMAL(18,2)
);

INSERT INTO @DoanhThu (Ngay, TongTien)
VALUES
    (0, 2500000),
    (1, 4200000),
    (2, 1800000),
    (3, 6500000),
    (4, 3200000),
    (5, 7800000),
    (6, 5500000);

WHILE @i <= 6
BEGIN
    INSERT INTO dbo.tblHoaDonBan
    (
        MaHDB,
        MaNV,
        MaKH,
        NgayLap,
        TongTien
    )
    VALUES
    (
        'TEST' + RIGHT('000' + CAST(@i + 1 AS VARCHAR(3)), 3),
        @MaNV,
        @MaKH,
        DATEADD(DAY, -@i, GETDATE()),
        (SELECT TongTien FROM @DoanhThu WHERE Ngay = @i)
    );

    SET @i = @i + 1;
END;
GO


/* =====================================================
   4. BỔ SUNG TÀI KHOẢN VÀ MẬT KHẨU CHO tblKhachHang
   ===================================================== */

IF COL_LENGTH('dbo.tblKhachHang', 'TaiKhoan') IS NULL
    ALTER TABLE dbo.tblKhachHang
    ADD TaiKhoan NVARCHAR(50) NULL;
GO

IF COL_LENGTH('dbo.tblKhachHang', 'MatKhau') IS NULL
    ALTER TABLE dbo.tblKhachHang
    ADD MatKhau NVARCHAR(255) NULL;
GO

/* Đảm bảo mỗi khách hàng có một tài khoản riêng */
IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'UX_tblKhachHang_TaiKhoan'
      AND object_id = OBJECT_ID('dbo.tblKhachHang')
)
BEGIN
    CREATE UNIQUE INDEX UX_tblKhachHang_TaiKhoan
    ON dbo.tblKhachHang(TaiKhoan)
    WHERE TaiKhoan IS NOT NULL;
END;
GO

USE QLCuaHangBanDienThoai;
GO

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'mai.nguyen',
    MatKhau = N'123456'
WHERE MaKH = 'KH001';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'nam.tran',
    MatKhau = N'123456'
WHERE MaKH = 'KH002';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'oanh.le',
    MatKhau = N'123456'
WHERE MaKH = 'KH003';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'phuc.pham',
    MatKhau = N'123456'
WHERE MaKH = 'KH004';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'quynh.hoang',
    MatKhau = N'123456'
WHERE MaKH = 'KH005';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'long.dang',
    MatKhau = N'123456'
WHERE MaKH = 'KH006';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'sen.bui',
    MatKhau = N'123456'
WHERE MaKH = 'KH007';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'tung.ngo',
    MatKhau = N'123456'
WHERE MaKH = 'KH008';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'uyen.vu',
    MatKhau = N'123456'
WHERE MaKH = 'KH009';

UPDATE dbo.tblKhachHang SET
    TaiKhoan = N'viet.duong',
    MatKhau = N'123456'
WHERE MaKH = 'KH010';
GO

USE QLCuaHangBanDienThoai;
GO

IF COL_LENGTH('dbo.tblHang', 'TenAnh') IS NULL
BEGIN
    ALTER TABLE dbo.tblHang
    ADD TenAnh NVARCHAR(255) NULL;
END;
GO

UPDATE tblHang
SET TenAnh = 'iphone18.jpg'
WHERE MaHang = 'SP001';

UPDATE tblHang
SET TenAnh = 'samsung_s25.jpg'
WHERE MaHang = 'SP002';


USE QLCuaHangBanDienThoai;
GO

-- Bổ sung trạng thái thanh toán nếu chưa có
IF COL_LENGTH('dbo.tblHoaDonBan', 'TrangThaiThanhToan') IS NULL
BEGIN
    ALTER TABLE dbo.tblHoaDonBan
    ADD TrangThaiThanhToan NVARCHAR(30)
        NOT NULL
        CONSTRAINT DF_tblHoaDonBan_TrangThaiThanhToan
        DEFAULT N'Chưa thanh toán';
END
GO

-- Bổ sung phương thức thanh toán
IF COL_LENGTH('dbo.tblHoaDonBan', 'PhuongThucThanhToan') IS NULL
BEGIN
    ALTER TABLE dbo.tblHoaDonBan
    ADD PhuongThucThanhToan NVARCHAR(50) NULL;
END
GO

-- Bổ sung ngày thanh toán
IF COL_LENGTH('dbo.tblHoaDonBan', 'NgayThanhToan') IS NULL
BEGIN
    ALTER TABLE dbo.tblHoaDonBan
    ADD NgayThanhToan DATETIME NULL;
END
GO

-- Kiểm tra nhân viên hệ thống NV001 có tồn tại không
SELECT MaNV, TenNV
FROM dbo.tblNhanVien
WHERE MaNV = 'NV001';
GO


USE QLCuaHangBanDienThoai;
GO

-- Kiểm tra các cột thanh toán
SELECT
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'tblHoaDonBan';
GO

-- Kiểm tra nhân viên hệ thống NV001
SELECT *
FROM tblNhanVien
WHERE MaNV = 'NV001';
GO

-- Kiểm tra cấu trúc chi tiết hóa đơn
SELECT
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'tblChiTietHDB';
GO

USE QLCuaHangBanDienThoai;
GO

IF COL_LENGTH('dbo.tblHoaDonBan', 'PhuongThucThanhToan') IS NULL
BEGIN
    ALTER TABLE dbo.tblHoaDonBan
    ADD PhuongThucThanhToan NVARCHAR(50) NULL;
END
GO

UPDATE tblHoaDonBan
SET TrangThaiThanhToan = N'Đã thanh toán',
    NgayThanhToan = GETDATE()
WHERE MaHDB = 'MÃ_HÓA_ĐƠN'
  AND TrangThaiThanhToan = N'Chờ xác nhận chuyển khoản';




  SELECT MaHang, TenHang, TenAnh
FROM tblHang;


SELECT MaHang, TenHang, Hang, Mau, DungLuong,
       DonGiaBan, SoLuongTon, TenAnh
FROM tblHang;