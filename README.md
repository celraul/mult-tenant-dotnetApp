# mult-tenant-dotnetApp
An application to test some concepts of mult tenant app using EF Core


# Run docker compose in the root folder
```
docker-compose up -d
```
# create table 
```SQL
CREATE TABLE Product
(
    Id INT IDENTITY(1,1) PRIMARY KEY,         
    Name NVARCHAR(100) NOT NULL,              
    CostPrice DECIMAL(18, 2) NOT NULL,        
    Price DECIMAL(18, 2) NOT NULL,            
    Description NVARCHAR(MAX),                 
    IsDeleted BIT NOT NULL DEFAULT 0,       
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(), 
    UpdatedDate DATETIME NULL               
);
````
```SQL
INSERT INTO [dbo].[Product]
           ([Name]
           ,[CostPrice]
           ,[Price]
           ,[Description]
           ,[IsDeleted]
           ,[CreatedDate]
           ,[UpdatedDate])
     VALUES
           ('Product tenant one - ABC'
           ,10
           ,20
           ,'Description'
           ,0
           ,SYSDATETIME()
           ,SYSDATETIME())
GO
```

