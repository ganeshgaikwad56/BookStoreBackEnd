using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [ApiController]  // Handle the Client error, Bind the Incoming data with parameters using more attribute
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminBL adminBL;

        public AdminController(IAdminBL adminBL)
        {
            this.adminBL = adminBL;
        }

        [HttpPost("AdminLogin")]
        public IActionResult AdminLogin(AdminLoginModel adminLogin)
        {
            try
            {
                var result = this.adminBL.AdminLogin(adminLogin);
                if (result != null)
                    return this.Ok(new { success = true, message = "Admin Login Successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Sorry!Admin Login Failed", data = result });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
