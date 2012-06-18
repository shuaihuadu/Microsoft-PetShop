CREATE TABLE [Account] (
	[UserId] varchar(20) PRIMARY KEY,
	[Email] varchar(80) NOT NULL,
	[FirstName] varchar(80) NOT NULL,
	[LastName] varchar(80) NOT NULL,
	[Status] varchar(2) NULL,
	[Addr1] varchar(80) NOT NULL,
	[Addr2] varchar(80) NULL,
	[City] varchar(80) NOT NULL,
	[State] varchar(80) NOT NULL,
	[Zip] varchar(20) NOT NULL,
	[Country] varchar(20) NOT NULL,
	[Phone] varchar(20) NOT NULL
)

CREATE TABLE [BannerData] (
	[FavCategory] varchar(80) PRIMARY KEY,
	[BannerData] varchar(255) NULL
)

CREATE TABLE [Category] (
	[CatId] varchar(10) PRIMARY KEY,
	[Name] varchar(80) NULL,
	[Descn] varchar(255) NULL
)

CREATE TABLE [Inventory] (
	[ItemId] varchar(10) PRIMARY KEY,
	[Qty] int NOT NULL
)

CREATE TABLE [Product] (
	[ProductId] varchar(10) PRIMARY KEY,
	[Category] varchar(10) NOT NULL REFERENCES [Category]([CatId]),
	[Name] varchar(80) NULL,
	[Descn] varchar(255) NULL
)

CREATE TABLE [Profile] (
	[UserId] varchar(20) PRIMARY KEY,
	[LangPref] varchar(80) NOT NULL,
	[FavCategory] varchar(30) NULL,
	[MyListOpt] int NULL,
	[BannerOpt] int NULL
)

CREATE TABLE [SignOn] (
	[UserName] varchar(20) PRIMARY KEY,
	[Password] varchar(20) NOT NULL
)

CREATE TABLE [Supplier] (
	[SuppId] int PRIMARY KEY,
	[Name] varchar(80) NULL,
	[Status] varchar(2) NOT NULL,
	[Addr1] varchar(80) NULL,
	[Addr2] varchar(80) NULL,
	[City] varchar(80) NULL,
	[State] varchar(80) NULL,
	[Zip] varchar(5) NULL,
	[Phone] varchar(40) NULL 
)

CREATE TABLE [Item] (
	[ItemId] varchar(10) PRIMARY KEY,
	[ProductId] varchar(10) NOT NULL REFERENCES [Product]([ProductId]),
	[ListPrice] decimal(10, 2) NULL,
	[UnitCost] decimal(10, 2) NULL,
	[Supplier] int NULL REFERENCES [Supplier]([SuppId]),
	[Status] varchar(2) NULL,
	[Attr1] varchar(80) NULL,
	[Attr2] varchar(80) NULL,
	[Attr3] varchar(80) NULL,
	[Attr4] varchar(80) NULL,
	[Attr5] varchar(80) NULL
)

CREATE TABLE [Orders] (
	[OrderId] int IDENTITY PRIMARY KEY,
	[UserId] varchar(20) NOT NULL,
	[OrderDate] datetime NOT NULL,
	[ShipAddr1] varchar(80) NOT NULL,
	[ShipAddr2] varchar(80) NULL,
	[ShipCity] varchar(80) NOT NULL,
	[ShipState] varchar(80) NOT NULL,
	[ShipZip] varchar(20) NOT NULL,
	[ShipCountry] varchar(20) NOT NULL,
	[BillAddr1] varchar(80) NOT NULL,
	[BillAddr2] varchar(80) NULL,
	[BillCity] varchar(80) NOT NULL,
	[BillState] varchar(80) NOT NULL,
	[BillZip] varchar(20) NOT NULL,
	[BillCountry] varchar(20) NOT NULL,
	[Courier] varchar(80) NOT NULL,
	[TotalPrice] decimal(10, 2) NOT NULL,
	[BillToFirstName] varchar(80) NOT NULL,
	[BillToLastName] varchar(80) NOT NULL,
	[ShipToFirstName] varchar(80) NOT NULL,
	[ShipToLastName] varchar(80) NOT NULL,
	[CreditCard] varchar(20) NOT NULL,
	[ExprDate] varchar(7) NOT NULL,
	[CardType] varchar(40) NOT NULL,
	[Locale] varchar(20) NOT NULL
)

