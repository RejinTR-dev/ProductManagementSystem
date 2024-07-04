using Microsoft.AspNetCore.Mvc;

namespace ProductManagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View("~/Views/Login.cshtml");
        }

        [HttpPost]
        public bool LoginUser(string username, string password)
        {
            // Replace this with your actual authentication logic
            if (username == "admin" && password == "password")
            {
                // Redirect to the Index action after successful login
                return true;
            }
            else
            {
                // Show an error message
                ViewBag.ErrorMessage = "Invalid username or password";
                return false;
            }
        }

        public IActionResult AddProduct(int val)
        {
            return View("~/Views/ProductDetails.cshtml");
        }
    }
}
