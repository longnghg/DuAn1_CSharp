use master
go   
drop database DUAN_ShopQA
go
create database DUAN_ShopQA
go
use DUAN_ShopQA
go
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = off
go
create table NHANVIEN( 
	STT int identity (1,1),
	MaNV varchar (5) PRIMARY KEY,
	TenNV nvarchar (30) NOT NULL,
	DiaChi nvarchar (50)NOT NULL,
	SDT varchar (15)NOT NULL,
	Email varchar (100)NOT NULL,
	MatKhau varchar (255)NOT NULL default '418515815641305135230215920295153463',
	GioiTinh bit NOT NULL,
	VaiTro bit NOT NULL,
	HinhAnh varchar (150) NOT NULL,
	isDelete bit default 0
	)
go
create table PHANLOAISP(
	MaLoai varchar (5) PRIMARY KEY,
	TenLoai nvarchar (30) NOT NULL
	)
go

create table SANPHAM(
	MaSP varchar (5) PRIMARY KEY,
	TenSP nvarchar (30) NOT NULL,
	DonGiaNhap float NOT NULL, 
	DonGiaBan float  NOT NULL,
	TongSoLuong int default 0,
	DoiTuong int,
	HinhAnhTrc varchar (150) NOT NULL,
	HinhAnhSau varchar (150) NOT NULL,
	Giamgia int NOT NULL,
	MaLoai varchar(5) references PHANLOAISP (MaLoai)
)

go
create table MAUSAC(
	MaMau int identity(1,1) primary key,
	tenmau nvarchar(10) NOT NULL
)
go
create table KICHCO(
	MaSize int identity(1,1) primary key,
	TenSize nvarchar(3) NOT NULL
)
go
create table CHITIETSANPHAM(
	MaSP varchar(5) references SANPHAM(MaSP),
	SoLuong int NOT NULL,
	Size int NOT NULL references KICHCO(MaSize),
	MaMau int references MAUSAC(MaMau) not null
)
go

create table DONVANCHUYEN(
	MaDonNhap int identity PRIMARY KEY,
	NgayNhapHang datetime NOT NULL
	)
go

create table CHITIETDONVANCHUYEN(
	MaDonNhap int references DONVANCHUYEN (MaDonNhap),
	MaSP varchar (5) references SANPHAM (MaSP),
	MaNV varchar(5) references NHANVIEN(MANV),
	Size int NOT NULL references KICHCO(MaSize),
	MaMau int NOT NULL references MAUSAC(MaMau),
	SoLuong int NOT NULL,
	)
go


create table KHACHHANG(
	 SDT varchar (15) PRIMARY KEY,
	 TenKH nvarchar (30) NOT NULL,
	 DiemTichLuy int NOT NULL,
	 isDelete bit default 0
	 )
go
create table HOADON(
	MaDonMua int identity(1,1) PRIMARY KEY,
	NgayMua datetime NOT NULL ,
	TinhTrang bit NOT NULL default 0, -- 0 là chưa thanh toán , 1 là đã thanh toán
	usePoints bit,
	TongTien float   NOT NULL
	)
 
go


create table HOADONCHITIET(
	MaDonMua int references HOADON (MaDonMua),
	MaSP varchar (5) references SANPHAM (MaSP),
	MaNV varchar (5) references NHANVIEN (MaNV),
	SDT varchar (15) references KHACHHANG (SDT),
	MaMau int references MAUSAC(MAMAU),
	MaSize int references KICHCO(MaSize),
	SoLuong int NOT NULL,
	DonGia float NOT NULL,
	GiamGia int NOT NULL,
	ThueVAT float NOT NULL,
	TongTien float  NOT NULL,
	)
go
	
	-- Procedure
	-- Nhân viên
-- kiểm tra có phải admin ko
create proc sp_isAdmin @email varchar(100)
as
	declare @status int
begin
	if (@email = 'admin')
		set @status = 1
	else
		set @status = 0
	select @status
end
go
-- kiểm tra có thay đổi sdt hay không
create proc sp_SamePhoneNumber @email varchar(100),@sdtht varchar(15)
as
	declare @status int
begin
	if exists(select * from NHANVIEN where Email = @email and SDT = @sdtht)
		set @status = 1
	else
		set @status = 0
	select @status
end
select * from DONVANCHUYEN
go
-- kiểm tra email có tồn tại không
create proc sp_isEmailExists @email varchar(100)
as
	declare @status int
begin
	if exists (select * from NHANVIEN where Email = @email)
	set @status = 1
	else 
	set @status = 0
	select @status
end
go
-- tìm kiểm nhân viên
create proc sp_TimkiemNV @keyword nvarchar(30)
as
begin
	select  MaNV,TenNV,DiaChi,sdt,Email,GioiTinh,VaiTro,HinhAnh from NHANVIEN
	where tennv like '%' +@keyword +'%' or MaNV = @keyword
end
go
-- Thay đổi thông tin nhân viên
create proc sp_changeTTNV @email varchar(100), @hoten nvarchar(30), @diachi nvarchar(50), @sdt varchar(15), @gioitinh bit, @anh varchar(150)
as
begin
	if exists (select * from NHANVIEN where Email = @email and SDT = @sdt)
		update NHANVIEN set TenNV = @hoten , DiaChi=@diachi, GioiTinh = @gioitinh, HinhAnh = @anh where Email = @email
	if not exists(select * from NHANVIEN where SDT = @sdt)
		update NHANVIEN set TenNV = @hoten , DiaChi=@diachi, SDT = @sdt, GioiTinh = @gioitinh, HinhAnh = @anh where Email = @email
end
go
-- Quên mật khẩu
create proc sp_QuenMK @email varchar(100) , @randompass varchar(255)
as
begin
	if exists(select * From NHANVIEN where Email = @email)
		update NHANVIEN set MatKhau = @randompass where email = @email
end
go

-- Đổi mật khẩu
create proc sp_changePW @email varchar(100),@curPass varchar(255) , @newpass varchar(255) , @rePass varchar(255)
as
begin
	if exists (select * from NHANVIEN where MatKhau = @curPass)
		begin
			update NHANVIEN set MatKhau = @newpass where Email = @email
		end
end
go
-- tìm kiếm nv bị xóa
create proc sp_findNVdeleted @chuoi nvarchar(30)
as
begin
	select MaNV,TenNV,DiaChi,SDT,Email,GioiTinh,VaiTro,HinhAnh from NHANVIEN 
	where isDelete = 1 and (MaNV like '%' +@chuoi +'%' or MaNV = @chuoi)
end
go
-- tìm kiếm nv chưa bị xóa
create proc sp_findNV @chuoi nvarchar(30)
as
begin
	select MaNV,TenNV,DiaChi,SDT,Email,GioiTinh,VaiTro,HinhAnh from NHANVIEN 
	where isDelete = 0 and (MaNV like '%' +@chuoi +'%' or MaNV = @chuoi)
end
go
-- khôi phục nhân viên
create proc sp_restoneNV @email varchar(30)
as
begin
	update	 NHANVIEN set isDelete = 0 where Email = @email
end
go
-- xem danh sách nv đã bị xóa
create proc sp_getlistStaffdeleted
as
	select MaNV,TenNV,DiaChi,SDT,Email,GioiTinh,VaiTro,HinhAnh from NHANVIEN where isDelete = 1
go
-- Xem danh sách nhân viên hoặc 1 NV
create proc sp_getListStaff @email varchar(100) = null
as
	if (@email is null)
		select MaNV,TenNV,DiaChi,SDT,Email,GioiTinh,VaiTro,HinhAnh from NHANVIEN where isDelete = 0
	else
		select MaNV,TenNV,DiaChi,SDT,Email,GioiTinh,VaiTro,HinhAnh from NHANVIEN where Email = @email and isDelete = 0
go
--Nhập nhân viên
create  proc sp_insertNV
@tennv nvarchar(30), @diachi nvarchar(50), @sdt varchar(15),
@email varchar(100),@gioitinh bit,@vaitro bit,
@hinhanh varchar(50)
as	
	declare		@id int,
				@manv varchar(5)