CREATE TABLE [LineItem] (
	[OrderId] int NOT NULL REFERENCES [Orders]([OrderId]),
	[LineNum] int NOT NULL,
	[ItemId] varchar(10) NOT NULL,
	[Quantity] int NOT NULL,
	[UnitPrice] decimal(10, 2) NOT NULL,
	CONSTRAINT [PkLineItem] PRIMARY KEY ([OrderId], [LineNum])
)

CREATE TABLE [OrderStatus] (
	[OrderId] int NOT NULL REFERENCES [Orders]([OrderId]),
	[LineNum] int NOT NULL,
	[Timestamp] datetime NOT NULL,
	[Status] varchar(2) NOT NULL,
	CONSTRAINT [PkOrderStatus] PRIMARY KEY ([OrderId], [LineNum])
)

CREATE INDEX [IxItem] ON [Item]([ProductId], [ItemId], [ListPrice], [Attr1])
CREATE INDEX [IxProduct1] ON [Product]([Name])
CREATE INDEX [IxProduct2] ON [Product]([Category])
CREATE INDEX [IxProduct3] ON [Product]([Category], [Name])
CREATE INDEX [IxProduct4] ON [Product]([Category], [ProductId], [Name])

INSERT INTO [SignOn] VALUES('DotNet', 'DotNet')
INSERT INTO [Account] VALUES('DotNet', 'yourname@yourdomain.com', 'ABC', 'XYX', 'OK', '901 San Antonio Road', 'MS UCUP02-206', 'Palo Alto', 'CA', '94303', 'USA', '555-555-5555')
INSERT INTO [Profile] VALUES('DotNet', 'English', 'Dogs', 1, 1)

INSERT INTO [SignOn] VALUES('ACID', 'ACID')
INSERT INTO [Account] VALUES('ACID', 'test@rollback.com', 'Distributed', 'Transaction', 'OK', 'PO Box 4482', '', 'Carmel', 'CA', '93921', 'USA', '831-625-1861')
INSERT INTO [Profile] VALUES('ACID', 'English', 'Birds', 1, 1)

INSERT INTO [BannerData] VALUES ('Fish', '<img src="Images/bannerFish.gif">')
INSERT INTO [BannerData] VALUES ('Cats', '<img src="Images/bannerCats.gif">')
INSERT INTO [BannerData] VALUES ('Dogs', '<img src="Images/bannerDogs.gif">')
INSERT INTO [BannerData] VALUES ('Reptiles', '<img src="Images/bannerReptiles.gif">')
INSERT INTO [BannerData] VALUES ('Birds', '<img src="Images/bannerBirds.gif">')

INSERT INTO [Category] VALUES ('FISH', 'Fish', NULL)
INSERT INTO [Category] VALUES ('DOGS', 'Dogs', NULL)
INSERT INTO [Category] VALUES ('REPTILES', 'Reptiles', NULL)
INSERT INTO [Category] VALUES ('CATS', 'Cats', NULL)
INSERT INTO [Category] VALUES ('BIRDS', 'Birds', NULL)

