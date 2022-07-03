-----create table for cart----

Create Table Cart
(
CartId int identity(1,1) primary key,
BookQuantity int default 1,
UserId int not null foreign key (UserId) references Users(UserId),
BookId int not null Foreign key (BookId) references Books(BookId)
)


select  *  From Cart

-----procedure for AddCart----
Create procedure Addcart
( @BookQuantity int,
@UserId int,
@BookId int
)
As
Begin
	insert into cart(BookQuantity,UserId, BookId)
	values ( @BookQuantity,@UserId, @BookId);
End

------procedure remove------

alter proc RemoveFromCart
(
@CartId int,
@UserId int
)
As
Begin
	delete from Cart where CartId = @CartId;
end

--------procedure for getcart by userId-----
create proc GetCartByUserId
(
	@UserId int
)
as
begin
	select CartId,BookQuantity,UserId,c.BookId,BookName,AuthorName,
	DiscountPrice,OriginalPrice,BookImage from Cart c join Books b on c.BookId=b.BookId 
	where UserId=@UserId;
end;


------Update Procedure-----

create proc UpdateCart
(
	@BookQuantity int,
	@BookId int,
	@UserId int,
	@CartId int
)
as
begin
update Cart set BookId=@BookId,
				UserId=@UserId,
				BookQuantity=@BookQuantity
				where CartId=@CartId;
end;