using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoInterdisciplinar.Data;
using ProjetoInterdisciplinar.Models;
using ProjetoInterdisciplinar.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoInterdisciplinar.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<AppUsers> signInManager;
        private readonly UserManager<AppUsers> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AppDbContext context;

        public AccountController(SignInManager<AppUsers> signInManager, UserManager<AppUsers> userManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);


            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null || !user.Able)
            {
                ModelState.AddModelError("", user == null ? "Email ou senha incorretos" : "Conta desabilitada");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                if (user.Discriminator == "Admin")
                {
                    return RedirectToAction("IndexAdmin", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Email ou senha incorretos");
            return View(model);
        }


        public IActionResult PFRegister()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PFRegister(PFRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                PFUser user = new PFUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.Email,
                    BirthDate = model.BirthDate,
                    Sex = model.Sex,
                    Able = true
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "PF");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }

            return View(model);
        }



        public IActionResult PJRegister()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PJRegister(PJRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                PJUser user = new PJUser()
                {
                    Name = model.Name,
                    CNPJ = model.CNPJ,
                    Ramo = model.Ramo,
                    Email = model.Email,
                    UserName = model.Email,
                    Able = false
                };

                if (!PJUser.IsCnpj(user.CNPJ))
                {
                    ModelState.AddModelError(nameof(model.CNPJ), "CNPJ inválido!");
                    return View(model);
                }

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "PJ");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }

            return View(model);
        }



        public IActionResult VerifyEmail()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Algo deu errado");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
                }
            }

            return View(model);
        }


        public IActionResult ChangePassWord(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }

            return View( new ChangePasswordViewModel {  Email = username });
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.RemovePasswordAsync(user);

                    if (result.Succeeded)
                    {
                        result = await userManager.AddPasswordAsync(user, model.NewPassword);
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email não foi encontrado");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Algo deu errado. Tente novamente");
                return View(model);
            }
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
