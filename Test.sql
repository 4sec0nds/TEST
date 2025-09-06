-- Tạo database


USE TEST;
GO

-- Bảng loại sách
CREATE TABLE tbl_loai_sach (
    ma_loai_sach INT IDENTITY(1,1) PRIMARY KEY,
    ten_loai_sach NVARCHAR(100) NOT NULL
);

-- Bảng sách
CREATE TABLE tbl_sach (
    ma_sach INT IDENTITY(1,1) PRIMARY KEY,
    ten_sach NVARCHAR(200) NOT NULL,
    ma_loai_sach INT NOT NULL,
    tac_gia NVARCHAR(100),
    so_luong INT,
    gia_ban FLOAT,
    CONSTRAINT fk_sach_loai FOREIGN KEY (ma_loai_sach)
        REFERENCES tbl_loai_sach(ma_loai_sach)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Bảng hóa đơn
CREATE TABLE tbl_hoa_don (
    ma_hoa_don INT IDENTITY(1,1) PRIMARY KEY,
    ngay_lap_hoa_don DATE NOT NULL,
    ten_khach_hang NVARCHAR(100),
    sdt_khach_hang NVARCHAR(15)
);

-- Bảng chi tiết hóa đơn
CREATE TABLE tbl_chi_tiet_hoa_don (
    ma_hoa_don INT NOT NULL,
    ma_sach INT NOT NULL,
    so_luong INT NOT NULL,
    PRIMARY KEY (ma_hoa_don, ma_sach),
    CONSTRAINT fk_cthd_hoadon FOREIGN KEY (ma_hoa_don)
        REFERENCES tbl_hoa_don(ma_hoa_don)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_cthd_sach FOREIGN KEY (ma_sach)
        REFERENCES tbl_sach(ma_sach)
        ON DELETE CASCADE ON UPDATE CASCADE
);

-- Bảng phiếu nhập
CREATE TABLE tbl_phieu_nhap (
    ma_phieu_nhap INT IDENTITY(1,1) PRIMARY KEY,
    ngay_lap_phieu_nhap DATE NOT NULL,
    ten_nha_cung_cap NVARCHAR(100)
);

-- Bảng chi tiết phiếu nhập
CREATE TABLE tbl_chi_tiet_phieu_nhap (
    ma_phieu_nhap INT NOT NULL,
    ma_sach INT NOT NULL,
    so_luong INT NOT NULL,
    PRIMARY KEY (ma_phieu_nhap, ma_sach),
    CONSTRAINT fk_ctpn_phieunhap FOREIGN KEY (ma_phieu_nhap)
        REFERENCES tbl_phieu_nhap(ma_phieu_nhap)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_ctpn_sach FOREIGN KEY (ma_sach)
        REFERENCES tbl_sach(ma_sach)
        ON DELETE CASCADE ON UPDATE CASCADE
);

--them sach
CREATE PROCEDURE sp_them_sach
    @ten_sach NVARCHAR(200),
    @ma_loai_sach INT,
    @tac_gia NVARCHAR(100),
    @so_luong INT,
    @gia_ban FLOAT
AS
BEGIN
    INSERT INTO tbl_sach (ten_sach, ma_loai_sach, tac_gia, so_luong, gia_ban)
    VALUES (@ten_sach, @ma_loai_sach, @tac_gia, @so_luong, @gia_ban);
END;
GO

-- sua sach
CREATE PROCEDURE sp_cap_nhat_sach
    @ma_sach INT,
    @ten_sach NVARCHAR(200),
    @ma_loai_sach INT,
    @tac_gia NVARCHAR(100),
    @so_luong INT,
    @gia_ban FLOAT
AS
BEGIN
    UPDATE tbl_sach
    SET ten_sach = @ten_sach,
        ma_loai_sach = @ma_loai_sach,
        tac_gia = @tac_gia,
        so_luong = @so_luong,
        gia_ban = @gia_ban
    WHERE ma_sach = @ma_sach;
END;
GO

--xoa sach
CREATE PROCEDURE sp_xoa_sach
    @ma_sach INT
AS
BEGIN
    DELETE FROM tbl_sach WHERE ma_sach = @ma_sach;
END;
GO

CREATE PROCEDURE sp_lay_danh_sach_sach
AS
BEGIN
    SELECT s.ma_sach, s.ten_sach, ls.ten_loai_sach, s.tac_gia, s.so_luong, s.gia_ban
    FROM tbl_sach s
    INNER JOIN tbl_loai_sach ls ON s.ma_loai_sach = ls.ma_loai_sach;
END;
GO

--test
	EXEC sp_them_sach N'Lập Trình C#', 1, N'Nguyễn Văn A', 50, 120000;

	--
INSERT INTO tbl_loai_sach (ten_loai_sach)
VALUES (N'Sách Lập Trình'),
       (N'Sách Thiếu Nhi'),
       (N'Tiểu Thuyết'),
       (N'Khoa Học');


--them sach
INSERT INTO tbl_sach (ten_sach, ma_loai_sach, tac_gia, so_luong, gia_ban)
VALUES 
(N'Lập Trình C# Cơ Bản', 1, N'Nguyễn Văn A', 30, 120000),
(N'Học Python Qua Ví Dụ', 1, N'Trần Văn B', 20, 150000),
(N'Doraemon Tập 1', 2, N'Fujiko F. Fujio', 100, 25000),
(N'Truyện Kiều', 3, N'Nguyễn Du', 50, 80000),
(N'Khám Phá Vũ Trụ', 4, N'Carl Sagan', 15, 200000);


--form2 Loai Sach

CREATE PROCEDURE sp_them_loai_sach
    @ten_loai_sach NVARCHAR(100)
AS
BEGIN
    INSERT INTO tbl_loai_sach (ten_loai_sach)
    VALUES (@ten_loai_sach);
END;
GO

--sua
CREATE PROCEDURE sp_cap_nhat_loai_sach
    @ma_loai_sach INT,
    @ten_loai_sach NVARCHAR(100)
AS
BEGIN
    UPDATE tbl_loai_sach
    SET ten_loai_sach = @ten_loai_sach
    WHERE ma_loai_sach = @ma_loai_sach;
END;
GO

--Xoa
CREATE PROCEDURE sp_xoa_loai_sach
    @ma_loai_sach INT
AS
BEGIN
    DELETE FROM tbl_loai_sach WHERE ma_loai_sach = @ma_loai_sach;
END;
GO

-- lay danh sach
CREATE PROCEDURE sp_lay_danh_sach_loai_sach
AS
BEGIN
    SELECT ma_loai_sach, ten_loai_sach
    FROM tbl_loai_sach;
END;
GO

-- vi du hoa don

INSERT INTO tbl_hoa_don (ngay_lap_hoa_don, ten_khach_hang, sdt_khach_hang)
VALUES 
('2025-09-01', N'Nguyễn Văn A', '0912345678'),
('2025-09-02', N'Trần Thị B', '0987654321'),
('2025-09-03', N'Lê Văn C', '0901234567');


--them hoa don
ALTER PROCEDURE sp_them_hoa_don
    @ngay_lap_hoa_don DATE,
    @ten_khach_hang NVARCHAR(100),
    @sdt_khach_hang NVARCHAR(15)
AS
BEGIN
    INSERT INTO tbl_hoa_don (ngay_lap_hoa_don, ten_khach_hang, sdt_khach_hang)
    VALUES (@ngay_lap_hoa_don, @ten_khach_hang, @sdt_khach_hang);

    -- Trả về ID hóa đơn vừa thêm (cho form thêm chi tiết)
    SELECT SCOPE_IDENTITY() AS ma_hoa_don;
END;
GO


--sua hoa don
ALter PROCEDURE sp_cap_nhat_hoa_don
    @ma_hoa_don INT,
    @ngay_lap_hoa_don DATE,
    @ten_khach_hang NVARCHAR(100),
    @sdt_khach_hang NVARCHAR(15)
AS
BEGIN
    UPDATE tbl_hoa_don
    SET ngay_lap_hoa_don = @ngay_lap_hoa_don,
        ten_khach_hang = @ten_khach_hang,
        sdt_khach_hang = @sdt_khach_hang
    WHERE ma_hoa_don = @ma_hoa_don;
END;
GO

--sua
ALTER PROCEDURE sp_cap_nhat_hoa_don
    @ngay_lap_hoa_don DATE,
    @ten_khach_hang NVARCHAR(100),
    @sdt_khach_hang NVARCHAR(15),
    @ma_hoa_don INT
AS
BEGIN
    UPDATE tbl_hoa_don
    SET ngay_lap_hoa_don = @ngay_lap_hoa_don,
        ten_khach_hang = @ten_khach_hang,
        sdt_khach_hang = @sdt_khach_hang
    WHERE ma_hoa_don = @ma_hoa_don;
END;
GO

--xóa hoa don
CREATE PROCEDURE sp_xoa_hoa_don
    @ma_hoa_don INT
AS
BEGIN
    DELETE FROM tbl_hoa_don WHERE ma_hoa_don = @ma_hoa_don;
END;
GO


