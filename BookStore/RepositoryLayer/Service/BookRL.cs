using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class BookRL : IBookRL
    {
        private SqlConnection sqlConnection;
        private readonly IConfiguration configuration;
        public BookRL(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        private IConfiguration Configuration { get; }
        
        public AddBookModel AddBook(AddBookModel book)
        {
            sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:BookStore"]);
            try
            {

                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("AddBook", sqlConnection);//strore procedure name
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", book.BookName);
                    cmd.Parameters.AddWithValue("@authorName", book.AuthorName);
                    cmd.Parameters.AddWithValue("@rating", book.Rating);
                    cmd.Parameters.AddWithValue("@totalView", book.TotalView);
                    cmd.Parameters.AddWithValue("@originalPrice", book.OriginalPrice);
                    cmd.Parameters.AddWithValue("@discountPrice", book.DiscountPrice);
                    cmd.Parameters.AddWithValue("@BookDetails", book.BookDetails);
                    cmd.Parameters.AddWithValue("@bookImage", book.BookImage);
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
                    //ExecuteNonQuery method is used to execute SQL Command or the storeprocedure performs, INSERT, UPDATE or Delete operations.
                    //It doesn't return any data from the database.
                    //Instead, it returns an integer specifying the number of rows inserted, updated or deleted.
                    sqlConnection.Close();
                    if (result != 0)
                    {
                        return book;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
