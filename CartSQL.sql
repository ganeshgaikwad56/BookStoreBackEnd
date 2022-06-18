create database BookStore;

Create table Users
( UserId int identity(1,1) Primary key,
FullName Varchar(225) not null,
Email Varchar(225) not null unique,
Password varchar(225) not null,
MobileNumber bigint not null
)

select *from Users

Create procedure SPUserRegister
(
@FullName varchar(255),
@Email varchar(255),
@Password Varchar(255),
@MobileNumber Bigint
)
as
Begin
		insert Users
		values (@FullName, @Email, @Password, @MobileNumber) 
end

create procedure spUserLogin
(
@Email varchar(255),
@Password varchar(255)
)
as
begin
select * from Users
where Email = @Email and Password = @Password
End;

create procedure spUserForgotPassword
(
@Email varchar(Max)
)
as
begin
Update Users
set Password = 'Null'
where Email = @Email;
select * from Users where Email = @Email;
End;


create procedure spUserResetPassword
(
@Email varchar(250),
@Password varchar(250)
)
AS
BEGIN
UPDATE Users 
SET 
Password = @Password 
WHERE Email = @Email;
End;


create Table AdminTable
(
AdminId int primary key identity(1,1),
FullName varchar(255),
Email varchar(255),
Password varchar(255),
PhoneNumber Bigint
);

Insert into AdminTable values('Admin', 'ganeshgaikwad4041@gmail.com', 'Ganesh@1234', '8698669929');
select * from AdminTable

Alter procedure AdminLogin
(
@Email varchar(255),
@Password varchar(255)
)
as
BEGIN
If(Exists(select * from AdminTable where Email = @Email and Password = @Password))
Begin
select AdminId, FullName,Password, Email, PhoneNumber from AdminTable;
end
Else
Begin
select 2;
End
END;


