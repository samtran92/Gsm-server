create database QuanlyAccountClientGSM
go

use QuanlyAccountClientGSM
go 

create table Account
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	UserName NVARCHAR(100),	
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Admin',
	PassWord NVARCHAR(max) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0 -- 1: admin && 0: staff
)
go

create table SMS
(
	Id INT NOT NULL PRIMARY KEY identity,
	SMS nvarchar(max) default N'Theo thông tin lũ khẩn cấp của Đài khí tượng thủy văn tỉnh Quảng Ngãi cho biết vào lúc 16h ngày 28/10, mực nước trên các con sông Trà Bồng tại trạm Châu Ổ vượt trên báo động 2; nước sông Vệ và sông Trà Câu trên báo động 3; sông Trà Khúc ở dưới mức báo động 3 ở trạm Sơn Giang;',
	foreign key (Id) references dbo.Account(Id)
)
GO

CREATE  TABLE SMSINFO
(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	Infordatetime DATE,
	FOREIGN key (Id) references dbo.SMS(Id)
)
GO







INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'Admin' , -- UserName - nvarchar(100)
          N'Thangdoan' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          1  -- Type - int
        )
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'staff' , -- UserName - nvarchar(100)
          N'staff' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
GO

--Tạo process Get Account By UserName
CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'Admin' -- nvarchar(100)

GO

--Tạo process login
CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO


INSERT dbo.SMS
(
    SMS
)
VALUES 
(
	N'Theo thông tin lũ khẩn cấp của Đài khí tượng thủy văn tỉnh Quảng Ngãi cho biết vào lúc 16h ngày 28/10, mực nước trên các con sông Trà Bồng tại trạm Châu Ổ vượt trên báo động 2; nước sông Vệ và sông Trà Câu trên báo động 3; sông Trà Khúc ở dưới mức báo động 3 ở trạm Sơn Giang;'
)
GO 

CREATE PROC USP_GetSMSList
AS SELECT *FROM dbo.SMS
GO

EXEC dbo.USP_GetSMSList


--Insert SMSInfo
INSERT INTO dbo.SMSINFO
(
    Infordatetime
)
VALUES
(
	GETDATE()
)


SELECT * from dbo.SMSINFO WHERE Id = 1 AND Infordatetime = GETDATE()