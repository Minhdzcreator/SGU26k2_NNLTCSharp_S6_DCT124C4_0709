-- ==============================================================
-- CƠ SỞ DỮ LIỆU: QLSinhVien
-- ==============================================================
USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QLSinhVien')
BEGIN
    CREATE DATABASE QLSinhVien;
END
GO

USE QLSinhVien;
GO

-- 1. Bảng Khoa
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Khoa' AND xtype='U')
BEGIN
    CREATE TABLE Khoa (
        MaKhoa VARCHAR(10) PRIMARY KEY,
        TenKhoa NVARCHAR(50) NOT NULL
    );
END
GO

-- 2. Bảng Lop (liên kết với Khoa)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Lop' AND xtype='U')
BEGIN
    CREATE TABLE Lop (
        MaLop VARCHAR(10) PRIMARY KEY,
        TenLop NVARCHAR(50) NOT NULL,
        MaKhoa VARCHAR(10) REFERENCES Khoa(MaKhoa)
    );
END
GO

-- 3. Bảng MonHoc
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='MonHoc' AND xtype='U')
BEGIN
    CREATE TABLE MonHoc (
        MaMH VARCHAR(10) PRIMARY KEY,
        TenMH NVARCHAR(50) NOT NULL
    );
END
GO

-- 4. Bảng SinhVien (liên kết với Lop)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SinhVien' AND xtype='U')
BEGIN
    CREATE TABLE SinhVien (
        MaSinhVien VARCHAR(10) PRIMARY KEY,
        HoTen NVARCHAR(50) NOT NULL,
        NgaySinh DATETIME,
        MaLop VARCHAR(10) REFERENCES Lop(MaLop)
    );
END
GO

-- 5. Bảng Diem (liên kết SinhVien và MonHoc)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Diem' AND xtype='U')
BEGIN
    CREATE TABLE Diem (
        MaSV VARCHAR(10) REFERENCES SinhVien(MaSinhVien),
        MaMH VARCHAR(10) REFERENCES MonHoc(MaMH),
        Diem FLOAT,
        PRIMARY KEY (MaSV, MaMH)
    );
END
GO

-- Dữ liệu mẫu ban đầu
IF NOT EXISTS (SELECT * FROM Khoa)
BEGIN
    INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES 
        ('CNTT', N'Công nghệ thông tin'), 
        ('QTKD', N'Quản trị kinh doanh');
    
    INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES 
        ('DCT1241', N'Đại học Công nghệ thông tin 1', 'CNTT'), 
        ('DCT124C4', N'Đại học Công nghệ thông tin C4', 'CNTT'), 
        ('DKD1241', N'Đại học Quản trị kinh doanh 1', 'QTKD');

    INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop) VALUES
        ('3124411169', N'Vũ Văn Minh', '2006-01-01', 'DCT1241');
END
GO
