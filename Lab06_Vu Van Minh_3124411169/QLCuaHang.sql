-- ==============================================================
-- CO SO DU LIEU: QLCuaHang
-- Sinh vien: Vu Van Minh - MSSV: 3124411169
-- ==============================================================
USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QLCuaHang')
BEGIN
    CREATE DATABASE QLCuaHang;
END
GO

USE QLCuaHang;
GO

-- 1. Bang SANPHAM
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SANPHAM' AND xtype='U')
BEGIN
    CREATE TABLE SANPHAM (
        MaSP INT IDENTITY(1,1) PRIMARY KEY,
        TenSP NVARCHAR(100) NOT NULL
    );
END
GO

-- 2. Bang TONKHO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TONKHO' AND xtype='U')
BEGIN
    CREATE TABLE TONKHO (
        MaSP INT NOT NULL,
        NgayTon DATE NOT NULL,
        SLDau INT DEFAULT 0,
        SLNhap INT DEFAULT 0,
        SLBan INT DEFAULT 0,
        PRIMARY KEY (MaSP, NgayTon),
        CONSTRAINT FK_TONKHO_SANPHAM FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
    );
END
GO

-- 3. Bang HOADON
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='HOADON' AND xtype='U')
BEGIN
    CREATE TABLE HOADON (
        MaHD INT IDENTITY(1,1) PRIMARY KEY,
        NgayTao DATETIME DEFAULT GETDATE(),
        TinhTrangThanhToan INT DEFAULT 0 -- 0: Chua thanh toan, 1: Da thanh toan
    );
END
GO

-- 4. Bang CHITIET_HOADON
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CHITIET_HOADON' AND xtype='U')
BEGIN
    CREATE TABLE CHITIET_HOADON (
        MaHD INT NOT NULL,
        MaSP INT NOT NULL,
        SoLuong INT NOT NULL,
        PRIMARY KEY (MaHD, MaSP),
        CONSTRAINT FK_CTHD_HOADON FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD),
        CONSTRAINT FK_CTHD_SANPHAM FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
    );
END
GO

-- Du lieu mau ban dau (theo hinh de bai)
DELETE FROM CHITIET_HOADON;
DELETE FROM HOADON;
DELETE FROM TONKHO;
DELETE FROM SANPHAM;
GO

DBCC CHECKIDENT ('SANPHAM', RESEED, 0);
DBCC CHECKIDENT ('HOADON', RESEED, 0);
GO

SET IDENTITY_INSERT SANPHAM ON;
INSERT INTO SANPHAM (MaSP, TenSP) VALUES
    (1, N'Trà xanh'),
    (2, N'Mức dâu'),
    (3, N'Cafe');
SET IDENTITY_INSERT SANPHAM OFF;
GO

-- Ton kho ban dau theo de bai ('2016-10-29')
INSERT INTO TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan) VALUES
    (1, '2016-10-29', 50, 0, 0),
    (2, '2016-10-29', 50, 0, 0),
    (3, '2016-10-29', 50, 0, 0);
GO

-- Them ton kho cho ngay hien tai de tien test ban hang ngay lap tuc
DECLARE @Today DATE = CAST(GETDATE() AS DATE);
IF NOT EXISTS (SELECT 1 FROM TONKHO WHERE NgayTon = @Today)
BEGIN
    INSERT INTO TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan) VALUES
        (1, @Today, 50, 0, 0),
        (2, @Today, 50, 0, 0),
        (3, @Today, 50, 0, 0);
END
GO