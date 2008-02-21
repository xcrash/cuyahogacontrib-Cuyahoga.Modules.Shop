CREATE TABLE cm_shop(
	shopid int IDENTITY(1,1) NOT NULL,
	updatetimestamp datetime NULL,
	inserttimestamp datetime NULL,
	categoryid int NULL,
	name nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	description nchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	sortorder int NULL,
	lastpublished datetime NULL,
	lastproductid int NULL,
	numproducts int NULL,
	numcomments int NULL,
	allowguestpublish int NULL,
	lastpublishusername nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT PK_shop PRIMARY KEY CLUSTERED 
(
	shopid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

go


CREATE TABLE cm_shopcategory(
	categoryid int IDENTITY(1,1) NOT NULL,
	siteid int NULL,
	updatetimestamp datetime NULL,
	inserttimestamp datetime NULL,
	name nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	sortorder int NULL,
 CONSTRAINT PK_shopcategory PRIMARY KEY CLUSTERED 
(
	categoryid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

go

CREATE TABLE cm_shopcomment(
	commentid int IDENTITY(1,1) NOT NULL,
	productid int NULL,
	updatetimestamp datetime NULL,
	inserttimestamp datetime NULL,
	title nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	userid int NULL,
	username nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	ip nvarchar(15) COLLATE Chinese_PRC_CI_AS NULL,
	message ntext COLLATE Chinese_PRC_CI_AS NULL,
	views int NULL,
	rating int NULL,
 CONSTRAINT PK_shopcomment PRIMARY KEY CLUSTERED 
(
	commentid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE TABLE cm_shopemoticon(
	emoticonid int IDENTITY(1,1) NOT NULL,
	textversion nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	imagename nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	updatetimestamp datetime NULL,
	inserttimestamp datetime NULL,
 CONSTRAINT PK_shopemoticon PRIMARY KEY CLUSTERED 
(
	emoticonid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE cm_shopimage(
	imageid int IDENTITY(1,1) NOT NULL,
	updatetimestamp datetime NULL,
	inserttimestamp datetime NULL,
	origimagename nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	shopimagename nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	imagesize int NULL,
	dlcount int NULL,
	contenttype nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	productid int NOT NULL,
 CONSTRAINT PK_cm_shopimage PRIMARY KEY CLUSTERED 
(
	imageid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE cm_shoporder(
	shoporderid int IDENTITY(1,1) NOT NULL,
	updatetimestamp datetime NULL,
	inserttimestamp datetime NULL,
	userid int NULL,
	orderstateid int NULL,
 CONSTRAINT PK_cm_shoptransaction PRIMARY KEY CLUSTERED 
(
	shoporderid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE cm_shoporderline(
	shoporderlineid int IDENTITY(1,1) NOT NULL,
	productid int NOT NULL,
	quantity int NULL,
	shoporderid int NOT NULL,
 CONSTRAINT PK_cm_shoporderline PRIMARY KEY CLUSTERED 
(
	shoporderlineid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE cm_shoporderstate(
	orderstateid int IDENTITY(1,1) NOT NULL,
	name nvarchar(50) COLLATE Chinese_PRC_CI_AS NOT NULL,
 CONSTRAINT PK_cm_shoporderstate PRIMARY KEY CLUSTERED 
(
	orderstateid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE cm_shopproduct(
	productid int IDENTITY(1,1) NOT NULL,
	shopid int NULL,
	updatetimestamp datetime NULL,
	inserttimestamp datetime NULL,
	title nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	userid int NULL,
	username nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	ip nvarchar(15) COLLATE Chinese_PRC_CI_AS NULL,
	message ntext COLLATE Chinese_PRC_CI_AS NULL,
	views int NULL,
	comments int NULL,
	price decimal(18, 2) NULL,
 CONSTRAINT PK_shopproduct PRIMARY KEY CLUSTERED 
(
	productid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE cm_shoptag(
	tagid int IDENTITY(1,1) NOT NULL,
	shopcodestart nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	shopcodeend nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	htmlcodestart nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	htmlcodeend nvarchar(50) COLLATE Chinese_PRC_CI_AS NULL,
	updatetimestamp datetime NULL,
	inserttimestamp datetime NULL,
 CONSTRAINT PK_shoptag PRIMARY KEY CLUSTERED 
(
	tagid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE cm_shopuseraddress(
	addressid int IDENTITY(1,1) NOT NULL,
	address1 nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	address2 nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	zip nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	region nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	city nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	country nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	telephone1 nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	telephone2 nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	mobile nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	firstname nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,
	lastname nvarchar(254) COLLATE Chinese_PRC_CI_AS NULL,	
	[userid] [int] NULL,
	delivery int NULL,
 CONSTRAINT PK_cm_address PRIMARY KEY CLUSTERED 
(
	addressid ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

/*
 *  Foreign Keys
 */

ALTER TABLE cm_shop WITH NOCHECK ADD  CONSTRAINT FK_cm_shop_cm_shopcategory FOREIGN KEY(categoryid)
REFERENCES cm_shopcategory (categoryid)
GO

ALTER TABLE cm_shopcomment  WITH NOCHECK ADD  CONSTRAINT FK_cm_shopcomment_cm_shopproduct FOREIGN KEY(productid)
REFERENCES cm_shopproduct (productid)
GO

ALTER TABLE cm_shopimage  WITH NOCHECK ADD  CONSTRAINT FK_cm_shopimage_cm_shopproduct FOREIGN KEY(productid)
REFERENCES cm_shopproduct (productid)
GO

ALTER TABLE cm_shoporder  WITH NOCHECK ADD  CONSTRAINT FK_cm_shoporder_cm_shoporderstate FOREIGN KEY(orderstateid)
REFERENCES cm_shoporderstate (orderstateid)
GO
ALTER TABLE cm_shoporder NOCHECK CONSTRAINT FK_cm_shoporder_cm_shoporderstate
GO
ALTER TABLE cm_shoporder  WITH NOCHECK ADD  CONSTRAINT FK_cm_shoporder_cuyahoga_user FOREIGN KEY(userid)
REFERENCES cuyahoga_user (userid)
GO

ALTER TABLE cm_shoporderline  WITH NOCHECK ADD  CONSTRAINT FK_cm_shoporderline_cm_shoporder1 FOREIGN KEY(shoporderid)
REFERENCES cm_shoporder (shoporderid)
GO
ALTER TABLE cm_shoporderline NOCHECK CONSTRAINT FK_cm_shoporderline_cm_shoporder1
GO
ALTER TABLE cm_shoporderline  WITH NOCHECK ADD  CONSTRAINT FK_cm_shoporderline_cm_shopproduct FOREIGN KEY(productid)
REFERENCES cm_shopproduct (productid)
GO
ALTER TABLE cm_shopproduct  WITH NOCHECK ADD  CONSTRAINT FK_cm_shopproduct_cm_shop FOREIGN KEY(shopid)
REFERENCES cm_shop (shopid)
GO
GO
ALTER TABLE [cm_shopuseraddress]  WITH NOCHECK ADD  CONSTRAINT [FK_cm_shopuseraddress_cuyahoga_user] FOREIGN KEY([userid])
REFERENCES [cuyahoga_user] ([userid])
GO
ALTER TABLE [cm_shopuseraddress] NOCHECK CONSTRAINT [FK_cm_shopuseraddress_cuyahoga_user]

ALTER TABLE cm_shopproduct NOCHECK CONSTRAINT FK_cm_shopproduct_cm_shop

ALTER TABLE cm_shoporderline NOCHECK CONSTRAINT FK_cm_shoporderline_cm_shopproduct

ALTER TABLE cm_shoporder NOCHECK CONSTRAINT FK_cm_shoporder_cuyahoga_user

ALTER TABLE cm_shopimage NOCHECK CONSTRAINT FK_cm_shopimage_cm_shopproduct

ALTER TABLE cm_shopcomment NOCHECK CONSTRAINT FK_cm_shopcomment_cm_shopproduct

ALTER TABLE cm_shop NOCHECK CONSTRAINT FK_cm_shop_cm_shopcategory

GO


/*
 *  Table data
 */

DECLARE @moduletypeid int

INSERT INTO cuyahoga_moduletype (name, assemblyname, classname, path, editpath, inserttimestamp, updatetimestamp) VALUES ('Shop', 'Cuyahoga.Modules.Shop', 'Cuyahoga.Modules.Shop.ShopModule', 'Modules/Shop/UserShop.ascx', 'Modules/Shop/AdminShop.aspx', '2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')

SELECT @moduletypeid = Scope_Identity()

INSERT INTO cuyahoga_version (assembly, major, minor, patch) VALUES ('Cuyahoga.Modules.Shop', 1, 5, 0)
go
INSERT INTO cuyahoga_modulesetting (moduletypeid, name, friendlyname, settingdatatype, iscustomtype, isrequired) VALUES (@moduletypeid, 'ALLOW_COMMENTS', 'Allow comments', 'System.Boolean', 0, 1)
go
INSERT INTO cuyahoga_modulesetting (moduletypeid, name, friendlyname, settingdatatype, iscustomtype, isrequired) VALUES (@moduletypeid, 'IMAGE_WIDTH', 'Image width', 'System.Int32', 0, 1)
go
INSERT INTO cuyahoga_modulesetting (moduletypeid, name, friendlyname, settingdatatype, iscustomtype, isrequired) VALUES (@moduletypeid, 'THUMB_WIDTH', 'Thumb width', 'System.Int32', 0, 1)
go

INSERT INTO cm_shopemoticon (textversion, imagename,  inserttimestamp, updatetimestamp) VALUES ('8)', 'cool.gif', '2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go
INSERT INTO cm_shopemoticon (textversion, imagename,  inserttimestamp, updatetimestamp) VALUES (':(', 'angry.gif', '2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go
INSERT INTO cm_shopemoticon (textversion, imagename,  inserttimestamp, updatetimestamp) VALUES (':)', 'happy.gif', '2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go
INSERT INTO cm_shopemoticon (textversion, imagename,  inserttimestamp, updatetimestamp) VALUES (';)', 'wink.gif', '2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go
INSERT INTO cm_shoptag (shopcodestart, shopcodeend,  htmlcodestart, htmlcodeend, inserttimestamp, updatetimestamp) VALUES ('[i]', '[/i]', '<em>', '</em>','2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go
INSERT INTO cm_shoptag (shopcodestart, shopcodeend,  htmlcodestart, htmlcodeend, inserttimestamp, updatetimestamp) VALUES ('[b]', '[/b]', '<strong>', '</strong>','2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go
INSERT INTO cm_shoptag (shopcodestart, shopcodeend,  htmlcodestart, htmlcodeend, inserttimestamp, updatetimestamp) VALUES ('[code]', '[/code]', '<code>', '</code>','2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go
INSERT INTO cm_shoptag (shopcodestart, shopcodeend,  htmlcodestart, htmlcodeend, inserttimestamp, updatetimestamp) VALUES ('[pre]', '[/pre]', '<pre>', '</pre>','2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go
INSERT INTO cm_shoptag (shopcodestart, shopcodeend,  htmlcodestart, htmlcodeend, inserttimestamp, updatetimestamp) VALUES ('[li]', '[/li]', '<li>', '</li>','2005-02-11 14:36:28.324', '2004-02-11 14:36:28.324')
go

INSERT INTO cm_shoporderstate(name) VALUES ('Open');
go
INSERT INTO cm_shoporderstate(name) VALUES ('Completed');
go
INSERT INTO cm_shoporderstate(name) VALUES ('Cancelled');
go
INSERT INTO cm_shoporderstate(name) VALUES ('Modified');
go
INSERT INTO cm_shoporderstate(name) VALUES ('Payed');
go
INSERT INTO cm_shoporderstate(name) VALUES ('Delivered');
go
INSERT INTO cm_shoporderstate(name) VALUES ('Suspended');
go
