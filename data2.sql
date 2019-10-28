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

use QuanLyBanHang
insert into nhan_vien values('Mai Quoc Viet',null,null,'Tien giang','123123123',530.000,1.2)
select * from dbo.nhan_vien
go
insert into nhan_vien values(1,'Nguyen Van Long','0','28/07/2000','10/10/2019','TP HCM','0907218732',500000,0.1)
