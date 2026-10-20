-- ==============================================================
-- CO SO DU LIEU: QLSinhVien
-- Sinh vien: Vu Van Minh - MSSV: 3124411169
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

-- 1. Bang Khoa
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Khoa' AND xtype='U')
BEGIN
    CREATE TABLE Khoa (
        MaKhoa VARCHAR(10) PRIMARY KEY,
        TenKhoa NVARCHAR(50) NOT NULL
    );
END
GO

-- 2. Bang Lop (lien ket voi Khoa)
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Lop' AND xtype='U')
BEGIN
    CREATE TABLE Lop (
        MaLop VARCHAR(10) PRIMARY KEY,
        TenLop NVARCHAR(50) NOT NULL,
        MaKhoa VARCHAR(10) REFERENCES Khoa(MaKhoa)
    );
END
GO

-- 3. Bang MonHoc
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='MonHoc' AND xtype='U')
BEGIN
    CREATE TABLE MonHoc (
        MaMH VARCHAR(10) PRIMARY KEY,
        TenMH NVARCHAR(50) NOT NULL
    );
END
GO

-- 4. Bang SinhVien (lien ket voi Lop)
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

-- 5. Bang Diem (lien ket SinhVien va MonHoc)
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

-- Du lieu mau (it nhat 5 mau tin moi bang theo yeu cau de bai)
-- Xoa du lieu cu neu can de dam bao chuan
DELETE FROM Diem;
DELETE FROM SinhVien;
DELETE FROM Lop;
DELETE FROM MonHoc;
DELETE FROM Khoa;
GO

INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES
    ('CNTT', N'Công nghệ thông tin'),
    ('QTKD', N'Quản trị kinh doanh'),
    ('KT', N'Kế toán'),
    ('NN', N'Ngoại ngữ'),
    ('HH', N'Hóa học');
GO

INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES
    ('04CDNTH', N'Cao đẳng Công nghệ thông tin', 'CNTT'),
    ('05DHKT2', N'Kế toán ngân hàng khóa 05', 'KT'),
    ('05DHTH1', N'Công nghệ phần mềm khóa 05', 'CNTT'),
    ('05DHTH2', N'Lập trình mạng khóa 05', 'CNTT'),
    ('06DHHH1', N'Hóa phân tích khóa 06', 'HH'),
    ('06DHKT1', N'Thuế doanh nghiệp khóa 06', 'KT'),
    ('06DHTH1', N'Công nghệ phần mềm khóa 06', 'CNTT');
GO

INSERT INTO MonHoc (MaMH, TenMH) VALUES
    ('1', N'Toán Cao cấp'),
    ('2', N'Mác - Lênin'),
    ('3', N'Tin học đại cương'),
    ('4', N'Cơ sở dữ liệu'),
    ('5', N'Lập trình C#');
GO

INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop) VALUES
    ('SV01', N'Trần Thanh Tùng', '1993-10-12', '05DHTH1'),
    ('SV02', N'Nguyễn Thanh Bình', '1993-02-04', '05DHTH1'),
    ('SV03', N'Nguyễn Đạt Nhân', '1992-03-15', '05DHTH2'),
    ('SV04', N'Nguyễn Gia Bảo', '1993-11-05', '04CDNTH'),
    ('SV05', N'Nguyễn Thanh Lan', '1993-12-06', '05DHKT2'),
    ('SV06', N'Lâm Văn Tuấn', '1993-03-08', '06DHTH1'),
    ('3124411169', N'Vũ Văn Minh', '2006-01-01', '05DHTH1');
GO

INSERT INTO Diem (MaSV, MaMH, Diem) VALUES
    ('SV01', '1', 4.0),
    ('SV01', '2', 7.0),
    ('SV02', '1', 6.0),
    ('SV02', '2', 3.0),
    ('SV02', '3', 5.0),
    ('SV03', '1', 9.0),
    ('SV03', '2', 10.0),
    ('SV03', '3', 9.0),
    ('SV04', '1', 3.0),
    ('SV04', '2', 6.0),
    ('SV05', '1', 5.0),
    ('SV05', '3', 7.0),
    ('SV06', '2', 8.0),
    ('SV06', '3', 8.0),
    ('3124411169', '5', 9.5);
GO