begin
	select @id = isnull(MAX(STT),0) + 1 from NHANVIEN
	if(@vaitro = 1)
	 SELECT @manv = 'QL' + RIGHT('00' + CAST(@Id AS VARCHAR(3)), 3)
	else
	 SELECT @manv = 'NV' + RIGHT('00' + CAST(@Id AS VARCHAR(3)), 3)
	if not exists(select * from NHANVIEN where Email = @email)
	begin
		if not exists(select * from NHANVIEN where SDT = @sdt)
		insert into NHANVIEN values (@manv,@tennv,@diachi,@sdt,@email,default,@gioitinh,@vaitro,@hinhanh,default)
	end
end
go
--Đăng nhập nhân viên
create proc sp_loginNV @email varchar(100), @matkhau varchar(255)
as
	declare @status int
begin
	if exists (select * from NHANVIEN where Email = @email and MatKhau = @matkhau and isDelete = 0)
		set @status = 1
	else
		set @status = 0
	select @status
end
go
--Cập nhật nhân viên
create  proc sp_updateNV 
@tennv nvarchar(30), @diachi nvarchar(50), @sdt varchar(15),
@email varchar(100),@gioitinh bit,@vaitro bit,
@hinhanh varchar(50)
as
begin 
	if(@vaitro =1 )
		begin
			if exists (select * from NHANVIEN where Email = @email and VaiTro = 0)
			update NHANVIEN set MaNV = REPLACE(MaNV,'NV','QL') where Email = @email
		end
	else
		begin
			if exists (select * from NHANVIEN where Email = @email and VaiTro = 1)
			update NHANVIEN set MaNV = REPLACE(MaNV,'QL','NV') where Email = @email
		end
	if exists(select * from NHANVIEN where Email = @email and SDT = @sdt)
		update NHANVIEN set TenNV = @tennv, DiaChi = @diachi , GioiTinh = @gioitinh ,VaiTro= @vaitro, HinhAnh=  @hinhanh 
		where EMAIL = @email
	if not exists(select * from NHANVIEN where SDT = @sdt)
		update NHANVIEN set TenNV = @tennv, DiaChi = @diachi , SDT = @sdt, GioiTinh = @gioitinh ,VaiTro= @vaitro, HinhAnh=  @hinhanh 
		where EMAIL = @email
end

--
go
	--Xóa nhân viên
create proc sp_deleteNV @emailBixoa  varchar(100), @emailXoa  varchar(100)
as
begin
	if(@emailBixoa != @emailXoa)
	update NHANVIEN set isDelete = 1 where Email = @emailBixoa
end
go
		-- danh mục sản phẩm
-- thêm danh mục sp
create proc sp_insertDMSP
@maloai varchar(5),@tenloai nvarchar(30)
as
begin
	if not exists(select * from PHANLOAISP where TenLoai like @tenloai)
	insert into PHANLOAISP values(@maloai,@tenloai)
end
go
-- Cập nhật danh mục sp
create proc sp_updateDMSP
@maloai varchar(5),@tenloai nvarchar(30)
as
begin
	if not exists(select * from PHANLOAISP where TenLoai like @tenloai)
	update PHANLOAISP set TenLoai = @tenloai where MaLoai = @maloai
end
go
-- Xóa danh mục sp
create  proc sp_deleteDMSP
@maloai varchar(5)
as
begin
	if not exists (select * from SANPHAM where MaLoai = @maloai)
	delete PHANLOAISP where MaLoai = @maloai
end
go
-- khôi phục khách hàng
create proc sp_restoneKH @sdt varchar(15)
as
begin
	update KHACHHANG set isDelete = 0 where SDT =@sdt
end
go
-- Xóa khách hàng
create proc sp_deleteKH @sdt varchar(15)
as
begin
	update KHACHHANG set isDelete = 1 where SDT =@sdt
end
go
-- Tìm kiếm khách hàng đã bị xóa

create proc sp_TimkiemKHbixoa @Chuoi nvarchar(30)
as
begin
	select SDT ,TenKH , DiemTichLuy from KHACHHANG
	where isDelete = 1 and (TenKH like '%' +@Chuoi +'%'or sdt  like '%' +@Chuoi +'%')
end
go
-- Tìm kiếm khách hàng

create proc sp_TimkiemKH @Chuoi nvarchar(30)
as
begin
	select SDT ,TenKH , DiemTichLuy from KHACHHANG
	where isDelete = 0 and (TenKH like '%' +@Chuoi +'%'or sdt  like '%' +@Chuoi +'%')
end
go
-- Thêm danh sách khách hàng
create proc sp_insertKh @sdt varchar(15),@tenkh nvarchar(30)
as
begin
	if not exists(select * from KHACHHANG where SDT = @sdt)
	begin
		insert into KHACHHANG values(@sdt,@tenkh,0,default)
	end
end	
go
-- cập nhật danh sách khách hàng
create  proc sp_updateKh @sdt varchar(15),@tenkh nvarchar(30)
as
begin
	update KHACHHANG set TenKH = @tenkh where SDT = @sdt
end	
go
-- NHẬP LIỆU PHÂN LOẠI
INSERT INTO PHANLOAISP VALUES('AN01',N'Áo ngắn tay'),
							('AD01',N'Áo dài tay'),
							('AHW01',N'Hoodies & Sweatshirts'),
							('AJ01',N'Áo Jacket'),
							('QN01',N'Quần ngắn'),
							('QD01',N'Quần'),
							('QV01',N'Váy'),
							('DB01',N'Đồ bộ')
							
go
-- NHẬP LIỆU MÀU SẮC
INSERT INTO MAUSAC VALUES(N'Đen'),
						(N'Trắng'),
						(N'Vàng'),
						(N'Đỏ'),
						(N'Xám'),	
						(N'Tím'),
						(N'Hồng'),
						(N'Cam'),
						(N'Xanh')
select * from MAUSAC
go
-- NHẬP LIỆU KÍCH CỠ
INSERT INTO KICHCO VALUES('S'),
						('M'),
						('L'),
						('XL'),
						('XXL')
						
-- NHẬP LIỆU NHÂN VIÊN
go
insert into NHANVIEN values ('QL001',N'Nguyễn Tăng Thanh Phương',N'1 Nguyễn Huệ, Quận 1','0909090999','ChinhChu@gmail.com','2122914021714301784233128915223624866126',0,1,'TuanMinh.jfif',0)
go
exec sp_insertNV N'Lê Hồng Gia',N'76 Nguyễn Trãi, Quận 3', '09158794564','HongGia@gmail.com',1,0,'HongGia.jfif'
go
exec sp_insertNV N'Lê Minh Anh',N'20 Phạm Văn Chí, Quận 6', '0120131254','MinhAnh@gmail.com',1,0,'LeAnh.jfif'
go
exec sp_insertNV N'Phạm Gia Kỳ',N'40 Mai Chí Thọ, Quận 2', '0906542225','GiaKy@gmail.com',0,0,'GiaKy.jfif'
go
exec sp_insertNV N'Ngọc Minh',N'1 Lê Hồng Phong, Quận 1', '0906542225','MinhMinh@gmail.com',1,0,'NgocMinh.jfif'
go
insert into NHANVIEN values ('AD','ADMIN','Q1','9999999998','admin','418515815641305135230215920295153463',0,1,'GiaKy.jfif',0)
go
create proc sp_taodonvanchuyen
as
begin
	insert into DONVANCHUYEN values(getdate());
end
go
create proc sp_xoadonvanchuyen -- cần thay đổi
as
begin
	delete DONVANCHUYEN where MaDonNhap not in (select MaDonNhap from CHITIETDONVANCHUYEN)
end
go
-- phân quyền nhân viên bằng email 
create proc sp_getRolebyEmail @email varchar(50)
as
	declare @status int
begin
	if exists (select VaiTro from NHANVIEN where Email = @email and VaiTro = 1)
	set @status = 1
	else 
	set @status = 0
	select @status
end
go
-- lấy mã nhân viên bằng email
create proc sp_getIDnvByEmail @email varchar(50)
as
begin
	select MaNV from NHANVIEN where Email = @email
end
go
	-- Sản phẩm
-- Tìm kiếm sản phẩm có được giảm giá

