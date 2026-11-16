USE [QLCuaHangBanDienThoai];
GO

-- 1. Thu tuc lay danh sach hang kem thong tin chi tiet



CREATE OR ALTER PROCEDURE sp_LayDanhSachHang
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        h.MaHang,
        h.TenHang,

        -- Mã danh mục để Form1 chọn và cập nhật
        h.MaHangSX,
        h.MaLoai,
        h.MaMau,
        h.MaDungLuong,

        -- Tên danh mục để hiển thị
        hs.TenHangSX AS Hang,
        l.TenLoai AS Loai,
        m.TenMau AS Mau,
        dl.TenDungLuong AS DungLuong,

        -- Thông tin sản phẩm
        h.DonGiaNhap,
        h.DonGiaBan,
        h.SoLuongTon,
        h.MoTa,
        h.TenAnh

    FROM dbo.tblHang h
    LEFT JOIN dbo.tblHangSX hs
        ON h.MaHangSX = hs.MaHangSX
    LEFT JOIN dbo.tblLoai l
        ON h.MaLoai = l.MaLoai
    LEFT JOIN dbo.tblMau m
        ON h.MaMau = m.MaMau
    LEFT JOIN dbo.tblDungLuong dl
        ON h.MaDungLuong = dl.MaDungLuong

    ORDER BY h.TenHang;
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
    @SoLuongTon INT,
    @TenAnh NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SoDong INT;

    INSERT INTO dbo.tblHang
    (
        MaHang, TenHang, MaHangSX, MaLoai,
        MaMau, MaDungLuong, DonGiaNhap,
        DonGiaBan, SoLuongTon, TenAnh
    )
    VALUES
    (
        @MaHang, @TenHang, @MaHangSX, @MaLoai,
        @MaMau, @MaDungLuong, @DonGiaNhap,
        @DonGiaBan, @SoLuongTon, @TenAnh
    );

    SET @SoDong = @@ROWCOUNT;

    RETURN @SoDong;
END;
GO



-- 3. Thu tuc cap nhat san pham
CREATE OR ALTER PROCEDURE sp_CapNhatHang
    @MaHang NVARCHAR(20),
    @TenHang NVARCHAR(100),
    @MaHangSX NVARCHAR(20) = NULL,
    @MaLoai NVARCHAR(20) = NULL,
    @MaMau NVARCHAR(20) = NULL,
    @MaDungLuong NVARCHAR(20) = NULL,
    @DonGiaNhap DECIMAL(18,2),
    @DonGiaBan DECIMAL(18,2),
    @SoLuongTon INT,
    @TenAnh NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE tblHang
    SET
        TenHang = @TenHang,
        MaHangSX = @MaHangSX,
        MaLoai = @MaLoai,
        MaMau = @MaMau,
        MaDungLuong = @MaDungLuong,
        DonGiaNhap = @DonGiaNhap,
        DonGiaBan = @DonGiaBan,
        SoLuongTon = @SoLuongTon,
        TenAnh = @TenAnh
    WHERE MaHang = @MaHang;

    DECLARE @SoDong INT = @@ROWCOUNT;

    RETURN @SoDong;
END;
GO

-- 4. Thu tuc xoa san pham
CREATE OR ALTER PROCEDURE sp_XoaHang
    @MaHang NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM tblHang
    WHERE MaHang = @MaHang;

    DECLARE @SoDong INT = @@ROWCOUNT;

    RETURN @SoDong;
END;
GO

-- 5. Thu tuc kiem tra dang nhap

CREATE OR ALTER PROCEDURE sp_KiemTraDangNhap
    @TaiKhoan NVARCHAR(50),
    @MatKhau NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        MaNV,
        TenNV,
        ChucVu AS VaiTro,
        TaiKhoan
    FROM dbo.tblNhanVien
    WHERE TaiKhoan = @TaiKhoan
      AND MatKhau = @MatKhau;
END;
GO

-- 6. Thu tuc tim kiem hang da tieu chi
CREATE OR ALTER PROCEDURE sp_TimKiemHang
    @TenHang NVARCHAR(200) = NULL,
    @MaHangSX NVARCHAR(20) = NULL,
    @MaLoai NVARCHAR(20) = NULL,
    @MaMau NVARCHAR(20) = NULL,
    @GiaTu DECIMAL(18,2) = NULL,
    @GiaDen DECIMAL(18,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        h.MaHang,
        h.TenHang,

        h.MaHangSX,
        h.MaLoai,
        h.MaMau,
        h.MaDungLuong,

        hs.TenHangSX AS Hang,
        l.TenLoai AS Loai,
        m.TenMau AS Mau,
        dl.TenDungLuong AS DungLuong,

        h.DonGiaNhap,
        h.DonGiaBan,
        h.SoLuongTon,
        h.MoTa,
        h.TenAnh

    FROM dbo.tblHang h

    LEFT JOIN dbo.tblHangSX hs
        ON h.MaHangSX = hs.MaHangSX

    LEFT JOIN dbo.tblLoai l
        ON h.MaLoai = l.MaLoai

    LEFT JOIN dbo.tblMau m
        ON h.MaMau = m.MaMau

    LEFT JOIN dbo.tblDungLuong dl
        ON h.MaDungLuong = dl.MaDungLuong

    WHERE
        (@TenHang IS NULL OR h.TenHang LIKE N'%' + @TenHang + '%')
        AND (@MaHangSX IS NULL OR h.MaHangSX = @MaHangSX)
        AND (@MaLoai IS NULL OR h.MaLoai = @MaLoai)
        AND (@MaMau IS NULL OR h.MaMau = @MaMau)
        AND (@GiaTu IS NULL OR h.DonGiaBan >= @GiaTu)
        AND (@GiaDen IS NULL OR h.DonGiaBan <= @GiaDen)

    ORDER BY h.TenHang;
END;
GO


