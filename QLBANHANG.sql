use master
Drop Database QLBanGiay
----------
create database QLBANHANG
GO
use QLBANHANG
GO
CREATE TABLE KHACHHANG
(
	MaKH INT IDENTITY(1,1),
	HoTen nVarchar(50) NOT NULL,
	Taikhoan Varchar(50) UNIQUE,
	Matkhau Varchar(50) NOT NULL,
	Email Varchar(100) UNIQUE,
	DiachiKH nVarchar(200),
	DienthoaiKH Varchar(50),	
	Ngaysinh DATETIME
	CONSTRAINT PK_Khachhang PRIMARY KEY(MaKH)
)
GO
Create Table CHUDE
(
	MaCD int Identity(1,1),
	TenChuDe nvarchar(50) NOT NULL,
	CONSTRAINT PK_ChuDe PRIMARY KEY(MaCD)
)
GO
Create Table NHAPHANPHOI
(
	MaNPP int identity(1,1),
	TenNPP nvarchar(50) NOT NULL,
	Diachi NVARCHAR(200),
	DienThoai VARCHAR(50),
	CONSTRAINT PK_NhaPhanPhoi PRIMARY KEY(MaNPP)
)
GO
Create Table Admin
(
	UserAdmin varchar(30) primary key,
	PassAdmin varchar(30) not null,
	Hoten nVarchar(50)
)
GO
CREATE TABLE CONGTY
(
	MaCT INT IDENTITY(1,1),
	TenCT NVARCHAR(50) NOT NULL,
	Diachi NVARCHAR(100),
	Tieusu nVarchar(Max),
	Dienthoai VARCHAR(50),
	CONSTRAINT PK_CongTy PRIMARY KEY(MaCT)
)
Go
CREATE TABLE GIAY
(
	Magiay INT IDENTITY(1,1),
	Tengiay NVARCHAR(100) NOT NULL,
	Giaban Decimal(18,0) CHECK (Giaban>=0),
	Mota NVarchar(Max),
	Anhbia VARCHAR(50),
	Ngaycapnhat DATETIME,
	Soluongton INT,
	MaCD INT,
	MaNPP INT,
	CONSTRAINT PK_Giay PRIMARY KEY(MaGiay),
	CONSTRAINT FK_Chude FOREIGN KEY(MaCD) REFERENCES CHUDE(MaCD),
	CONSTRAINT FK_Nhaphanphoi FOREIGN KEY(MaNPP) REFERENCES NHAPHANPHOI(MaNPP)
)
GO
CREATE TABLE LAMGIAY
(
	MaCT INT,
	Magiay INT,
	Vaitro NVARCHAR(50),
	Vitri NVarchar(50)
	CONSTRAINT FK_CT FOREIGN KEY(MaCT) REFERENCES CONGTY(MaCT),
	CONSTRAINT FK_Giay FOREIGN KEY(MaGiay) REFERENCES Giay(MaGiay),
	CONSTRAINT PK_LamGiay PRIMARY KEY(MaCT,MaGiay)
)
GO
CREATE TABLE DONDATHANG
(
	MaDonHang INT IDENTITY(1,1),
	Dathanhtoan bit,
	Tinhtranggiaohang  bit,
	Ngaydat Datetime,
	Ngaygiao Datetime,	
	MaKH INT,
	CONSTRAINT FK_Khachhang FOREIGN KEY(MaKH) REFERENCES Khachhang(MaKH),
	CONSTRAINT PK_DonDatHang PRIMARY KEY(MaDonHang)
)
GO
CREATE TABLE CHITIETDONTHANG
(
	MaDonHang INT,
	MaGiay INT,
	Soluong Int Check(Soluong>0),
	Dongia Decimal(18,0) Check(Dongia>=0),	
	CONSTRAINT PK_CTDatHang PRIMARY KEY(MaDonHang,MaGiay),
)
GO

/****** CHUDE******/
INSERT CHUDE(TenChuDe) VALUES (N'Sandal')
INSERT CHUDE(TenChuDe) VALUES (N'Giày Búp Bê')
INSERT CHUDE(TenChuDe) VALUES (N'Giày Thể Thao')
INSERT CHUDE(TenChuDe) VALUES (N'Dép Lê')
INSERT CHUDE(TenChuDe) VALUES (N'Giày Cao Gót')
INSERT CHUDE(TenChuDe) VALUES (N'Giày Đế Xuồng')
INSERT CHUDE(TenChuDe) VALUES (N'Thời Trang')
INSERT CHUDE(TenChuDe) VALUES (N'Son,Phấn')

