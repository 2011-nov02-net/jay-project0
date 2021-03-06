create schema Aquarium;
go

create table Aquarium.Animal (
	AnimalId int not null primary key identity(1, 1),
		Name nvarchar(30) not null,
	Price smallmoney not null
);
go

create table Aquarium.Inventory (
	InventoryId int not null primary key identity(1, 1),
	AnimalId int not null
		foreign key references Aquarium.Animal(AnimalId) on delete cascade on update cascade,
	Quantity int not null
);
go

create table Aquarium.Store (
	StoreId int not null primary key identity(1, 1),
	City nvarChar(30) not null,
	Country nvarChar(30) not null
);
go

create table Aquarium.Customer (
	CustomerId int not null primary key identity(1, 1),
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	Email nvarchar(100) not null unique
);
go

create table Aquarium.Orders (
	OrderId int not null primary key identity(1, 1),
	StoreId int not null
		foreign key references Aquarium.Store(StoreId) on delete cascade on update cascade,
	CustomerId int not null 
		foreign key references Aquarium.Customer(CustomerId) on delete cascade on update cascade,
	Date datetime2 not null,
	Quantity int not null,
	Total smallmoney not null
);