USE [QLCuaHangBanDienThoai];
GO

-- 1. Thu tuc lay danh sach hang kem thong tin chi tiet
CREATE OR ALTER PROCEDURE sp_LayDanhSachHang
AS
BEGIN
    SET NOCOUNT ON;
    SELECT h.MaHang, h.TenHang, sx.TenHangSX AS Hang, l.TenLoai AS Loai, 
           m.TenMau AS Mau, dl.TenDungLuong AS DungLuong,
           h.DonGiaNhap AS GiaNhap, h.DonGiaBan AS GiaBan, h.SoLuongTon AS SoLuong,
           h.MaHangSX, h.MaLoai, h.MaMau, h.MaDungLuong
    FROM tblHang h
    LEFT JOIN tblHangSX sx ON h.MaHangSX = sx.MaHangSX
    LEFT JOIN tblLoai l ON h.MaLoai = l.MaLoai
    LEFT JOIN tblMau m ON h.MaMau = m.MaMau
    LEFT JOIN tblDungLuong dl ON h.MaDungLuong = dl.MaDungLuong
    ORDER BY h.MaHang;
END;
GO

-- 2. Thu tuc them san pham moi
CREATE OR ALTER PROCEDURE sp_ThemHang
    @MaHang NVARCHAR(20),
    @TenHang NVARCHAR(100),
    @MaHangSX NVARCHAR(20),
    @MaLoai NVARCHAR(20),
    @MaMau NVARCHAR(20),
    @MaDungLuong NVARCHAR(20),
    @DonGiaNhap DECIMAL(18,2),
    @DonGiaBan DECIMAL(18,2),
    @SoLuongTon INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblHang (MaHang, TenHang, MaHangSX, MaLoai, MaMau, MaDungLuong, DonGiaNhap, DonGiaBan, SoLuongTon)
    VALUES (@MaHang, @TenHang, @MaHangSX, @MaLoai, @MaMau, @MaDungLuong, @DonGiaNhap, @DonGiaBan, @SoLuongTon);
END;
GO

-- 3. Thu tuc cap nhat san pham
CREATE OR ALTER PROCEDURE sp_CapNhatHang
    @MaHang NVARCHAR(20),
    @TenHang NVARCHAR(100),
    @MaHangSX NVARCHAR(20),
    @MaLoai NVARCHAR(20),
    @MaMau NVARCHAR(20),
    @MaDungLuong NVARCHAR(20),
    @DonGiaNhap DECIMAL(18,2),
    @DonGiaBan DECIMAL(18,2),
    @SoLuongTon INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblHang
    SET TenHang = @TenHang,
        MaHangSX = @MaHangSX,
        MaLoai = @MaLoai,
        MaMau = @MaMau,
        MaDungLuong = @MaDungLuong,
        DonGiaNhap = @DonGiaNhap,
        DonGiaBan = @DonGiaBan,
        SoLuongTon = @SoLuongTon
    WHERE MaHang = @MaHang;
END;
GO

-- 4. Thu tuc xoa san pham
CREATE OR ALTER PROCEDURE sp_XoaHang
    @MaHang NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM tblHang WHERE MaHang = @MaHang;
END;
GO

-- 5. Thu tuc kiem tra dang nhap
CREATE OR ALTER PROCEDURE sp_KiemTraDangNhap
    @TaiKhoan NVARCHAR(50),
    @MatKhau NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaNV, TenNV, VaiTro 
    FROM tblNhanVien 
    WHERE (TenDangNhap = @TaiKhoan OR MaNV = @TaiKhoan) AND MatKhau = @MatKhau;
END;
GO

-- 6. Thu tuc tim kiem hang da tieu chi
CREATE OR ALTER PROCEDURE sp_TimKiemHang
    @TenHang NVARCHAR(100) = NULL,
    @MaHangSX NVARCHAR(20) = NULL,
    @MaLoai NVARCHAR(20) = NULL,
    @MaMau NVARCHAR(20) = NULL,
    @GiaTu DECIMAL(18,2) = NULL,
    @GiaDen DECIMAL(18,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT h.MaHang, h.TenHang, sx.TenHangSX AS Hang, l.TenLoai AS Loai, 
           m.TenMau AS Mau, dl.TenDungLuong AS DungLuong,
           h.DonGiaBan, h.SoLuongTon
    FROM tblHang h
    LEFT JOIN tblHangSX sx ON h.MaHangSX = sx.MaHangSX
    LEFT JOIN tblLoai l ON h.MaLoai = l.MaLoai
    LEFT JOIN tblMau m ON h.MaMau = m.MaMau
    LEFT JOIN tblDungLuong dl ON h.MaDungLuong = dl.MaDungLuong
    WHERE (@TenHang IS NULL OR h.TenHang LIKE '%' + @TenHang + '%')
      AND (@MaHangSX IS NULL OR @MaHangSX = '' OR h.MaHangSX = @MaHangSX)
      AND (@MaLoai IS NULL OR @MaLoai = '' OR h.MaLoai = @MaLoai)
      AND (@MaMau IS NULL OR @MaMau = '' OR h.MaMau = @MaMau)
      AND (@GiaTu IS NULL OR h.DonGiaBan >= @GiaTu)
      AND (@GiaDen IS NULL OR h.DonGiaBan <= @GiaDen)
    ORDER BY h.MaHang;
END;
GO