create proc sp_timkiemspCoGiam  @chuoitimkiem nvarchar(30)
as
begin
	select masp,TenSP,DonGiaBan,Giamgia,(DonGiaBan - ((DonGiaBan*Giamgia)/100)) as GiaSauKhiGiam from SANPHAM where Giamgia <> 0 and (TenSP like '%'+@chuoitimkiem+'%'or MaSP like '%'+@chuoitimkiem+'%')
end
go
-- Tìm kiếm sản phẩm ko được giảm giá

create proc sp_timkiemspKoGiam  @chuoitimkiem nvarchar(30)
as
begin
	select masp,TenSP,DonGiaBan,Giamgia,(DonGiaBan - ((DonGiaBan*Giamgia)/100)) as GiaSauKhiGiam from SANPHAM where Giamgia = 0 and (TenSP like '%'+@chuoitimkiem+'%'or MaSP like '%'+@chuoitimkiem+'%')
end
go
-- Tìm kiêm sản phẩm cho bang giảm giá theo tên hoặc theo mã sản phẩm
create proc sp_timkiemsp  @chuoitimkiem nvarchar(30)
as
begin
	select masp,TenSP,DonGiaBan,Giamgia,(DonGiaBan - ((DonGiaBan*Giamgia)/100)) as GiaSauKhiGiam from SANPHAM where TenSP like '%'+@chuoitimkiem+'%'or MaSP like '%'+@chuoitimkiem+'%'
end
go
-- đang làm

create proc sp_xoamasp @masp varchar(5) , @manv varchar(5)
as
begin
	if (@manv like '%QL%')
	begin
		if exists( select * from SANPHAM where masp not in(select MaSP from HOADONCHITIET))
		begin
			delete HOADONCHITIET where MaSP = @masp
			delete CHITIETDONVANCHUYEN where MaSP = @masp
			delete CHITIETSANPHAM where masp = @masp
			delete SANPHAM where MaSP = @masp
		end
	end
end
go
-- Thêm chi tiết hóa đơn vận chuyển select * from donvanchuyen
create proc sp_themCTDVC  @masp varchar(5), @manv varchar(5),@size int,@mamau int,@soluong int
as
	declare @madn int,
			@slht int,
			@slthem int
	select @slht = soluong from CHITIETDONVANCHUYEN where MaSP= @masp and Size = @size and MaMau = @mamau
	set @slthem = @soluong
begin
	if exists(select * from DONVANCHUYEN )
		select @madn = max(MaDonNhap) from DONVANCHUYEN
	else
		begin
			exec sp_taodonvanchuyen
			select @madn = max(MaDonNhap) from DONVANCHUYEN
		end
	if exists(select * from CHITIETDONVANCHUYEN where MaSP = @masp and MaDonNhap = @madn and Size= @size and MaMau = @mamau)
		update CHITIETDONVANCHUYEN set Soluong	= (@slht + @slthem) where MaDonNhap = @madn and MaSP = @masp and Size= @size and MaMau = @mamau
	else
		insert into CHITIETDONVANCHUYEN values(@madn,@masp,@manv,@size,@mamau,@soluong)
end	
go
-- kiểm tra ng dùng có thay đổi tên sp hay không
create proc sp_NotChangeNameItem @masp varchar(5), @tensp nvarchar(30)
as
	declare @status int
begin
	if exists(select * from SANPHAM where MaSP = @masp and TenSP = @tensp)
		set @status = 1
	else
		set @status = 0
	select @status
end
go
-- cập nhật lại sản phẩm
create proc sp_UpdateSP 
@masp varchar(5),@tensp nvarchar(30),@dgn float , @dgb float,
@doituong int, @hinhanhtrc varchar(50),@hinhanhsau varchar(50),
@maloai varchar(5)
as
begin
	update SANPHAM set TenSP = @tensp , DonGiaNhap = @dgn , DonGiaBan = @dgb,
	DoiTuong = @doituong,HinhAnhSau = @hinhanhsau , HinhAnhTrc = @hinhanhtrc,MaLoai = @maloai
	where MaSP = @masp
end
go
-- lấy tên sp từ mã sp
create proc sp_getnambyID @masp varchar(5)
as
begin
	select tensp from SANPHAM where masp = @masp
end
go
create proc sp_themSP 
@masp varchar(5),@tensp nvarchar(30),@dgn float , @dgb float,
@doituong int, @hinhanhtrc varchar(50),@hinhanhsau varchar(50),
@maloai varchar(5),@soluong int ,@size int,@mamau int , @manv varchar(5)
as
	declare @slht int,
			@slthem int
	select @slht = soluong from CHITIETSANPHAM where MaSP= @masp and Size = @size and MaMau = @mamau
	set @slthem = @soluong
begin
	if exists (select Masp from SANPHAM where MaSP = @masp and TenSP = @tensp
		and DonGiaNhap = @dgn and DonGiaBan =@dgb and DoiTuong = @doituong   and MaLoai = @maloai and HinhAnhTrc = @hinhanhtrc and HinhAnhSau = @hinhanhsau )
		begin
			if exists(select MaSP from CHITIETSANPHAM where MaSP = @masp )
				begin
					if exists(select Size from CHITIETSANPHAM where MaSP = @masp and Size = @size)
						if exists (select MaMau from CHITIETSANPHAM where MaSP = @masp and Size = @size and MaMau = @mamau)
						begin
							update CHITIETSANPHAM set SoLuong = (@slht + @slthem) where MaSP = @masp and Size = @size and Mamau = @mamau
							exec sp_themCTDVC  @masp , @manv ,@size ,@mamau ,@soluong 
							
						end
						else
							begin
								insert into CHITIETSANPHAM values(@masp,@soluong,@size,@mamau)
								exec sp_themCTDVC  @masp , @manv ,@size ,@mamau ,@soluong 
							end
					else
						begin
								insert into CHITIETSANPHAM values(@masp,@soluong,@size,@mamau)
								exec sp_themCTDVC  @masp , @manv ,@size ,@mamau ,@soluong 
						end
				end
			else
				begin
					INSERT INTO SANPHAM VALUES(@masp,@tensp,@dgn,@dgb,default,@doituong,@hinhanhtrc,@hinhanhsau,0,@maloai) 
					insert into CHITIETSANPHAM values(@masp,@soluong,@size,@mamau)
					exec sp_themCTDVC  @masp , @manv ,@size ,@mamau ,@soluong 
				end
		end

	if not exists (select * from SANPHAM where TenSP = @tensp)
		begin
			if not exists (select Masp from SANPHAM where MaSP = @masp and (TenSP != @tensp
			or DonGiaNhap = @dgn or DonGiaBan =@dgb or DoiTuong = @doituong or MaLoai = @maloai))
				begin
					if not exists(select masp from SANPHAM where MaSP = @masp)
					begin
						INSERT INTO SANPHAM VALUES(@masp,@tensp,@dgn,@dgb,default,@doituong,@hinhanhtrc,@hinhanhsau,0,@maloai)
						insert into CHITIETSANPHAM values(@masp,@soluong,@size,@mamau)
						exec sp_themCTDVC  @masp , @manv ,@size ,@mamau ,@soluong 
					end
					else
					begin
						INSERT INTO SANPHAM VALUES(@masp,@tensp,@dgn,@dgb,default,@doituong,@hinhanhtrc,@hinhanhsau,0,@maloai)
						insert into CHITIETSANPHAM values(@masp,@soluong,@size,@mamau)
						exec sp_themCTDVC  @masp , @manv ,@size ,@mamau ,@soluong 
					end
				end
			
		end
end
--
go
CREATE TRIGGER UTG_ThemSLSanPham
ON CHITIETSANPHAM
AFTER INSERT , UPDATE
AS
	declare @tongslhientai int
	select @tongslhientai = Sum(SoLuong) from CHITIETSANPHAM where MaSP = (select MaSP from inserted)
	print cast(@tongslhientai as varchar)
BEGIN
		update SANPHAM set TongSoLuong = @tongslhientai where MaSP = (select MaSP from inserted)
		--delete CHITIETSANPHAM where SoLuong = 0