/****** KHACHHANG ******/
INSERT KHACHHANG (Hoten, DiachiKH, DienthoaiKH, Taikhoan, Matkhau, Ngaysinh, Email)
VALUES (N'Dương Thành Phết', N'12 Trần Huy Liệu', N'0918062755', N'thayphet.net', N'123456', '08/20/1976', 'phetcm@hgmail.com')
INSERT KHACHHANG (Hoten, DiachiKH, DienthoaiKH, Taikhoan, Matkhau, Ngaysinh, Email) 
VALUES (N'Nguyễn Tiến Luân', N'21 Quận 6', N'0917654310', N'thang', N'123456', '10/15/1990', N'ntluan@hcmuns.edu.vn')
INSERT KHACHHANG (Hoten, DiachiKH, DienthoaiKH, Taikhoan, Matkhau, Ngaysinh, Email) 
VALUES (N'Đặng Quốc Hòa', N'32 Sư Vạn Hạnh', N'098713245', N'dqhoa', N'hoa', '05/21/1991', N'dqhoa@hcmuns.edu.vn')
INSERT KHACHHANG (Hoten, DiachiKH, DienthoaiKH, Taikhoan, Matkhau, Ngaysinh, Email) 
VALUES (N'Ngô Ngọc Ngân', N'12 Khu chung cư', N'0918544699', N'nnngan', N'ngan', '10/12/1986', N'nnngan@hcmuns.edu.vn')
INSERT KHACHHANG (Hoten, DiachiKH, DienthoaiKH, Taikhoan, Matkhau, Ngaysinh, Email) 
VALUES (N'Trịnh Minh Long', N'102 Bà Huyện Thanh Quan', N'0852827998', N'minhlong', N'123456', '04/06/1995', N't.minhlong1996@gmail.com')
/****** CONGTY******/
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTYTNHH1TV HKT', N'197 Trần Hưng Đạo','', N'98877668')
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTY ONE1TOWN', N'179 Chánh hưng - F.4 - Q.8 Tp.HCM','', N'19001611')
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTY HOWTODO', N'45 Lý Thái Tổ-F2.Q.3 Tp.HCM','', N'19001570')
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTY BACONHEO', NULL, NULL,NULL)
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTY Hồ Tiên', NULL, NULL,NULL)
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTY JiHOO', NULL, NULL,NULL)
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES ( N'CTY Hữu Khang',NULL, NULL,NULL)
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES ( N'CTY Đức Trí',NULL, NULL,NULL)
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES ( N'CTY Thành Tín', N'179 Chánh Hưng F.4 Q.8 Tp.HCM', '',N'8504122')
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTY MinhLongShop', N'124 Bắc Hải P.6 Q.TB', '',N'0918121188')
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTY BunNye', N'','', '')
INSERT CONGTY(TenCT, Diachi, Tieusu, Dienthoai) VALUES (N'CTY bts viết thường', N'','', '')

/****** NHAPHANPHOI    ******/

INSERT NHAPHANPHOI(TenNPP, Diachi, Dienthoai) VALUES (N'MinhLongShop', N'102 Bà Huyện Thanh Quan Q3', N'19001560')
INSERT NHAPHANPHOI(TenNPP, Diachi, Dienthoai) VALUES ( N'CTY ONE1TOWN', N'Đồng Nai', N'19001511')
INSERT NHAPHANPHOI(TenNPP, Diachi, Dienthoai) VALUES ( N'CTY JiHOO', N'Tp.HCM', N'19001570')
INSERT NHAPHANPHOI(TenNPP, Diachi, Dienthoai) VALUES ( N'CTY JiHOO', N'Tp.HCM', N'0908419981')
INSERT NHAPHANPHOI(TenNPP, Diachi, Dienthoai) VALUES ( N'CTYTNHH1TV HKT', N'Đà Nẵng', N'0903118833')
INSERT NHAPHANPHOI(TenNPP, Diachi, Dienthoai) VALUES ( N'CTYTNHH1TV H2O', N'Bình Dương', N'0913336677')
INSERT NHAPHANPHOI(TenNPP, Diachi, Dienthoai) VALUES ( N'CTY HOWTODO', N'Tp.HCM', N'0989888888')
INSERT NHAPHANPHOI(TenNPP, Diachi, Dienthoai) VALUES ( N'CTY BACONHEO', N'Hà Nội', N'8351056')


