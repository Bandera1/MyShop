using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FirstASP.NETapplication.Data.EFContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop_MVC.Data.Interfaces;
using Shop_MVC.Data.Models;
using Shop_MVC.Models;
using Shop_MVC.ViewModels.Account;

namespace Shop_MVC.Controllers
{
    //[Authorize(Roles = "User")]
    public class AccountController : Controller
    {
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly RoleManager<DbRole> _roleManager;
        private readonly EFDbContext _context;
        private readonly IUser _user;


        public AccountController(UserManager<DbUser> userManager, SignInManager<DbUser> signInManager,
            RoleManager<DbRole> roleManager, EFDbContext context, IUser user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _user = user;
        }


        //**********************Register***********************

        [HttpGet]
        public IActionResult Register()
        {        
            if (HttpContext.Session.GetString("UserInfo") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //if (!(await _roleManager.RoleExistsAsync("User")))
            //{
            //    var result = await _roleManager.CreateAsync(new DbRole() { Name = "User" });
            //}

            var roleName = "User";

            if (ModelState.IsValid)
            {               
                if(CheckNickName(model.Name) != null)
                {
                    ModelState.AddModelError("Name", CheckNickName(model.Name));
                    return View(model);
                }
                if(CheckEmailToExist(model.Email) != null)
                {
                    ModelState.AddModelError("Email", CheckEmailToExist(model.Email));
                    return View(model);
                }
                if(CheckPassword(model.Password) != null)
                {
                    ModelState.AddModelError("Password", CheckPassword(model.Password));
                    return View(model);
                }
                if (CheckConfirmPassword(model.Password,model.PasswordConfirm) != null)
                {
                    ModelState.AddModelError("PasswordConfirm", CheckConfirmPassword(model.Password, model.PasswordConfirm));
                    return View(model);
                }



                UserProfile userProfile = new UserProfile()
                {                   
                    RegistrationDate = DateTime.Now
                };
                DbUser dbUser = new DbUser()
                {
                    Email = model.Email,
                    UserName = model.Name,                  
                    UserProfile = userProfile
                };


                // Add DbUser to Database
                var result = await _userManager.CreateAsync(dbUser, model.Password);
                result = _userManager.AddToRoleAsync(dbUser, roleName).Result;


                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(dbUser, false);
                    // Set session5
                    dbUser = _user.GetUsers(null, x => x.Id, -1).FirstOrDefault(x => x.Email == model.Email);
                    var userInfo = new UserInfo()
                    {
                        UserId = dbUser.Id,
                    };
                    HttpContext.Session.SetString("UserInfo", JsonConvert.SerializeObject(userInfo));
                    

                    return RedirectToAction("Index", "Home");
                }               
            }

            

            return View(model);
        }



        private string CheckNickName(string nickName)
        {
            var containtBetween3And15 = new Regex(@"[A-Za-z0-9._()\[\]-]{3,15}$");

            if (!containtBetween3And15.IsMatch(nickName))
            {
                return "Name must be more then 3 and less then 15";
            }


            return null;
        }

        private string CheckEmailToExist(string email)
        {
            var users = _user.GetUsers(null, x => x.Id, -1);

            var res = users.FirstOrDefault(x => x.Email == email);

            if(res != null)
            {
                return "User alredy exist";
            }

            return null;
        }

        private string CheckPassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,16}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasNumber.IsMatch(password))
            {
                return "Password must contain numbers";
            }
            if (!hasUpperChar.IsMatch(password))
            {
                return "Password must contain upper symbols";
            }
            if (!hasMiniMaxChars.IsMatch(password))
            {
                return "Password must contain more 6 and less 15 symbols";
            }
            if (!hasLowerChar.IsMatch(password))
            {
                return "Password must contain lower symbols";
            }
            //if (!hasSymbols.IsMatch(password))
            //{
            //    return "Password must contain symbols";
            //}

            return null;
        }

        private string CheckConfirmPassword(string password,string confirmPassword)
        {
            if(password != confirmPassword)
            {
                return "Password doesn`t confirm";
            }

            return null;
        }


        //*********************Login************************


        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserInfo") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Get user from Db by email
            var user = _user.GetUsers(null, x => x.Id,-1).FirstOrDefault(x => x.Email == model.Email);
            // If user not found
            if(user == null)
            {
                ModelState.AddModelError("Email", "User not exist");
                return View(model);
            }

            // Check enter password
            var result = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;
            // If password doesn`t correct
            if (!result.Succeeded)
            {
                ModelState.AddModelError("Password", "Password not correct");
                return View(model);
            }

            // Sign in
            await _signInManager.SignInAsync(user, isPersistent: false);
            // Coockie
            await Authenticate(model.Email);

            // Add session
            var userInfo = new UserInfo()
            {
                UserId = user.Id         
            };
            HttpContext.Session.SetString("UserInfo", JsonConvert.SerializeObject(userInfo));

            return RedirectToAction("Index", "Home");
        }


        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserInfo");

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}