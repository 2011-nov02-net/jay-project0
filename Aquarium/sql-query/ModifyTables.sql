alter table Aquarium.Inventory
	add StoreId int not null
		constraint FK_Inventory_StoreId foreign key references Aquarium.Store(StoreId) on delete cascade on update cascade;
go

alter table Aquarium.Orders
	add constraint Date default getdate() for Date
	add AnimalId int not null
		constraint FK_Orders_AnimalId foreign key references Aquarium.Animal(AnimalId) on delete cascade on update cascade;
go

insert into Aquarium.Animal (Name, Price)
	values (
		'Whale',
		1000.00
	);

insert into Aquarium.Animal (Name, Price)
	values (
		'Shark',
		300.00
	);

insert into Aquarium.Animal (Name, Price)
	values (
		'Penguin',
		100.00
	);
go

insert into Aquarium.Customer (FirstName, LastName, Email)
	values (
		'Mona',
		'Lisa',
		'Mona@gmail.com'
	);

insert into Aquarium.Customer (FirstName, LastName)
	values (
		'Steve',
		'Young'
	);
go

insert into Aquarium.Store (City, Country)
	values (
		'Nyc',
		'USA'
	);

insert into Aquarium.Store (City, Country)
	values (
		'Seoul',
		'South Korea'
	);
go

insert into Aquarium.Inventory (AnimalId, Quantity, StoreId)
	values (
		(select AnimalId from Aquarium.Animal where Name = 'Whale'),
		10,
		(select StoreId from Aquarium.Store where City = 'Nyc')
	);

insert into Aquarium.Inventory (AnimalId, Quantity, StoreId)
	values (
		(select AnimalId from Aquarium.Animal where Name = 'Shark'),
		75,
		(select StoreId from Aquarium.Store where City = 'Nyc')
	);

insert into Aquarium.Inventory (AnimalId, Quantity, StoreId)
	values (
		(select AnimalId from Aquarium.Animal where Name = 'Penguin'),
		230,
		(select StoreId from Aquarium.Store where City = 'Seoul')
	);
go

insert into Aquarium.Orders (StoreId, CustomerId, Quantity, Total, AnimalId)
	values (
		(select StoreId from Aquarium.Store where City = 'Nyc'),
		(select CustomerId from Aquarium.Customer where FirstName = 'Mona'),
		5,
		5000.00,
		(select AnimalId from Aquarium.Animal where Name = 'Whale')
	);