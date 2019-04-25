create table Product(
	id int identity(1,1) primary key not null,
	Name nvarchar(max),
	Price int not null,
	Expiry datetime not null
)