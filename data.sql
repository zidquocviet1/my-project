use QuanLyBanHang

go

create table khach_hang
(
	id_khach_hang int identity primary key,
	ten_cong_ty nvarchar(100),
	ten_giao_dich nvarchar(100),
	dia_chi nvarchar(100) NOT NULL,
	email nvarchar(100),
	dien_thoai nvarchar(20) NOT NULL,
	fax nvarchar(50),
)
go

create table nha_cung_cap
(
	id_cong_ty int identity primary key,
	ten_cong_ty nvarchar(100),
	ten_giao_dich nvarchar(100),
	dia_chi nvarchar(100) NOT NULL,
	email nvarchar(100),
	dien_thoai nvarchar(20) NOT NULL,
	fax nvarchar(50),
)
go
create table Account
(
	username nvarchar(100) primary key,
	displayname nvarchar(100) NOT NULL default N'Chua co ten',
	password nvarchar(100) NOT NULL,
	type nvarchar(1) NOT NULL default 0, -- 0 la admin 1 la staff
)
go


create table AccountInfo
(
	id int IDENTITY primary key,
	displayname nvarchar(100) NOT NULL default N'Chua co ten',
	address nvarchar(50) NOT NULL default N'Chua xac dinh',
	phonenumber nvarchar,
	ngaySinh datetime NOT NULL,
	gioiTinh bit NOT NULL default 0, --0 la nu & 1 la nam
	email nvarchar(100),
	username nvarchar(100),
	
	foreign key(username) references dbo.Account(username)
)
go

create procedure USP_Login
@username nvarchar(100), @password nvarchar(100)
as
begin
	select * from dbo.Account where username = @username and password = @password
end
go
create table mat_hang
(
	id_mat_hang int identity primary key,
	ten_hang nvarchar(50) NOT NULL,
	id_cong_ty int NOT NULL,
	id_loai_hang int NOT NULL,
	so_luong int,
	don_vi_tinh nvarchar(50),
	gia float NOT NULL,
	
	foreign key (id_cong_ty) references dbo.nha_cung_cap(id_cong_ty),
	
)
go

create table loai_hang
(
	id_loai_hang int identity primary key,
	ten_loai_hang nvarchar(50),
)
go

create table don_dat_hang
(
	id_hoa_don int identity primary key,
	id_khach_hang int NOT NULL,
	id_nhan_vien int NOT NULL,
	ngay_dat_hang DateTime,
	ngay_giao_hang DateTime,
	ngay_chuyen_hang DateTime,
	dia_chi nvarchar(100),
	
	foreign key (id_khach_hang) references dbo.khach_hang(id_khach_hang)
	
)
go
create table chi_tiet_don_hang
(
	id_hoa_don int NOT NULL,
	id_mat_hang int NOT NULL,
	gia_ban Money,
	so_luong int default 1,
	muc_giam_gia float default 0,
	
	--constraint ctdh_pk primary key (id_hoa_don, id_mat_hang),
	
	foreign key(id_mat_hang) references dbo.mat_hang(id_mat_hang),
	foreign key(id_hoa_don) references dbo.don_dat_hang(id_hoa_don)
)
go
create table nhan_vien
(
	id_nhan_vien int identity(1,1) primary key,
	ten nvarchar(100) NOT NULL,
	gioi_tinh bit default 0, --0 la nam 1 la nu
	ngay_sinh DateTime,
	ngay_lam_viec Datetime,
	dia_chi nvarchar(100),
	dien_thoai nvarchar(20),
	luong Money,
	phu_cap float default 0, --tinh theo phan tram
)
go


create procedure USP_AddEmployee
@name nvarchar(100), @ngay_sinh date, @ngay_lam_viec date,
@dia_chi nvarchar(100), @dien_thoai nvarchar(20), @luong Money, @gioi_tinh bit
as
begin
	insert into nhan_vien values(@name,@ngay_sinh,@ngay_lam_viec,@dia_chi,@dien_thoai,@luong,@gioi_tinh)
