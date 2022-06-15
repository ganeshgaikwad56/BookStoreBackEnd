using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [ApiController]  // Handle the Client error, Bind the Incoming data with parameters using more attribute
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }

        [HttpPost("register")]
        public IActionResult Registration(UserRegModel UserReg)
        {
            try
            {
                UserRegModel userData = this.userBL.Registration(UserReg);
                if (userData != null)
                {
                    return this.Ok(new { Success = true, message = "User Added Sucessfully", Response = userData });
                }
                return this.Ok(new { Success = true, message = "Sorry! User Already Exists" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
        [HttpPost("login")]
        public IActionResult UserLogin(UserLoginModel userLog)
        {
            try
            {
                var result = this.userBL.UserLogin(userLog);
                if (result != null)
                    return this.Ok(new { success = true, message = "Login Successful", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Sorry! Login Failed", data = result });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("login/{Email}")]
        public IActionResult ForgotPassword(string Email)
        {
            try
            {
                var result = this.userBL.ForgotPassword(Email);
                if (result != null)
                    return this.Ok(new { success = true, message = "Mail Send Successfully", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Sorry! Sending Failed", data = result });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
