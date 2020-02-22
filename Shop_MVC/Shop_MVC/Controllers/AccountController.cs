using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FirstASP.NETapplication.Data.EFContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop_MVC.Data.Interfaces;
using Shop_MVC.Data.Models;
using Shop_MVC.ViewModels.Account;

namespace Shop_MVC.Controllers
{
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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

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


                var result = await _userManager.CreateAsync(dbUser, model.Password);
                result = _userManager.AddToRoleAsync(dbUser, roleName).Result;


                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(dbUser, false);
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            return View(model);
        }
    }
}