END
go
-- trigger cập nhật lại số lượng khi xóa chitietsanpham   
CREATE  TRIGGER UTG_XoaCTSP
ON CHITIETSANPHAM
FOR DELETE
AS
	declare @tongslhientai int,
			@sltrongkho int
	select @tongslhientai = Sum(SoLuong) from CHITIETSANPHAM where MaSP = (select MaSP from deleted)
	print cast(@tongslhientai as varchar)
BEGIN
		update SANPHAM set TongSoLuong = @tongslhientai where MaSP = (select MaSP from deleted)
END
go

-- Điều chỉnh số lượng ở kho sản phẩm khi chi tiết đơn vận chuyển đc cập nhật lại
 CREATE TRIGGER UTG_DieuChinhSLCTDVC
ON CHITIETDONVANCHUYEN
AFTER  UPDATE
AS
	declare @sldau int,
			@slnhapdau int,
			@slnhapsau int,

			@maspIn varchar(5),
			@sizeIn int,
			@mamauIn int,
			@maspDl varchar(5),
			@sizeDl int,
			@mamauDl int,
			@madonnhapIn int
			-- bảng inserted
	select @maspIn = MaSP from inserted
	select @sizeIn = Size from inserted
	select @mamauIn = MaMau from inserted
	select @madonnhapIn  = MaDonNhap from inserted
	-- bảng deleted 
	select @maspDl = MaSP from deleted
	select @sizeDl = Size from deleted
	select @mamauDl = MaMau from deleted
	-- thống kê số lượng
	select @sldau = SoLuong from CHITIETSANPHAM where MaSP = @maspDl and MaMau = @mamauDl and Size = @sizeDl
	select @slnhapdau = SoLuong from deleted where MaSP = @maspDl and MaMau = @mamauDl and Size = @sizeDl
	select @slnhapsau = SoLuong from inserted  where MaSP = @maspIn and MaMau = @mamauIn and Size = @sizeIn
	print 'SL A:' + cast(@sldau as varchar)
	print 'SL B:' + cast(@slnhapdau as varchar)
	print 'SL C:' + cast(@slnhapsau as varchar)
	print 'masp ' + cast(@maspIn as varchar)
	print '@sizeIn ' + cast(@sizeIn as varchar)
	print '@mamauIn ' + cast(@mamauIn as varchar)

	print '@maspDl ' + cast(@maspDl as varchar)
	print '@sizeDl ' + cast(@sizeDl as varchar)
	print '@mamauDl ' + cast(@mamauDl as varchar)
BEGIN
	-- trường hợp có thay đổi thông tin
	if (@maspIn <> @maspDl or @sizeIn <> @sizeDl or @mamauIn <> @mamauDl)
	begin
		update	CHITIETSANPHAM set SoLuong = @sldau - @slnhapdau where MaSP = @maspDl and MaMau = @mamauDl and Size = @sizeDl
		if exists(select * from CHITIETSANPHAM where MaSP = @maspIn and MaMau = @mamauIn and Size = @sizeIn)
		begin
			print 'da co (thay doi)'
			declare @soluong int
			select @soluong = SoLuong from CHITIETSANPHAM where MaSP = @maspIn and MaMau = @mamauIn and Size = @sizeIn
			update CHITIETSANPHAM  set SoLuong = @soluong + @slnhapsau where MaSP = @maspIn and MaMau = @mamauIn and Size = @sizeIn
		end
		else
		begin
			print 'Chua co (thay doi)'
			insert into CHITIETSANPHAM values (@maspIn,@slnhapsau,@sizeIn,@mamauIn)
		end
	end
	-- trường hợp không có thay dổi thông tin
	--else
	--begin
	--	if(@slnhapdau > @slnhapsau)
	--	begin
	--		print 'giam ( 0 thay doi)'
	--		update CHITIETSANPHAM set SoLuong = @sldau - (@slnhapdau - @slnhapsau)  where MaSP = @maspIn and MaMau = @mamauIn and Size = @sizeIn
	--	end
	--	else if (@slnhapdau < @slnhapsau)
	--	begin
	--		print 'tang ( 0 thay doi)'
	--		update CHITIETSANPHAM set SoLuong = @sldau + (@slnhapsau - @slnhapdau )  where MaSP = @maspIn and MaMau = @mamauIn and Size = @sizeIn
	--	end
	--	else
	--	begin
	--		print 'kolamgi ( 0 thay doi)'
	--		update CHITIETSANPHAM set SoLuong = @sldau  where MaSP = @maspIn and MaMau = @mamauIn and Size = @sizeIn
	--	end
	--end
END
go
-- delete chitietdonvan chuyen
create proc sp_xoaspinbill @madon int, @mamau int , @masize int
as
	declare
	@thoigianchinhsua int
	select @thoigianchinhsua = DATEDIFF(MINUTE,NgayNhapHang,GETDATE()) from DONVANCHUYEN where MaDonNhap = @madon
begin
	if(@thoigianchinhsua <1440)
	begin
		delete CHITIETDONVANCHUYEN where MaDonNhap = @madon and MaMau = @mamau and Size = @masize
	end
end
go
create proc sp_updateCTDVC
@maspcu varchar(5) , @sizecu int, @mamaucu int,
@maspmoi varchar(5) , @sizemoi int, @mamaumoi int,
@madonnhap int, @manv varchar(5), @soluong int
as
	declare @soluongbd int,
			@thoigianchinhsua int,
			@soluongkho int
	select @soluongkho = SoLuong from CHITIETSANPHAM where MaSP = @maspmoi and Size = @sizemoi and MaMau = @mamaumoi
	select @thoigianchinhsua = DATEDIFF(MINUTE,NgayNhapHang,GETDATE()) from DONVANCHUYEN where MaDonNhap = @madonnhap
	select @soluongbd = SoLuong from CHITIETDONVANCHUYEN where MaSP = @maspmoi and Size = @sizemoi and MaMau = @mamaumoi and MaDonNhap = @madonnhap

begin
	if(@thoigianchinhsua <1440)
	begin
		if exists(select * from CHITIETDONVANCHUYEN where MaSP = @maspmoi and Size = @sizemoi and MaMau = @mamaumoi and MaDonNhap = @madonnhap)
		begin
				delete CHITIETDONVANCHUYEN where MaSP = @maspcu and Size = @sizecu and MaMau = @mamaucu and MaDonNhap = @madonnhap
				update CHITIETDONVANCHUYEN set SoLuong = @soluongbd + @soluong where MaSP = @maspmoi and Size = @sizemoi and MaMau = @mamaumoi and MaDonNhap = @madonnhap
				update CHITIETSANPHAM set SoLuong = @soluongkho + @soluong where MaSP = @maspmoi and Size = @sizemoi and MaMau = @mamaumoi
			--if exists(select * from CHITIETDONVANCHUYEN where MaSP = @maspcu and Size = @sizecu and MaMau = @mamaucu and MaDonNhap = @madonnhap)
			--begin
			--	delete CHITIETDONVANCHUYEN where MaSP = @maspcu and Size = @sizecu and MaMau = @mamaucu and MaDonNhap = @madonnhap
			--	update CHITIETDONVANCHUYEN set SoLuong = @soluongbd + @soluong where MaSP = @maspmoi and Size = @sizemoi and MaMau = @mamaumoi and MaDonNhap = @madonnhap
			--end
			--else
			--begin
			--	update CHITIETDONVANCHUYEN set SoLuong = @soluong where MaSP = @maspcu and Size = @sizecu and MaMau = @mamaucu and MaDonNhap = @madonnhap
			--end	
		end
		else
		begin
			update CHITIETDONVANCHUYEN set SoLuong = @soluong,MaSP= @maspmoi, Size = @sizemoi, MaMau = @mamaumoi where MaSP = @maspcu and Size = @sizecu and MaMau = @mamaucu and MaDonNhap = @madonnhap
		end
	end
		
