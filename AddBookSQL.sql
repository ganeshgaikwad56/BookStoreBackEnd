---Create Book Table----
create table Books(
BookId int identity (1,1)primary key,
BookName varchar(255),
AuthorName varchar(255),
Rating int,
TotalView int,
OriginalPrice decimal,
DiscountPrice decimal,
BookDetails varchar(255),
BookImage varchar(255),
);


select *from Books
----Add Procedure  for AddBook----
create procedure AddBook
(
@BookName varchar(255),
@authorName varchar(255),
@rating int,
@totalView int,
@originalPrice Decimal,
@discountPrice Decimal,
@BookDetails varchar(255),
@bookImage varchar(255)
)
as
BEGIN
Insert into Books(BookName, authorName, rating, totalview, originalPrice, 
discountPrice, BookDetails, bookImage)
values (@BookName, @authorName, @rating, @totalView ,@originalPrice, @discountPrice,
@BookDetails, @bookImage);
End;

----Store procedure for update book--

create procedure UpdateBook
(
@BookId int,
@BookName varchar(255),
@authorName varchar(255),
@rating int,
@totalView int,
@originalPrice Decimal,
@discountPrice Decimal,
@BookDetails varchar(255),
@bookImage varchar(255)
)
as
BEGIN
Update Books set BookName = @BookName, 
authorName = @authorName,
rating = @rating,
totalView =@totalView,
originalPrice= @originalPrice,
discountPrice = @discountPrice,
BookDetails = @BookDetails,
bookImage =@bookImage
where BookId = @BookId;
End;

-------Procedure for delete----
create procedure DeleteBook
(
@BookId int
)
as
BEGIN
Delete Books 
where BookId = @BookId;
End;

----procedure for get book by id-----

create procedure GetBookByBookId
(
@BookId int
)
as
BEGIN
select * from Books
where BookId = @BookId;
End;

----Procedure for getAllBook----

create procedure GetAllBook
as
BEGIN
	select * from Books;
End;