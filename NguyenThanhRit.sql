create database NguyenThanhRitDB
go
Use NguyenThanhRitDB
go 
create table UserAccount(
ID INT IDENTITY(1,1)  ,
UserName varchar(50) primary key,
Password varchar (50)null,
Status varchar(50)null,
)
create table Product(
ID INT IDENTITY(1,1)  primary key,
Name nvarchar(50)null,
Category_ID INT,
UnitCost money null,
Quantity int null,
Image varchar(255) null,
Description nvarchar(255) null,
Status nvarchar(50) null,
FOREIGN KEY (Category_ID)
REFERENCES Category (Category_ID)
)
create table Category(
Category_ID INT IDENTITY(1,1)  primary key,
Name nvarchar(50)null,
Description nvarchar(255) null,
)

go 
insert into UserAccount(UserName, Password, Status)
values (N'admin','admin','Active'),
(N'admin1','admin1','Active'),
(N'admin2','admin','Blocked'),
(N'admin3','admin','Active'),
(N'admin4','admin','Blocked'),
(N'rit123','admin','Active'),
(N'rit122','admin','Blocked'),
(N'rit112','admin','Active'),
(N'rit001','admin','Blocked');

insert into Category(Name, Description)
values (N'Giày thể thao',N'Chất lượng cao'),
(N'Giày thời trang',N'Giày để đi chơi'),
(N'Giày cao gót',N'Giày cho phụ nữ'),
(N'Giày da ',N'Giày da được làm từ da cá xấu'),
(N'Giày trẻ em',N'Giày này chỉ dùng cho trẻ em'),
(N'Giày nhập khẩu',N'Giày nhập khẩu từ nước ngoài');

insert into Product(Name, Category_ID,UnitCost,Quantity,Image,Description,Status)
values (N'Giày Adidas Super Star',1,2000000,50,'',N'Giày phong cách thể thao dành cho giới trẻ','Còn hàng'),
(N'Giày Adidas Prophere',1,3000000,40,'',N'Giày phong cách thể thao dành cho giới trẻ','Còn hàng'),
(N'Giày Nike Air',1,4000000,30,'',N'Giày phong cách thể thao dành cho giới trẻ','Còn hàng'),
(N'Giày lười nam Blue',2,2000000,50,'',N'Giày đẹp để đi đám cưới người yêu cũ','Còn hàng'),
(N'Giày Cổ cao thời thượng',2,6000000,20,'',N'Giày thích hợp để đi phượt','Còn hàng'),
(N'Giày cao cấp ELLY',3,1000000,70,'',N'Giày tôn lên vẻ đẹp người phụ nữ Việt','Còn hàng'),
(N'Giày nữ cao cấp SHDG',3,2000000,50,'',N'Giày tôn lên vẻ đẹp người phụ nữ Việt','Còn hàng'),
(N'Giày da Manzano',4,2000000,50,'',N'Giày da thật chính hãng , tôn lên vẻ lịch lãm nam tính cho phái mạnh','Còn hàng'),
(N'Giày da thật ELLY HOMME',4,3000000,70,'',N'Giày da thật chính hãng , tôn lên vẻ lịch lãm nam tính cho phái mạnh','Còn hàng'),
(N'Giày trẻ em GAP',5,1000000,50,'',N'Giúp nâng niu bàn chân Việt','Còn hàng'),
(N'Giày thượng đình nhập khẩu Trung Quốc',6,200000,100,'',N'Giày Trung Quốc chất lượng thấp','Còn hàng');

