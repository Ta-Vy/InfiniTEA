create database INFINITEA
go

use INFINITEA
go
-- CSDL gồm 7 bảng sau:
-- TAIKHOAN: Tài khoản
-- NHANVIEN: Nhân viên (Thông tin nhân viên)
-- SANPHAM: Đồ ăn, đồ uống cụ thể trong các nhóm của thực đơn
-- DMBAN: Danh sách các bàn
-- DMSANPHAM: Các nhóm mặt hàng kinh doanh (Trà chanh, Trà sữa, Topping)
-- HOADON: Hóa đơn (thông tin bàn, đồ uống, và có thể in bill này đưa cho khách để nhận đồ)
-- TTHOADON: Chi tiết thông tin từng hóa đơn (mã hóa đơn, số món trong hóa đơn,... phục vụ việc quản lý)

--Bảng nhân viên
create table NHANVIEN(
	id_nv int identity primary key,
	ten_nv nvarchar(100) not null,
	sdt nvarchar(10) not null,
	diachi nvarchar(100) not null,
	cccd nvarchar(12) not null,

)
go

--Bảng tài khoản
create table TAIKHOAN(
	taikhoan nvarchar(50) primary Key not null, 
	matkhau nvarchar(50) not null,
	id_nv int not null,
	ten_nv nvarchar(100) not null,
	loai int not null, --loại tài khoản: 0-NHANVIEN, 1-manager
	foreign key (id_nv) references NHANVIEN(id_nv),
)

go

--Bảng bàn
create table DMBAN(
	id_ban int identity primary key, --tạo ID tự động bằng identity
	ten_ban nvarchar(100) not null, 
	trangthai nvarchar(100)not null, --trạng thái bàn: Trống - Có người
)
go

--Bảng danh mục sản phẩm
create table DMSANPHAM(
	id_dmsp int identity primary key not null, --tạo ID tự động
	ten_dmsp nvarchar(50) not null,
)
go

--Bảng món sản phẩm
create table SANPHAM(
	id_sp int identity primary key,
	ten_sp nvarchar(50) not null,
	id_dmsp int not null,
	gia int not null,
	foreign key (id_dmsp) references DMSANPHAM(id_dmsp),
)
go

--Bảng Bill cho khách
create table HOADON(
	id_hoadon int identity primary key,
	dateCheckIn Date not null, --Ngày đặt đơn
	dateCheckOut Date,			--Ngày thanh toán (Thường thì khách sẽ thanh toán ngay, nên 2 ngày này sẽ trùng nhau)
	id_ban int not null,
	trangthai int not null,		-- 1-Đã thanh toán, 0-Chưa thanh toán
	giamgia int default  0,
	tongtien float,
	foreign Key (id_ban) references DMBAN(id_ban),
)
go

--Bảng quản lý Bill
create table TTHOADON(
	id_tthoadon int identity primary key,
	id_hoadon int not null,
	id_sp int,
	foreign key (id_hoadon) references HOADON(id_hoadon),
	foreign key (id_sp) references SANPHAM(id_sp),
	count int, --Đếm SANPHAMID
)
go

--Thêm dữ liệu cho bản NHANVIEN
insert into NHANVIEN values (N'Tạ Cao Vỹ','0975871895','Hanoi','037200003028')
insert into NHANVIEN values (N'Đoàn Xuân Thắng','0975871895','Hanoi','037200003028')
insert into NHANVIEN values (N'Hoàng Thị Phượng','0975871895','Hanoi','037200003028')
insert into NHANVIEN values (N'Bùi Hồng Thắng','0975871895','Hanoi','037200003028')
insert into NHANVIEN values (N'Hoàng Quang Khôi','0975871895','Hanoi','037200003028')
go

--Thêm dữ liệu vào bảng TAIKHOAN
insert into TAIKHOAN values ('manager','1','1',N'Tạ Cao Vỹ','1')
insert into TAIKHOAN values ('nv1','1','2',N'Đoàn Xuân Thắng','0')
insert into TAIKHOAN values ('nv2','1','3',N'Hoàng Thị Phượng','0')
insert into TAIKHOAN values ('nv3','1','4',N'Bùi Hồng Thắng','0')
insert into TAIKHOAN values ('nv4','1','5',N'Hoàng Quang Khôi','0')
go

