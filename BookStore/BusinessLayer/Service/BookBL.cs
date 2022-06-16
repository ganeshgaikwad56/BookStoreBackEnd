using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL bookRL;

        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public AddBookModel AddBook(AddBookModel book)
        {
            try
            {
                return this.bookRL.AddBook(book);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteBook(int BookId)
        {
            try
            {
                return this.bookRL.DeleteBook(BookId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AddBookModel> GetAllBooks()
        {
            try
            {
                return this.bookRL.GetAllBooks();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AddBookModel GetBookByBookId(int BookId)
        {
            try
            {
                return this.bookRL.GetBookByBookId(BookId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UpdateBookModel UpdateBook(UpdateBookModel updatebook)
        {
            try
            {
                return this.bookRL.UpdateBook(updatebook);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
