create database QuanLyBanHang
go

use QuanLyBanHang
go

create table Account
(
	username nvarchar(100) primary key,
	displayname nvarchar(100) NOT NULL default N'Chua co ten',
	password nvarchar(100) NOT NULL,
	type nvarchar(1) NOT NULL default 0, -- 0 la admin 1 la staff
)
go

create table Category
(
	id int IDENTITY primary key,
	name nvarchar(50) NOT NULL default N'Chua co ten',
)
go

create table Product
(
	id int IDENTITY primary key,
	idCate int,
	nameProduct nvarchar(50) NOT NULL default N'chua co ten',
	nameCate nvarchar(50) NOT NULL,
	price float NOT NULL,
	
	foreign key(idCate) references dbo.Category(id)
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

insert into dbo.Account
	(
		username,
		displayname,
		password,
		type
	)
values
	(
		N'admin',
		N'Administrator',
		N'admin',
		N'0'
	)
go

insert into dbo.Account
	(
		username,
		displayname,
		password,
		type
	)
values
	(
		N'staff',
		N'Staff',
		N'1234',
		N'1'
	)
go

create procedure USP_Login
@username nvarchar(100), @password nvarchar(100)
as
begin
	select * from dbo.Account where username = @username and password = @password
end
go

exec USP_Login @username = N'admin', @password = N'admin'

select * from Account