--Thêm dữ liệu vào bảng DMBAN

declare @i int =1
while @i<=30
begin
	insert into DMBAN values(N'Bàn '+Cast(@i as nvarchar(100)),N'Trống') --Tự động insert 30 bản ghi vào bảng DMBAN
	set @i=@i+1
end
go

--Thêm dữ liệu vào bảng DMSANPHAM
Insert into DMSANPHAM values(N'Trà Chanh')
Insert into DMSANPHAM values(N'Trà Sữa')
Insert into DMSANPHAM values(N'Chè')
Insert into DMSANPHAM values(N'Topping')
Insert into DMSANPHAM values(N'Đồ ăn vặt')
Insert into DMSANPHAM values(N'Đồ nóng')
go

--Thêm các mặt hàng vào bảng SANPHAM
Insert into SANPHAM values (N'Trà chanh nhiệt đới',1,40000)
Insert into SANPHAM values (N'Trà tắc nha đam',1,40000)
Insert into SANPHAM values (N'Trà chanh sả',1,50000)
Insert into SANPHAM values (N'Trà sữa caramen',2,40000)
Insert into SANPHAM values (N'Trà sữa dừa',2,30000)
Insert into SANPHAM values (N'Trà chocolate',2,30000)
Insert into SANPHAM values (N'Chè thập cẩm',3,15000)
Insert into SANPHAM values (N'Chè tự chọn',3,15000)
Insert into SANPHAM values (N'Trân châu đen',4,10000)
Insert into SANPHAM values (N'Trân châu trắng',4,10000)
Insert into SANPHAM values (N'Trân châu hoàng gia',4,10000)
Insert into SANPHAM values (N'Hướng dương',5,10000)
Insert into SANPHAM values (N'Bò khô',5,20000)
Insert into SANPHAM values (N'Xúc xích',6,10000)
Insert into SANPHAM values (N'Bắp nướng',6,10000)
Insert into SANPHAM values (N'Cacao nóng',6,25000)
go

--Tạo view đưa ra ID món, ID loại món, tên món, tên loại và giá từng món
create view view_SANPHAM
as
select s.id_sp as [Mã sản phẩm], s.ten_sp as [Tên sản phẩm], s.id_dmsp as [Mã danh mục], dm.ten_dmsp as [Tên danh mục], s.gia as [Đơn giá] 
from SANPHAM as s, DMSANPHAM as dm 
where s.id_dmsp = dm.id_dmsp
go

--Tạo view DMSanpham
create view view_DMSP
as
Select id_dmsp as [Mã danh mục], ten_dmsp as [Tên danh mục] 
from DMSANPHAM
go

--Tạo view Bàn
create view view_DMBan
as
Select id_ban as [Mã bàn], ten_ban as [Tên bàn], trangthai as [Trạng thái] 
from DMBAN
go

--Tạo view thông tin nhân viên
create view view_NHANVIEN
as
select id_nv as [Mã nhân viên], ten_nv as [Tên nhân viên], sdt as [Số điện thoại], diachi as [Địa chỉ], cccd as [Căn cước công dân]
from NHANVIEN
go

--Tạo view đưa ra thông tin tài khoản
create view view_ThongtinTK
as
select TAIKHOAN.taikhoan as [Tài khoản], TAIKHOAN.id_nv as [Mã nhân viên], NHANVIEN.ten_nv as [Tên nhân viên], TAIKHOAN.loai as [Loại tài khoản]
from NHANVIEN, TAIKHOAN 
where NHANVIEN.id_nv = TAIKHOAN.id_nv
go

---------------------------------------
create view view_TK_SanPham
as
	select dateCheckOut as [Ngày], tt.id_sp as [Mã sản phẩm], sp.ten_sp as [Tên sản phẩm], tt.count as [Số lượng], sp.gia*tt.count as [Tổng tiền]
	from HOADON as hd, SANPHAM as sp, TTHOADON as tt
	where hd.id_hoadon = tt.id_hoadon and sp.id_sp = tt.id_sp
