﻿using BusinessLayer.Interface;
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