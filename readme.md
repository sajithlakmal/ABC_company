CREATE TABLE [dbo].[adminUser](
       [email] [nvarchar](100) NULL,
       [password] [nvarchar](100) NULL
)

insert into adminUser(email,password) values('admin','admin123');

CREATE PROC login
@email NVARCHAR(100),
@password NVARCHAR(100),
@Isvalid BIT OUT
AS
BEGIN
SET @Isvalid = (SELECT COUNT(1) FROM adminUser WHERE email = @email AND password =@password)
end