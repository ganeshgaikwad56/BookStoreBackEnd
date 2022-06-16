using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRL adminRL;

        public AdminBL(IAdminRL adminRL)
        {
            this.adminRL = adminRL;
        }
        public AdminLoginModel AdminLogin(AdminLoginModel adminLogin)
        {
            try
            {
                return this.adminRL.AdminLogin(adminLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