INSERT INTO [Product] VALUES ('FI-SW-01', 'FISH', 'Angelfish', '<img align="absmiddle" src="Images/Pets/fish1.jpg">Saltwater fish from Australia')
INSERT INTO [Product] VALUES ('FI-SW-02', 'FISH', 'Tiger Shark', '<img align="absmiddle" src="Images/Pets/fish2.jpg">Saltwater fish from Australia')
INSERT INTO [Product] VALUES ('FI-FW-01', 'FISH', 'Koi', '<img align="absmiddle" src="Images/Pets/fish3.jpg">Freshwater fish from Japan')
INSERT INTO [Product] VALUES ('FI-FW-02', 'FISH', 'Goldfish', '<img align="absmiddle" src="Images/Pets/fish4.jpg">Freshwater fish from China')
INSERT INTO [Product] VALUES ('K9-BD-01', 'DOGS', 'Bulldog', '<img align="absmiddle" src="Images/Pets/dog1.jpg">Friendly dog from England')
INSERT INTO [Product] VALUES ('K9-PO-02', 'DOGS', 'Poodle', '<img align="absmiddle" src="Images/Pets/dog2.jpg">Cute dog from France')
INSERT INTO [Product] VALUES ('K9-DL-01', 'DOGS', 'Dalmation', '<img align="absmiddle" src="Images/Pets/dog3.jpg">Great dog for a fire station')
INSERT INTO [Product] VALUES ('K9-RT-01', 'DOGS', 'Golden Retriever', '<img align="absmiddle" src="Images/Pets/dog4.jpg">Great family dog')
INSERT INTO [Product] VALUES ('K9-RT-02', 'DOGS', 'Labrador Retriever', '<img align="absmiddle" src="Images/Pets/dog5.jpg">Great hunting dog')
INSERT INTO [Product] VALUES ('K9-CW-01', 'DOGS', 'Chihuahua', '<img align="absmiddle" src="Images/Pets/dog6.jpg">Great companion dog')
INSERT INTO [Product] VALUES ('RP-SN-01', 'REPTILES', 'Rattlesnake', '<img align="absmiddle" src="Images/Pets/reptile1.jpg">Doubles as a watch dog')
INSERT INTO [Product] VALUES ('RP-LI-02', 'REPTILES', 'Iguana', '<img align="absmiddle" src="Images/Pets/reptile2.jpg">Friendly green friend')
INSERT INTO [Product] VALUES ('FL-DSH-01', 'CATS', 'Manx', '<img align="absmiddle" src="Images/Pets/cat1.jpg">Great for reducing mouse populations')
INSERT INTO [Product] VALUES ('FL-DLH-02', 'CATS', 'Persian', '<img align="absmiddle" src="Images/Pets/cat2.jpg">Friendly house cat, doubles as a princess')
INSERT INTO [Product] VALUES ('AV-CB-01', 'BIRDS', 'Amazon Parrot', '<img align="absmiddle" src="Images/Pets/bird1.jpg">Great companion for up to 75 years')
INSERT INTO [Product] VALUES ('AV-SB-02', 'BIRDS', 'Finch', '<img align="absmiddle" src="Images/Pets/bird2.jpg">Great stress reliever')

INSERT INTO [Supplier] VALUES (1, 'XYZ Pets', 'AC', '600 Avon Way', '', 'Los Angeles', 'CA', '94024', '212-947-0797')
INSERT INTO [Supplier] VALUES (2, 'ABC Pets', 'AC', '700 Abalone Way', '', 'San Francisco', 'CA', '94024', '415-947-0797')

