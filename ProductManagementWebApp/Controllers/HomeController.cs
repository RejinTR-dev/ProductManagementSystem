using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }

        [HttpPost]
        public IActionResult LoginUser(string username, string password)
        {
            // Replace this with your actual authentication logic
            if (username == "admin" && password == "password")
            {
                // Redirect to the Index action after successful login
               
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] 
                    {
                      new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(new { Token = tokenString });
            }
            else
            {
                // Show an error message
                ViewBag.ErrorMessage = "Invalid username or password";
                return Unauthorized(new { Message = "Invalid username or password" });
            }
        }

        //[Authorize]
        public IActionResult AddProduct(int val)
        {
            return View("~/Views/ProductDetails.cshtml");
        }
    }
}
