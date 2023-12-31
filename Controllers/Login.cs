using Microsoft.AspNetCore.Mvc;

namespace MyMvcApiProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Login/Authenticate
        [HttpPost]
        public IActionResult Authenticate(string username, string password)
        {
            // Implement your authentication logic here
            // For simplicity, let's assume authentication is successful

            // You might want to replace this with actual user authentication logic
            if (username == "demo" && password == "password")
            {
                // Redirect to a dashboard or some other page on successful login
                return RedirectToAction("Dashboard");
            }
            else
            {
                // Redirect back to the login page with an error message
                ViewBag.ErrorMessage = "Invalid username or password";
                return View("Index");
            }
        }

        // GET: /Login/Dashboard
        public IActionResult Dashboard()
        {
            // This is just a placeholder for the dashboard page
            return View();
        }
    }
}