/******Giay ******/


INSERT Giay(TenGiay, Giaban, Mota,Anhbia, MaCD, MaNPP, Ngaycapnhat, Soluongton) 
VALUES (N'Sandal 1', 150000, N'Sản phẩm: Mã sản phẩm: 2178

Đế: Nhựa sốp( đi nước và vệ sinh bình thường)
Đặc điểm : Nhẹ và êm chân
Kiểu dáng: Xỏ ngón, cổ điển
Chất liệu: Da bò thật 100%
Độ cao: 1.5cm
Màu sắc: Nâu
Lót chân: Da bò lộn
Bảo hành 6 tháng.
Hổ trợ đổi size và mẫu trong 2 ngày!
Xin trân trọng giới thiệu cuốn sách cùng bạn', 
'Sandal.jpg', 7, 1, '10/25/2014', 120)

INSERT Giay(TenGiay, Giaban, Mota,Anhbia, MaCD, MaNPP, Ngaycapnhat, Soluongton) 
VALUES (N'SANDAL NỮ MONA CAO', 250000,  
N'- Với chiều cao 7cm, giúp các nàng thoải mái với chiều cao vừa phải vẫn tự tin vì rất lên dáng
- Lót mút bên trong dày, êm chân, thêm vào đó là được thiết kế với lỗ hút giúp thoáng cho đôi chân
- Kiểu dáng cơ bản, ôm dáng với chất liệu da thật cực kỳ ôm chân
- Kiểu dáng trẻ trung năng động, đi làm, đi chơi, dạo phố đều đẹp.', 
'Sandal1.jpg', 3, 2, '10/23/2013', 25)

INSERT Giay(TenGiay, Giaban, Mota,Anhbia, MaCD, MaNPP, Ngaycapnhat, Soluongton) 
VALUES ( N'Sandal nữ S14 VIETLAVANI', 11500, 
 N'Guốc 5 Phân 2 Quai bản ngang 
Xuất sắc các bác ôiiii 
Eo ôi cực phẩm này không quá cao, không quá thấp nên dễ đi lắm đây này
Chiều cao: 5cm
Màu sắc: 2 màu cơ bản Đen và Nude
Bản gót dẹp mới nhất hiện nay
Đi ôm chân cực sang chảnh
Quai bản to đi cực chắc chân 
thích hợp đi chơi, đi học, du lịch, đi đường xa....', 
'Sandal2.jpg', 7, 3, '12/21/2014', 23)

INSERT Giay(TenGiay, Giaban, Mota,Anhbia, MaCD, MaNPP, Ngaycapnhat, Soluongton) 
VALUES ( N'sandal đế xuồng phong cách Hàn Quốc', 200000, 
 N'Giày Sandal đế xuồng cá tính
✔ Chất liệu:  Da và PU
✔ Màu sắc: Trắng
✔ Đế cao: 6cm
✔ Size: 35 đến 40, GIÀY CÓ SẴN 
✔  Bảo hành keo, gót 12 tháng
✈ Giao hàng: Shop giao hàng Toàn Quốc', 
'Sandal2.jpg', 8, 4, '9/15/2014', 240)
INSERT Giay(TenGiay, Giaban, Mota,Anhbia, MaCD, MaNPP, Ngaycapnhat, Soluongton) 
VALUES ( N'SANDAL NỮ 2 DÂY NGANG GÓT THUN CO DÃN mã SD-002', 250000, 
N'Chi tiết sản phẩm và THÔNG SỐ KỸ THUẬT
Mã SP: MÃ SD-002
Kiểu dáng: saldal SD 002
Độ cao: Cao 2.5cm
Màu sắc:  BE - Đen
Kích cỡ: 36-37-38-39-40
SANDAL NỮ 2 MÀU ĐEN - BE MÃ SD-002
kiểu dáng năng động, tiện dụng.
 Giày  sandal quai ngang duyên dáng Giày sandal quai hậu to bản ôm gọn cổ chân  Đế cao su nguyên khối dày, có rãnh chống trơn trượt an toàn khi di chuyển và vận động. Thích hợp với trang phục năng động, trẻ trung Phù hợp đi chơi, du lịch, dạo phố, đi học...v...v...v', 
'Sandal3.jpg', 1, 7,'10/18/2015', 16)