end
go 
-- trigger điều chỉnh lại số lượng khi xóa ctdvc
CREATE TRIGGER UTG_XoaCTDVC
ON CHITIETDONVANCHUYEN
FOR  DELETE
AS
	declare @maspDl varchar(5),
			@sizeDl int,
			@mamauDl int,
			@sldau int,
			@slnhapdau int,
			@slnhapsau int
	select @maspDl = MaSP from deleted
	select @sizeDl = Size from deleted
	select @mamauDl = MaMau from deleted
	select @sldau = SoLuong from CHITIETSANPHAM where MaSP = @maspDl and MaMau = @mamauDl and Size = @sizeDl
	select @slnhapdau = SoLuong from deleted where MaSP = @maspDl and MaMau = @mamauDl and Size = @sizeDl
	print 'SLdau ' + cast(@sldau as varchar)
	print 'SLnhapsau  '  + cast(@slnhapsau as varchar)
BEGIN
	update	CHITIETSANPHAM set SoLuong = @sldau - @slnhapdau where MaSP = @maspDl and MaMau = @mamauDl and Size = @sizeDl
END
go
-- danh sách chi tiết sản phẩm
create proc sp_getMaloai @tenloai nvarchar(50)
as
begin
	select maloai from PHANLOAISP where TenLoai = @tenloai
end
go
-- tìm kiếm sp trong danh sách chi tiết 
create proc sp_timkiemdanhsachchitietsp @chuoi nvarchar(30)
as
	select sp.MaSP,TenSP,DonGiaNhap,DonGiaBan,TenSize,tenmau,DoiTuong,SoLuong,HinhAnhTrc,HinhAnhSau,TenLoai from SANPHAM sp 
	inner join CHITIETSANPHAM ctsp on sp.MaSP = ctsp.MaSP
	inner join MAUSAC ms on ctsp.MaMau = ms.MaMau 
	inner join KICHCO kc on ctsp.Size = kc.MaSize
	inner join PHANLOAISP pl on sp.MaLoai = pl.MaLoai
	where sp.MaSP = @chuoi or sp.TenSP like '%' + @chuoi + '%'
go
create proc sp_danhsachchitietsp
as
	select sp.MaSP,TenSP,DonGiaNhap,DonGiaBan,TenSize,tenmau,DoiTuong,SoLuong,HinhAnhTrc,HinhAnhSau,TenLoai from SANPHAM sp 
	inner join CHITIETSANPHAM ctsp on sp.MaSP = ctsp.MaSP
	inner join MAUSAC ms on ctsp.MaMau = ms.MaMau 
	inner join KICHCO kc on ctsp.Size = kc.MaSize
	inner join PHANLOAISP pl on sp.MaLoai = pl.MaLoai
go
-- điều chỉnh giảm giá
create proc sp_SetupGiamGia  @giamgia int , @masp varchar(5) = null 
as
begin
	if(@masp is null)
		begin
			if(@giamgia = 0)
				update SANPHAM set Giamgia = @giamgia 
			else
				update SANPHAM set Giamgia = @giamgia where Giamgia = 0
		end
	else
		update SANPHAM set Giamgia = @giamgia where MaSP = @masp 
end
go
-- Danh sách sản phẩm có giảm giá hoặc chưa giảm giá
create proc sp_ListProductSaleOrNot @isSale bit
as
begin
	if(@isSale = 1)
	select masp,TenSP,DonGiaBan,Giamgia,(DonGiaBan - ((DonGiaBan*Giamgia)/100)) as GiaSauKhiGiam  from SANPHAM where Giamgia <> 0 
	else
	select masp,TenSP,DonGiaBan,Giamgia,(DonGiaBan - ((DonGiaBan*Giamgia)/100)) as GiaSauKhiGiam from SANPHAM where Giamgia = 0 
	select masp,TenSP,DonGiaBan,Giamgia,(DonGiaBan - ((DonGiaBan*Giamgia)/100)) as GiaSauKhiGiam  from SANPHAM 
end
go
-- danh sách sản phẩm không sale
create proc sp_danhsachNosale
as
begin
	select * from SANPHAM
end
go
-- tìm kiếm sản phẩm trong danh sách rút gọn
create  proc sp_Timkiemdanhsachsp @chuoi nvarchar(30)
as
begin
	select MaSP,TenSP,DonGiaNhap,DonGiaBan,TongSoLuong,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,TenLoai,Sanpham.MaLoai from SANPHAM inner join PHANLOAISP
	on SANPHAM.MaLoai = PHANLOAISP.MaLoai
	where SANPHAM.MaSP  = @chuoi or TenSP like '%' + @chuoi + '%'
end
go
-- danh sách sản phẩm all
create  proc sp_danhsachsp @masp varchar(5) = null
as
begin
	if(@masp is null)
	select MaSP,TenSP,DonGiaNhap,DonGiaBan,TongSoLuong,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,TenLoai,Sanpham.MaLoai from SANPHAM inner join PHANLOAISP
	on SANPHAM.MaLoai = PHANLOAISP.MaLoai
	else 
	select MaSP,TenSP,DonGiaNhap,DonGiaBan,TongSoLuong,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaSP = @masp 
end
go
-- xem chi tiết 1 sản phẩm
create  proc sp_chitiet1sp @masp varchar(5), @size int , @mamau int
as
begin
	select TenSP,DonGiaBan,SoLuong,MaMau,Size,HinhAnhTrc,HinhAnhSau,Giamgia from CHITIETSANPHAM inner join SANPHAM
	on SANPHAM.MaSP = CHITIETSANPHAM.MaSP
	where SANPHAM.MaSP = @masp and Size = @size and mamau = @mamau 
end
go
-- Load img
create proc sp_loadImage
as
begin
	select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where TongSoLuong > 0
end
go
-- Load size
create proc sp_loadSize @masp varchar(5)
as
begin
	select masp,size from CHITIETSANPHAM  where masp = @masp
	group by masp,Size
end
go
-- Load màu
create  proc sp_loadColor @masp varchar(5)
as
begin
	select masp,MaMau from CHITIETSANPHAM  where masp = @masp
	group by masp,MaMau
end
go
-- Load   màu sắc theo size
create proc sp_LoadColorBySize @masp varchar(5), @masize int
as
begin
	select masp,mamau,Size,SoLuong from CHITIETSANPHAM where MaSP = @masp and Size = @masize
end
go
-- Load  số lượng theo màu sắc và size
create proc sp_LoadQuantityBySizeAndColor @masp varchar(5), @masize int , @mamau int
as
	select masp,mamau,Size,SoLuong from CHITIETSANPHAM where MaSP = @masp and Size = @masize and MaMau = @mamau
go
-- proc show bill vận chuyển
create proc sp_showbillvanchuyen
as
	select MaDonNhap, convert(varchar(10),ngaynhaphang,103) as NgayNhapHang,  convert(varchar(10),ngaynhaphang,108) as ThoiGian from donvanchuyen
-- proc show bill vận chuyển theo mã đơn
go
create proc sp_showbillVanChuyenByID @madonnhap int
as
		select MaDonNhap, convert(varchar(10),ngaynhaphang,103) as NgayNhapHang,  convert(varchar(10),ngaynhaphang,108) as ThoiGian from donvanchuyen 
		where madonnhap = @madonnhap
go
create  proc sp_ListDVC
as
begin
	select dvc.MaDonNhap,sp.TenSP,ctdvc.MaNV,kc.TenSize,ms.tenmau,ctdvc.SoLuong, convert(varchar(10),dvc.NgayNhapHang,105) as Ngay, convert(varchar(10),dvc.NgayNhapHang,108) as Gio from CHITIETDONVANCHUYEN ctdvc 
	inner join DONVANCHUYEN dvc on ctdvc.MaDonNhap = dvc.MaDonNhap
	inner join SANPHAM sp on ctdvc.MaSP = sp.MaSP
	inner join KICHCO kc on kc.MaSize = ctdvc.Size
	inner join MAUSAC ms on ms.MaMau = ctdvc.MaMau
end
go
create  proc sp_loadDonVanChuyen
as
begin
	select dvc.MaDonNhap,sp.MaSP,ctdvc.MaNV,kc.TenSize,ms.tenmau,ctdvc.SoLuong, convert(varchar(10),dvc.NgayNhapHang,105) as Ngay, convert(varchar(10),dvc.NgayNhapHang,108) as Gio from CHITIETDONVANCHUYEN ctdvc 
	inner join DONVANCHUYEN dvc on ctdvc.MaDonNhap = dvc.MaDonNhap
	inner join SANPHAM sp on ctdvc.MaSP = sp.MaSP
	inner join KICHCO kc on kc.MaSize = ctdvc.Size
	inner join MAUSAC ms on ms.MaMau = ctdvc.MaMau
