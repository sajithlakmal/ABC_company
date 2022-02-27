CREATE TABLE [dbo].[tbl_login](
       [Admin_id] [nvarchar](100) NULL,
       [Ad_Password] [nvarchar](100) NULL
)

insert into tbl_login(Admin_id,Ad_Password) values('admin','admin123');

CREATE PROC Sp_Login
@Admin_id NVARCHAR(100),
@Password NVARCHAR(100),
@Isvalid BIT OUT
AS
BEGIN
SET @Isvalid = (SELECT COUNT(1) FROM tbl_login WHERE Admin_id = @Admin_id AND Ad_Password=@Password)
end