INSERT Giay(TenGiay, Giaban, Mota,Anhbia, MaCD, MaNPP, Ngaycapnhat, Soluongton) 
VALUES ( N'SANDAL NỮ 2 DÂY NGANG GÓT', 285000, 
N'MÃ SẢN PHẨM :SANDAL ĐẾ XUỒNG CAO 7CM ĐƠN GIẢN
Sản phẩm giày sandal nữ mẫu mới thoáng chân với kiểu dáng đơn giản, tiện lợi phù hợp đi học, đi làm, đi chơi đã có mặt tại UMI SHOES rồi nhé cả nhà ơi
Dép sandal đế xuồng nữ này sử dụng trong mọi phong cách, mọi hoàn cảnh. 
Mix phong cách vintage cổ điển, nhẹ nhàng, trẻ trung thì chắc chắn e sandal đế xuồng này sẽ không làm các nàng thất vọng. Sử dụng mọi mục đích: sandal đế xuồng đi biển, sandal đế xuồng đi học, sandal đế xuồng đi du lịch, sandal đế xuồng đi chơi dạo phố, sandal đế xuồng công sở, sandal đế xuồng đi làm văn phòng, sandal đế xuồng đi làm công ty  xưởng máy....
✔Dép sandal đế xuồng nữ phong cách Hàn Quốc với kiểu dán đơn giản nhưng không kém phần thời trang, thanh lịch có 2 kiểu dáng sandal quai ngang và quai chéo lên chân siêu gọn ôm chân. Đây là 1 trong số những đôi sandal vừa HẠT DẺ lại vừa XINH DÃ MAN tại Shop đấy 
✔Kết cấu đế PVC cao 7cm siêu êm, chống nước và mồi hôi, không gây hôi chân, cả ngày thoải mái tự tin tung tăng di chuyển bất chấp đi mưa nhé.
✔Dép xăng đan nữ  này quai được đính chắc chắn bằng lớp keo ép nhiệt và cả đinh tán 2 cạnh nên khi quyết định mua ẻm sandal này thì các bạn sẽ yên tâm tuyệt đối vì mẫu dép quai hậu này đảm bảo đủ các yếu tố chất lượng bền, kiểu dáng đẹp hợp thời trang và giá rẻ hấp dẫn vô cùng. 
Sản phẩm sandal nữ này có 3 màu: Đen, be, nâu lên chân làm sáng da và rất dễ phối đồ. Kết hợp nhiều loại trang phục như jeans, short, quần tây, kaki...', 
'Sandal2.jpg', 2, 1, '10/18/2015', 16)



select * from Giay

/******		LamGiay ******/
INSERT LamGiay(MaGiay, MaCT,Vitri, Vaitro) VALUES (1, 1,'Nhà phân phối' , N'Công ty')


/****** DONDATHANG ******/

INSERT DONDATHANG (MaKH, Dathanhtoan,Ngaydat,Ngaygiao,Tinhtranggiaohang) 
VALUES ( 1,0, '10/15/2115', '10/20/2015',0)

INSERT DONDATHANG (MaKH, Dathanhtoan,Ngaydat,Ngaygiao,Tinhtranggiaohang) 
VALUES ( 3,0, '10/05/2114', '10/20/2014',0)

/******CHITIETDONHANG ******/
INSERT CHITIETDONTHANG (MaDonHang,MAGiay,SOLUONG, Dongia) VALUES (1, 19, 1, 25000)
INSERT CHITIETDONTHANG (MaDonHang,MAGiay,SOLUONG, Dongia) VALUES (1, 15, 3, 50000)
INSERT CHITIETDONTHANG (MaDonHang,MAGiay,SOLUONG, Dongia) VALUES (1, 14, 1, 25000)
INSERT CHITIETDONTHANG (MaDonHang,MAGiay,SOLUONG, Dongia) VALUES (2, 5, 3, 10000)
INSERT CHITIETDONTHANG (MaDonHang,MAGiay,SOLUONG, Dongia) VALUES (2, 9, 1, 15000)
INSERT CHITIETDONTHANG (MaDonHang,MAGiay,SOLUONG, Dongia) VALUES (2, 15, 3, 150000)
INSERT CHITIETDONTHANG (MaDonHang,MAGiay,SOLUONG, Dongia) VALUES (3, 9, 1, 25000)
INSERT CHITIETDONTHANG (MaDonHang,MAGiay,SOLUONG, Dongia) VALUES (3, 10, 3,70000)

/******Admin ******/
Insert into Admin values('admin','123456','Trịnh Minh Long')
Insert into Admin values('user','123456','Bùi Thế Lượng')