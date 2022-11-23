using DataAccessLib.Data;
using DataAccessLib.Models;
using Microsoft.AspNetCore.Mvc;
using PesonalPhotos.Models;

namespace PesonalPhotos.Controllers
{
    public class LoginsController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserData _userData;

        public LoginsController (IUserData userData, HttpContextAccessor contextAccessor)
        {
            _userData = userData;
            _contextAccessor = contextAccessor;
        }
        public IActionResult Index(string returnUrl = null) 
        {
            var model= new LoginModel { ReturnUrl = returnUrl };
            return View("Login", model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid login details");
                return View("Login",model);
            }
            var user = await _userData.GetUser(model.Email);
            if (user != null)
            {
                if (user.Password == model.Password)
                {
                    _contextAccessor.HttpContext.Session.SetString("User", model.Email);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Password");
                    return View("Login", model);
                }
            }
            else
            {
                ModelState.AddModelError("", "User was not found");
                return View("Login", model);
            }

            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return RedirectToAction("Display", "Photos");
            }
        }
    
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid user details");
                return View(model);
            }

            var existingUSer = await _userData.GetUser(model.Email);
            if (existingUSer != null)
            {
                ModelState.AddModelError("", "This email adress is already registered");
                return View(model);
            }

            await _userData.InsertUser(new UsersModel { Email=model.Email, Password=model.Password});
            return RedirectToAction("Index", "Logins");
        }
    }
}
