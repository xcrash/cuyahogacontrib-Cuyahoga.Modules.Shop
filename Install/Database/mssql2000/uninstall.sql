DELETE FROM cuyahoga_version WHERE assembly = 'Cuyahoga.Modules.Shop'
go
 
DELETE FROM cuyahoga_modulesetting
WHERE moduletypeid = (SELECT moduletypeid FROM cuyahoga_moduletype WHERE assemblyname = 'Cuyahoga.Modules.Shop')
go
 
DELETE FROM cuyahoga_moduletype
WHERE assemblyname = 'Cuyahoga.Modules.Shop'
go


ALTER TABLE [cm_shop] DROP CONSTRAINT [FK_cm_shop_cm_shopcategory]
GO

DROP TABLE [cm_shop]

GO
DROP TABLE [cm_shopcategory]

GO

ALTER TABLE [cm_shopcomment] DROP CONSTRAINT [FK_cm_shopcomment_cm_shopproduct]
GO

DROP TABLE [cm_shopcomment]

GO

DROP TABLE [cm_shopemoticon]

GO
ALTER TABLE [cm_shopimage] DROP CONSTRAINT [FK_cm_shopimage_cm_shopproduct]
GO

DROP TABLE [cm_shopimage]

GO

ALTER TABLE [cm_shoporder] DROP CONSTRAINT [FK_cm_shoporder_cm_shoporderstate]
GO

ALTER TABLE [cm_shoporder] DROP CONSTRAINT [FK_cm_shoporder_cuyahoga_user]
GO

DROP TABLE [cm_shoporder]

GO

ALTER TABLE [cm_shoporderline] DROP CONSTRAINT [FK_cm_shoporderline_cm_shoporder1]
GO


ALTER TABLE [cm_shoporderline] DROP CONSTRAINT [FK_cm_shoporderline_cm_shopproduct]
GO

DROP TABLE [cm_shoporderline]

GO

DROP TABLE [cm_shoporderstate]

GO

ALTER TABLE [cm_shopproduct] DROP CONSTRAINT [FK_cm_shopproduct_cm_shop]

GO

DROP TABLE [cm_shopproduct]

GO

DROP TABLE [cm_shoptag]

GO

ALTER TABLE [cm_shopuser] DROP CONSTRAINT [FK_cm_shopuser_cuyahoga_user]

GO

DROP TABLE [cm_shopuser]

GO

ALTER TABLE [cm_shopuseraddress] DROP CONSTRAINT [FK_cm_shopuseraddress_cuyahoga_user]

GO

DROP TABLE [cm_shopuseraddress]

GO
