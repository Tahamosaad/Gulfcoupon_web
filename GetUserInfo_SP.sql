/****** Script for SelectTopNRows command from SSMS  ******/
CREATE  PROCEDURE [dbo].[GetLoginInfo]  
    @UserName VARCHAR(20),  
    @Password varchar(20)  
AS  
SET NOCOUNT ON  
Declare @Failedcount AS INT  
SET @Failedcount = (SELECT LoginFailedCount from LoginInfo WHERE UserName = @UserName)  
  
IF EXISTS(SELECT * FROM LoginInfo WHERE UserName = @UserName)  
  
 BEGIN  
  
 IF EXISTS(SELECT * FROM LoginInfo WHERE UserName = @UserName AND Password = @Password )  
    SELECT 'Success' AS UserExists  
ELSE  
  
Update LoginInfo set  LoginFailedCount = @Failedcount+1  WHERE UserName = @UserName  
  
Update LoginInfo set LastLoginDate=GETDATE()  WHERE UserName = @UserName  
 BEGIN  
IF @Failedcount >=5  
  
  
SELECT 'Maximum Attempt Reached (5 times) .Your Account is locked now.' AS UserExists  
ELSE  
  
select CONVERT(varchar(10), (SELECT LoginFailedCount from LoginInfo   WHERE UserName = @UserName))   AS UserFailedcount  
END   
END  
 ELSE  
  
 BEGIN   
  
SELECT 'User Does not Exists' AS UserExists  
 END  