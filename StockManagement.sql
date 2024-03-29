USE [StockManagement]
create database [StockManagement]

--drop database[StockManagement]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/16/2019 6:34:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
drop database StockManagement
--drop table Companies

create table Companies(
CompanyID int Identity (1,1) primary Key(CompanyID),
CompanyName varchar(20)
)

SELECT * FROM Companies
INSERT iNTO Companies(CompanyName) values ('DAARAZ')
--drop table Categories
create table Categories(
CategoryID int Identity (1,1) primary Key(CategoryID),
CategoryName varchar(20)
)
INSERT iNTO Categories(CategoryName) values ('Furniture')
SELECT * FROM Categories
--drop table Items
create table Items(
ItemID int Identity (1,1) primary Key(ItemID),
ItemName varchar(30),
ReorderLevel int,
CompanyID int foreign key(CompanyID) references Companies (CompanyID),
CategoryID int foreign key (CategoryID) references Categories(CategoryID)

)
Insert into Items (ItemName,ReorderLevel,CompanyID,CategoryID) values ('FLOOR CARPETS',10,5,4)
SELECT * FROM Items

CREATE VIEW Item AS 

--drop view Item
select i.ItemID, i.ItemName,i.ReorderLevel,cm.CompanyName,ct.CategoryName from Items as I 
join Companies as cm on cm.CompanyID=i.CompanyID 
join Categories as ct on ct.CategoryID=i.CategoryID 

select ReorderLevel from Items  where ItemName ='WINDOWS 10'

select item.ReorderLevel from Item where Item.ItemName ='WINDOWS 10'

--drop table StockIn
create table StockIn(
StockInID int Identity (1,1) primary Key(StockInID),
StockInQuentity int,
StockInDate DATE,
StockAvailable int,
ItemID int foreign key(ItemID) references Items (ItemID)
)
Insert into StockIn (StockInQuentity,StockInDate,ItemID) values (100,'2019-07-31',26)

SELECT * FROM StockIn

select Stock.StockInID from Stock where Stock.ItemName='Hi'

UPDATE StockIn
SET StockAvailable = 50
WHERE StockInID = 3;


CREATE VIEW Stock AS 
select S.StockInID,s.StockAvailable,s.StockInDate,S.StockInQuentity,I.ItemName,I.ReorderLevel,I.CompanyName,I.CategoryName from StockIn as S
join Item as I on I.ItemID=S.ItemID where i.ReorderLevel=10

select I.ItemName, s.StockAvailable,I.ReorderLevel,I.CompanyName,I.CategoryName from StockIn as S join Item as I on I.ItemID=S.ItemID where  (I.CompanyName ='RFL') and (I.CategoryName='PEN')

Drop view Stock

CREATE VIEW StockReorderLavel AS 
select  I.ReorderLevel from StockIn as S
join Item as I on I.ItemID=S.ItemID where 

--drop table StockOut
DROP VIEW Stock



create table StockOut(
StockOutID int Identity (1,1) primary Key(StockOutID),
StockOutQuentity int,
StockOutStatus varchar(10),
StockOutDate DATE,
ItemID int foreign key(ItemID) references Items (ItemID)
)

select * FROM (select * FROM StockOut where StockOutStatus= 'sell') StockOut where StockOutDate between '2019-07-06' and '2019-07-07'

select * FROM StockOut 
Insert into StockOut (StockOutQuentity,StockOutStatus,StockOutDate,StockInID) values (45,'LOST','2019-07-30',3)

create view StockOutdate as

select so.StockInID,so.StockOutQuentity,so.StockOutDate,so.StockOutStatus,s.CompanyName from StockOut as SO
join Stock as S on S.StockInID=SO.StockInID where so.StockOutDate between '2019-07-05' and '2019-07-10'  

select *from StockOutDate where StockOutStatus='damage'
--DROP DATABASE StockManagement


select i.ItemID, i.ItemName,i.ReorderLevel,cm.CompanyName,ct.CategoryName from Items as I 
join Companies as cm on cm.CompanyID=i.CompanyID 
join Categories as ct on ct.CategoryID=i.CategoryID 

join StockIn as si on si.StockInID=i.CategoryID



select Item.ItemName from Item where Item.CategoryName = 'Iphone'

create table Logintable
(
username varchar(20),
userpassword int
)
select S.StockInID as SL,I.ItemName,S.StockInQuentity,s.StockInDate from StockIn as S
join Item as I on I.ItemID=S.ItemID


Select s.StockOutID,i.CompanyName,s.StockOutQuentity From StockOut as s join Item as I on I.ItemID=S.ItemID
select I.ItemName, i.CompanyName,StockOut.StockOutQuentity as DamageLostSellQuentity FROM (select * FROM StockOut  where StockOutStatus= 'sell') StockOut join Item as I on I.ItemID=StockOut.ItemID    where StockOutDate between '2019-07-06' and '2019-07-08' 


insert into logintable (username,userpassword) values('admin',123456)