end
go
create proc sp_loadDVCbyID @madonnhap int
as
begin
	select dvc.MaDonNhap,sp.MaSP,ctdvc.MaNV,kc.TenSize,ms.tenmau,ctdvc.SoLuong, convert(varchar(10),dvc.NgayNhapHang,105) as Ngay, convert(varchar(10),dvc.NgayNhapHang,108) as Gio from CHITIETDONVANCHUYEN ctdvc 
	inner join DONVANCHUYEN dvc on ctdvc.MaDonNhap = dvc.MaDonNhap
	inner join SANPHAM sp on ctdvc.MaSP = sp.MaSP
	inner join KICHCO kc on kc.MaSize = ctdvc.Size
	inner join MAUSAC ms on ms.MaMau = ctdvc.MaMau
	where dvc.MaDonNhap = @madonnhap
end
go
create proc sp_getMaxIDDVC
as
	select max(MaDonNhap) from CHITIETDONVANCHUYEN
go
create proc sp_getMinIDDVC
as
	select min(MaDonNhap) from CHITIETDONVANCHUYEN
go
create proc sp_LoadBillDVCByDay @fromDay datetime , @toDay datetime
as
begin
	select dvc.MaDonNhap,sp.MaSP,ctdvc.MaNV,kc.TenSize,ms.tenmau,ctdvc.SoLuong, convert(varchar(10),dvc.NgayNhapHang,105) as Ngay, convert(varchar(10),dvc.NgayNhapHang,108) as Gio from CHITIETDONVANCHUYEN ctdvc 
	inner join DONVANCHUYEN dvc on ctdvc.MaDonNhap = dvc.MaDonNhap
	inner join SANPHAM sp on ctdvc.MaSP = sp.MaSP
	inner join KICHCO kc on kc.MaSize = ctdvc.Size
	inner join MAUSAC ms on ms.MaMau = ctdvc.MaMau
	where dvc.NgayNhapHang >=(@fromDay + ' 00:00:00') and dvc.NgayNhapHang <= (@toDay + ' 23:59:59')
end
go
-- lấy mã size
create proc sp_getIDSize @tensize varchar(5)
as
begin
	select MaSize from KICHCO where TenSize = @tensize
end
go
-- lấy mã màu
create proc sp_getIDColor @tencolor Nvarchar(10)
as
begin
	select MaMau from MAUSAC where tenmau = @tencolor
end
go
-- Load màu dữ liệu làm bảng thanh toán
create proc sp_loadSize1 @masp varchar(5)
as
begin
	select masp,size,TenSize from CHITIETSANPHAM inner join KICHCO
	ON KICHCO.MaSize = CHITIETSANPHAM.Size
	where masp = @masp 
	group by masp,Size,TenSize
end
go
-- Load   màu sắc theo size
create proc sp_LoadColorBySize1 @masp varchar(5), @masize int
as
begin
	select masp,MAUSAC.MaMau,Size,MAUSAC.tenmau,SoLuong from CHITIETSANPHAM INNER JOIN MAUSAC
	ON MAUSAC.MaMau = CHITIETSANPHAM.MaMau
	where MaSP = @masp and Size = @masize
end

go
	-- Hóa đơn mua
-- tạo hóa đơn
create proc sp_createCheckBill 
as
begin
	insert HOADON values(GETDATE(),default,0,0)
end
go
-- sửa hóa đơn chi tiết 
create proc sp_updateItemCTHDM @masp varchar(5), @madonmua int , @mamau int , @masize int, @soluong int
as
declare 
				@thanhtien1 float,
				@tongtien float,
				@soluongtong int,
				@dongia int,
				@giamgia int,
				@vat float
		select @dongia = dongia from HOADONCHITIET where MaDonMua = @madonmua and MaMau = @mamau and MaSize = @masize and MaSP = @masp
		select @giamgia = GiamGia from HOADONCHITIET where MaDonMua = @madonmua and MaMau = @mamau and MaSize = @masize and MaSP = @masp
		select @vat = ThueVAT from HOADONCHITIET where MaDonMua = @madonmua and MaMau = @mamau and MaSize = @masize and MaSP = @masp
		set @soluongtong = @soluong
		set @thanhtien1 = (@soluongtong*@dongia) + ((@soluongtong*@dongia)*@vat)/100
		set @tongtien = @thanhtien1 - (@thanhtien1 * @giamgia) / 100
begin
	update HOADONCHITIET set SoLuong = @soluong,TongTien = @tongtien where MaDonMua = @madonmua and MaMau = @mamau and MaSize = @masize and MaSP = @masp
end
go
-- thêm vào hóa đơn chi tiết
create proc sp_addItemCTHDM @masp varchar(5), @manv varchar(5),
@sdt varchar(15),@soluong int ,@dongia float,
@giamgia int,@vat float , @mamau int ,@masize int 
as
	declare @MaDonMua int
	select @MaDonMua = MaDonMua from HOADON where TinhTrang = 0
	
begin
	if not exists(select * from HOADON where tinhtrang = 0)
		begin
			exec sp_createCheckBill
			select @MaDonMua = MaDonMua from HOADON where TinhTrang = 0
		end
	if exists(select * from HOADONCHITIET where MaDonMua = (select MaDonMua from HOADON where TinhTrang = 0) and MaSP = @masp and MaMau = @mamau and MaSize = @masize)
	begin
		declare @soluongdangco int,
				@soluongtong int
		select @soluongdangco = SoLuong from HOADONCHITIET where MaDonMua = (select MaDonMua from HOADON where TinhTrang = 0) and MaSP = @masp and MaMau = @mamau and MaSize = @masize
		set @soluongtong = @soluongdangco + @soluong
		declare @thanhtien1 float,
				@tongtien float
		set @thanhtien1 = ((@soluongtong*@dongia) + ((@soluongtong*@dongia)*@vat)/100)
		set @tongtien = @thanhtien1 - (@thanhtien1 * @giamgia) / 100
		update HOADONCHITIET set SoLuong = @soluongtong , TongTien = @tongtien
		where MaDonMua = (select MaDonMua from HOADON where TinhTrang = 0) and MaSP = @masp and MaMau = @mamau and MaSize = @masize
	end
	else
	begin
		declare @thanhtien float
		set @thanhtien = ((@soluong*@dongia) + ((@soluong*@dongia)*@vat)/100)
		insert into HOADONCHITIET values(@MaDonMua,@masp,@manv,@sdt,@mamau,@masize,@soluong,@dongia,@giamgia,@vat,(@thanhtien - (@thanhtien * @giamgia)/ 100))
	end
end
 go
CREATE TRIGGER UTG_ThanhToan
ON HOADON 
AFTER UPDATE
AS
	declare @mahoadon int
	select @mahoadon = MaDonMua from inserted
BEGIN
declare thanhtoancorsor Cursor for select  Masp,MaSize,MaMau,SoLuong from HOADONCHITIET inner join HOADON 
on HOADONCHITIET.MaDonMua = HOADON.MaDonMua where HOADON.TinhTrang = 1 and HOADON.MaDonMua = @mahoadon
OPEN thanhtoancorsor
	declare @masp varchar(5),
			@masize int ,
			@mamau int,
			@soluong int
	FETCH NEXT FROM thanhtoancorsor INTO @masp ,@masize,@mamau, @soluong

while @@FETCH_STATUS = 0
begin
	declare @slht int
	select @slht = SoLuong from CHITIETSANPHAM where MaSP= @masp and Size = @masize and MaMau = @mamau
	if(@soluong > 0)
	update CHITIETSANPHAM set SoLuong = @slht - @soluong where MaSP= @masp and Size = @masize and MaMau = @mamau
	FETCH NEXT FROM thanhtoancorsor INTO @masp ,@masize,@mamau, @soluong
