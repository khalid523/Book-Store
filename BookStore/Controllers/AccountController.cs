using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountservice;
        public AccountController(IAccountService _accountservice)
        {
            accountservice = _accountservice;
        }
        
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            SignUpModelView vm = new SignUpModelView();
            List<IdentityRole> lirole= accountservice.GetRole();
            vm.lirole = lirole;
            return View("NewAccount",vm);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAccount(SignUpModelView signUpModelView)
        {
            SignUpModelView vm = new SignUpModelView();
          List<IdentityRole> liRloe=  accountservice.GetRole();
            vm.lirole = liRloe;
            
           var result= await  accountservice.CreateUser(signUpModelView.signUpModel);

            return View("NewAccount",vm);
        }
        public IActionResult SignIn()
       {
            return View("Login");
        }
        public async Task<IActionResult> SignOut()
        {
           await accountservice.Logout();
            return View("Login");
        }
        public async Task<IActionResult> CheckPassword(SignInModel signInModel)
        {
         var result=  await accountservice.CheckPassword(signInModel);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Books");
            }
            else
            {
                ViewData["errorMessage"] = "Invalid UserName or Password";

                return View("Login");
            }
        
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveRole(RoleModel roleModel)
        {
            
          var result= await accountservice.NewRole(roleModel);
            return View("NewRole");
        }
        public IActionResult AccessDenied1()
        {
            return View("AccessDenied");
        }

        }
}
