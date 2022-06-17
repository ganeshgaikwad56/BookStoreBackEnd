using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Service
{
    public class AdminRL : IAdminRL

    {
        private SqlConnection sqlConnection;
        private readonly IConfiguration configuration;
        public AdminRL(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        private IConfiguration Configuration { get; }
        public AdminLoginModel AdminLogin(AdminLoginModel adminLogin)
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.configuration["ConnectionStrings:BookStore"]);
                SqlCommand cmd = new SqlCommand("AdminLogin", this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Email", adminLogin.Email);
                cmd.Parameters.AddWithValue("@Password", adminLogin.Password);

                this.sqlConnection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                //ExecuteReader method is used to execute a SQL Command or storedprocedure returns a set of rows from the database.

                if (reader.HasRows)//HasRows:-Search there is any row or not
                {
                    int AdminId = 0;
                    AdminLoginModel admin = new AdminLoginModel();
                    while (reader.Read()) //using while loop for read multiple rows.
                    {
                        admin.Email = Convert.ToString(reader["Email"]);
                        admin.Password = Convert.ToString(reader["Password"]);
                        AdminId = Convert.ToInt32(reader["AdminId"]);


                    }

                    this.sqlConnection.Close();
                    admin.Token = this.GenerateJWTTokenForAdmin(admin.Email, AdminId);
                    return admin;
                }
                else
                {
                    this.sqlConnection.Close();
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
        private string GenerateJWTTokenForAdmin(string Email, int AdminId)
        {
            //generate token

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", Email),
                    new Claim("AdminId",AdminId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(24),

                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
