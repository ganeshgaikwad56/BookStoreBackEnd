using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }


        public UserRegModel Registration(UserRegModel UserReg)
        {
            try
            {
                return this.userRL.Registration(UserReg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserLoginModel UserLogin(UserLoginModel userLog)
        {
            try
            {
                return this.userRL.UserLogin(userLog);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string ForgotPassword(string Email)
        {
            try
            {
                return this.userRL.ForgotPassword(Email);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