end
go

create procedure USP_UpdateCustomer
@id int,@ten nvarchar(100), @ten_giao_dich nvarchar(100), 
@dia_chi nvarchar(100), @email nvarchar(100), @dien_thoai nvarchar(20), @fax nvarchar(20)
as
begin
	update khach_hang set ten_cong_ty = @ten, ten_giao_dich = @ten_giao_dich,
	dia_chi = @dia_chi, email = @email, dien_thoai = @dien_thoai, fax = @fax
	where id_khach_hang = @id
end
go

create proc USP_AddCategory
	@ten_hang nvarchar(100), @id_cong_ty int, @id_loai_hang int, @so_luong int,
	@don_vi_tinh nvarchar(100), @gia decimal, @image_path nvarchar(1000), @ghi_chu nvarchar(4000)
as
begin
	insert into mat_hang values(@ten_hang, @id_cong_ty, @id_loai_hang, @so_luong, 
	@don_vi_tinh, @gia, @image_path, @ghi_chu) 
end
go

create procedure USP_UpdateCategory
	@id int, @ten_hang nvarchar(100), @id_cong_ty int, @id_loai_hang int, @so_luong int,
	@don_vi_tinh nvarchar(100), @gia decimal, @image_path nvarchar(1000), @ghi_chu nvarchar(4000)
as
begin
	if (@so_luong > 0)
	begin
		update mat_hang set ten_hang = @ten_hang, id_cong_ty = @id_cong_ty,
		id_loai_hang = @id_loai_hang, so_luong = @so_luong, don_vi_tinh = @don_vi_tinh, gia = @gia,
		image_path = @image_path, ghi_chu = N'Còn hàng'
		where id_mat_hang = @id
	end
	else
	begin
		update mat_hang set ten_hang = @ten_hang, id_cong_ty = @id_cong_ty,
		id_loai_hang = @id_loai_hang, so_luong = @so_luong, don_vi_tinh = @don_vi_tinh, gia = @gia,
		image_path = @image_path, ghi_chu = N'Hết hàng'
		where id_mat_hang = @id
	end
end
go

create proc USP_LoadHangHoa
as
begin
	select * from mat_hang
end
go


create table hoa_don
(
	id int identity(1,1) primary key,
	ngay_ban date,
	status nvarchar(100),
)
go

create table chi_tiet_hoa_don
(
	id int identity(1,1) primary key,
	id_hoa_don int,
	id_mat_hang int,
	so_luong int,
	
	foreign key (id_hoa_don) references dbo.hoa_don(id),
	foreign key (id_mat_hang) references dbo.mat_hang(id_mat_hang)
)
go

create procedure USP_UpdateProvider
	@id int, @name nvarchar(100), @address nvarchar(100), @email nvarchar(100), @phoneNumber nvarchar(100),
	@fax nvarchar(100)
as
begin
	update nha_cung_cap set ten_cong_ty = @name, dia_chi = @address, email = @email, dien_thoai = @phoneNumber, fax = @fax
	where id_cong_ty = @id
end
go

create procedure USP_DoanhThu
	@fromDate DateTime, @toDate DateTime
as
begin
	select id, ngay_ban, status, khuyen_mai, tong_tien from hoa_don
	where ngay_ban >= @fromDate and ngay_ban <= @toDate
end
go

create procedure USP_UpdateSoLuong
	@id int, @soLuongBan int
as
begin
	declare @soLuongHienTai int
	
	update mat_hang set so_luong = so_luong - @soLuongBan where id_mat_hang = @id
	
	select @soLuongHienTai = so_luong from mat_hang where id_mat_hang = @id
	
		if @soLuongHienTai <= 0
		begin 
			update mat_hang set ghi_chu = N'Hết hàng' where id_mat_hang = @id
		end
end
go
