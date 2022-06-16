using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore.Controllers
{
    [ApiController]  // Handle the Client error, Bind the Incoming data with parameters using more attribute
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookBL bookBL;

        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(AddBookModel book)
        {
            try
            {
                AddBookModel userData = this.bookBL.AddBook(book);
                if (userData != null)
                {
                    return this.Ok(new { Success = true, message = "Book Added Sucessfully", Response = userData });
                }
                return this.Ok(new { Success = true, message = "Sorry! Book Already Exists" });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
    }
}