INSERT INTO [Item] VALUES ('EST-1', 'FI-SW-01', 16.50, 10.00, 1, 'P', 'Large', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-2', 'FI-SW-01', 16.50, 10.00, 1, 'P', 'Small', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-3', 'FI-SW-02', 18.50, 12.00, 1, 'P', 'Toothless', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-4', 'FI-FW-01', 18.50, 12.00, 1, 'P', 'Spotted', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-5', 'FI-FW-01', 18.50, 12.00, 1, 'P', 'Spotless', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-6', 'K9-BD-01', 18.50, 12.00, 1, 'P', 'Male Adult', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-7', 'K9-BD-01', 18.50, 12.00, 1, 'P', 'Female Puppy', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-8', 'K9-PO-02', 18.50, 12.00, 1, 'P', 'Male Puppy', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-9', 'K9-DL-01', 18.50, 12.00, 1, 'P', 'Spotless Male Puppy', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-10', 'K9-DL-01', 18.50, 12.00, 1, 'P', 'Spotted Adult Female', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-11', 'RP-SN-01', 18.50, 12.00, 1, 'P', 'Venomless', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-12', 'RP-SN-01', 18.50, 12.00, 1, 'P', 'Rattleless', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-13', 'RP-LI-02', 18.50, 12.00, 1, 'P', 'Green Adult', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-14', 'FL-DSH-01', 58.50, 12.00, 1, 'P', 'Tailless', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-15', 'FL-DSH-01', 23.50, 12.00, 1, 'P', 'Tailed', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-16', 'FL-DLH-02', 93.50, 12.00, 1, 'P', 'Adult Female', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-17', 'FL-DLH-02', 93.50, 12.00, 1, 'P', 'Adult Male', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-18', 'AV-CB-01', 193.50, 92.00, 1, 'P', 'Adult Male', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-19', 'AV-SB-02', 15.50, 2.00, 1, 'P', 'Adult Male', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-20', 'FI-FW-02', 5.50, 2.00, 1, 'P', 'Adult Male', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-21', 'FI-FW-02', 5.29, 1.00, 1, 'P', 'Adult Female', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-22', 'K9-RT-02', 135.50, 100.00, 1, 'P', 'Adult Male', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-23', 'K9-RT-02', 145.49, 100.00, 1, 'P', 'Adult Female', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-24', 'K9-RT-02', 255.50, 92.00, 1, 'P', 'Adult Male', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-25', 'K9-RT-02', 325.29, 90.00, 1, 'P', 'Adult Female', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-26', 'K9-CW-01', 125.50, 92.00, 1, 'P', 'Adult Male', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-27', 'K9-CW-01', 155.29, 90.00, 1, 'P', 'Adult Female', NULL, NULL, NULL, NULL)
INSERT INTO [Item] VALUES ('EST-28', 'K9-RT-01', 155.29, 90.00, 1, 'P', 'Adult Female', NULL, NULL, NULL, NULL)

INSERT INTO [Inventory] VALUES ('EST-1', 10000)
INSERT INTO [Inventory] VALUES ('EST-2', 10000)
INSERT INTO [Inventory] VALUES ('EST-3', 10000)
INSERT INTO [Inventory] VALUES ('EST-4', 10000)
INSERT INTO [Inventory] VALUES ('EST-5', 10000)
INSERT INTO [Inventory] VALUES ('EST-6', 10000)
INSERT INTO [Inventory] VALUES ('EST-7', 10000)
INSERT INTO [Inventory] VALUES ('EST-8', 10000)
INSERT INTO [Inventory] VALUES ('EST-9', 10000)
INSERT INTO [Inventory] VALUES ('EST-10', 10000)
INSERT INTO [Inventory] VALUES ('EST-11', 10000)
INSERT INTO [Inventory] VALUES ('EST-12', 10000)
INSERT INTO [Inventory] VALUES ('EST-13', 10000)
INSERT INTO [Inventory] VALUES ('EST-14', 10000)
INSERT INTO [Inventory] VALUES ('EST-15', 10000)
INSERT INTO [Inventory] VALUES ('EST-16', 10000)
INSERT INTO [Inventory] VALUES ('EST-17', 10000)
INSERT INTO [Inventory] VALUES ('EST-18', 10000)
INSERT INTO [Inventory] VALUES ('EST-19', 10000)
INSERT INTO [Inventory] VALUES ('EST-20', 10000)
INSERT INTO [Inventory] VALUES ('EST-21', 10000)
INSERT INTO [Inventory] VALUES ('EST-22', 10000)
INSERT INTO [Inventory] VALUES ('EST-23', 10000)
INSERT INTO [Inventory] VALUES ('EST-24', 10000)
INSERT INTO [Inventory] VALUES ('EST-25', 10000)
INSERT INTO [Inventory] VALUES ('EST-26', 10000)
INSERT INTO [Inventory] VALUES ('EST-27', 10000)
INSERT INTO [Inventory] VALUES ('EST-28', 10000)