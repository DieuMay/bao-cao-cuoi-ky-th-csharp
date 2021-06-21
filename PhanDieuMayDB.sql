Use PhanDieuMayDB

CREATE TABLE UserAccount (
	Id int IDENTITY(1,1) primary key,
	UserName nvarchar(50),
	Password nvarchar(50),
	Status nvarchar(255)
)

CREATE TABLE Category (
	Id int IDENTITY(1,1) primary key,
	Name nvarchar(50),
	Description nvarchar(255)
)

CREATE TABLE Product (
	Id int IDENTITY(1,1) primary key,
	Name nvarchar(50),
	UnitCost decimal,
	Quantity int,
	Image char(255),
	Description nvarchar(255),
	Status nvarchar(255),
	Category_Id int,
	constraint fk_Product_Category foreign key (Category_Id) references Category(Id)
)

insert into Product values('BC01','But chi','cay','Singapore',3000)
insert into Product values('BC02','But chi','cay','Singapore',5000)
insert into Product values('BC03','But chi','cay','Viet Nam',3500)
insert into Product values('BC04','But chi','hop','Viet Nam',30000)
insert into Product values('BB01','But bi','cay','Viet Nam',5000)
insert into Product values('BB02','But bi','cay','Trung Quoc',7000)
insert into Product values('BB03','But bi','hop','Thai Lan',100000)
insert into Product values('TV01','Tap 100 giay mong','quyen','Trung Quoc',2500)
insert into Product values('TV02','Tap 200 giay mong','quyen','Trung Quoc',4500)
insert into Product values('TV03','Tap 100 giay tot','quyen','Viet Nam',3000)
insert into Product values('TV04','Tap 200 giay tot','quyen','Viet Nam',5500)
insert into Product values('TV05','Tap 100 trang','chuc','Viet Nam',23000)
insert into Product values('TV06','Tap 200 trang','chuc','Viet Nam',53000)
insert into Product values('TV07','Tap 100 trang','chuc','Trung Quoc',34000)
insert into Product values('ST01','So tay 500 trang','quyen','Trung Quoc',40000)
insert into Product values('ST02','So tay loai 1','quyen','Viet Nam',55000)
insert into Product values('ST03','So tay loai 2','quyen','Viet Nam',51000)
insert into Product values('ST04','So tay','quyen','Thai Lan',55000)
insert into Product values('ST05','So tay mong','quyen','Thai Lan',20000)
insert into Product values('ST06','Phan viet bang','hop','Viet Nam',5000)
insert into Product values('ST07','Phan khong bui','hop','Viet Nam',7000)
insert into Product values('ST08','Bong bang','cai','Viet Nam',1000)
insert into Product values('ST09','But long','cay','Viet Nam',5000)
insert into Product values('ST10','But long','cay','Trung Quoc',7000)
