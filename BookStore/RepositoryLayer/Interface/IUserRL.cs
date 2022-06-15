using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserRegModel Registration(UserRegModel UserReg);
        public UserLoginModel UserLogin(UserLoginModel userLog);
        public string ForgotPassword(string Email);
        public bool ResetPassword(string email, string newPassword, string confirmPassword);
    }
}
