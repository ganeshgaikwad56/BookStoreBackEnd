using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [ApiController]  // Handle the Client error, Bind the Incoming data with parameters using more attribute
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cartBL;

        public CartController(ICartBL cartBL)
        {
            this.cartBL = cartBL;
        }
        [HttpPost("AddCart/{userId}")]
        public IActionResult AddCart(CartModel cart,int userId)
        {
            try
            {
               
                var cartData = this.cartBL.AddCart(cart, userId);
                if (cartData != null)
                {
                    return this.Ok(new { success = true, message = "Book Added SuccessFully in Cart ", response = cartData });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Cart Add Unsuccessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, response = ex.Message });
            }
        }
        [HttpDelete("DeleteBook/{CartId}")]
        public IActionResult RemoveFromCart(int CartId)
        {
            try
            {
                var result = this.cartBL.RemoveFromCart(CartId);
                if (result != null)
                {
                    return this.Ok(new { status = true, message = $"Delete cart Successful", Data = result });

                }
                return this.BadRequest(new { status = true, message = $" cart delete Failed", Data = result });

            }
            catch
            {

                throw;
            }
        
            
        }

    }
}