end
CLOSE thanhtoancorsor
deallocate thanhtoancorsor
END
go
-- đổi trạng thái từ chwua thanh toán thành đã thanh toán  select * from hoadonchitiet
create proc sp_thanhToan @usePoint bit , @sdt varchar(15)
as
	declare @mahoadon int,
			@tongtien float,
			@diemtichluy int

	select @mahoadon = MaDonMua from HOADON where tinhtrang = 0
	select @tongtien = SUM(TongTien) from HOADONCHITIET where MaDonMua = @mahoadon
	select @diemtichluy = DiemTichLuy from KHACHHANG where SDT = @sdt
begin
	if(@usePoint = 1)
	begin
		update HOADON set TinhTrang = 1 , TongTien = @tongtien - ((@tongtien*10)/100) , usePoints = 1 where MaDonMua = @mahoadon
		print @sdt + 'đây là số điện thoại'
		update KHACHHANG set DiemTichLuy = @diemtichluy - 1000 where SDT = @SDt
	end
	else
	begin  select * from HOADON
		update HOADON set TinhTrang = 1 , TongTien = @tongtien where MaDonMua = @mahoadon
	end
end
go
-- danh sách hóa đơn đang mua của khách hàng
create  proc sp_showBuyingBill
as
begin
	select Hoadon.MaDonMua,hdct.MaSP,TenSP,tenmau,TenSize,MaNV,SDT,SoLuong,DonGia,hdct.GiamGia,ThueVAT,hdct.TongTien,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio from HOADONCHITIET hdct  
	inner join SANPHAM
	on hdct.MaSP = SANPHAM.MaSP
	inner join MAUSAC 
	on MAUSAC.MaMau = hdct.MaMau
	inner join  HOADON
	on HOADON.MaDonMua =hdct.MaDonMua
	inner join KICHCO
	on KICHCO.MaSize = hdct.MaSize
	where TinhTrang = 0
end
go
-- kiểm tra số lượng đang có và số lượng mua của khách hàng select * from chitietsanpham
create proc sp_CheckQuantityWhenBuying @madon int,@masp varchar(5), @masize int , @mamau int
as
	declare @slhtinBuyingbill int
	select @slhtinBuyingbill = SoLuong from HOADONCHITIET where MaDonMua = @madon and MaSP = @masp and MaMau = @mamau and MaSize = @masize
begin
	if(@slhtinBuyingbill is null)
	select 0
	else
	select @slhtinBuyingbill
end
go
-- danh sách hóa đơn select * From hoadonchitiet select * from hoadon delete hoadonchitiet	
create proc sp_getlistBill 
as
begin
	select Hoadon.MaDonMua,MaSP,MaNV,SDT,SoLuong,DonGia,GiamGia,ThueVAT,HOADONCHITIET.TongTien,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio from HOADON inner join HOADONCHITIET
	on HOADON.MaDonMua =HOADONCHITIET.MaDonMua where TinhTrang = 1
end
go  
create proc sp_addDiem @sdt varchar(15) , @diem int
as
	declare @diemhientai int
	select @diemhientai = DiemTichLuy from KHACHHANG where SDT= @sdt
begin
	update KHACHHANG set DiemTichLuy = @diemhientai + @diem where SDT = @sdt
end
go
create proc sp_useDiem @sdt varchar(15)
as
	declare @diemhientai int
	select @diemhientai = DiemTichLuy from KHACHHANG where SDT= @sdt select * from KHACHHANG
begin
	update KHACHHANG set DiemTichLuy = @diemhientai - 1000 where SDT = @sdt
end
go  
	-- Hóa đơn mua 
-- Show bill chi tiết hóa đơn mua  select * from hoadonchitiet   select * From hoadon 
create proc sp_showbillHDM 
as
begin
	select hd.MaDonMua,sp.TenSP,kc.TenSize,ms.tenmau,hdct.SoLuong,hdct.DonGia,hdct.GiamGia,hdct.SDT,hdct.MaNV,hd.usePoints,hdct.TongTien ,hd.TongTien as TongTienHD, hdct.ThueVAT,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio From HOADON hd inner join HOADONCHITIET hdct
	on hd.MaDonMua = hdct.MaDonMua inner join SANPHAM sp
	on hdct.MaSP = sp.MaSP  inner join MAUSAC ms
	on hdct.MaMau = ms.MaMau inner join KICHCO kc
	on hdct.MaSize = kc.MaSize
end
go
-- Show bill chi tiết hóa đơn mua (tìm kiếm theo mã đơn) select * from hoadon
create  proc sp_showbill1HDM @madon int
as
begin
	select hd.MaDonMua,sp.TenSP,kc.TenSize,ms.tenmau,hdct.SoLuong,hdct.DonGia,hdct.GiamGia,hdct.SDT,hdct.MaNV,hd.usePoints,hdct.TongTien ,hd.TongTien as TongTienHD,hdct.ThueVAT,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio From HOADON hd inner join HOADONCHITIET hdct
	on hd.MaDonMua = hdct.MaDonMua inner join SANPHAM sp
	on hdct.MaSP = sp.MaSP  inner join MAUSAC ms
	on hdct.MaMau = ms.MaMau inner join KICHCO kc
	on hdct.MaSize = kc.MaSize where hd.MaDonMua = @madon
end
go
create proc sp_showbillHDMbyDay @fromDay datetime , @today datetime
as
begin
	select hd.MaDonMua,sp.TenSP,kc.TenSize,ms.tenmau,hdct.SoLuong,hdct.DonGia,hdct.GiamGia,hdct.SDT,hdct.MaNV,hd.usePoints,hdct.TongTien ,hd.TongTien as TongTienHD,hdct.ThueVAT,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio From HOADON hd inner join HOADONCHITIET hdct
	on hd.MaDonMua = hdct.MaDonMua inner join SANPHAM sp
	on hdct.MaSP = sp.MaSP  inner join MAUSAC ms
	on hdct.MaMau = ms.MaMau inner join KICHCO kc
	on hdct.MaSize = kc.MaSize  where hd.NgayMua >=(@fromDay + ' 00:00:00') and hd.NgayMua <= (@toDay + ' 23:59:59')
end
go
create proc sp_showHOADON
as
begin
	select hd.MaDonMua,hdct.SDT,hd.TongTien,usePoints,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio From HOADON  hd
	inner join HOADONCHITIET hdct
	on hd.MaDonMua = hdct.MaDonMua
	group by  hd.MaDonMua,hdct.SDT,hd.TongTien,usePoints,convert(varchar(10),NgayMua,105) ,convert(varchar(10),NgayMua,108) 
end
go
create proc sp_showHOADONbyID @id int
as
begin
	select hd.MaDonMua,hdct.SDT,hd.TongTien,usePoints,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio From HOADON  hd
	inner join HOADONCHITIET hdct
	on hd.MaDonMua = hdct.MaDonMua
	where hd.MaDonMua = @id
	group by  hd.MaDonMua,hdct.SDT,hd.TongTien,usePoints,convert(varchar(10),NgayMua,105) ,convert(varchar(10),NgayMua,108)  
end
go
create  proc sp_showHOADONbydate @fromday datetime , @today datetime
as
begin
	select hd.MaDonMua,hdct.SDT,hd.TongTien,usePoints,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio From HOADON  hd
	inner join HOADONCHITIET hdct
	on hd.MaDonMua = hdct.MaDonMua
	where NgayMua >=(@fromDay + ' 00:00:00') and NgayMua <= (@toDay + ' 23:59:59')
	group by  hd.MaDonMua,hdct.SDT,hd.TongTien,usePoints,convert(varchar(10),NgayMua,105) ,convert(varchar(10),NgayMua,108)  
	
end

go
create proc sp_DoanhThu @thang int , @nam int
as
begin
	select MaDonMua,NgayMua,TongTien from HOADON
	where TinhTrang = 1 and month(NgayMua) = @thang and YEAR(NgayMua) = @nam
end
go
create proc sp_loadYearforDoanhthu 
as
	select YEAR(NgayMua) as Nam from HOADON
	group by YEAR(NgayMua)
go
-- thống kê doanh thu chi tiết
create proc sp_loadBillhoadonByMonth  @month int , @year int
as
begin
	select hd.MaDonMua,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio,hd.TongTien from HOADONCHITIET hdct inner join HOADON hd
	on hdct.MaDonMua = hd.MaDonMua where MONTH(NgayMua) = @month and YEAR(NgayMua) = @year
	group by  hd.MaDonMua,convert(varchar(10),NgayMua,105),convert(varchar(10),NgayMua,108),hd.TongTien
