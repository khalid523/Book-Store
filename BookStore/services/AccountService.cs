using BookStore.data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class AccountService:IAccountService
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManger;
        public AccountService(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager,RoleManager<IdentityRole> _roleManger)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManger = _roleManger;
        }

        public async Task<IdentityResult> CreateUser(SignUpModel signUpModel)
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = signUpModel.Name;
            user.Email = signUpModel.Email;
            user.UserName = signUpModel.Email;
            var result=   await userManager.CreateAsync(user,signUpModel.Password);
            if (result.Succeeded)
            {
                var role = await roleManger.FindByIdAsync(signUpModel.RoleId);
               result = await userManager.AddToRoleAsync(user, role.Name);
            }
            return result;
        }
        public async Task<SignInResult> CheckPassword(SignInModel signInModel)
         {
          var result= await signInManager.PasswordSignInAsync(signInModel.Username,signInModel.Password,signInModel.RememberMe,false);
            return result;
        }
        public async Task<IdentityResult> NewRole (RoleModel roleModel)

        {
            IdentityRole role = new IdentityRole();
            role.Name = roleModel.Name;

          var result=  await roleManger.CreateAsync(role);
            return result;
        }
        public List<IdentityRole> GetRole()
        {

          List<IdentityRole> liRole=  roleManger.Roles.ToList();
            return liRole;
        }
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
        
    }
}