go
-----------------------------------------
-- Thống kê danh sách sản phẩm đã bán theo thời gian được chọn
select [Tên sản phẩm], sum([Số lượng]) as [Tổng bán], sum([Tổng tiền]) as [Tổng doanh thu]
from view_TK_SanPham
where [Ngày] >= '20211022' and [Ngày] <= '20211022'
group by  [Tên sản phẩm]
go

create view view_DTTheoSanPham
as
select [Tên sản phẩm],Ngày, sum([Số lượng]) as [Tổng bán], sum([Tổng tiền]) as [Tổng doanh thu]
from view_TK_SanPham
group by  [Tên sản phẩm], Ngày
go 

select * from view_DTTheoSanPham where Ngày >= '20211022' and Ngày <= '20211024'
-------------------------------------------
-- View Doanh thu theo ngày

create view view_TK_DoanhThuNgay
as
	select dateCheckOut as [Ngày],count(id_hoadon) as [Số hóa đơn], sum((tongtien*giamgia)/(100 - giamgia)) as [Tổng giảm giá], sum(tongtien) as [Tổng doanh thu] 
	from HOADON
	group by dateCheckOut
go

select * from view_TK_DoanhThuNgay where [Ngày] = '20211106'
go

--Tạo procedure lấy tài khoản trong bảng tài khoản 
create proc proc_Login
@taikhoan nvarchar(50), @matkhau nvarchar(50)
as
begin
	select * from TAIKHOAN where taikhoan = @taikhoan and matkhau = @matkhau
end
go


--Lỗi SQL injection => Lấy hết dữ liệu từ bảng Tài khoản
--select * from TAIKHOAN where taikhoan = N'' or 1=1 --'


--Procedure thêm hóa đơn
create proc proc_ThemHoadon
@id_ban int
as
begin
	 Insert into HOADON values (GETDATE(),null, @id_ban, 0, 0, 0)
end
go

--Procedure thêm thông tin hóa đơn
create proc proc_ThemTTHoadon
@id_hoadon int, @id_sp int, @count int
as
begin
	declare @check_TTHoadon int
	declare @count_SP int = 1

	select @check_TTHoadon = id_tthoadon, @count_SP = count from TTHOADON where @id_hoadon = id_hoadon and @id_sp = id_sp

	if(@check_TTHoadon > 0 )
		begin
			declare @newCount int = @count_SP + @count
			if(@newCount > 0 )
				update TTHOADON set count = @count_SP + @count where id_sp = @id_sp and id_hoadon = @id_hoadon
			else
				delete TTHOADON where  id_hoadon = @id_hoadon and id_sp = @id_sp	
		end
	else
		Insert into TTHOADON values (@id_hoadon, @id_sp, @count)		
end
go


--Các trigger cap nhat thong tin hoa don va hoa don

--Trigger insert, update TTHD
create trigger trig_CapnhatTTHD 
on TTHOADON 
for insert, update
as
	Begin
		Declare @id_hoadon int
		Select @id_hoadon = id_hoadon from inserted

		Declare @id_ban int
		Select @id_ban = id_ban from HOADON where id_hoadon = @id_hoadon and trangthai = 0

		Declare @count int
		Select @count = Count(*) from TTHOADON where  id_hoadon = @id_hoadon

		if(@count > 0)
			Update DMBAN set trangthai = N'Có người' where id_ban = @id_ban
		else 
			Update DMBAN set trangthai = N'Trống' where id_ban = @id_ban
	End
Go
--Trigger xóa hóa TTHD
create trigger trig_DeleteTTHD
on TTHOADON 
for delete
as
	Begin
		declare @id_hoadon int
		declare @id_tthoadon int
		select @id_hoadon = id_tthoadon, @id_hoadon = deleted.id_hoadon from deleted

		declare @id_ban int
		select @id_ban = id_ban from HOADON where id_hoadon = @id_hoadon

		declare @count int
		select @count = COUNT(*) from TTHOADON where id_hoadon = @id_hoadon 

		if(@count = 0)
			update DMBAN set trangthai = N'Trống' where id_ban = @id_ban
			delete HOADON where id_hoadon = @id_hoadon
	End