end
go
create  proc sp_loadBillhoadonByDayinMonth  @month int, @day int , @year int
as
begin
	select hd.MaDonMua,convert(varchar(10),NgayMua,105) as Ngay,convert(varchar(10),NgayMua,108) as Gio,hd.TongTien from HOADONCHITIET hdct inner join HOADON hd
	on hdct.MaDonMua = hd.MaDonMua where MONTH(NgayMua) = @month and DAY(NgayMua) = @day and YEAR(NgayMua) = @year
	group by  hd.MaDonMua,convert(varchar(10),NgayMua,105),convert(varchar(10),NgayMua,108),hd.TongTien
end
go
create proc sp_loadMinDayHoaDon @month int, @year int
as
begin
	select MIN(Day(NgayMua)) from HOADONCHITIET hdct inner join HOADON hd
	on hdct.MaDonMua = hd.MaDonMua where MONTH(NgayMua) = @month and YEAR(NgayMua) = @year
end
-- thống kê chi phí chi tiết
-- thống kê theo tháng
go
create proc sp_loadBillVCbyMonth    @month int, @year int
as
begin
	select dvc.MaDonNhap , convert(varchar(10),dvc.NgayNhapHang,105) as Ngay,convert(varchar(10),dvc.NgayNhapHang,108) as Gio,sp.TenSP,sum(SoLuong) as TongSL
	,DonGiaNhap , (sum(SoLuong) * DonGiaNhap) as TongTienNhap from DONVANCHUYEN dvc inner join CHITIETDONVANCHUYEN ctdvc
	on dvc.MaDonNhap = ctdvc.MaDonNhap inner join SANPHAM sp
	on ctdvc.MaSP = sp.MaSP
	where MONTH(NgayNhapHang) = @month and YEAR(NgayNhapHang) = @year
	group by   dvc.MaDonNhap , convert(varchar(10),dvc.NgayNhapHang,105),convert(varchar(10),dvc.NgayNhapHang,108),sp.TenSP ,DonGiaNhap
end
go
-- thống kê theo ngày trong tháng  select * From donvanchuyen  select * from hoadon update hoadon set ngaymua = '20211101' where madonmua = 2
create proc sp_loadBillVCbyDayinMonth    @month int, @day int,@year int
as
begin
	select dvc.MaDonNhap , convert(varchar(10),dvc.NgayNhapHang,105) as Ngay,convert(varchar(10),dvc.NgayNhapHang,108) as Gio,sp.TenSP,sum(SoLuong) as TongSL
	,DonGiaNhap , (sum(SoLuong) * DonGiaNhap) as TongTienNhap from DONVANCHUYEN dvc inner join CHITIETDONVANCHUYEN ctdvc
	on dvc.MaDonNhap = ctdvc.MaDonNhap inner join SANPHAM sp
	on ctdvc.MaSP = sp.MaSP
	where MONTH(NgayNhapHang) = @month and YEAR(NgayNhapHang) = @year and DAY(NgayNhapHang) = @day
	group by   dvc.MaDonNhap , convert(varchar(10),dvc.NgayNhapHang,105),convert(varchar(10),dvc.NgayNhapHang,108),sp.TenSP ,DonGiaNhap
end
go   
create proc sp_loadMindayinDVC    @month int,@year int
as
begin
	select MIN(DAY(NgayNhapHang))  from DONVANCHUYEN dvc inner join CHITIETDONVANCHUYEN ctdvc
	on dvc.MaDonNhap = ctdvc.MaDonNhap
	where MONTH(NgayNhapHang) = @month and YEAR(NgayNhapHang) = @year 
end
go
-- lấy ra ngày thấp nhất trog bill mua
create proc sp_minNgayMuaTrongThang @ngay int, @thang int
as
begin
	select * From HOADONCHITIET
end
go
create proc sp_deleteBuyingBill @masp varchar(5)
as
	declare @madon int
	select @madon = MaDonMua from HOADON where TinhTrang = 0
begin
	delete HOADONCHITIET where MaSP = @masp and MaDonMua = @madon
end
go

--- tìm kiếm danh mục
create   proc sp_TimkiemDM_SP @TenLoai nvarchar(30), @maloai nvarchar(5)
as
begin
	select * from PHANLOAISP where TenLoai like '%' +@TenLoai +'%' or MaLoai like '%' +@maloai +'%'
end
go

--
	--select hd.NgayMua,hd.TongTien,hdct.masp from HOADON hd  inner join HOADONCHITIET hdct
	--on hd.MaDonMua = hdct.MaDonMua inner join SANPHAM sp
	--on hdct.MaSP = sp.MaSP
------ đang làm delete  hoadonchitiet

--create table HOADON(
--	MaDonMua int identity(1,1) PRIMARY KEY,
--	NgayMua datetime NOT NULL ,
--	TinhTrang bit NOT NULL default 0 -- 0 là chưa thanh toán , 1 là đã thanh toán
--	)
--go

--create table HOADONCHITIET(
--	MaDonMua int identity(1,1) references HOADON (MaDonMua),
--	MaSP varchar (5) references SANPHAM (MaSP),
--	MaNV varchar (5) references NHANVIEN (MaNV),
--	SDT varchar (15) references KHACHHANG (SDT),
--	SoLuong int NOT NULL,
--	DonGia int NOT NULL,
--	GiamGia int NOT NULL,
--	ThueVAT float(50) NOT NULL,
--	TongTien float(50) NOT NULL
--	)
--go
-------------------------- Dữ liệu
 --select * from NHANVIEN
-------------------------
--exec sp_taodonvanchuyen
--declare @i int  = 1
--while @i <=5
--begin
--exec sp_themSP 'AD2',N'AnTA',150000,230000,3,'atd_den.png','atd_sau_den.png','AN01', 20, 1, @i ,'QL002'
--	set @i = @i + 1
--end
--SELECT * FROM KICHCO
--exec sp_themSP 'A2',N'Fun And Peace TS',150000,250000,3,'atd_sau_den.png','atd_sau_den.png','AN01', 10, 1, 5,'QL002'
--select * from SANPHAM
--select * from MAUSAC
--SELECT * FROM CHITIETSANPHAM 
--exec sp_loadColor 'A3'
--select * from CHITIETDONVANCHUYEN
--select * from DONVANCHUYEN
--delete CHITIETDONVANCHUYEN where madonnhap = 26
--DELETE CHITIETSANPHAM
--delete DONVANCHUYEN
--DELETE SANPHAM
--select masp,MaMau from CHITIETSANPHAM 
--group by masp,MaMau
--select * from MAUSAC

-- select convert(varchar(10),NgayNhapHang,105) from DONVANCHUYEN where   convert(varchar(10),NgayNhapHang,108) like '%18%'

--select * from NHANVIEN

--update NHANVIEN set MatKhau = '418515815641305135230215920295153463' where MaNV = 'QL001'



----@maspcu varchar(5) , @sizecu int, @mamaucu int,
----@maspmoi varchar(5) , @sizemoi int, @mamaumoi int,
----@madonnhap int, @manv varchar(5), @soluong int
--select  * from hoadonchitiet  
--select * from CHITIETSANPHAM
--select * from SANPHAM
--update hoadon set NgayMua = '20220720 00:00:00' where MaDonMua = 2
--select * From HOADON
































































---- test
--select * from NHANVIEN where Email like '%@%' or 1=1--', and MatKhau = ''
--exec sp_loginNV @email = true , @matkhau = or 1= 1
--exec sp_loginNV '', 1=1
--select * from NHANVIEN

--	--Đăng nhập nhân viên
--create  proc sp_loginNV @email varchar(100), @matkhau varchar(255)
--as
--	declare @status int
--begin
--	if exists (select * from NHANVIEN where Email = @email and MatKhau = @matkhau)
--		set @status = 1
--	else
--		set @status = 0
--	select @status
--end
--exec sp_loginnv 'long@gmail.com' ,'123' 
--select * From NHANVIEN
--go