using JwtAuthDemo.Models;
using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace JwtAuthDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly Appdatacontext _context;
        private readonly JwtService _jwtService;

        public AccountController(Appdatacontext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [HttpPost]
public async Task<IActionResult> Register([FromBody] RegisterModel model)
{
    if (model == null)
        return Json(new { success = false, message = "Invalid data provided." });

    var userExists = await _context.Users.AnyAsync(u => u.Username == model.Username);
    if (userExists)
        return Json(new { success = false, message = "Username already exists. Choose a different one." });

    var user = new User
    {
        Username = model.Username,
        PasswordHash = HashPassword(model.Password),
        FirstName = model.FirstName,
        LastName = model.LastName,
        Address = model.Address,
        Phone = model.Phone
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return Json(new { success = true });
}


        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
public async Task<IActionResult> Login(string username, string password, bool rememberMe)
{
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    
    if (user == null || user.PasswordHash != HashPassword(password))
    {
        return Json(new { success = false, message = "Wrong Username or Password" });
    }

    var token = _jwtService.GenerateToken(user.Username);

    HttpContext.Session.SetString("AuthToken", token);
    HttpContext.Session.SetString("Username", user.Username);

    if (rememberMe)
    {
        HttpContext.Session.SetInt32("RememberMe", 1);
        HttpContext.Session.SetString("SessionTimeout", "7Days");
    }
    else
    {
        HttpContext.Session.SetInt32("RememberMe", 0);
        HttpContext.Session.SetString("SessionTimeout", "30Minutes");
    }

    return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
}


        public IActionResult Profile()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("Username"));
            if (user != null)
            {
                HttpContext.Session.SetString("FirstName", user.FirstName);
                HttpContext.Session.SetString("LastName", user.LastName);
                HttpContext.Session.SetString("Address", user.Address);
                HttpContext.Session.SetString("Phone", user.Phone);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileUpdateModel model)
        {
            if (model == null)
                return Json(new { success = false, message = "Invalid data." });

            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
                return Json(new { success = false, message = "User not authenticated." });

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return Json(new { success = false, message = "User not found." });

            // Update user data in database
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;
            user.Phone = model.Phone;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            // Update session data
            HttpContext.Session.SetString("FirstName", model.FirstName);
            HttpContext.Session.SetString("LastName", model.LastName);
            HttpContext.Session.SetString("Address", model.Address);
            HttpContext.Session.SetString("Phone", model.Phone);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }

    public class ProfileUpdateModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
    }
}
