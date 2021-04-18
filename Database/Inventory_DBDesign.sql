SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[shopping_user] (
	ID uniqueIDentifier not null,
	FirstName nvarchar(50) not null,
	MiddleName nvarchar(50) null default null,
	LastName nvarchar(50) null default null,
	UserName nvarchar(50) unique not null,
	EmailOrPhone nvarchar(100) not null,
	PasswordHash nvarchar(100) not null,
	LastLogin datetime null default null,
	CONSTRAINT PK_user_ID PRIMARY KEY CLUSTERED 
	( 
		ID asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[inventory_items] (
	ID uniqueIDentifier not null,
	Name nvarchar(512) not null,
	Description ntext not null,
	Price nvarchar(512) not null, 
	ImagePath nvarchar(512) null default null,
	ItemAddedOn datetime not null,
	itemUpdatedOn datetime not null,
	CONSTRAINT PK_inventory_item_ID PRIMARY KEY CLUSTERED 
	( 
		ID asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[suppliers] (
	ID uniqueIDentifier not null,
	SupplierName nvarchar(250) not null,
	EmailOrPhone nvarchar(100) not null,
	CONSTRAINT PK_suppliers_ID PRIMARY KEY CLUSTERED 
	( 
		ID asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
)
GO

CREATE TABLE [dbo].[orders] (
	ID uniqueIDentifier not null,
	Title nvarchar(150) not null,
	ProductId uniqueIDentifier not null,
	SupplierId uniqueIDentifier not null,
	OrderDateAndTime datetime not null,
	UserId uniqueIDentifier not null,
	NumberOfItems INT null default 1,
	CONSTRAINT PK_orders_ID PRIMARY KEY CLUSTERED 
	( 
		ID asc 
	) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
	CONSTRAINT FK_orders_ID_product_ID FOREIGN KEY (ProductId) 
	REFERENCES [dbo].[inventory_items] (ID)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION,

	CONSTRAINT FK_orders_ID_supplier_ID FOREIGN KEY (SupplierId) 
	REFERENCES [dbo].[suppliers] (ID)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION,
	
	CONSTRAINT FK_orders_ID_user_ID FOREIGN KEY (UserId) 
	REFERENCES [dbo].[shopping_user] (ID)
	ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
GO

INSERT INTO shopping_user (ID, FirstName, MiddleName, LastName, UserName, EmailOrPhone, passwordHash, registeredAt, lastLogin)
VALUES 
(
	newID(), 'Rohit', null, 'Sukhija', 'rsukhija', 'rohit.sukhija@gmail.com', 'ddssfakn112213443', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP 
)


INSERT INTO inventory_items(ID, Name, Description, Price, ImagePath, ItemAddedOn, itemUpdatedOn)
VALUES 
(
	newid(), 'IPods', 'Apple IPods', '$24455.12', 'abc/def/efg.png', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP
)
INSERT INTO inventory_items(ID, Name, Description, Price, ImagePath, ItemAddedOn, itemUpdatedOn)
VALUES 
(
	newid(), 'A30CCEE7-C3FB-4314-831F-05663582CB73', null, 'My First Blog Post', '-By RohitS', 'my_first_blog_post', 1, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 'Content to look for!!'
)

