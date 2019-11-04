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

drop procedure USP_Update
go

alter table AccountInfo
add constraint unique_phoneNumber UNIQUE(phonenumber);
go

select * from nhan_vien

insert into nha_cung_cap values(N'Công ty Mai Qu?c Vi?t', N'Giao Hàng', N'sadf',N'abc@gmail.com', N'012324567', '12354')
select * from nha_cung_cap
go

insert into loai_hang values(N'Th?m Ch?i')
select * from loai_hang
go

update nhan_vien set ngay_sinh = '11-04-2019' where id_nhan_vien = 43

SET IDENTITY_INSERT mat_hang ON
insert into mat_hang(ten_hang, id_cong_ty, id_loai_hang, so_luong, don_vi_tinh, gia, image_path) 
values(N'Bánh Kem',1, 3, 5, N'Cái', 229000, 'E:\ComputerSience_TDT\Software Architecture\DoAn\image\lego.jpg')
SET IDENTITY_INSERT mat_hang OFF

select * from mat_hang

update mat_hang set gia = 229000

alter table mat_hang
alter column gia decimal

alter table mat_hang
check constraint FK_MatHang_LoaiHang

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
	update mat_hang set ten_hang = @ten_hang, id_cong_ty = @id_cong_ty,
	id_loai_hang = @id_loai_hang, so_luong = @so_luong, don_vi_tinh = @don_vi_tinh, gia = @gia,
	image_path = @image_path, ghi_chu = @ghi_chu
	where id_khach_hang = @id
end
go
