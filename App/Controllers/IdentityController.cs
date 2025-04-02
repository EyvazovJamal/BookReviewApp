
using App.Dtos;
using App.EntityFramework;
using App.Enums;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;


public class IdentityController : Controller
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly AppDbContext context;

    public IdentityController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager,
        AppDbContext context
    )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
        this.context = context;
    }

    [HttpGet]
    public ActionResult Registration(){
        var errorMessage=base.TempData["Error"];

        if (errorMessage!=null)
        {
            ModelState.AddModelError("All",errorMessage.ToString()!);
        }
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Registration([FromForm]RegistrationDto registrationDto){
        
        if (!ModelState.IsValid)
        {
            return View(registrationDto);
        }

        try
        {
            var uniqueEmail= await userManager.FindByEmailAsync(registrationDto.Email);
            if (uniqueEmail!=null)
            {
                ModelState.AddModelError("All","Email is already reqistered");
                return View(nameof(Registration)) ;
            }

            var user=new IdentityUser{
                UserName=registrationDto.Username,
                Email=registrationDto.Email,
            };

            var result = await userManager.CreateAsync(user, registrationDto.Password);
        
            if (!result.Succeeded)
            {
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(nameof(Registration));
            }
            
            var allUsersCount = context.Users.Count(); 

            
            if (allUsersCount == 1) 
            {
                await userManager.AddToRoleAsync(user, nameof(Roles.Admin));
            }
            else 
            {
                await userManager.AddToRoleAsync(user, nameof(Roles.User));
            }
            return RedirectToAction(nameof(Login));
        }
        catch (Exception)
        {
            base.TempData["Error"]="Something went wrong";
        }

        return base.RedirectToAction(nameof(Login));
    }

    [HttpGet]
    public  ActionResult Login(string ReturnUrl){
         var errorMessage = base.TempData["Error"];

        if(string.IsNullOrWhiteSpace(ReturnUrl) == false) {
            base.ViewData["returnUrl"] = ReturnUrl;
        }

        if(errorMessage != null) {
            base.ModelState.AddModelError("All", errorMessage.ToString()!);
        }

        return base.View();
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromForm]LoginDto loginDto ){
        if (!ModelState.IsValid)
        {
            return View(nameof(Login));
        }
        var foundUser=await userManager.FindByEmailAsync(loginDto.Login);
        
        if (foundUser==null)
        {
            base.TempData["Error"] = "Incorrect login or password";
            return View(nameof(Login));

        }
        var signInResult= await signInManager.PasswordSignInAsync(foundUser,loginDto.Password,true,true);

        if (signInResult.Succeeded==false)
        {
            base.TempData["Error"] = "Incorrect login or password";
            return View(nameof(Login));
        }
        if(string.IsNullOrWhiteSpace(loginDto.ReturnUrl) == false) {
            return base.Redirect(loginDto.ReturnUrl);
        }
        return base.RedirectToAction(actionName: "Index", controllerName: "Home");

    }


    [HttpGet]
    public async Task<ActionResult> Logout([FromForm] LoginDto dto) {
        await signInManager.SignOutAsync();
        return base.RedirectToAction(actionName: "Index", controllerName: "Home");
    }
}
