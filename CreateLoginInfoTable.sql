SET QUOTED_IDENTIFIER ON  
GO  
  
CREATE TABLE [dbo].[LoginInfo](  
    [CustomerId] [int] NOT NULL,  
    [UserName] [nvarchar](20) NULL,  
    [Password] [nvarchar](20) NULL,  
    [LastLoginDate] [datetime] NULL,  
    [LoginFailedCount] [int] NULL,  
    [LoginIPAddress] [nvarchar](20) NULL,  
    [CustomerTimeZone] [nvarchar](20) NULL,  
    [LastAccessedDate] [datetime] NULL,  
    [AccountLocked] [bit] NULL,  
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED   
([CustomerId] ASC )WITH 
(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
ON [PRIMARY]) ON [PRIMARY]  
  
GO  