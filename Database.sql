create database DBEcommerce

go

use DBEcommerce

go

create table Category(
IdCategory int primary key identity,
Name varchar(50),
CreationDate datetime default getdate()
)

go

create table Product(
IdProduct int primary key identity,
Name varchar(50),
Description varchar(1000),
IdCategory int references Category(IdCategory),
Price decimal(10,2),
PriceOffer decimal(10,2),
Amount int,
Image varchar(max),
CreationDate datetime default getdate()
)

go

create table Users(
IdUser int primary key identity,
FullName varchar(50),
Mail varchar(50),
Password varchar(50),
Role varchar(50),
CreationDate datetime default getdate()
)

go

create table Sale(
IdSale int primary key identity,
IdUser int references Users(IdUser),
Total decimal(10,2),
CreationDate datetime default getdate()
)

go

create table DetailSale
(
IdDetailSale int primary key identity,
IdSale int references Sale(IdSale),
IdProduct int references Product(IdProduct),
Amount int,
Total decimal(10,2)
)

--insertamos un usuario para poder iniciar sesion

insert into Users(FullName,Mail,Password,Role) values
('admin','admin@example.com','123','Admin')