Go

--Trigger update HD
create trigger trig_CapnhatHD
on HOADON 
for update
as
	Begin
		Declare @id_hoadon int
		Select @id_hoadon = id_hoadon from inserted

		Declare @id_ban int
		Select @id_ban = id_ban from HOADON where id_hoadon = @id_hoadon 

		Declare @count int 
		Select @count = COUNT(*) from HOADON Where id_ban = @id_ban and trangthai = 0

		if (@count = 0)
			Update DMBAN set trangthai = N'Trống' where id_ban = @id_ban
	End
Go


--Procedure chuyển bàn
create proc proc_Chuyenban
@idBan_cu int, @idBan_moi int
as
	Begin
		Declare @idHD_cu int
		Declare @idHD_moi int

		Declare @HDcu int = 1
		Declare @HDmoi int = 1

		Select @idHD_cu = id_hoadon from HOADON where id_ban = @idBan_cu and trangthai = 0
		Select @idHD_moi = id_hoadon from HOADON where id_ban = @idBan_moi and trangthai = 0
		
		if(@idHD_cu is Null)
			Begin
				insert into HOADON values(Getdate(),NULL,@idBan_cu,0,0,0)
				Select @idHD_cu= max(id_hoadon) from HOADON where  id_ban = @idBan_cu and trangthai = 0
			End
		Select @HDcu = Count(*) from TTHOADON where id_hoadon = @idHD_cu

		if(@idHD_moi is Null)
			Begin
				insert into HOADON values(Getdate(),NULL,@idBan_moi,0,0,0)
				Select @idHD_moi= max(id_hoadon) from HOADON where id_ban = @idBan_moi and trangthai = 0
			End
		Select @HDmoi=Count(*) from TTHOADON where id_hoadon = @idHD_moi

		Select id_tthoadon into TTHOADON_Table from TTHOADON where id_hoadon = @idHD_moi

		Update TTHOADON set id_hoadon = @idHD_moi where id_hoadon = @idHD_cu
		Update TTHOADON set id_hoadon = @idHD_cu where id_tthoadon in (Select * from TTHOADON_Table)
		
		Drop table TTHOADON_Table

		if(@HDcu = 0)
			Update DMBAN set trangthai = N'Trống' where id_ban = @idBan_moi
		if(@HDmoi = 0)
			Update DMBAN set trangthai = N'Trống' where id_ban = @idBan_cu

	End
Go

-- Procedure hiển thị danh sách hóa đơn đã checkOUT

create proc proc_HienThiDoanhThu
@checkIn date, @checkOut date
as
begin
	select b.ten_ban as N'Tên bàn', dateCheckIn as N'Ngày vào', dateCheckOut as N'Ngày ra', giamgia as 'Giảm giá', hd.tongtien as N'Tổng tiền'
	from HOADON as hd, DMBAN as b
	where dateCheckIn >= @checkIn and dateCheckOut <= @checkOut and hd.trangthai = 1 and b.id_ban = hd.id_ban
end
go

exec proc_HienThiDoanhThu @checkIn = '20211022' , @checkOut = '20211030'

--Cập nhật tài khoản
create proc proc_CapnhatTK
@TK nvarchar(100), @TenNV nvarchar(100), @MK nvarchar(100), @MK_moi nvarchar(100)
as
begin
	declare @isCorrectPass int = 0

	select @isCorrectPass = COUNT(*) from TAIKHOAN where taikhoan = @TK and matkhau = @MK

	if(@isCorrectPass = 1)
	begin
		if(@MK_moi is null or @MK_moi = '')
		begin
			update TAIKHOAN set ten_nv = @TenNV where taikhoan = @TK
		end
		else
			update TAIKHOAN set ten_nv = @TenNV, matkhau = @MK_moi where taikhoan = @TK
	end
end
go


select * from HOADON 
select * from TTHOADON 