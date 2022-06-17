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
    public class CartRL : ICartRL
    {
        private SqlConnection sqlConnection;
        private readonly IConfiguration configuration;
        public CartRL(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        private IConfiguration Configuration { get; }
        public CartModel AddCart(CartModel cart, int userId)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:BookStore"]);
                SqlCommand cmd = new SqlCommand("Addcart", this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@BookQuantity", cart.BookQuantity);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@BookId", cart.BookId);
                this.sqlConnection.Open();
                int i = cmd.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (i >= 1)
                {
                    return cart;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        public string RemoveFromCart(int CartId)
        {
             sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:BookStore"]);
            try
            {

                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("RemoveFromCart", sqlConnection);//strore procedure name
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != 0)
                    {
                        return "Book Removed";
                    }
                    else
                    {
                        return "Failed";
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
