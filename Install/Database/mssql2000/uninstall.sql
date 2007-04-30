DELETE FROM cuyahoga_version WHERE assembly = 'Cuyahoga.Modules.Shop'
go
 
DELETE FROM cuyahoga_modulesetting
WHERE moduletypeid = (SELECT moduletypeid FROM cuyahoga_moduletype WHERE assemblyname = 'Cuyahoga.Modules.Shop')
go
 
DELETE FROM cuyahoga_moduletype
WHERE assemblyname = 'Cuyahoga.Modules.Shop'
go

DROP TABLE cm_shop
go

DROP TABLE cm_shopproduct
go

DROP TABLE cm_shopcomment
go

DROP TABLE cm_shopcategory
go

DROP TABLE cm_shopemoticon
go

DROP TABLE cm_shoptag
go

DROP TABLE cm_shopimage
go

DROP TABLE cm_shoptransaction
go

DROP TABLE cm_shoptransactionproduct
go

DROP TABLE cm_shopuseraddress
go
